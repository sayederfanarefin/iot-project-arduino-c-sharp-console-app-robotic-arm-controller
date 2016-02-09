using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolemovementtry
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] ports = SerialPort.GetPortNames();
            for (int i =0; i < ports.Length; i++) {
                Console.WriteLine(ports[i]);
            }
            String portName = Console.ReadLine();
            SerialPort port = new SerialPort(portName, 9600);
            port.Open();
           
            

            while (true) { 
                ConsoleKeyInfo keyInfo = Console.ReadKey();
            
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    Console.WriteLine("up");
                    port.Write("0");
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    Console.WriteLine("down");
                    port.Write("1");
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine("left");
                    port.Write("2");
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    Console.WriteLine("right");
                    port.Write("3");
                }
            }
            Console.ReadLine();
            port.Close();
        }
    }
}
