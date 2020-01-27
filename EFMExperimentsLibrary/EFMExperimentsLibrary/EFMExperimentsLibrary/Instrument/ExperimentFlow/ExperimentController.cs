using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFMExperimentsLibrary
{
    
    public class ExperimentController
    {
        private List<EFMExperiment> experimentList;
        private int currentExperiment;

        public event EventHandler<ReadingsUpdateEventArgs> experimentReadingsUpdate;
        public event EventHandler<EFMExperimentUpdateEventArgs> experimentUpdate;
        public bool experimentRunning { get; set; }

        
        public ExperimentController()
        {
            experimentList = new List<EFMExperiment>();
            currentExperiment = 0;
            experimentRunning = false;
        }

        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            if (experimentRunning)
            {
                if (experimentReadingsUpdate != null)
                    experimentReadingsUpdate(sender, e);

                if (currentExperiment < experimentList.Count)
                {
                    if (experimentList[currentExperiment].updateExperimentFlow())
                    {
                        experimentList[currentExperiment] = null;
                        currentExperiment++;
                    }
                }
            }
        }

        public void addExperiment( EFMExperiment exp )
        {
            experimentReadingsUpdate += exp.readingsUpdate;
            experimentList.Add(exp);
            updateExperimentEvent();
            
        }

        public void removeExperiment( int i )
        {
            if ( i >= 0 && i < experimentList.Count )
            {
                experimentList.RemoveAt(i);
            }
            updateExperimentEvent();
        }

        private void updateExperimentEvent()
        {
            if (experimentUpdate != null)
            {
                EFMExperimentUpdateEventArgs e = new EFMExperimentUpdateEventArgs();
                e.currentExperiment = currentExperiment;
                e.experimentList = experimentList;
                experimentUpdate(this, e);
            }
        }
    }

    

    public abstract class ExperimentTask
    {
        protected enum TaskStatus { NotStarted, OnGoing, Finished}

        protected TaskStatus status;

        public string statusText { get; protected set; }
        
        public virtual bool IsFinished()
        {
            return true;
        }

        public virtual void start()
        {
            status = TaskStatus.OnGoing;
            
        }

        public bool notStarted()
        {
            return status == TaskStatus.NotStarted;
        }

        
    }

    public class SetTemperatureTask : ExperimentTask
    {
        public double Tset { get; set; }
        public PIDControl_Tset tempCtrl;
        public override bool IsFinished()
        {
            return base.IsFinished();
        }

        public override void start()
        {
            statusText = "Setting temperature";
            tempCtrl.setTemperature(Tset);
            base.start();
        }
    }

    public interface PIDControl_Tset
    {
        void setTemperature(double T);
    }

    public class SetFieldTask : ExperimentTask
    {
        

        public double field { get; set; }
        public double rampRate { get; set; }

        public SetFieldControl fieldCtrl;

        public override bool IsFinished()
        {
            if (fieldCtrl.atSetField())
                return true;
            else
                return false;
        }

        public override void start()
        {
            statusText = "Setting field";
            fieldCtrl.setField(field, rampRate);
            
            base.start();
        }        
        
    }
    
   public interface SetFieldControl
   {
       void setField(double field, double rampRate);
       bool atSetField();
   }
    

    public class SetTemperatureRampTask : ExperimentTask
    {
        public double Tmin { get; set; }
        public double Tmax { get; set; }
        public double Tramp { get; set; }

        public SetTemperatureRampCtrl tempRampCtrl;
        public override bool IsFinished()
        {
            return tempRampCtrl.rampFinished();
        }

        public override void start()
        {
            statusText = "Ramping temperature";
            tempRampCtrl.setRamp(Tmin, Tmax, Tramp);
            base.start();
        }
    }

    public interface SetTemperatureRampCtrl
    {
        void setRamp( double Tmin, double Tmax, double Tramp );

        bool rampFinished();
    }

    
    public class WaitTimeTask : ExperimentTask
    {
        public double waitTime { get; set; }
        private DateTime startTime;
        public override bool IsFinished()
        {
            if ( status == TaskStatus.NotStarted )
            {
                return false;
            }
            else
            {
                TimeSpan dt = DateTime.Now - startTime;
                return dt.TotalSeconds >= waitTime;                    
            }
        }

        public override void start()
        {
            statusText = "Waiting for " + waitTime.ToString() + " s";
            base.start();
            startTime = DateTime.Now;
        }
    }

    public class WaitStabilizeTask : ExperimentTask
    {
        public double criterion { get; set; }
        public StabilityCtrl stabCtrl;
        public override bool IsFinished()
        {
            return criterion >= stabCtrl.getStabilityValue();
        }

        public override void start()
        {
            statusText = "Waiting to stabilize";
            base.start();
        }
    }

    public interface StabilityCtrl
    {
        double getStabilityValue();
    }

    public class ExperimentFinishedTask : ExperimentTask
    {
        public override bool IsFinished()
        {
            return base.IsFinished();
        }

        public override void start()
        {
            statusText = "Experiment finished";
            base.start();
        }
    }

    public class SeparateDatafileTask : ExperimentTask
    {
        public string filename { get; set; }
        public string[] header { get; set; }
        private DSCDataSaver dataSaver;
        public DatasaveFilePath filePath;
        private bool stopDatastream = false;

        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            if ( dataSaver != null )
                dataSaver.writeLine(e.readings);
        }
        
        

        public override bool IsFinished()
        {
            return base.IsFinished();
        }

        public override void start()
        {
            statusText = "Opening separate datafile";
            /**
             * Simple solution for stopping the data stream. The second time start() is called this is a signal that the data stream should be stopped
             * */
            if ( stopDatastream )
            {
                dataSaver = null;
            }
            else
            {
                if (header == null)
                {
                    header = new string[1];
                    header[0] = "%dummyheader";
                }
                string path = "";
                if (filePath != null)
                {
                    path = filePath.getPath();
                    filename = filePath.getFilename() + filename;
                }

                dataSaver = new DSCDataSaver( path + filename, header, DateTime.Now );
                base.start();
                stopDatastream = true;
            }
        }
    }
    public interface DatasaveFilePath
    {
        string getPath();
        string getFilename();
    }
    public interface ExperimentStatusUpdate
    {
        void updateStatusString(string status);
    }

    public class StopSeparateDatafileTask : ExperimentTask
    {

    }

    /**
     * Parent class for any experiment in the EFMExperimentsLibrary
     * */
    public class EFMExperiment
    {
        public List<ExperimentTask> taskList;
        private int currentTask = 0;
        public event EventHandler<ReadingsUpdateEventArgs> experimentReadingsUpdate;

        protected StabilityCtrl stabCtrl;
        protected SetTemperatureRampCtrl rampCtrl;
        protected SetFieldControl fieldCtrl;
        protected PIDControl_Tset pidCtrl;
        protected ExperimentStatusUpdate statusCtrl;
        protected DatasaveFilePath datasaveCtrl;
        protected string[] header;

        public string experimentDescriptor { get; protected set; }

        public EFMExperiment(StabilityCtrl sCtrl, SetTemperatureRampCtrl rCtrl, SetFieldControl fCtrl, PIDControl_Tset pCtrl, DatasaveFilePath datCtrl, ExperimentStatusUpdate stCtrl, string[] header_)
        {
            stabCtrl = sCtrl;
            rampCtrl = rCtrl;
            fieldCtrl = fCtrl;
            pidCtrl = pCtrl;
            statusCtrl = stCtrl;
            datasaveCtrl = datCtrl;
            header = header_;
        }
      
        public EFMExperiment()
        {

        }

       
        /**
         * Called by owner instance everytime new data is available
         * Returns true of the entire experiment has finished
         * */
        public bool updateExperimentFlow()
        {
            ExperimentTask task = getCurrentTask();
            //bootstrapping
            if ( task.notStarted() )
            {
                task.start();
                statusCtrl.updateStatusString(task.statusText);
            }
            else
            {
                //if the task has finished then go on with the next task.
                if ( task.IsFinished() )
                {
                    task = getNextTask();
                    task.start();
                    statusCtrl.updateStatusString(task.statusText);
                }
            }
            if ( task.GetType() == typeof(ExperimentFinishedTask))
            {
                experimentReadingsUpdate = null;
                return true;
            }
           
            return false;
        }

        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            
            if (experimentReadingsUpdate != null)
                experimentReadingsUpdate(sender, e);
        }

        private ExperimentTask getCurrentTask()
        {
            if (currentTask < taskList.Count)
            {
                return taskList[currentTask];
            }
            else
            {
                ExperimentFinishedTask tsk = new ExperimentFinishedTask();
                
                return tsk;
            }
        }

        private ExperimentTask getNextTask()
        {
            currentTask++;
            return getCurrentTask();
        }
    }
    /**
     * Specific implementation for a DSC experiment
     * */
    public class EFMExperimentDSC : EFMExperiment
    {
        public EFMExperimentDSC(EFMExperimentSettingsDSC setts, StabilityCtrl sCtrl, SetTemperatureRampCtrl rCtrl, SetFieldControl fCtrl, PIDControl_Tset pCtrl, DatasaveFilePath datCtrl, ExperimentStatusUpdate stCtrl, string[] header_)
            : base(sCtrl, rCtrl, fCtrl, pCtrl,datCtrl,stCtrl,header_)
        {
            
            taskList = new List<ExperimentTask>();
            makeDSCSequence(setts);
        }

        private void makeDSCSequence( EFMExperimentSettingsDSC setts )
        {
            
            /*The procedure for a DSC run, i.e. getting the specific heat as a function of temperature for a given constant field is as follows
             * 1. Set the desired magnetic field
             * 2. Got to the starting temperature
             * 3. Wait for half a minute to make sure the stabilization criterion is not met (if the system has been completely stable it takes a few data cycles to realize a change is happening)
             * 4. Wait for stabilization
             * 5. Open separate data file
             * 6. Start the temperature ramp
             * 7. Finish experiment (close data file)
             * */
            
            
            //1. Set the required field
            SetFieldTask setField = new SetFieldTask();
            
            setField.field = setts.H;
            setField.rampRate = 0.1;//T/s
            setField.fieldCtrl = fieldCtrl;
            taskList.Add(setField);

            //2. set the starting temperature
            double Tmin = setts.Tmin;
            double Tmax = setts.Tmax;
            double Tstart = Tmin;
            if ( setts.Tramp < 0 )
            {
                Tstart = setts.Tmax;                
            }
            SetTemperatureTask setT = new SetTemperatureTask();
            setT.Tset = Tstart;
            setT.tempCtrl = pidCtrl;
            taskList.Add(setT);

            //3. Wait for a little time            
            WaitTimeTask wt = new WaitTimeTask();
            wt.waitTime = 10;//seconds            
            taskList.Add(wt);

            //4. wait for stabilization
            WaitStabilizeTask wtS = new WaitStabilizeTask();
            wtS.criterion = setts.stabilizeCriterium;
            wtS.stabCtrl = stabCtrl;
            taskList.Add(wtS); 
            
            //5. open separate data file
            SeparateDatafileTask opTask = new SeparateDatafileTask();
            opTask.filename = "dsc_Tstart_" + Tmin.ToString() + "_Tend_" + Tmax.ToString() + "_Tramp_" + setts.Tramp.ToString() + "_Happ_" + setts.H.ToString();
            experimentReadingsUpdate += opTask.readingsUpdate;
            opTask.filePath = datasaveCtrl;
            opTask.header = header;
            taskList.Add(opTask);

            //6. start the ramp
            SetTemperatureRampTask tRamp = new SetTemperatureRampTask();
            tRamp.Tmin = Tmin;
            tRamp.Tmax = Tmax;
            tRamp.Tramp = setts.Tramp;
            tRamp.tempRampCtrl = rampCtrl;
            taskList.Add(tRamp);

            //7. finish the experiment, i.e. close the file
            ExperimentFinishedTask expF = new ExperimentFinishedTask();
            taskList.Add(expF);

            //set the descriptor text of this experiment
            experimentDescriptor = "DSC_Tmin_" + Tmin.ToString() + "_Tmax_" + Tmax.ToString() + "_Tramp_" + setts.Tramp.ToString() + "_H_" + setts.H.ToString();
        }
    }
    /**
     * Specific implementation for a deltaS experiment
     * 
     * */
    public class EFMExperimentDeltaS : EFMExperiment
    {
       
        public EFMExperimentDeltaS(EFMExperimentSettingsDeltaS setts, StabilityCtrl sCtrl, SetTemperatureRampCtrl rCtrl, SetFieldControl fCtrl, PIDControl_Tset pCtrl, DatasaveFilePath datCtrl, ExperimentStatusUpdate stCtrl,string[] header_)
            : base(sCtrl, rCtrl, fCtrl, pCtrl,datCtrl,stCtrl,header_)
        {
            
            taskList = new List<ExperimentTask>();
            makeDeltaSSequence(setts);
        }

        private void makeDeltaSSequence(EFMExperimentSettingsDeltaS setts)
        {

            //first make arrays with the set temperatures and the set fields, respectively
            int nT = (int)Math.Ceiling((setts.Tmax - setts.Tmin) / setts.Tstep) + 1;

            int nH = (int)Math.Ceiling((setts.Hmax - setts.Hmin) / setts.Hstep) + 1;

            double[] Tset = new double[nT];
            double[] Hset = new double[nH];

            Tset[0] = setts.Tmin;
            for ( int i = 1; i < Tset.Length; i++)            
                Tset[i] = Tset[i-1] + setts.Tstep;

            Hset[0] = setts.Hmin;
            for ( int i = 1; i < Hset.Length; i++)            
                Hset[i] = Hset[i-1] + setts.Hstep;
            

            /**
             * The experiment logic is a follows
             * 1. Set the starting field 
             * 2. If reset is on the go to the reset temperature
             * 3. Wait 10 seconds
             * 4. Wait for stabilization
             * 5. Goto the next set temperature
             * 6. Wait 10 seconds
             * 7. Wait for stabilization
             * 8. Open new data file
             * 9. Change field according to the settings
             * 10. Wait 10 seconds
             * 11. Wait for stabilization
             * 12. Stop data stream to new file (sub-experiment is done)             
             * */

            //loop over each configuration in order to add the experiments
            for ( int i = 0; i < Tset.Length; i++ )
            {
                for ( int j = 1; j < Hset.Length; j++ )
                {
                    //1. Set the initial field (always the zero'th member of the field array)
                    SetFieldTask setField = new SetFieldTask();
            
                    setField.field = Hset[0];
                    setField.rampRate = 0.1;//T/s
                    setField.fieldCtrl = fieldCtrl;
                    taskList.Add(setField);
                    
                    if ( setts.doReset )
                    {
                        //2. In case of resetting then go to the reset temperature and stabilize
                        SetTemperatureTask setT = new SetTemperatureTask();
                        setT.Tset = setts.Treset;
                        setT.tempCtrl = pidCtrl;
                        taskList.Add(setT);

                        //3. Wait for a little time            
                        WaitTimeTask wt = new WaitTimeTask();
                        wt.waitTime = 10;//seconds            
                        taskList.Add(wt);

                        //4. wait for stabilization
                        WaitStabilizeTask wtS = new WaitStabilizeTask();
                        wtS.criterion = setts.stabilizeCriterium;
                        wtS.stabCtrl = stabCtrl;
                        taskList.Add(wtS); 
                    }

                    //5. set next temperature                    
                    SetTemperatureTask setT_next = new SetTemperatureTask();
                    setT_next.Tset = Tset[i];
                    setT_next.tempCtrl = pidCtrl;
                    taskList.Add(setT_next);

                    //6. Wait for a little time            
                    WaitTimeTask wt_next = new WaitTimeTask();
                    wt_next.waitTime = 10;//seconds            
                    taskList.Add(wt_next);

                    //7. wait for stabilization
                    WaitStabilizeTask wtS_next = new WaitStabilizeTask();
                    wtS_next.criterion = setts.stabilizeCriterium;
                    wtS_next.stabCtrl = stabCtrl;
                    taskList.Add(wtS_next); 

                     //8. open separate data file
                    SeparateDatafileTask opTask = new SeparateDatafileTask();
                    opTask.filename = "deltaS_Tset_" + Tset[i].ToString() +  "_Hset_" + Hset[j].ToString();
                    experimentReadingsUpdate += opTask.readingsUpdate;
                    opTask.filePath = datasaveCtrl;
                    opTask.header = header;
                    taskList.Add(opTask);

                    //9. Change the field according to the current data point
                    SetFieldTask setField_next = new SetFieldTask();            
                    setField_next.field = Hset[j];
                    setField_next.rampRate = setts.Hrate;//T/s
                    setField_next.fieldCtrl = fieldCtrl;
                    taskList.Add(setField_next);

                    //10. Wait for a little time            
                    WaitTimeTask wt_aft_exp = new WaitTimeTask();
                    wt_aft_exp.waitTime = 10;//seconds            
                    taskList.Add(wt_aft_exp);

                    //11. wait for stabilization
                    WaitStabilizeTask wtS_aft_exp = new WaitStabilizeTask();
                    wtS_aft_exp.criterion = setts.stabilizeCriterium;
                    wtS_aft_exp.stabCtrl = stabCtrl;
                    taskList.Add(wtS_aft_exp); 

                    //12. Stop the data stream. Add the output task once more. It's start() method will then be called and this taken as a signal to stop outputting data.
                    taskList.Add(opTask);
                }
            }
            //turn off the field at the very end            
            SetFieldTask setField_end = new SetFieldTask();
            setField_end.field = Hset[0];
            setField_end.rampRate = setts.Hrate;//T/s
            setField_end.fieldCtrl = fieldCtrl;
            taskList.Add(setField_end);
            
            //add experiment finished task
            ExperimentFinishedTask expF = new ExperimentFinishedTask();
            taskList.Add(expF);
            //set the descriptor text of this experiment
            experimentDescriptor = "deltaS_Tmin_" + setts.Tmin.ToString() + "_Tmax_" + setts.Tmax.ToString() + "_Hmin_" + setts.Hmin.ToString() + "_Hmax_" + setts.Hmax.ToString();
            if (setts.doReset)
                experimentDescriptor += "_Treset_" + setts.Treset.ToString();
        }
    }
    /**
     * Abstract parent class for passing the specific settings of an experiment
     * 
     * */
    public abstract class EFMExperimentSettings
    {
        public double stabilizeCriterium { get; protected set; }
    }

    /**
     * Settings for the DSC experiment
     * */
    public class EFMExperimentSettingsDSC : EFMExperimentSettings
    {
        public EFMExperimentSettingsDSC()
        {

        }
        public EFMExperimentSettingsDSC( double Tmin_, double Tmax_, double Tramp_, double H_, double stabCrit )
        {
            Tmin = Tmin_;
            Tmax = Tmax_;
            Tramp = Tramp_;
            H = H_;
            stabilizeCriterium = stabCrit;
        }
        public double Tmin { get; private set; }
        public double Tmax { get; private set;}
        public double Tramp { get; private set; }
        
        public double H { get; private set; }
        
    }
    /**
     * Specific settings for the deltaS experiment
     * 
     * */
    public class EFMExperimentSettingsDeltaS : EFMExperimentSettings
    {
        public double Tmin { get; private set; }
        public double Tmax { get; private set; }
        public double Tstep { get; private set; }
        public double Treset { get; private set; }

        public bool doReset { get; private set; }

        public double Hmin { get; private set; }
        public double Hmax { get; private set; }
        public double Hstep { get; private set; }
        public double Hrate { get; private set; }
        
        public EFMExperimentSettingsDeltaS( double Tmin_, double Tmax_, double Tstep_, double Treset_, bool doReset_, double Hmin_, double Hmax_, double Hstep_, double Hrate_, double stabCrit)            
        {
            Tmin = Tmin_;
            Tmax = Tmax_;
            Tstep = Tstep_;
            Treset = Treset_;
            doReset = doReset_;
            Hmin = Hmin_;
            Hmax = Hmax_;
            Hstep = Hstep_;
            Hrate = Hrate_;
            stabilizeCriterium = stabCrit;
        }
    }

    public class EFMExperimentUpdateEventArgs : EventArgs
    {
        public List<EFMExperiment> experimentList = new List<EFMExperiment>();
        public int currentExperiment = -1;
    }
}
