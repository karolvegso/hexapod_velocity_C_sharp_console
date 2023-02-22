using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace hexapod_velocity_console
{
    class Program
    {
        static void Main(string[] args)
        {
            // this program set velocity of hexapod
            // ask for IP address of hexapod
            Console.WriteLine("Insert IP address of hexapod: ");
            string server_hexapod = Console.ReadLine();
            // ask for port of hexapod
            Console.WriteLine("Insert port number of hexapod (e.g. 50000): ");
            string port_hexapod_str = Console.ReadLine();
            Int32 port_hexapod = Int32.Parse(port_hexapod_str);
            // create session with hexapod
            TcpClient session_hexapod = new TcpClient(server_hexapod, port_hexapod);
            NetworkStream stream_hexapod = session_hexapod.GetStream();
            // declare data as byte array in method and initialize it to null value
            Byte[] data = null;
            // ask for last system velocity of hexapod
            Console.WriteLine("Last system velocity is: ");
            string cmd_vel_qm = "VEL?" + "\n";
            data = System.Text.Encoding.ASCII.GetBytes(cmd_vel_qm);
            stream_hexapod.Write(data, 0, data.Length);
            Console.WriteLine(cmd_vel_qm);
            data = null;
            // read last system velocity of hexapod
            data = new Byte[256];
            string response_vel_qm = String.Empty;
            Int32 bytes = stream_hexapod.Read(data, 0, data.Length);
            response_vel_qm = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            data = null;
            Thread.Sleep(250);
            // print last system velocity on screen
            Console.WriteLine($"The last system velocity of hexapod is {response_vel_qm}.");
            // ask if you want to set new system velocity of hexapod
            Console.WriteLine("Do you want to set new system velocity of hexapod (Y/N)?");
            string response_str = Console.ReadLine();
            // main condition
            if (response_str == "Y" || response_str == "y")
            {
                // ask for new system velocity value
                Console.WriteLine("New system velocity value of hexapod is: ");
                string vel_str = Console.ReadLine();
                string cmd_vel_str = "VEL " + vel_str + "\n";
                data = System.Text.Encoding.ASCII.GetBytes(cmd_vel_str);
                stream_hexapod.Write(data, 0, data.Length);
                Console.WriteLine(cmd_vel_str);
                Thread.Sleep(250);
                data = null;
                // ask for new system velocity of hexapod
                Console.WriteLine("New system velocity is: ");
                cmd_vel_qm = "VEL?" + "\n";
                data = System.Text.Encoding.ASCII.GetBytes(cmd_vel_qm);
                stream_hexapod.Write(data, 0, data.Length);
                Console.WriteLine(cmd_vel_qm);
                data = null;
                // read new system velocity of hexapod
                data = new Byte[256];
                response_vel_qm = String.Empty;
                bytes = stream_hexapod.Read(data, 0, data.Length);
                response_vel_qm = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                data = null;
                Thread.Sleep(250);
                // print last system velocity on screen
                Console.WriteLine($"The new system velocity of hexapod is {response_vel_qm}.");
            }
            else
            {
                Console.WriteLine("Continue without setting system velocity of hexapod.");
            }
            // close stream and session, close all
            stream_hexapod.Flush();
            stream_hexapod.Close();
            session_hexapod.Close();
            // end of program
        }
    }
}
