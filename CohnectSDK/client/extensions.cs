namespace CohnectSDK.Client {
    namespace Extensions {
        public static class CohnectGuidExtensions {
            public static string ToStringLittleEndian(this Guid guid) {
                var bigEndianBytes = guid.ToByteArray();

                if (bigEndianBytes.Length != 16) {
                    throw new ArgumentException("Big endian byte array must be 16 bytes long");
                }

                var littleEndianBytes = new byte[16];

                // Reorder to match C# Guid's internal structure (little-endian for the first 3 fields)
                // Data1 (4 bytes) - reverse
                littleEndianBytes[0] = bigEndianBytes[3];
                littleEndianBytes[1] = bigEndianBytes[2];
                littleEndianBytes[2] = bigEndianBytes[1];
                littleEndianBytes[3] = bigEndianBytes[0];

                // Data2 (2 bytes) - reverse
                littleEndianBytes[4] = bigEndianBytes[5];
                littleEndianBytes[5] = bigEndianBytes[4];

                // Data3 (2 bytes) - reverse
                littleEndianBytes[6] = bigEndianBytes[7];
                littleEndianBytes[7] = bigEndianBytes[6];

                // The remaining 8 bytes (Data4) remain in the same order
                Array.Copy(bigEndianBytes, 8, littleEndianBytes, 8, 8);

                var newGuid = new Guid(littleEndianBytes);
                return newGuid.ToString();
            }
        }
    }
}