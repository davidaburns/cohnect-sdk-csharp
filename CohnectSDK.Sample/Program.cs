using CohnectSDK.Client;

namespace CohnectSDKTestClient {
    internal class Program {
        private static void Main() {
            const string host = "localhost";
            const int port = 8068;

            var client = new CohnectClient(host, port);
            client.Get("TEST_GET_KEY");
            client.Set("TEST_SET_KEY", 1);
            client.Get("TEST_SET_KEY");
        }
    }
}

