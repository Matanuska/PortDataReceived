using System;
using System.IO.Ports;

namespace PortDataReceived
{
    class PortDataReceived
    {
        public static void Main()
        {
            //SerialPort mySerialPort = new SerialPort("COM8");

            //mySerialPort.BaudRate = 9600;
            //mySerialPort.Parity = Parity.None;
            //mySerialPort.StopBits = StopBits.One;
            //mySerialPort.DataBits = 8;
            //mySerialPort.Handshake = Handshake.None;
            //mySerialPort.RtsEnable = true;

            //mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);




            SerialPort myport1 = new SerialPort();
            try
            {     
                myport1.PortName = "COM8";
                myport1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                myport1.Open();
                myport1.DiscardOutBuffer();
                myport1.DiscardInBuffer();
            }
            catch (System.IO.IOException e) { }
            finally { }

            SerialPort myport2 = new SerialPort();
            try
            {               
                myport2.PortName = "COM9";
                myport2.DtrEnable = true;
                myport2.RtsEnable = true;

                myport2.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                myport2.Open();
                myport2.DiscardOutBuffer();
                myport2.DiscardInBuffer();
            }
            catch (System.IO.IOException e) { }
            finally { }


            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();
            Console.ReadKey();

            if (myport1.IsOpen)
                myport1.Close();

            if(myport2.IsOpen)
                myport2.Close();


        }

        private static void DataReceivedHandler(
                            object sender,
                            SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
           // Console.WriteLine("Data Received:");
            Console.Write(indata);
        }
    }
}