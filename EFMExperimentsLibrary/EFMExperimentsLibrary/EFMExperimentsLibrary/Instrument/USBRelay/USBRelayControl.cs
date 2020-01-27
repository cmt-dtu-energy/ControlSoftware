using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFMExperimentsLibrary
{
    public partial class USBRelayControl : UserControl, CurrentRelay
    {
        private string serial = "";
        private int deviceHandle = -1;
        private DateTime previousTime;
        private const int minTime = 2;
        public USBRelayControl()
        {
            InitializeComponent();
        }

        public void USBRelayControl_Load()
        {            
            if (USBRelayDriver.usb_relay_init() != 0)
            {
                Console.WriteLine("Couldn't initialize!");
                return;
            }
            else { Console.WriteLine("Initialized successfully!"); }

            
            usb_relay_device_info deviceInfo = USBRelayDriver.usb_relay_device_enumerate();

            serial = deviceInfo.serial_number;
            deviceHandle = USBRelayDriver.usb_relay_device_open_with_serial_number(serial, serial.Length);
            int openResult = USBRelayDriver.usb_relay_device_open_all_relay_channel(deviceHandle);

            if (openResult == 0)
            {
                Console.WriteLine("No error returned from usb_relay_device_open_one_relay_channel!");
                lblNameInfo.Text = serial;
                chkOpen.Checked = true;
                previousTime = DateTime.Now;
            }
            else if (openResult == 1)
            {
                Console.WriteLine("Got error from OpenOneRelayChannel!");
                deviceHandle = -1;
                return;
            }

            
        }
        /**
         * Returns 0 if it is okay to close the application. 1 otherwise
         */         
        public int closeUSBRelayControl()
        {
            if (deviceHandle > 0)
            {
                int res = USBRelayDriver.usb_relay_device_close_all_relay_channel(deviceHandle);
                USBRelayDriver.usb_relay_device_close(deviceHandle);
            }
            deviceHandle = -1;
            return 0;
            
        }
        
        public void updateState( bool newState)
        {
            int res = -1;
            if (deviceHandle > 0)
            {
                TimeSpan ts = DateTime.Now - previousTime;
                previousTime = DateTime.Now;
                if ( ts.Seconds >= minTime )
                {
                    if (newState)
                    {
                        deviceHandle = USBRelayDriver.usb_relay_device_open_with_serial_number(serial, serial.Length);
                        res = USBRelayDriver.usb_relay_device_open_all_relay_channel(deviceHandle);
                    }
                    else
                    {
                        res = USBRelayDriver.usb_relay_device_close_all_relay_channel(deviceHandle);
                        USBRelayDriver.usb_relay_device_close(deviceHandle);
                    }
                }
            }


            if (res != 0 || deviceHandle < 0)
            {
                //revert back to the original state if the device was not able to respond
                ignoreCheckEvent = true;
                chkOpen.Checked = !newState;
                ignoreCheckEvent = false;
            }
            
        }
        private bool ignoreCheckEvent = false;
        private void chkOpen_CheckedChanged(object sender, EventArgs e)
        {
            if ( !ignoreCheckEvent)
            {
                bool newState = chkOpen.Checked;

                updateState(newState);
            }
            
        }

       

    }

    public interface CurrentRelay
    {
        void updateState( bool st );
    }
}
