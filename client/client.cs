using System.Net.Sockets;
using System.Text;
using SpanJson;
using CohnectSDK.Extensions;

namespace CohnectSDK {
    public class CohnectClient : IDisposable {
        private readonly UdpClient _client;
        private readonly Guid _clientUuid;
        private readonly string _host;
        private readonly int _port;

        public CohnectClient(string host, int port) {
            _host = host;
            _port = port;

            _client = new UdpClient();
            _client.Connect(_host, _port);
            _clientUuid = Guid.NewGuid();
        }

        public async void Get(string key) {
            var parameters = new CohnectGetParams{ClientUuid=_clientUuid, Key=key};

            byte[] body = JsonSerializer.Generic.Utf8.SerializeToArrayPool(parameters).ToArray();
            CohnectPacket packet = CohnectPacket.FromOpcode(CohnectOpcode.Get, body);

            await SendPacketAsync(packet);
        }

        public async void Set(string key, object data) {
            var parameters = new CohnectSetParams{ClientUuid=_clientUuid, Key=key, Data=data};

            byte[] body = JsonSerializer.Generic.Utf8.SerializeToArrayPool(parameters).ToArray();
            CohnectPacket packet = CohnectPacket.FromOpcode(CohnectOpcode.Set, body);

            await SendPacketAsync(packet);
        }

        public async void SetClientTags(string[] tags) {
            var parameters = new CohnectSetClientTagsParams{ClientUuid=_clientUuid, Tags=tags};

            byte[] body = JsonSerializer.Generic.Utf8.SerializeToArrayPool(parameters).ToArray();
            CohnectPacket packet = CohnectPacket.FromOpcode(CohnectOpcode.SetClientTags, body);

            await SendPacketAsync(packet);
        }

        public async void Execute(string action, Dictionary<string, object> actionParams) {
            var parameters = new CohnectExecuteParams{ClientUuid=_clientUuid, Action=action, Params=actionParams};

            byte[] body = JsonSerializer.Generic.Utf8.SerializeToArrayPool(parameters).ToArray();
            CohnectPacket packet = CohnectPacket.FromOpcode(CohnectOpcode.Execute, body);

            await SendPacketAsync(packet);
        }

        private async Task SendPacketAsync(CohnectPacket packet) {
            Console.WriteLine($"Sending Packet [{new Guid(packet.Uuid).ToStringLittleEndian()}]: v{packet.Version}, Op: {packet.Opcode}, BodyLength: {packet.BodyLength}");
            Console.WriteLine($"{Encoding.UTF8.GetString(packet.Body)}");

            byte[] data = CohnectPacket.BytesFromInstance(packet);
            await _client.SendAsync(data, data.Length);
        }

        public void Dispose() {
            _client?.Dispose();
        }
    }
}