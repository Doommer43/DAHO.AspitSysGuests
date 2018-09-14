using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using DAHO.AspitSysGuests.BusinessLayer;

namespace DAHO.AspitSysGuests.Server
{
    public class Server
    {
        /// <summary>
        /// The TcpListener used to receive the clients.
        /// </summary>
        private TcpListener listener { get; }
        /// <summary>
        /// The IP Address of the server.
        /// </summary>
        public IPAddress ServerIpAddress { get; }
        /// <summary>
        /// The constructor initializes the IP Address and the TcpListener.
        /// Uses either local IP Address, or the IPv4 Address of the computer.
        /// </summary>
        /// <param name="port">Which port to be used</param>
        /// <param name="useLocal">Optional, is true by default.</param>
        public Server(int port, bool useLocal = true)
        {
            if (useLocal)
                ServerIpAddress = IPAddress.Parse("127.0.0.1");
            else
            {
                var hostName = Dns.GetHostName();
                var ipAddresses = Dns.GetHostAddresses(hostName);
                ServerIpAddress = ipAddresses.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
            }

            if (ServerIpAddress == null)
                throw new NullReferenceException("No IPv4 address for the server");

            listener = new TcpListener(ServerIpAddress, port);
        }

        /// <summary>
        /// This method starts the server listening for a client.
        /// It receives the request, handles it, and returns the response.
        /// It is ran in a infinite loop.
        /// </summary>
        public void Start()
        {
            listener.Start();

            while (true)
            {
                try
                {

                    using (TcpClient client = listener.AcceptTcpClient())
                    using (NetworkStream ns = client.GetStream())
                    using (StreamWriter writer = new StreamWriter(ns))
                    using (StreamReader reader = new StreamReader(ns))
                    {
                        writer.AutoFlush = true;

                        string request = reader.ReadLine();
                        string response = Handle(request);

                        writer.WriteLine(response);
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Method used to handle the request from the client.
        /// </summary>
        /// <param name="request">The request from the client. Must be CSV and atleast two values.</param>
        /// <returns>Returns the response to the client</returns>
        private string Handle(string request)
        {
            var splittedRequest = request.Split(',');
            string response = "";
            if (VerifyRequest(splittedRequest))
            {
                StatisticHandler SH = new StatisticHandler();
                switch (int.Parse(splittedRequest[0]))
                {
                    case 1:
                        //Do some calls to the logic
                        response = SH.GetAverageGuestAge().ToString();
                        break;
                    case 2:
                        //Do some calls to the logic
                        //Dummy code
                        response = SH.TotalGuests().ToString();
                        break;
                    default:
                        response = "Error, wrong method call";
                        break;
                }
                return response;
            }
            return $"'{splittedRequest[0]}' is not a correct input.";
        }

        /// <summary>
        /// Method used to validate the request.
        /// </summary>
        /// <param name="splittedRequest">The splitted CSV request</param>
        /// <returns>Returns true if valid</returns>
        private bool VerifyRequest(string[] splittedRequest)
        {
            //DAVA's Solution
            return int.TryParse(splittedRequest[0], out int result);
            //foreach (char number in splittedRequest[0])
            //{
            //    if (!char.IsDigit(number))
            //        return false;
            //}
            //return true;
        }
    }
}
