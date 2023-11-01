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

  public partial class Data : TBase
  {
    private global::Yaskawa.Ext.API.Series _sData;
    private global::Yaskawa.Ext.API.Category _cData;

    public global::Yaskawa.Ext.API.Series SData
    {
      get
      {
        return _sData;
      }
      set
      {
        __isset.sData = true;
        this._sData = value;
      }
    }

    public global::Yaskawa.Ext.API.Category CData
    {
      get
      {
        return _cData;
      }
      set
      {
        __isset.cData = true;
        this._cData = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool sData;
      public bool cData;
    }

    public Data()
    {
    }

    public Data DeepCopy()
    {
      var tmp138 = new Data();
      if((SData != null) && __isset.sData)
      {
        tmp138.SData = (global::Yaskawa.Ext.API.Series)this.SData.DeepCopy();
      }
      tmp138.__isset.sData = this.__isset.sData;
      if((CData != null) && __isset.cData)
      {
        tmp138.CData = (global::Yaskawa.Ext.API.Category)this.CData.DeepCopy();
      }
      tmp138.__isset.cData = this.__isset.cData;
      return tmp138;
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
              if (field.Type == TType.Struct)
              {
                SData = new global::Yaskawa.Ext.API.Series();
                await SData.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Struct)
              {
                CData = new global::Yaskawa.Ext.API.Category();
                await CData.ReadAsync(iprot, cancellationToken);
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
        var tmp139 = new TStruct("Data");
        await oprot.WriteStructBeginAsync(tmp139, cancellationToken);
        var tmp140 = new TField();
        if((SData != null) && __isset.sData)
        {
          tmp140.Name = "sData";
          tmp140.Type = TType.Struct;
          tmp140.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp140, cancellationToken);
          await SData.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((CData != null) && __isset.cData)
        {
          tmp140.Name = "cData";
          tmp140.Type = TType.Struct;
          tmp140.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp140, cancellationToken);
          await CData.WriteAsync(oprot, cancellationToken);
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
      if (!(that is Data other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.sData == other.__isset.sData) && ((!__isset.sData) || (global::System.Object.Equals(SData, other.SData))))
        && ((__isset.cData == other.__isset.cData) && ((!__isset.cData) || (global::System.Object.Equals(CData, other.CData))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((SData != null) && __isset.sData)
        {
          hashcode = (hashcode * 397) + SData.GetHashCode();
        }
        if((CData != null) && __isset.cData)
        {
          hashcode = (hashcode * 397) + CData.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp141 = new StringBuilder("Data(");
      int tmp142 = 0;
      if((SData != null) && __isset.sData)
      {
        if(0 < tmp142++) { tmp141.Append(", "); }
        tmp141.Append("SData: ");
        SData.ToString(tmp141);
      }
      if((CData != null) && __isset.cData)
      {
        if(0 < tmp142++) { tmp141.Append(", "); }
        tmp141.Append("CData: ");
        CData.ToString(tmp141);
      }
      tmp141.Append(')');
      return tmp141.ToString();
    }
  }

}
