namespace CohnectSDK {
    public class CohnectParamsBase {
        public required Guid ClientUuid;
    }

    public class CohnectGetParams : CohnectParamsBase {
        public required string Key;
    }

    public class CohnectSetParams : CohnectParamsBase {
        public required string Key;
        public required object Data;
    }

    public class CohnectSetClientTagsParams : CohnectParamsBase {
        public required string[] Tags;
    }

    public class CohnectExecuteParams : CohnectParamsBase {
        public required string Action;
        public required Dictionary<string, object> Params;
    }
}