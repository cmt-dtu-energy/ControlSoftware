using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 
using System.Windows.Forms;
using Zaber.Serial.Core;
using System.Collections;
namespace EFMExperimentsLibrary
{
    public interface XYZ_Interface
    {
        double[] getCoordinates();
    }

    
    public partial class XYZControl: UserControl, XYZ_Interface
    {
        public event EventHandler<TemperatureGaugeEventArgs> ProbeTouchingStateChanged;
        public XYZControl()
        {
            InitializeComponent();
            InitializeStateStringTable();
            
            for (int i = 0; i < nPorts; i++)
            {
                cmbLoadPort.Items.Add("Port " + (i+1).ToString());
                cmbSelectLoadCellExcitation.Items.Add("Port " + (i+1).ToString());
            }
            cmbLoadPort.SelectedIndex = 12;

            cmbSelectLoadCellExcitation.SelectedIndex = 9;
            
            startPoint = new Point();
            endPoint = new Point();
            ProbeTouchingStateChanged += updateProbeTextState;
        }
        public void initializeXYZControl()
        {
            initializeZaberDevice();
        }
        private void initializeZaberDevice()
        {
            string selectedPort = txtCOMPort.Text;

            if (selectedPort == null)
            {
                selectedPort = "COM1";
            }            
            zaberPort = new ZaberBinaryPort(selectedPort);
            try
            {
                zaberPort.Open();

                List<IZaberAxis> axes = zaberPort.FindAxes();
                if (axes.Count() == 3)
                {
                    
                    axisX = new ZaberBinaryDevice(zaberPort, 2);
                    axisY = new ZaberBinaryDevice(zaberPort, 3);
                    axisZ = new ZaberBinaryDevice(zaberPort, 1);
                    updateAxesPos();
                    lblInitialized.Text = "Initialized";
                }
            }
            catch
            {
                updateErrorState(InternalErrorState.COMPortNotOpened);
            }            
        }

        public psuRetrieveReading k2230Readings { set; get; }

        public SeebeckExperimentCallback experimentCallback { get;  set; }

        public EventHandler<PlotMapEventArgs> plotMapCallback;

        private Point startPoint;
        private Point endPoint;

        private int nX;
        private int nY;

        private double incrX = 0; // For grid initialization and scanning routine
        private double incrY = 0;

        private int iX = 1; // For scanning routine
        private int iY = 1;

        private double loadOffset = 0;

        private double doubleCurrentLoad;
        private double doubleGotoLoad;
        private int TotalPointsMeasured = 0;

        private bool isEstablishingContact = false;
        private bool isDeEstablishingContact = false;
        private bool scanForward = true;
        public bool isScanning = false;
        
        private const string strProbeTouching = "Probe is touc  hing";
        private const string strProbeNotTouching = "Probe is not touching";

        private bool probeTouchingState = false;

        private const int nPorts = 20;

        private double minLoadCellError = 0.1;

        private Zaber.Serial.Core.ZaberBinaryPort zaberPort;
        private Zaber.Serial.Core.ZaberBinaryDevice axisX, axisY, axisZ;
        private const double micronPerMicroStep = 0.09921875;
        private InternalErrorState error;

        enum InternalErrorState { NoError, COMPortNotOpened, WrongNumberFormat, RequestOutOfRange };
        enum CurrentState {Idle, Error, HomingXAxis, HomingYAxis, HomingZAxis, MovingXAxis, MovingYAxis,
            MovingZAxis, Measuring, Scanning, Aborted, EstablishingContact, DeEstablishingContact,
            BeforeMeasurement,AfterMeasurement,DuringMeasurement};
        private Dictionary<CurrentState,string> stateStringTable;
        
