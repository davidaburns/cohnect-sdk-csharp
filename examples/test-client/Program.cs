using System;
using System.Threading;
using System.Threading.Tasks;
using CohnectSDK;

namespace test_client {
    class Program {
        static void Main() {
            // using (var cts = new CancellationTokenSource()) {
            //     Console.CancelKeyPress += (sender, eventArgs) => {
            //         Console.WriteLine("Stopping...");
            //         cts.Cancel();
            //         eventArgs.Cancel = true;
            //     };

            //     try{
            //         var host = "localhost";
            //         var port = 8068;

            //         var client = new CohnectClient(host, port);
            //         client.Get("TEST_KEY");
            //         client.Set("TEST_KEY", 1);

            //         Task.Delay(Timeout.Infinite, cts.Token).Wait();
            //     } catch (OperationCanceledException err) {
            //         Console.WriteLine(err);
            //     }

            //     Console.WriteLine("Exiting...");
            // }

            var host = "localhost";
            var port = 8068;

            var client = new CohnectClient(host, port);
            client.Get("TEST_GET_KEY");
            client.Set("TEST_SET_KEY", 1);
        }
    }
}

