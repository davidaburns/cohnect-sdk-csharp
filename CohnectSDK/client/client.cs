using System.Net;
using System.Net.Sockets;
using Google.FlatBuffers;
using CohnectSDK.Buffers;
using System.IO.Compression;

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

    public class CohnectClientListener : IDisposable {
        private readonly UdpClient _client;
        private Dictionary<ClientMessageType, List<Action>> _messageHandlers;

        public CohnectClientListener() {
            _messageHandlers = new Dictionary<ClientMessageType, List<Action>>();
            _client = new UdpClient();
        }

        public void RegisterMessageHandler(ClientMessageType messageType, Action handler) {
            if (!_messageHandlers.ContainsKey(messageType)) {
                _messageHandlers[messageType] = new List<Action>();
            }

            _messageHandlers[messageType].Add(handler);
        }

        public void UnregisterMessageHandler(ClientMessageType messageType, Action handler) {
            if (_messageHandlers.ContainsKey(messageType)) {
                _messageHandlers[messageType].Remove(handler);
            }
        }

        public void StartListening(int port) {
            Task.Run(() => Listen(port));
        }

        public void Dispose() {
            _client?.Dispose();
        }

        private void Listen(int port) {
            try {
                using (var client = new UdpClient(port)) {
                    while (true) {
                        try {
                            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
                            byte[] bytes = client.Receive(ref endpoint);

                            ClientMessagePacketT packet = ClientMessagePacket.GetRootAsClientMessagePacket(new ByteBuffer(bytes)).UnPack();
                            if (_messageHandlers.ContainsKey(packet.Type)) {
                                foreach (var handler in _messageHandlers[packet.Type]) {
                                    handler.Invoke();
                                }
                            }
                        } catch (Exception ex) {
                            Console.WriteLine($"Error while processing incoming packet: {ex}");
                        }
                        
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error while starting up listener: {ex}");
            }      
        }
    }
}
