using System;
using CohnectSDK.Client;

namespace CohnectSDKTestClient {
    internal class Program {
        private static bool running = true;

        private static void Main() {
            AppDomain.CurrentDomain.ProcessExit += (sender, args) => {
                running = false;
            };

            Console.CancelKeyPress += (sender, args) => {
                running = false;
                args.Cancel = true;
            };

            var listener = new CohnectClientListener();
            listener.RegisterMessageHandler(CohnectSDK.Buffers.ClientMessageType.PING_SUCCESS, () => Console.WriteLine("PING_SUCCESS Recieved via Message Handler"));
            listener.RegisterMessageHandler(CohnectSDK.Buffers.ClientMessageType.PING_SUCCESS, () => Console.WriteLine("Second handler"));
            listener.StartListening(8067);

            var client = new CohnectClient("localhost", 8068);
            client.Ping();

            while (running) {
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

