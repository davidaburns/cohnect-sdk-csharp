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

        public async void Ping() {
            var packet = RequestPacketTUtils.FromOpcode(RequestOp.PING, body: new RequestParamsBase{ClientUuid=_clientUuid});
            await SendPacketAsync(packet);
        }

        public async void SessionStart() {
            var packet = RequestPacketTUtils.FromOpcode(RequestOp.SESSION_START, body: new RequestParamsBase{ClientUuid=_clientUuid});
            await SendPacketAsync(packet);
        }

        public async void SessionEnd() {
            var packet = RequestPacketTUtils.FromOpcode(RequestOp.SESSION_END, body: new RequestParamsBase{ClientUuid=_clientUuid});
            await SendPacketAsync(packet);
        }

        public async void FireEvent() {
            var packet = RequestPacketTUtils.FromOpcode(RequestOp.EVENT, body: new RequestParamsBase{ClientUuid=_clientUuid});
            await SendPacketAsync(packet);
        }

        public async void RegisterClientTags() {
            var packet = RequestPacketTUtils.FromOpcode(RequestOp.REGISTER_CLIENT_TAGS, body: new RequestParamsBase{ClientUuid=_clientUuid});
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