        private void InitializeStateStringTable()
        {
            stateStringTable = new Dictionary<CurrentState, string>();
            stateStringTable.Add( CurrentState.Idle,  "Idle" );
            stateStringTable.Add( CurrentState.Error, "Error");
            stateStringTable.Add( CurrentState.HomingXAxis, "Homing X axis");
            stateStringTable.Add( CurrentState.HomingYAxis, "Homing Y axis");
            stateStringTable.Add( CurrentState.HomingZAxis, "Homing Z axis");
            stateStringTable.Add( CurrentState.MovingXAxis, "Moving X axis");
            stateStringTable.Add( CurrentState.MovingYAxis, "Moving Y axis");
            stateStringTable.Add( CurrentState.MovingZAxis, "Moving Z axis");
            stateStringTable.Add(CurrentState.Measuring, "Measuring");
            stateStringTable.Add(CurrentState.Scanning, "Scanning");
            stateStringTable.Add(CurrentState.Aborted, "Measurement aborted!");
            stateStringTable.Add(CurrentState.EstablishingContact, "Establishing contact");
            stateStringTable.Add(CurrentState.DeEstablishingContact, "De-establishing contact");
            stateStringTable.Add(CurrentState.BeforeMeasurement, "Before measurement");
            stateStringTable.Add(CurrentState.AfterMeasurement, "After measurement");
            stateStringTable.Add(CurrentState.DuringMeasurement, "Doing measurement");
        }

        private void updateErrorState( InternalErrorState err )
        {
            error = err;
            string errString = "No error";
            switch( err )
            {
                case InternalErrorState.NoError:
                    updateCurrentState(CurrentState.Idle);
                    break;
                case InternalErrorState.COMPortNotOpened:
                    errString = "COM port could not be opened";
                    updateCurrentState(CurrentState.Error);
                    break;
                case InternalErrorState.WrongNumberFormat:
                    errString = "Number is not formatted correctly";
                    updateCurrentState(CurrentState.Error);
                    break;
                case InternalErrorState.RequestOutOfRange:
                    errString = "Requested movement out of range";
                    updateCurrentState(CurrentState.Error);
                    break;
            }
            lblError.Text = errString;
        }

        private void updateCurrentState( CurrentState state )
        {
            string stateString = "Current state: ";

            string val = stateStringTable[state];

            if (val != null)
                stateString += val;

            lblState.Text = stateString;
            if (state == CurrentState.Idle)
                setControlState(true);
            else
                setControlState(false);
        }

        private void setControlState( bool enabled )
        {
            cmdGoToEndPoint.Enabled = enabled;
            cmdGoToStartPoint.Enabled = enabled;
            cmdLoad.Enabled = enabled;
            cmdMoveX.Enabled = enabled;
            cmdMoveY.Enabled = enabled;
            cmdMoveZ.Enabled = enabled;
            cmdOpenComPort.Enabled = enabled;
            cmdStartPoint.Enabled = enabled;
            cmdEndPoint.Enabled = enabled;
            cmdHome.Enabled = enabled;
            cmdTareLoad.Enabled = enabled;
            cmdXDecr.Enabled = enabled;
            cmdXIncr.Enabled = enabled;
            cmdYDecr.Enabled = enabled;
            cmdYIncr.Enabled = enabled;
            cmdZDecr.Enabled = enabled;
            cmdZIncr.Enabled = enabled;
            cmdgotoLoad.Enabled = enabled;
            tempscan.Enabled = enabled;
        }

        private void updateAxesPos()
        {
            if (axisX != null)
                txtXPos.Text = convertToMM(axisX.GetPosition()).ToString();
            if (axisY != null)
                txtYPos.Text = convertToMM(axisY.GetPosition()).ToString();
            if (axisZ != null)
                txtZPos.Text = convertToMM(axisZ.GetPosition()).ToString();
        }

        private double getXAxisPos()
        {
            return getAxisPos(axisX);
        }
        private double getYAxisPos()
        {
            return getAxisPos(axisY);
        }
        private double getZAxisPos()
        {
            return getAxisPos(axisZ);
        }

        private double getAxisPos( ZaberBinaryDevice axis )
        {
            if (axis != null)
            {
                return convertToMM(axis.GetPosition());
            }
            return -1;
        }

        private void homeAxes()
        {
            if (axisZ != null)
            {
                axisZ.Home();
                updateCurrentState(CurrentState.HomingZAxis);
            }
            if (axisX != null)
            {
                axisX.Home();
                updateCurrentState(CurrentState.HomingXAxis);
            }
            if (axisY != null)
            {
                axisY.Home();
                updateCurrentState(CurrentState.HomingYAxis);
            }
        updateAxesPos();
        updateCurrentState(CurrentState.Idle);
        }

