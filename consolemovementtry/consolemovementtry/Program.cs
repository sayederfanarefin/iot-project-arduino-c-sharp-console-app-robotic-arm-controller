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

            int base1 = 5;
            int base2 = 180;
            int shoulder = 0;
            int arm = 0;
            int wrist = 0;
            int claw = 0;

            /*
            -1 = shit
            0 = base
            1 = shoulder 
            2 = arm
            */
            int selected = -1;
             

            while (true) { 
                ConsoleKeyInfo keyInfo = Console.ReadKey();
            
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    
                    if (selected == 0)
                    {
                        
                        base1= base1+10;
                        base2 = base2-10;
                        Console.WriteLine("base" +base1.ToString());
                    }
                    else if (selected == 1)
                    {
                        if (shoulder < 180) {
                            shoulder=shoulder+20;
                            Console.WriteLine("shoulder" + shoulder.ToString());
                        }
                        else
                        {
                            Console.WriteLine("shoulder is at max");
                        }
                        
                    }
                    else if (selected == 2)
                    {
                        arm=arm+20;
                        Console.WriteLine("arm" + arm.ToString());
                    }
                    else if (selected == -1)
                    {
                        Console.WriteLine("Nothing selected");
                    }
                    else
                    {
                        Console.WriteLine("unknown call :P");
                    }
                    
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (selected == 0)
                    {

                        base1= base1-10;
                        base2= base2+10;
                        Console.WriteLine("base" + base1.ToString());
                    }
                    else if (selected == 1)
                    {
                        shoulder=shoulder-20;
                        Console.WriteLine("shoulder" + shoulder.ToString());
                    }
                    else if (selected == 2)
                    {
                        arm=arm-20;
                        Console.WriteLine("arm" + arm.ToString());
                    }
                    else if (selected == -1)
                    {
                        Console.WriteLine("Nothing selected");
                    }
                    else
                    {
                        Console.WriteLine("unknown call :P");
                    }

                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    claw=claw-60;
                    Console.WriteLine("claw close "+ claw.ToString());
                    
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    claw=claw+60;
                    Console.WriteLine("claw open "+ claw.ToString());
                   
                }
                else if (keyInfo.Key == ConsoleKey.B)
                {
                    //base
                    Console.WriteLine("base");
                    selected = 0;
                }
                else if (keyInfo.Key == ConsoleKey.S)
                {
                    //shoulder
                    Console.WriteLine("shoulder");
                    selected = 1;
                }
                else if (keyInfo.Key == ConsoleKey.A)
                {
                    //wrist up down
                    Console.WriteLine("arm");
                    selected = 2;
                }
                else if (keyInfo.Key == ConsoleKey.J)
                {
                    //wrist left
                    Console.WriteLine("wrist spin left");
                    wrist=70;
                }
                else if (keyInfo.Key == ConsoleKey.K)
                {
                    //wrist stop
                    Console.WriteLine("wrist spinning stop");
                    wrist = 90;
                }
                else if (keyInfo.Key == ConsoleKey.L)
                {
                    //wrist right
                    Console.WriteLine("wrist spin right");
                    wrist= 110;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    //wrist right
                    Console.WriteLine("Good bye");
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.P)
                {
                    //print all angles
                    Console.WriteLine("Angles: (base1, base2, shoulder,arm,wrist,claw)"+base1.ToString() + "," +
                                 base2.ToString() + "," +
                                 shoulder.ToString() + "," +
                                 arm.ToString() + "," +
                                 wrist.ToString() + "," +
                                 claw.ToString());
                }
                //randomly generate a token

                Random rnd = new Random();
                int GuidInt = rnd.Next(1, 100000000);
                String GuidString = GuidInt.ToString() ;
               

                String return_ = base1.ToString() + "," + 
                                 base2.ToString() + "," + 
                                 shoulder.ToString() + "," +
                                 arm.ToString() + "," +
                                 wrist.ToString() + "," +
                                 claw.ToString() + "," +
                                 GuidString;

                //"1,45,678,3,09,67"
                
                port.Write(return_);
                Console.WriteLine("servo angles sent..");// +return_);
               
                String token_back = port.ReadLine();
                token_back.Replace(" ", "");

                 Console.WriteLine("returned " + token_back);
                int token_back_int = Convert.ToInt32(token_back);
                if (GuidInt == token_back_int)
                {
                    Console.WriteLine("Servo angles written..");
                }
                else
                {
                    Console.WriteLine("uck");
                }
                
            }
            //Console.ReadLine();
            port.Close();
        }
    }
}
