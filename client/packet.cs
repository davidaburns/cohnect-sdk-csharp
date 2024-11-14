using System.Runtime.InteropServices;

namespace CohnectSDK {
    [StructLayout(LayoutKind.Sequential)]
    public struct CohnectPacket {
        public byte Version;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Uuid;
        public CohnectOpcode Opcode;
        public short BodyLength;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1453)]
        public byte[] Body;

        public static CohnectPacket FromOpcode(CohnectOpcode opcode, byte[] body) {
            byte[] bodyFixed = new byte[1453];
            byte[] guidFixed = new byte[16];
            byte[] guid = Guid.NewGuid().ToByteArray();

            Array.Copy(body, 0, bodyFixed, 0, Math.Min(body.Length, bodyFixed.Length));
            Array.Copy(guid, 0, guidFixed, 0, Math.Min(guid.Length, guidFixed.Length));

            return new CohnectPacket {
                Version = CohnectConstants.PacketAcceptedVersion,
                Uuid = guidFixed,
                Opcode = opcode,
                BodyLength = (short)body.Length,
                Body = bodyFixed,
            };
        }

        public static byte[] BytesFromInstance(CohnectPacket inst) {
            int size = Marshal.SizeOf(inst);
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            try {
                Marshal.StructureToPtr(inst, ptr, true);
                Marshal.Copy(ptr, bytes, 0, size);
            } finally {
                Marshal.FreeHGlobal(ptr);
            }

            return bytes;
        }
    }
}