        private CurrentState getAxisMoving( ZaberBinaryDevice axis )
        {
            CurrentState state = CurrentState.Idle;
            if ( axis != null)
            {
                if (axis == axisX)
                    state = CurrentState.MovingXAxis;
                if (axis == axisY)
                    state = CurrentState.MovingYAxis;
                if (axis == axisZ)
                    state = CurrentState.MovingZAxis;
            }
            return state;
        }

        private void moveRelativeDistance(TextBox txtDist, TextBox txtResult, ZaberBinaryDevice axis, int dir, bool ignoreProbeContact)
        {
            if (axis != null)
            {
                try
                {
                    updateCurrentState( getAxisMoving( axis ) );
                    int dist = dir * convertToInternalUnits(Convert.ToDouble(txtDist.Text));
                    moveAxisRel(axis, dist, ignoreProbeContact);
                    txtResult.Text = convertToMM(axis.GetPosition()).ToString();
                    updateErrorState(InternalErrorState.NoError);

                }
                catch (FormatException ex)
                {
                    updateErrorState(InternalErrorState.WrongNumberFormat);
                }
                catch (OverflowException ex)
                {
                    updateErrorState(InternalErrorState.WrongNumberFormat);
                }
                catch (UnexpectedReplyReceivedException ex)
                {
                    updateErrorState(InternalErrorState.RequestOutOfRange);
                }
            }
        }

        private void moveAbsoluteDistance(TextBox txtDist, TextBox txtResult, ZaberBinaryDevice axis)
        {
            if (axis != null)
            {
                try
                {
                    int dist = convertToInternalUnits(Convert.ToDouble(txtDist.Text));
                    moveAxisAbs(axis, dist);                    
                    txtResult.Text = convertToMM(axis.GetPosition()).ToString();
                    updateErrorState(InternalErrorState.NoError);
                }
                catch (FormatException ex)
                {
                    updateErrorState(InternalErrorState.WrongNumberFormat);
                }
                catch (OverflowException ex)
                {
                    updateErrorState(InternalErrorState.WrongNumberFormat);
                }
                catch (UnexpectedReplyReceivedException ex)
                {
                    updateErrorState(InternalErrorState.RequestOutOfRange);
                }
            }
        }

        private void cmdMoveX_Click(object sender, EventArgs e)
        {
            moveRelativeDistance(txtMoveX, txtXPos, axisX, 1, false);
        }

        private void cmdMoveY_Click(object sender, EventArgs e)
        {
            moveRelativeDistance(txtMoveY, txtYPos, axisY, 1, false);
        }

        private void cmdMoveZ_Click(object sender, EventArgs e)
        {
            moveRelativeDistance(txtMoveZ, txtZPos, axisZ, 1, true);
        }

