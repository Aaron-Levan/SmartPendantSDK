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
      var tmp88 = new Any();
      if(__isset.bValue)
      {
        tmp88.BValue = this.BValue;
      }
      tmp88.__isset.bValue = this.__isset.bValue;
      if(__isset.iValue)
      {
        tmp88.IValue = this.IValue;
      }
      tmp88.__isset.iValue = this.__isset.iValue;
      if(__isset.rValue)
      {
        tmp88.RValue = this.RValue;
      }
      tmp88.__isset.rValue = this.__isset.rValue;
      if((SValue != null) && __isset.sValue)
      {
        tmp88.SValue = this.SValue;
      }
      tmp88.__isset.sValue = this.__isset.sValue;
      if((VValue != null) && __isset.vValue)
      {
        tmp88.VValue = this.VValue.DeepCopy();
      }
      tmp88.__isset.vValue = this.__isset.vValue;
      if((PValue != null) && __isset.pValue)
      {
        tmp88.PValue = (global::Yaskawa.Ext.API.Position)this.PValue.DeepCopy();
      }
      tmp88.__isset.pValue = this.__isset.pValue;
      if((AValue != null) && __isset.aValue)
      {
        tmp88.AValue = this.AValue.DeepCopy();
      }
      tmp88.__isset.aValue = this.__isset.aValue;
      if((MValue != null) && __isset.mValue)
      {
        tmp88.MValue = this.MValue.DeepCopy();
      }
      tmp88.__isset.mValue = this.__isset.mValue;
      return tmp88;
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
                  var _list89 = await iprot.ReadListBeginAsync(cancellationToken);
                  VValue = new List<double>(_list89.Count);
                  for(int _i90 = 0; _i90 < _list89.Count; ++_i90)
                  {
                    double _elem91;
                    _elem91 = await iprot.ReadDoubleAsync(cancellationToken);
                    VValue.Add(_elem91);
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
                  var _list92 = await iprot.ReadListBeginAsync(cancellationToken);
                  AValue = new List<global::Yaskawa.Ext.API.Any>(_list92.Count);
                  for(int _i93 = 0; _i93 < _list92.Count; ++_i93)
                  {
                    global::Yaskawa.Ext.API.Any _elem94;
                    _elem94 = new global::Yaskawa.Ext.API.Any();
                    await _elem94.ReadAsync(iprot, cancellationToken);
                    AValue.Add(_elem94);
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
                  var _map95 = await iprot.ReadMapBeginAsync(cancellationToken);
                  MValue = new Dictionary<string, global::Yaskawa.Ext.API.Any>(_map95.Count);
                  for(int _i96 = 0; _i96 < _map95.Count; ++_i96)
                  {
                    string _key97;
                    global::Yaskawa.Ext.API.Any _val98;
                    _key97 = await iprot.ReadStringAsync(cancellationToken);
                    _val98 = new global::Yaskawa.Ext.API.Any();
                    await _val98.ReadAsync(iprot, cancellationToken);
                    MValue[_key97] = _val98;
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
        var tmp99 = new TStruct("Any");
        await oprot.WriteStructBeginAsync(tmp99, cancellationToken);
        var tmp100 = new TField();
        if(__isset.bValue)
        {
          tmp100.Name = "bValue";
          tmp100.Type = TType.Bool;
          tmp100.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp100, cancellationToken);
          await oprot.WriteBoolAsync(BValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.iValue)
        {
          tmp100.Name = "iValue";
          tmp100.Type = TType.I64;
          tmp100.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp100, cancellationToken);
          await oprot.WriteI64Async(IValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.rValue)
        {
          tmp100.Name = "rValue";
          tmp100.Type = TType.Double;
          tmp100.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp100, cancellationToken);
          await oprot.WriteDoubleAsync(RValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((SValue != null) && __isset.sValue)
        {
          tmp100.Name = "sValue";
          tmp100.Type = TType.String;
          tmp100.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp100, cancellationToken);
          await oprot.WriteStringAsync(SValue, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((VValue != null) && __isset.vValue)
        {
          tmp100.Name = "vValue";
          tmp100.Type = TType.List;
          tmp100.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp100, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Double, VValue.Count), cancellationToken);
          foreach (double _iter101 in VValue)
          {
            await oprot.WriteDoubleAsync(_iter101, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((PValue != null) && __isset.pValue)
        {
          tmp100.Name = "pValue";
          tmp100.Type = TType.Struct;
          tmp100.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp100, cancellationToken);
          await PValue.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((AValue != null) && __isset.aValue)
        {
          tmp100.Name = "aValue";
          tmp100.Type = TType.List;
          tmp100.ID = 7;
          await oprot.WriteFieldBeginAsync(tmp100, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, AValue.Count), cancellationToken);
          foreach (global::Yaskawa.Ext.API.Any _iter102 in AValue)
          {
            await _iter102.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((MValue != null) && __isset.mValue)
        {
          tmp100.Name = "mValue";
          tmp100.Type = TType.Map;
          tmp100.ID = 8;
          await oprot.WriteFieldBeginAsync(tmp100, cancellationToken);
          await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.Struct, MValue.Count), cancellationToken);
          foreach (string _iter103 in MValue.Keys)
          {
            await oprot.WriteStringAsync(_iter103, cancellationToken);
            await MValue[_iter103].WriteAsync(oprot, cancellationToken);
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
      var tmp104 = new StringBuilder("Any(");
      int tmp105 = 0;
      if(__isset.bValue)
      {
        if(0 < tmp105++) { tmp104.Append(", "); }
        tmp104.Append("BValue: ");
        BValue.ToString(tmp104);
      }
      if(__isset.iValue)
      {
        if(0 < tmp105++) { tmp104.Append(", "); }
        tmp104.Append("IValue: ");
        IValue.ToString(tmp104);
      }
      if(__isset.rValue)
      {
        if(0 < tmp105++) { tmp104.Append(", "); }
        tmp104.Append("RValue: ");
        RValue.ToString(tmp104);
      }
      if((SValue != null) && __isset.sValue)
      {
        if(0 < tmp105++) { tmp104.Append(", "); }
        tmp104.Append("SValue: ");
        SValue.ToString(tmp104);
      }
      if((VValue != null) && __isset.vValue)
      {
        if(0 < tmp105++) { tmp104.Append(", "); }
        tmp104.Append("VValue: ");
        VValue.ToString(tmp104);
      }
      if((PValue != null) && __isset.pValue)
      {
        if(0 < tmp105++) { tmp104.Append(", "); }
        tmp104.Append("PValue: ");
        PValue.ToString(tmp104);
      }
      if((AValue != null) && __isset.aValue)
      {
        if(0 < tmp105++) { tmp104.Append(", "); }
        tmp104.Append("AValue: ");
        AValue.ToString(tmp104);
      }
      if((MValue != null) && __isset.mValue)
      {
        if(0 < tmp105++) { tmp104.Append(", "); }
        tmp104.Append("MValue: ");
        MValue.ToString(tmp104);
      }
      tmp104.Append(')');
      return tmp104.ToString();
    }
  }

}
