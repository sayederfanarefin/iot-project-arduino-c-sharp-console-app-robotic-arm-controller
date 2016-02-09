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
                    Console.WriteLine("claw close");
                    port.Write("2");
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    Console.WriteLine("claw open");
                    port.Write("3");
                }
                else if (keyInfo.Key == ConsoleKey.B)
                {
                    //base
                    Console.WriteLine("base");
                    port.Write("4");
                }
                else if (keyInfo.Key == ConsoleKey.S)
                {
                    //shoulder
                    Console.WriteLine("shoulder");
                    port.Write("5");
                }
                else if (keyInfo.Key == ConsoleKey.W)
                {
                    //wrist up down
                    Console.WriteLine("wrist updown");
                    port.Write("6");
                }
                else if (keyInfo.Key == ConsoleKey.M)
                {
                    //wrist left
                    Console.WriteLine("wrist left");
                    port.Write("7");
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    //wrist right
                    Console.WriteLine("wrist right");
                    port.Write("8");
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    //wrist right
                    Console.WriteLine("Good bye");
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }
            //Console.ReadLine();
            port.Close();
        }
    }
}
