using Newtonsoft.Json;
using CohnectSDK.Buffers;

namespace CohnectSDK.Client {
    public static class RequestPacketTUtils {
        public static RequestPacketT FromOpcode(RequestOp opcode, RequestParamsBase body) {
            var settings = new JsonSerializerSettings {};
            var json = JsonConvert.SerializeObject(body, body.GetType(), settings);
            var bytes = System.Text.Encoding.UTF8.GetBytes(json).ToList();

            return new RequestPacketT {
                Uuid=Guid.NewGuid().ToByteArray().ToList(),
                Opcode=opcode,
                Length=(ushort)bytes.Count,
                Body=bytes
            };
        }
    }
    
    public class RequestParamsBase {
        public required Guid ClientUuid;
    }

    public class RequestParamsGet : RequestParamsBase {
        public required string Key;
    }

    public class RequestParamsSet : RequestParamsBase {
        public required string Key;
        public required object Data;
    }

    public class RequestParamsSetClientTags : RequestParamsBase {
        public required string[] Tags;
    }

    public class RequestParamsExecute : RequestParamsBase {
        public required string Action;
        public required Dictionary<string, object> Params;
    }
}
