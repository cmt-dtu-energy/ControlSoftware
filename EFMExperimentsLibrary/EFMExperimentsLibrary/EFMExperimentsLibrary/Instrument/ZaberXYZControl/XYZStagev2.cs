using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zaber.Serial.Core;
namespace EFMExperimentsLibrary
{
    public partial class XYZStagev2 : UserControl
    {
        private Zaber.Serial.Core.ZaberBinaryPort zaberPort;
        private Zaber.Serial.Core.ZaberBinaryDevice axisX, axisY, axisZ;
        private const double micronPerMicroStep = 0.09921875;

        public EventHandler<XYZEventArgs> xyzPointReached;

        public XYZStagev2()
        {
            InitializeComponent();
            txtDeltaX.Leave += TxtDeltaX_Leave;
            txtDeltaY.Leave += TxtDeltaY_Leave;
            txtDeltaZ.Leave += TxtDeltaZ_Leave;
        }

        private void TxtDeltaX_Leave(object sender, EventArgs e)
        {
            updateGridPoints();
        }
        private void TxtDeltaY_Leave(object sender, EventArgs e)
        {
            updateGridPoints();
        }
        private void TxtDeltaZ_Leave(object sender, EventArgs e)
        {
            updateGridPoints();
        }

        private void cmdInitialize_Click(object sender, EventArgs e)
        {
            initializeXYZControl();
        }

