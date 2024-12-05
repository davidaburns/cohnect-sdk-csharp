using Newtonsoft.Json;
using CohnectSDK.Buffers;

namespace CohnectSDK.Client {
    public static class RequestPacketTUtils {
        public static RequestPacketT FromOpcode(RequestOp opcode, RequestParamsBase? body = null) {
            var settings = new JsonSerializerSettings {};
            var json = JsonConvert.SerializeObject(body, body?.GetType(), settings);
            var bytes = System.Text.Encoding.UTF8.GetBytes(json).ToList();

            return new RequestPacketT {
                CorrelationId=Guid.NewGuid().ToByteArray().ToList(),
                Opcode=opcode,
                Length=(ushort)bytes.Count,
                Body=bytes
            };
        }
    }
    
    public class RequestParamsBase {
        public required Guid ClientUuid;
    }
}
