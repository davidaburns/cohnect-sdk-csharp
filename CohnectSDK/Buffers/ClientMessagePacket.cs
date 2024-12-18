// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace CohnectSDK.Buffers
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct ClientMessagePacket : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_24_3_25(); }
  public static ClientMessagePacket GetRootAsClientMessagePacket(ByteBuffer _bb) { return GetRootAsClientMessagePacket(_bb, new ClientMessagePacket()); }
  public static ClientMessagePacket GetRootAsClientMessagePacket(ByteBuffer _bb, ClientMessagePacket obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public ClientMessagePacket __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public byte CorrelationId(int j) { int o = __p.__offset(4); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int CorrelationIdLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetCorrelationIdBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetCorrelationIdBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetCorrelationIdArray() { return __p.__vector_as_array<byte>(4); }
  public CohnectSDK.Buffers.ClientMessageType Type { get { int o = __p.__offset(6); return o != 0 ? (CohnectSDK.Buffers.ClientMessageType)__p.bb.GetUshort(o + __p.bb_pos) : CohnectSDK.Buffers.ClientMessageType.PING_SUCCESS; } }
  public ushort Length { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetUshort(o + __p.bb_pos) : (ushort)0; } }
  public byte Body(int j) { int o = __p.__offset(10); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int BodyLength { get { int o = __p.__offset(10); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetBodyBytes() { return __p.__vector_as_span<byte>(10, 1); }
#else
  public ArraySegment<byte>? GetBodyBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetBodyArray() { return __p.__vector_as_array<byte>(10); }

  public static Offset<CohnectSDK.Buffers.ClientMessagePacket> CreateClientMessagePacket(FlatBufferBuilder builder,
      VectorOffset correlation_idOffset = default(VectorOffset),
      CohnectSDK.Buffers.ClientMessageType type = CohnectSDK.Buffers.ClientMessageType.PING_SUCCESS,
      ushort length = 0,
      VectorOffset bodyOffset = default(VectorOffset)) {
    builder.StartTable(4);
    ClientMessagePacket.AddBody(builder, bodyOffset);
    ClientMessagePacket.AddCorrelationId(builder, correlation_idOffset);
    ClientMessagePacket.AddLength(builder, length);
    ClientMessagePacket.AddType(builder, type);
    return ClientMessagePacket.EndClientMessagePacket(builder);
  }

  public static void StartClientMessagePacket(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddCorrelationId(FlatBufferBuilder builder, VectorOffset correlationIdOffset) { builder.AddOffset(0, correlationIdOffset.Value, 0); }
  public static VectorOffset CreateCorrelationIdVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateCorrelationIdVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateCorrelationIdVectorBlock(FlatBufferBuilder builder, ArraySegment<byte> data) { builder.StartVector(1, data.Count, 1); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateCorrelationIdVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<byte>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartCorrelationIdVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddType(FlatBufferBuilder builder, CohnectSDK.Buffers.ClientMessageType type) { builder.AddUshort(1, (ushort)type, 0); }
  public static void AddLength(FlatBufferBuilder builder, ushort length) { builder.AddUshort(2, length, 0); }
  public static void AddBody(FlatBufferBuilder builder, VectorOffset bodyOffset) { builder.AddOffset(3, bodyOffset.Value, 0); }
  public static VectorOffset CreateBodyVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateBodyVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateBodyVectorBlock(FlatBufferBuilder builder, ArraySegment<byte> data) { builder.StartVector(1, data.Count, 1); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateBodyVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<byte>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartBodyVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static Offset<CohnectSDK.Buffers.ClientMessagePacket> EndClientMessagePacket(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<CohnectSDK.Buffers.ClientMessagePacket>(o);
  }
  public ClientMessagePacketT UnPack() {
    var _o = new ClientMessagePacketT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(ClientMessagePacketT _o) {
    _o.CorrelationId = new List<byte>();
    for (var _j = 0; _j < this.CorrelationIdLength; ++_j) {_o.CorrelationId.Add(this.CorrelationId(_j));}
    _o.Type = this.Type;
    _o.Length = this.Length;
    _o.Body = new List<byte>();
    for (var _j = 0; _j < this.BodyLength; ++_j) {_o.Body.Add(this.Body(_j));}
  }
  public static Offset<CohnectSDK.Buffers.ClientMessagePacket> Pack(FlatBufferBuilder builder, ClientMessagePacketT _o) {
    if (_o == null) return default(Offset<CohnectSDK.Buffers.ClientMessagePacket>);
    var _correlation_id = default(VectorOffset);
    if (_o.CorrelationId != null) {
      var __correlation_id = _o.CorrelationId.ToArray();
      _correlation_id = CreateCorrelationIdVector(builder, __correlation_id);
    }
    var _body = default(VectorOffset);
    if (_o.Body != null) {
      var __body = _o.Body.ToArray();
      _body = CreateBodyVector(builder, __body);
    }
    return CreateClientMessagePacket(
      builder,
      _correlation_id,
      _o.Type,
      _o.Length,
      _body);
  }
}

public class ClientMessagePacketT
{
  public List<byte> CorrelationId { get; set; }
  public CohnectSDK.Buffers.ClientMessageType Type { get; set; }
  public ushort Length { get; set; }
  public List<byte> Body { get; set; }

  public ClientMessagePacketT() {
    this.CorrelationId = null;
    this.Type = CohnectSDK.Buffers.ClientMessageType.PING_SUCCESS;
    this.Length = 0;
    this.Body = null;
  }
}


static public class ClientMessagePacketVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, uint tablePos)
  {
    return verifier.VerifyTableStart(tablePos)
      && verifier.VerifyVectorOfData(tablePos, 4 /*CorrelationId*/, 1 /*byte*/, false)
      && verifier.VerifyField(tablePos, 6 /*Type*/, 2 /*CohnectSDK.Buffers.ClientMessageType*/, 2, false)
      && verifier.VerifyField(tablePos, 8 /*Length*/, 2 /*ushort*/, 2, false)
      && verifier.VerifyVectorOfData(tablePos, 10 /*Body*/, 1 /*byte*/, false)
      && verifier.VerifyTableEnd(tablePos);
  }
}

}
