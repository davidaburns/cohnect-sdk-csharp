namespace CohnectSDK {
    public struct CohnectConstants {
        public static byte PacketAcceptedVersion = 1;
        public static short PacketBufferTotal = 1472;
        public static short PacketVersionSize = 1;
        public static short PacketUuidSize = 16;
        public static short PacketOpcodeSize = 2;
        public static short PacketBodyLengthSize = 2;
        public static short PacketHeaderSize = (short)(PacketVersionSize + PacketUuidSize + PacketOpcodeSize + PacketBodyLengthSize);
        public static short PacketBodySize = (short)(PacketBufferTotal - PacketHeaderSize);
    }
}