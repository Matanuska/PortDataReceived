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




            Class1 myport1 = new Class1();
            myport1.PortName = "COM8";

            Class1 myport2 = new Class1();
            myport2.PortName = "COM9";

            myport2.DtrEnable = true;
            myport2.RtsEnable = true;

            myport1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            myport2.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

           
            myport1.Open();
            myport2.Open();

            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();
            Console.ReadKey();
            myport1.Close();
            myport2.Close();


        }

        private static void DataReceivedHandler(
                            object sender,
                            SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.Write(indata);
        }
    }
}