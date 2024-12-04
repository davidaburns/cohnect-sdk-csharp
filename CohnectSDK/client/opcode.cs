namespace CohnectSDK.Client {
    public enum CohnectOpcode : short {
        Get = 0x01,
        Set = 0x02,
        SetClientTags = 0x03,
        Execute = 0x04,
        Subscribe = 0x05,
        Broadcast = 0x06
    }
}