using System.Net.Sockets;
using CohnectSDK.Buffers;

namespace CohnectSDK.Client {
    public class CohnectClient : IDisposable {
        private readonly UdpClient _client;
        private readonly Guid _clientUuid;

        public CohnectClient(string host, int port) {
            _client = new UdpClient();
            _client.Connect(host, port);
            _clientUuid = Guid.NewGuid();
        }

        public async void Get(string key) {
            var parameters = new RequestParamsGet{ClientUuid=_clientUuid, Key=key};
            var packet = RequestPacketTUtils.FromOpcode(RequestOp.GET, parameters);

            await SendPacketAsync(packet);
        }

        public async void Set(string key, object data) {
            var parameters = new RequestParamsSet{ClientUuid=_clientUuid, Key=key, Data=data};
            var packet = RequestPacketTUtils.FromOpcode(RequestOp.SET, parameters);

            await SendPacketAsync(packet);
        }

        public async void SetClientTags(string[] tags) {
            var parameters = new RequestParamsSetClientTags{ClientUuid=_clientUuid, Tags=tags};
            var packet = RequestPacketTUtils.FromOpcode(RequestOp.SET_CLIENT_TAGS, parameters);

            await SendPacketAsync(packet);
        }

        public async void Execute(string action, Dictionary<string, object> actionParams) {
            var parameters = new RequestParamsExecute{ClientUuid=_clientUuid, Action=action, Params=actionParams};
            var packet = RequestPacketTUtils.FromOpcode(RequestOp.EXECUTE, parameters);

            await SendPacketAsync(packet);
        }

        private async Task SendPacketAsync(RequestPacketT packet) {
            var data = packet.SerializeToBinary();
            await _client.SendAsync(data, data.Length);
        }

        public void Dispose() {
            _client?.Dispose();
        }
    }
}