        public void initializeXYZControl()
        {
            initializeZaberDevice();
        }
        private void initializeZaberDevice()
        {
            string selectedPort = txtComPort.Text;

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
                    cmdInitialize.BackColor = Color.LawnGreen;
                }
            }
            catch( Exception ex )
            {
                cmdInitialize.BackColor = Color.Red;
            }
        }

        private void updateAxesPos()
        {
            if (axisX != null)
            {
                txtCurX.Text = convertToMM(axisX.GetPosition()).ToString();
                txtLocX.Text = Convert.ToString( Convert.ToDouble(txtCurX.Text) - Convert.ToDouble(txtZeroX.Text) );
            }
            if (axisY != null)
            {
                txtCurY.Text = convertToMM(axisY.GetPosition()).ToString();
                txtLocY.Text = Convert.ToString(Convert.ToDouble(txtCurY.Text) - Convert.ToDouble(txtZeroY.Text));
            }
            if (axisZ != null)
            {
                txtCurZ.Text = convertToMM(axisZ.GetPosition()).ToString();
                txtLocZ.Text = Convert.ToString(Convert.ToDouble(txtCurZ.Text) - Convert.ToDouble(txtZeroZ.Text));
            }
        }

        private void cmdSetZero_Click(object sender, EventArgs e)
        {
            txtZeroX.Text = txtCurX.Text;
            txtZeroY.Text = txtCurY.Text;
            txtZeroZ.Text = txtCurZ.Text;
            updateAxesPos();
        }

        private int convertToInternalUnits(double moveMM)
        {
            return (int)(Math.Round(1000 * moveMM / micronPerMicroStep));
        }
        private double convertToMM(int moveMicro)
        {
            return micronPerMicroStep * moveMicro / 1000;
        }

        private void moveRelativeDistance(MaskedTextBox txtDist, MaskedTextBox txtResult, ZaberBinaryDevice axis, int dir)
        {
            if (axis != null)
            {
                try
                {
                    
                    int dist = dir * convertToInternalUnits(Convert.ToDouble(txtDist.Text));
                    moveAxisRel(axis, dist);
                    txtResult.Text = convertToMM(axis.GetPosition()).ToString();
                    

                }
                catch (Exception ex)
                {
                   
                }
            }
            updateAxesPos();
        }

        private void moveAbsoluteDistance(MaskedTextBox txtDist, MaskedTextBox txtResult, ZaberBinaryDevice axis)
        {
            if (axis != null)
            {
                try
                {
                    int dist = convertToInternalUnits(Convert.ToDouble(txtDist.Text));
                    moveAxisAbs(axis, dist);
                    txtResult.Text = convertToMM(axis.GetPosition()).ToString();
                    
                }
                catch (Exception ex)
                {
                   
                }
            }
        }

        private void cmdMoveXNeg_Click(object sender, EventArgs e)
        {
            moveRelativeDistance(txtDeltaX, txtCurX, axisX, -1);
        }

        private void cmdMoveXPos_Click(object sender, EventArgs e)
        {
            moveRelativeDistance(txtDeltaX, txtCurX, axisX, 1);
        }

        private void cmdMoveYNeg_Click(object sender, EventArgs e)
        {
            moveRelativeDistance(txtDeltaY, txtCurY, axisY, -1);
        }

        private void cmdMoveYPos_Click(object sender, EventArgs e)
        {
            moveRelativeDistance(txtDeltaY, txtCurY, axisY, 1);
        }

        private void cmdMoveZNeg_Click(object sender, EventArgs e)
        {
            moveRelativeDistance(txtDeltaZ, txtCurZ, axisZ, -1);
        }

        private void cmdMoveZPos_Click(object sender, EventArgs e)
        {
            moveRelativeDistance(txtDeltaZ, txtCurZ, axisZ, 1);
        }

        private void cmdGoto_Click(object sender, EventArgs e)
        {
            gotoPoint();
        }

        private void gotoPoint()
        {
            moveAbsoluteDistance(txtSetXPos, txtCurX, axisX);
            moveAbsoluteDistance(txtSetYPos, txtCurY, axisY);
            moveAbsoluteDistance(txtSetZPos, txtCurZ, axisZ);
            updateAxesPos();
        }

        private void cmdStartPoint_Click(object sender, EventArgs e)
        {
            startPoint.x = Convert.ToDouble(txtCurX.Text);
            startPoint.y = Convert.ToDouble(txtCurY.Text);
            startPoint.z = Convert.ToDouble(txtCurZ.Text);

            txtStartX.Text = Convert.ToString(startPoint.x);
            txtStartY.Text = Convert.ToString(startPoint.y);
            txtStartZ.Text = Convert.ToString(startPoint.z);
            updateGridPoints();

        }
        private void updateGridPoints()
        {
            nx = Math.Max(1, (int)Math.Abs(Math.Ceiling( ( Convert.ToDecimal(txtEndX.Text) - Convert.ToDecimal(txtStartX.Text) ) / Convert.ToDecimal(txtDeltaX.Text))) );
            ny = Math.Max(1, (int)Math.Abs(Math.Ceiling( ( Convert.ToDecimal(txtEndY.Text) - Convert.ToDecimal(txtStartY.Text)) / Convert.ToDecimal(txtDeltaY.Text))));
            nz = Math.Max(1, (int)Math.Abs(Math.Ceiling( ( Convert.ToDecimal(txtEndZ.Text) - Convert.ToDecimal(txtStartZ.Text)) / Convert.ToDecimal(txtDeltaZ.Text))));
            
            txtNx.Text = Convert.ToString(nx);
            txtNy.Text = Convert.ToString(ny);
            txtNz.Text = Convert.ToString(nz);
        }
        private void moveAxisAbs(ZaberBinaryDevice axis, int pos)
        {
            if (axis != null)
            {
                axis.MoveAbsolute(pos);
                axis.PollUntilIdle();
            }
        }

        private void cmdEndPoint_Click(object sender, EventArgs e)
        {
            endPoint.x = Convert.ToDouble(txtCurX.Text);
            endPoint.y = Convert.ToDouble(txtCurY.Text);
            endPoint.z = Convert.ToDouble(txtCurZ.Text);

            txtEndX.Text = Convert.ToString(endPoint.x);
            txtEndY.Text = Convert.ToString(endPoint.y);
            txtEndZ.Text = Convert.ToString(endPoint.z);
            updateGridPoints();
        }

        private void cmdGotoStart_Click(object sender, EventArgs e)
        {
            gotoStart();
        }

        private void gotoStart()
        {
            txtSetXPos.Text = txtStartX.Text;
            txtSetYPos.Text = txtStartY.Text;
            txtSetZPos.Text = txtStartZ.Text;

            gotoPoint();
        }

        private void cmdGotoEnd_Click(object sender, EventArgs e)
        {
            gotoEnd();
        }

        private void gotoEnd()
        {
            txtSetXPos.Text = txtEndX.Text;
            txtSetYPos.Text = txtEndY.Text;
            txtSetZPos.Text = txtEndZ.Text;

            gotoPoint();
        }

        private void moveAxisRel(ZaberBinaryDevice axis, int dist)
        {
            if (axis != null)
            {
               
               axis.MoveRelative(dist);
               axis.PollUntilIdle();
            }

        }

        private P3D getCurrentPoint()
        {
            P3D p;
            p.x = Convert.ToDouble(txtLocX.Text);
            p.y = Convert.ToDouble(txtLocY.Text);
            p.z = Convert.ToDouble(txtLocZ.Text);

            return p;
        }

        private void txtDeltaX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private double[,] scanPoints;
        private int scanIndex;
        private void cmdStartScan_Click(object sender, EventArgs e)
        {
            //clean up any previous on-going scan
            scanning = false;
            //goto the start point
            gotoStart();

            //calculate the scanning points
            int ntot = nx * ny * nz;
            scanPoints = new double[ntot,3];
            double dx = Convert.ToDouble(txtDeltaX.Text);
            double dy = Convert.ToDouble(txtDeltaY.Text);
            double dz = Convert.ToDouble(txtDeltaZ.Text);
            for ( int i = 0; i < nx; i++ )
            {
                for ( int j = 0; j < ny; j++ )
                {
                    for ( int k = 0; k < nz; k++)
                    {
                        int curIndex = i * ny * nz + j * nz + k;
                        scanPoints[curIndex, 0] = startPoint.x + i * dx;
                        scanPoints[curIndex, 1] = startPoint.y + j * dy;
                        scanPoints[curIndex, 2] = startPoint.z + k * dz;
                    }
                }
            }
            //start at one as the first point will be measured directly below
            scanIndex = 1;
            //raise the flag that a scan is now ongoing
            scanning = true;
            stdBgColor = cmdStartScan.BackColor;
            cmdStartScan.BackColor = Color.LawnGreen;
            //send the event that a point has been reached and that data should be collected
            if ( xyzPointReached != null )
            {
                XYZEventArgs evt = new XYZEventArgs(getCurrentPoint());
                xyzPointReached(this, evt);
            }
        }

        public void measurementsCompleted( object sender, EventArgs args )
        {
            //if scanning then go to the next point
            if ( scanning )
            {
                if ( scanIndex<scanPoints.GetLength(0))
                {
                    
                    txtSetXPos.Text = Convert.ToString(scanPoints[scanIndex, 0]);
                    txtSetYPos.Text = Convert.ToString(scanPoints[scanIndex, 1]);
                    txtSetZPos.Text = Convert.ToString(scanPoints[scanIndex, 2]);
                    gotoPoint();
                    scanIndex++;
                    if (xyzPointReached != null)
                    {
                        XYZEventArgs evt = new XYZEventArgs(getCurrentPoint());
                        xyzPointReached(this, evt);
                    }
                }
                else
                {
                    cmdStartScan.BackColor = stdBgColor;
                    scanning = false;
                }
            }
        }
        private Color stdBgColor;
        private P3D startPoint, endPoint;
        private int nx, ny, nz;
        private bool scanning = false;
    }

    public struct P3D
    {
        public double x, y, z;
    }

    public class XYZEventArgs : EventArgs
    {
        public P3D curPoint;
        public XYZEventArgs( P3D p )
        {
            curPoint = p;
        }
    }

}
