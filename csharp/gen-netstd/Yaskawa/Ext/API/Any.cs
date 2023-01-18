/**
 * <auto-generated>
 * Autogenerated by Thrift Compiler (0.17.0)
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 * </auto-generated>
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE0017  // object init can be simplified
#pragma warning disable IDE0028  // collection init can be simplified
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable CA1822   // empty DeepCopy() methods still non-static
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace Yaskawa.Ext.API
{

  /// <summary>
  /// Useful union for holding one of several data types
  /// </summary>
  public partial class Any : TBase
  {
    private bool _bValue;
    private long _iValue;
    private double _rValue;
    private string _sValue;
    private List<double> _vValue;
    private global::Yaskawa.Ext.API.Position _pValue;
    private List<global::Yaskawa.Ext.API.Any> _aValue;
    private Dictionary<string, global::Yaskawa.Ext.API.Any> _mValue;

    public bool BValue
    {
      get
      {
        return _bValue;
      }
      set
      {
        __isset.bValue = true;
        this._bValue = value;
      }
    }

    public long IValue
    {
      get
      {
        return _iValue;
      }
      set
      {
        __isset.iValue = true;
        this._iValue = value;
      }
    }

    public double RValue
    {
      get
      {
        return _rValue;
      }
      set
      {
        __isset.rValue = true;
        this._rValue = value;
      }
    }

    public string SValue
    {
      get
      {
        return _sValue;
      }
      set
      {
        __isset.sValue = true;
        this._sValue = value;
      }
    }

    public List<double> VValue
    {
      get
      {
        return _vValue;
      }
      set
      {
        __isset.vValue = true;
        this._vValue = value;
      }
    }

    public global::Yaskawa.Ext.API.Position PValue
    {
      get
      {
        return _pValue;
      }
      set
      {
        __isset.pValue = true;
        this._pValue = value;
      }
    }

    public List<global::Yaskawa.Ext.API.Any> AValue
    {
      get
      {
        return _aValue;
      }
      set
      {
        __isset.aValue = true;
        this._aValue = value;
      }
    }

    public Dictionary<string, global::Yaskawa.Ext.API.Any> MValue
    {
      get
      {
        return _mValue;
      }
      set
      {
        __isset.mValue = true;
        this._mValue = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool bValue;
      public bool iValue;
      public bool rValue;
      public bool sValue;
      public bool vValue;
      public bool pValue;
      public bool aValue;
      public bool mValue;
    }

    public Any()
    {
    }

    public Any DeepCopy()
    {
      var tmp84 = new Any();
      if(__isset.bValue)
      {
        tmp84.BValue = this.BValue;
      }
      tmp84.__isset.bValue = this.__isset.bValue;
      if(__isset.iValue)
      {
        tmp84.IValue = this.IValue;
      }
      tmp84.__isset.iValue = this.__isset.iValue;
      if(__isset.rValue)
      {
        tmp84.RValue = this.RValue;
      }
      tmp84.__isset.rValue = this.__isset.rValue;
      if((SValue != null) && __isset.sValue)
      {
        tmp84.SValue = this.SValue;
      }
      tmp84.__isset.sValue = this.__isset.sValue;
      if((VValue != null) && __isset.vValue)
      {
        tmp84.VValue = this.VValue.DeepCopy();
      }
      tmp84.__isset.vValue = this.__isset.vValue;
      if((PValue != null) && __isset.pValue)
      {
        tmp84.PValue = (global::Yaskawa.Ext.API.Position)this.PValue.DeepCopy();
      }
      tmp84.__isset.pValue = this.__isset.pValue;
      if((AValue != null) && __isset.aValue)
      {
        tmp84.AValue = this.AValue.DeepCopy();
      }
      tmp84.__isset.aValue = this.__isset.aValue;
      if((MValue != null) && __isset.mValue)
      {
        tmp84.MValue = this.MValue.DeepCopy();
      }
      tmp84.__isset.mValue = this.__isset.mValue;
      return tmp84;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.Bool)
              {
                BValue = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I64)
              {
                IValue = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.Double)
              {
                RValue = await iprot.ReadDoubleAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.String)
              {
                SValue = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 5:
              if (field.Type == TType.List)
              {
                {
                  var _list85 = await iprot.ReadListBeginAsync(cancellationToken);
                  VValue = new List<double>(_list85.Count);
                  for(int _i86 = 0; _i86 < _list85.Count; ++_i86)
                  {
                    double _elem87;
                    _elem87 = await iprot.ReadDoubleAsync(cancellationToken);
                    VValue.Add(_elem87);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.Struct)
              {
                PValue = new global::Yaskawa.Ext.API.Position();
                await PValue.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 7:
              if (field.Type == TType.List)
              {
                {
                  var _list88 = await iprot.ReadListBeginAsync(cancellationToken);
                  AValue = new List<global::Yaskawa.Ext.API.Any>(_list88.Count);
                  for(int _i89 = 0; _i89 < _list88.Count; ++_i89)
                  {
                    global::Yaskawa.Ext.API.Any _elem90;
                    _elem90 = new global::Yaskawa.Ext.API.Any();
                    await _elem90.ReadAsync(iprot, cancellationToken);
                    AValue.Add(_elem90);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 8:
              if (field.Type == TType.Map)
              {
                {
                  var _map91 = await iprot.ReadMapBeginAsync(cancellationToken);
                  MValue = new Dictionary<string, global::Yaskawa.Ext.API.Any>(_map91.Count);
                  for(int _i92 = 0; _i92 < _map91.Count; ++_i92)
                  {
                    string _key93;
                    global::Yaskawa.Ext.API.Any _val94;
                    _key93 = await iprot.ReadStringAsync(cancellationToken);
                    _val94 = new global::Yaskawa.Ext.API.Any();
                    await _val94.ReadAsync(iprot, cancellationToken);
                    MValue[_key93] = _val94;
                  }
                  await iprot.ReadMapEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default: 
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var tmp95 = new TStruct("Any");
        await oprot.WriteStructBeginAsync(tmp95, cancellationToken);
        var tmp96 = new TField();
        if(__isset.bValue)
        {
          tmp96.Name = "bValue";
          tmp96.Type = TType.Bool;
          tmp96.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp96, cancellationToken);
          await oprot.WriteBoolAsync(BValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.iValue)
        {
          tmp96.Name = "iValue";
          tmp96.Type = TType.I64;
          tmp96.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp96, cancellationToken);
          await oprot.WriteI64Async(IValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.rValue)
        {
          tmp96.Name = "rValue";
          tmp96.Type = TType.Double;
          tmp96.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp96, cancellationToken);
          await oprot.WriteDoubleAsync(RValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((SValue != null) && __isset.sValue)
        {
          tmp96.Name = "sValue";
          tmp96.Type = TType.String;
          tmp96.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp96, cancellationToken);
          await oprot.WriteStringAsync(SValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((VValue != null) && __isset.vValue)
        {
          tmp96.Name = "vValue";
          tmp96.Type = TType.List;
          tmp96.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp96, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Double, VValue.Count), cancellationToken);
          foreach (double _iter97 in VValue)
          {
            await oprot.WriteDoubleAsync(_iter97, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((PValue != null) && __isset.pValue)
        {
          tmp96.Name = "pValue";
          tmp96.Type = TType.Struct;
          tmp96.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp96, cancellationToken);
          await PValue.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((AValue != null) && __isset.aValue)
        {
          tmp96.Name = "aValue";
          tmp96.Type = TType.List;
          tmp96.ID = 7;
          await oprot.WriteFieldBeginAsync(tmp96, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, AValue.Count), cancellationToken);
          foreach (global::Yaskawa.Ext.API.Any _iter98 in AValue)
          {
            await _iter98.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((MValue != null) && __isset.mValue)
        {
          tmp96.Name = "mValue";
          tmp96.Type = TType.Map;
          tmp96.ID = 8;
          await oprot.WriteFieldBeginAsync(tmp96, cancellationToken);
          await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.Struct, MValue.Count), cancellationToken);
          foreach (string _iter99 in MValue.Keys)
          {
            await oprot.WriteStringAsync(_iter99, cancellationToken);
            await MValue[_iter99].WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteMapEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object that)
    {
      if (!(that is Any other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.bValue == other.__isset.bValue) && ((!__isset.bValue) || (global::System.Object.Equals(BValue, other.BValue))))
        && ((__isset.iValue == other.__isset.iValue) && ((!__isset.iValue) || (global::System.Object.Equals(IValue, other.IValue))))
        && ((__isset.rValue == other.__isset.rValue) && ((!__isset.rValue) || (global::System.Object.Equals(RValue, other.RValue))))
        && ((__isset.sValue == other.__isset.sValue) && ((!__isset.sValue) || (global::System.Object.Equals(SValue, other.SValue))))
        && ((__isset.vValue == other.__isset.vValue) && ((!__isset.vValue) || (global::System.Object.Equals(VValue, other.VValue))))
        && ((__isset.pValue == other.__isset.pValue) && ((!__isset.pValue) || (global::System.Object.Equals(PValue, other.PValue))))
        && ((__isset.aValue == other.__isset.aValue) && ((!__isset.aValue) || (TCollections.Equals(AValue, other.AValue))))
        && ((__isset.mValue == other.__isset.mValue) && ((!__isset.mValue) || (TCollections.Equals(MValue, other.MValue))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.bValue)
        {
          hashcode = (hashcode * 397) + BValue.GetHashCode();
        }
        if(__isset.iValue)
        {
          hashcode = (hashcode * 397) + IValue.GetHashCode();
        }
        if(__isset.rValue)
        {
          hashcode = (hashcode * 397) + RValue.GetHashCode();
        }
        if((SValue != null) && __isset.sValue)
        {
          hashcode = (hashcode * 397) + SValue.GetHashCode();
        }
        if((VValue != null) && __isset.vValue)
        {
          hashcode = (hashcode * 397) + VValue.GetHashCode();
        }
        if((PValue != null) && __isset.pValue)
        {
          hashcode = (hashcode * 397) + PValue.GetHashCode();
        }
        if((AValue != null) && __isset.aValue)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(AValue);
        }
        if((MValue != null) && __isset.mValue)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(MValue);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp100 = new StringBuilder("Any(");
      int tmp101 = 0;
      if(__isset.bValue)
      {
        if(0 < tmp101++) { tmp100.Append(", "); }
        tmp100.Append("BValue: ");
        BValue.ToString(tmp100);
      }
      if(__isset.iValue)
      {
        if(0 < tmp101++) { tmp100.Append(", "); }
        tmp100.Append("IValue: ");
        IValue.ToString(tmp100);
      }
      if(__isset.rValue)
      {
        if(0 < tmp101++) { tmp100.Append(", "); }
        tmp100.Append("RValue: ");
        RValue.ToString(tmp100);
      }
      if((SValue != null) && __isset.sValue)
      {
        if(0 < tmp101++) { tmp100.Append(", "); }
        tmp100.Append("SValue: ");
        SValue.ToString(tmp100);
      }
      if((VValue != null) && __isset.vValue)
      {
        if(0 < tmp101++) { tmp100.Append(", "); }
        tmp100.Append("VValue: ");
        VValue.ToString(tmp100);
      }
      if((PValue != null) && __isset.pValue)
      {
        if(0 < tmp101++) { tmp100.Append(", "); }
        tmp100.Append("PValue: ");
        PValue.ToString(tmp100);
      }
      if((AValue != null) && __isset.aValue)
      {
        if(0 < tmp101++) { tmp100.Append(", "); }
        tmp100.Append("AValue: ");
        AValue.ToString(tmp100);
      }
      if((MValue != null) && __isset.mValue)
      {
        if(0 < tmp101++) { tmp100.Append(", "); }
        tmp100.Append("MValue: ");
        MValue.ToString(tmp100);
      }
      tmp100.Append(')');
      return tmp100.ToString();
    }
  }

}
