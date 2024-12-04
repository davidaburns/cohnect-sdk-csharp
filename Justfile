generate-buffers:
    @rm -rf ./CohnectSDK/Buffers
    @flatc --csharp --gen-object-api -o ./ ./CohnectSDK/Schemas/buffers.fbs