        private int convertToInternalUnits( double moveMM )
        {
            return (int)(Math.Round(1000 * moveMM / micronPerMicroStep));                        
        }
        private double convertToMM( int moveMicro )
        {
            return micronPerMicroStep * moveMicro / 1000;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmdOpenComPort_Click(object sender, EventArgs e)
        {
            if (zaberPort == null)            
                initializeZaberDevice();   
        }

        private void cmdYIncr_Click(object sender, EventArgs e)
        {
            updateCurrentState(CurrentState.MovingYAxis);
            moveRelativeDistance(txtYIncr, txtYPos, axisY, 1, false);
            updateCurrentState(CurrentState.Idle);
        }

        private void cmdXDecr_Click(object sender, EventArgs e)
        {
            updateCurrentState(CurrentState.MovingXAxis);
            moveRelativeDistance(txtXIncr, txtXPos, axisX, -1, false);
            updateCurrentState(CurrentState.Idle);
        }

        private void cmdXIncr_Click(object sender, EventArgs e)
        {
            updateCurrentState(CurrentState.MovingXAxis);
            moveRelativeDistance(txtXIncr, txtXPos, axisX, 1, false);
            updateCurrentState(CurrentState.Idle);
        }

        private void cmdYDecr_Click(object sender, EventArgs e)
        {
            updateCurrentState(CurrentState.MovingYAxis);
            moveRelativeDistance(txtYIncr, txtYPos, axisY, -1, false);
            updateCurrentState(CurrentState.Idle);
        }

        private void cmdZIncr_Click(object sender, EventArgs e)
        {
            updateCurrentState(CurrentState.MovingZAxis);
            moveRelativeDistance(txtZIncr, txtZPos, axisZ, -1, true);
            updateCurrentState(CurrentState.Idle);
        }

        private void cmdZDecr_Click(object sender, EventArgs e)
        {
            updateCurrentState(CurrentState.MovingZAxis);
            moveRelativeDistance(txtZIncr, txtZPos, axisZ, 1, true);
            updateCurrentState(CurrentState.Idle);
        }

        private void cmdHome_Click(object sender, EventArgs e)
        {
            homeAxes();
        }

        private Point setPoint(TextBox txtX, TextBox txtY )
        {
            Point p = new Point();
            if ( axisX != null && axisY != null )
            {
                int xPos = axisX.GetPosition();
                int yPos = axisY.GetPosition();

                txtX.Text = convertToMM(xPos).ToString();
                txtY.Text = convertToMM(yPos).ToString();

                p.X = xPos;
                p.Y = yPos;

                updateGridCount();
            }
            return p;
        }

        
        /**
         * Listener for updates from the Keithley readings
         */
        public void readingsUpdate(object sender, ReadingsUpdateEventArgs e)
        {
            /*
            //extract the data from the load cell port
            //should be changed so the keithleyControl can provide the correct
            //port info, but is hardly a big issue at the moment.
            int port = cmbLoadPort.SelectedIndex;
            double load = e.readings[port, 1];

            
            double excitation = e.readings[cmbSelectLoadCellExcitation.SelectedIndex, 1];

            doubleCurrentLoad = LCEB_LoadCell.getLoadNewton(load, excitation);
            doubleCurrentLoad = doubleCurrentLoad - loadOffset;
            txtCurrentLoad.Text = doubleCurrentLoad.ToString();

            updateProbeContact();

            // Initiate the probe scanning routine if flagged by isScanning
            scanningRoutine();
            */
        }
        
        private bool axesBusy()
        {
            if (axisX == null || axisY == null || axisZ == null)
            {
                return true;
            }
            else 
            {
                return (axisX.IsBusy() || axisY.IsBusy() || axisZ.IsBusy());
            }
        }

        // Method to establish contact by going to the load set by the user
        private void establishContact()
        {
            if ( !axesBusy() )
            {
                if (doubleCurrentLoad < doubleGotoLoad)
                {                    
                    updateCurrentState(CurrentState.EstablishingContact);
                    double gotoLoadIncrement = (double)nudLoadIncrement.Value;
                    if (gotoLoadIncrement == 0)
                        gotoLoadIncrement = 0.05;

                    int dist = convertToInternalUnits(gotoLoadIncrement);
                    moveAxisRel(axisZ, dist, true);
                    updateAxesPos();
                    isEstablishingContact = true;
                }
                else
                {
                    isEstablishingContact = false;
                    updateCurrentState(CurrentState.Idle);
                }
            }
        }

        // Method to de-establish contact by going to negative load
        private void deEstablishContact()
        {
            if ( !axesBusy() )
            {
                if (probeInContact())  // doubleCurrentLoad > -0.24 or the weight of the probe itself
                {                    
                    updateCurrentState(CurrentState.DeEstablishingContact);
                    double deLoadIncrement = 0.2;
                    int dist = convertToInternalUnits(deLoadIncrement);
                    moveAxisRel(axisZ, -dist, true);
                    updateAxesPos();
                    isDeEstablishingContact = true;
                }
                else
                {
                    // Move an extra mm up to be certain.
                    int dist = convertToInternalUnits(0.2);
                    isDeEstablishingContact = false;
                    moveAxisRel(axisZ, -dist, true);
                    updateAxesPos();
                }
            }
        }

        // Scanning routine to move stage and call method to make measurement at
        // different points on sample.
        /* algorithm for this routine
        *  1. Check that scanning mode is enabled and none of the axes are moving
         * 2. Check probe contact.
         * if in contact 
         *      if measurement ongoing
         *          do nothing
         *      else if measurement finished
         *          set next point
         *          move away from contact
         *          if doneScanning
         *              stop scanning
         *          end
         *      else if measurement not commenced
         *          begin measurement
         *      end
         * else if not in contact
         *      if at next point
         *          move to load
         *      else if not at next point
         *          move to next point
         *      end
         *      
         * end
         *      
        * */
        /*
        public void scanningRoutine()
        {
            // We should enforce that no axes are moving at all.
            if (isScanning && !axesBusy() && experimentCallback != null)
            {
                if (!isEstablishingContact && probeInContact())
                {
                    
                    // Problems:
                    // - Measurement starts regardless of the current position being start point or not.
                    // - If probe is initially in contact, the measurement of first point is made, regardless of the load level being less than the required (set) load.
                    switch (experimentCallback.getMeasurementState())
                    {
                        case ExperimentControl.MeasurementState.DuringMeasurement:                            
                            updateCurrentState(CurrentState.DuringMeasurement);
                            break;

                        case ExperimentControl.MeasurementState.AfterMeasurement:                            
                            updateCurrentState(CurrentState.AfterMeasurement);
                            deEstablishContact();
                            updateCurrentState(CurrentState.Scanning);
                            break;

                        case ExperimentControl.MeasurementState.BeforeMeasurement:                            
                            updateCurrentState(CurrentState.BeforeMeasurement);
                            experimentCallback.startMeasurement();
                            updateCurrentState(CurrentState.Measuring);
                            break;
                    }
                }
                else //if not in contact
                {
                    switch (experimentCallback.getMeasurementState())
                    {
                        case ExperimentControl.MeasurementState.AfterMeasurement:                            
                            updateCurrentState(CurrentState.AfterMeasurement);
                            // Increment the number of measured points for interface
                            TotalPointsMeasured++;
                            txttotalpointsmeasured.Text = TotalPointsMeasured.ToString();
                            // Then increment and move to next point
                            deEstablishContact();
                            if (iY < nY && scanForward)
                            {
                                int distY = convertToInternalUnits(incrY);
                                moveAxisRel(axisY, distY, true);
                                updateAxesPos();
                            }
                            else if (iY < nY && !scanForward)
                            {
                                int distY = convertToInternalUnits(incrY);
                                moveAxisRel(axisY, -distY, true);
                                updateAxesPos();
                            }
                            else
                            {
                                int distX = convertToInternalUnits(incrX);
                                moveAxisRel(axisX, distX, true);
                                updateAxesPos();
                            }
                            experimentCallback.setMeasurementState(ExperimentControl.MeasurementState.BeforeMeasurement);
                            setNextPoint();
                            break;

                        case ExperimentControl.MeasurementState.BeforeMeasurement:
                            updateCurrentState(CurrentState.BeforeMeasurement);
                            
                            // Should be at position, now move the probe down.
                            establishContact();
                            break;
                    }
                }                            
            }
            else
            {
                if (isEstablishingContact)                                    
                    establishContact();                
            }
        }
        */
        // Updates the target x,y point
        private void setNextPoint()
        {
            if (!isDeEstablishingContact)
            {
                if (iY < nY)
                {
                    iY++;
                }
                else if (iX < nX)
                {
                    // New row
                    iX++;
                    scanForward = !scanForward;
                    iY = 1;
                }
                else
                {
                    // Done with the scan
                    isScanning = false;
                    experimentCallback.endMeasuring();
                    //homeAxes();
                }
            }
        }
        
        private void updateGridCount()
        {
            try
            {
                double sX = Convert.ToDouble(txtStartX.Text);
                double sY = Convert.ToDouble(txtStartY.Text);
                double eX = Convert.ToDouble(txtEndX.Text);
                double eY = Convert.ToDouble(txtEndY.Text);

                nX = Convert.ToInt32(numberOfPointsX.Text);
                nY = Convert.ToInt32(numberOfPointsY.Text);

                //double incrX = Convert.ToDouble(txtXIncr.Text);
                //double incrY = Convert.ToDouble(txtYIncr.Text);

                if (nX != 0)
                    incrX = Math.Floor(((eX - sX) / (nX - 1))*10000)/10000;
                if (nY != 0)
                    incrY = Math.Floor(((eY - sY) / (nY - 1))*10000)/10000;

                /*
                int nX = 0;
                int nY = 0;
                if (incrX != 0)
                    nX = (int)Math.Round((eX - sX) / incrX) + 1;
                if (incrY != 0)
                    nY = (int)Math.Round((eY - sY) / incrY) + 1;
                */

                txtIncrementX.Text = incrX.ToString();
                txtIncrementY.Text = incrY.ToString();
                txtTotalPoints.Text = (nX * nY).ToString();

            }
            catch( FormatException ex)
            {

            }
        }
        private void OnProbeUpdate(TemperatureGaugeEventArgs e)
        {
            if ( ProbeTouchingStateChanged != null )
            {
                ProbeTouchingStateChanged(this, e);
            }
        }
        private void updateProbeContact()
        {            
            if (probeInContact() && !probeTouchingState)
            {
                probeTouchingState = true;
                TemperatureGaugeEventArgs evt = new TemperatureGaugeEventArgs();
                evt.temperatureGaugeEnabled = true;
                OnProbeUpdate(evt);
            }
            else if ( !probeInContact() && probeTouchingState )
            {
                probeTouchingState = false;
                TemperatureGaugeEventArgs evt = new TemperatureGaugeEventArgs();
                evt.temperatureGaugeEnabled = false;
                OnProbeUpdate(evt);
            }                            
        }
        private void updateProbeTextState( Object sender, TemperatureGaugeEventArgs e )
        {
            if ( e.temperatureGaugeEnabled )
                lblLoadIndicator.Text = strProbeTouching;
            else
                lblLoadIndicator.Text = strProbeNotTouching;
        }

        public void startScan()
        {
            isScanning = true;
            updateCurrentState(CurrentState.Scanning);
            TotalPointsMeasured = 0;
            txttotalpointsmeasured.Text = TotalPointsMeasured.ToString();
        }

        public void abortScan()
        {
            /*
            isScanning = false;
            updateCurrentState(CurrentState.Aborted);
            experimentCallback.setMeasurementState(ExperimentControl.MeasurementState.BeforeMeasurement);
            isEstablishingContact = false;
            isDeEstablishingContact = false;
            scanForward = true;
            */
        }

        // Setting the goto load, the start- and endpoints
        private void cmdLoad_Click(object sender, EventArgs e)
        {
            txtGotoLoad.Text = txtCurrentLoad.Text;
            doubleGotoLoad = doubleCurrentLoad;
        }

        private void cmdStartPoint_Click(object sender, EventArgs e)
        {
            startPoint = setPoint(txtStartX, txtStartY);
        }

        private void cmdEndPoint_Click(object sender, EventArgs e)
        {
            endPoint = setPoint(txtEndX, txtEndY);
        }   
     
        //Returns true of the probe is touching the sample
        private bool probeInContact()
        {
            return (doubleCurrentLoad > minLoadCellError) ;
        }

        private void moveAxisAbs( ZaberBinaryDevice axis, int pos )
        {
            if (axis != null && !probeInContact())                            
                axis.MoveAbsolute(pos);            
        }

        private void moveAxisRel( ZaberBinaryDevice axis, int dist, bool ignoreProbeContact )
        {
            if (axis != null)
            {
                if (ignoreProbeContact)
                {
                    axis.MoveRelative(dist);                    
                }
                else if (!probeInContact())
                {                    
                    axis.MoveRelative(dist);
                }
            }
            
        }

        private void txtXIncr_TextChanged(object sender, EventArgs e)
        {
            updateGridCount();
        }

        private void txtYIncr_TextChanged(object sender, EventArgs e)
        {
            updateGridCount();
        }

        private void txtZIncr_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdgotoLoad_Click(object sender, EventArgs e)
        {
            establishContact();
        }

        private void cmdgotoStartPoint_Click(object sender, EventArgs e)
        {
            if (!probeInContact())
            {
                updateCurrentState(CurrentState.MovingXAxis);
                moveAxisAbs(axisX, startPoint.X);
                updateCurrentState(CurrentState.MovingYAxis);
                moveAxisAbs(axisY, startPoint.Y);
                updateAxesPos();
                updateCurrentState(CurrentState.Idle);
                
            }
        }

        private void cmdGoToEndPoint_Click(object sender, EventArgs e)
        {
            if (!probeInContact())
            {
                updateCurrentState(CurrentState.MovingXAxis);
                moveAxisAbs(axisX, endPoint.X);
                updateCurrentState(CurrentState.MovingYAxis);
                moveAxisAbs(axisY, endPoint.Y);
                updateAxesPos();
                updateCurrentState(CurrentState.Idle);
            }
        }

        private void txtStartX_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStartY_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblStartX_Click(object sender, EventArgs e)
        {

        }

        private void txtXPos_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblXPos_Click(object sender, EventArgs e)
        {

        }

        private void txtMoveX_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGotoLoad_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblGotoLoad_Click(object sender, EventArgs e)
        {

        }

        private void txtCurrentLoad_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblZIncr_Click(object sender, EventArgs e)
        {

        }

        private void txtIncrementX_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblIncrementX_Click(object sender, EventArgs e)
        {

        }

        private void txtIncrementY_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblIncrementY_Click(object sender, EventArgs e)
        {

        }

        private void tempscan_Click(object sender, EventArgs e)
        {
            isScanning = true;
            updateCurrentState(CurrentState.Scanning);
            TotalPointsMeasured = 0;
            txttotalpointsmeasured.Text = TotalPointsMeasured.ToString();
            if ( plotMapCallback != null)
            {
                PlotMapEventArgs evt = new PlotMapEventArgs();
                evt.nX = nX;
                evt.nY = nY;
                evt.startX = convertToMM(startPoint.X);
                evt.startY = convertToMM(startPoint.Y);
                evt.endX = convertToMM(endPoint.X);
                evt.endY = convertToMM(endPoint.Y);
                plotMapCallback(this, evt);
            }
                
                    
        }

        private void abortscan_Click(object sender, EventArgs e)
        {
            /*
            isScanning = false;
            updateCurrentState(CurrentState.Aborted);
            experimentCallback.setMeasurementState(ExperimentControl.MeasurementState.BeforeMeasurement);
            isEstablishingContact = false;
            isDeEstablishingContact = false;
            scanForward = true;*/
        }

        private void lblnumberOfPointsX_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalPoints_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTotalPoints_Click(object sender, EventArgs e)
        {

        }

        private void numberOfPointsX_TextChanged(object sender, EventArgs e)
        {
            updateGridCount();
        }

        private void lblnumberOfPointsY_Click(object sender, EventArgs e)
        {

        }

        private void numberOfPointsY_TextChanged(object sender, EventArgs e)
        {
            updateGridCount();
        }

        private void XYZControl_Load(object sender, EventArgs e)
        {

        }

        private void lblState_Click(object sender, EventArgs e)
        {

        }

        private void txttotalpointsmeasured_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbLoadPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSelectLoadCellExcitation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public double[] getCoordinates()
        {
            double[] coords = new double[4];
            coords[0] = getXAxisPos();
            coords[1] = getYAxisPos();
            coords[2] = getZAxisPos();
            coords[3] = doubleCurrentLoad;
            return coords;
        }
        
        private void cmdTareLoad_Click(object sender, EventArgs e)
        {
            loadOffset = Convert.ToDouble(txtCurrentLoad.Text);
        }

        private void cmdResetError_Click(object sender, EventArgs e)
        {
            updateCurrentState(CurrentState.Idle);
        }
    }
    public class PlotMapEventArgs : EventArgs
    {
        public int nX, nY;
        public double startX, startY, endX, endY;
    }
    public class TemperatureGaugeEventArgs : EventArgs
    {
        public bool temperatureGaugeEnabled;
    }

    public interface SeebeckExperimentCallback
    {
        //ExperimentControl.MeasurementState getMeasurementState();

        void startMeasurement();

        //void setMeasurementState(ExperimentControl.MeasurementState state);

        void endMeasuring();
    }


}
