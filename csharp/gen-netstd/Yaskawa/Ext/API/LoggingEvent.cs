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

  public partial class LoggingEvent : TBase
  {
    private long _timestamp;
    private string _datetime;
    private global::Yaskawa.Ext.API.LoggingLevel _level;
    private string _entry;

    public long Timestamp
    {
      get
      {
        return _timestamp;
      }
      set
      {
        __isset.timestamp = true;
        this._timestamp = value;
      }
    }

    public string Datetime
    {
      get
      {
        return _datetime;
      }
      set
      {
        __isset.datetime = true;
        this._datetime = value;
      }
    }

    /// <summary>
    /// 
    /// <seealso cref="global::Yaskawa.Ext.API.LoggingLevel"/>
    /// </summary>
    public global::Yaskawa.Ext.API.LoggingLevel Level
    {
      get
      {
        return _level;
      }
      set
      {
        __isset.level = true;
        this._level = value;
      }
    }

    public string Entry
    {
      get
      {
        return _entry;
      }
      set
      {
        __isset.entry = true;
        this._entry = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool timestamp;
      public bool datetime;
      public bool level;
      public bool entry;
    }

    public LoggingEvent()
    {
    }

    public LoggingEvent DeepCopy()
    {
      var tmp102 = new LoggingEvent();
      if(__isset.timestamp)
      {
        tmp102.Timestamp = this.Timestamp;
      }
      tmp102.__isset.timestamp = this.__isset.timestamp;
      if((Datetime != null) && __isset.datetime)
      {
        tmp102.Datetime = this.Datetime;
      }
      tmp102.__isset.datetime = this.__isset.datetime;
      if(__isset.level)
      {
        tmp102.Level = this.Level;
      }
      tmp102.__isset.level = this.__isset.level;
      if((Entry != null) && __isset.entry)
      {
        tmp102.Entry = this.Entry;
      }
      tmp102.__isset.entry = this.__isset.entry;
      return tmp102;
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
              if (field.Type == TType.I64)
              {
                Timestamp = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                Datetime = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.I32)
              {
                Level = (global::Yaskawa.Ext.API.LoggingLevel)await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.String)
              {
                Entry = await iprot.ReadStringAsync(cancellationToken);
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
        var tmp103 = new TStruct("LoggingEvent");
        await oprot.WriteStructBeginAsync(tmp103, cancellationToken);
        var tmp104 = new TField();
        if(__isset.timestamp)
        {
          tmp104.Name = "timestamp";
          tmp104.Type = TType.I64;
          tmp104.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp104, cancellationToken);
          await oprot.WriteI64Async(Timestamp, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Datetime != null) && __isset.datetime)
        {
          tmp104.Name = "datetime";
          tmp104.Type = TType.String;
          tmp104.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp104, cancellationToken);
          await oprot.WriteStringAsync(Datetime, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.level)
        {
          tmp104.Name = "level";
          tmp104.Type = TType.I32;
          tmp104.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp104, cancellationToken);
          await oprot.WriteI32Async((int)Level, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Entry != null) && __isset.entry)
        {
          tmp104.Name = "entry";
          tmp104.Type = TType.String;
          tmp104.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp104, cancellationToken);
          await oprot.WriteStringAsync(Entry, cancellationToken);
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
      if (!(that is LoggingEvent other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.timestamp == other.__isset.timestamp) && ((!__isset.timestamp) || (global::System.Object.Equals(Timestamp, other.Timestamp))))
        && ((__isset.datetime == other.__isset.datetime) && ((!__isset.datetime) || (global::System.Object.Equals(Datetime, other.Datetime))))
        && ((__isset.level == other.__isset.level) && ((!__isset.level) || (global::System.Object.Equals(Level, other.Level))))
        && ((__isset.entry == other.__isset.entry) && ((!__isset.entry) || (global::System.Object.Equals(Entry, other.Entry))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.timestamp)
        {
          hashcode = (hashcode * 397) + Timestamp.GetHashCode();
        }
        if((Datetime != null) && __isset.datetime)
        {
          hashcode = (hashcode * 397) + Datetime.GetHashCode();
        }
        if(__isset.level)
        {
          hashcode = (hashcode * 397) + Level.GetHashCode();
        }
        if((Entry != null) && __isset.entry)
        {
          hashcode = (hashcode * 397) + Entry.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp105 = new StringBuilder("LoggingEvent(");
      int tmp106 = 0;
      if(__isset.timestamp)
      {
        if(0 < tmp106++) { tmp105.Append(", "); }
        tmp105.Append("Timestamp: ");
        Timestamp.ToString(tmp105);
      }
      if((Datetime != null) && __isset.datetime)
      {
        if(0 < tmp106++) { tmp105.Append(", "); }
        tmp105.Append("Datetime: ");
        Datetime.ToString(tmp105);
      }
      if(__isset.level)
      {
        if(0 < tmp106++) { tmp105.Append(", "); }
        tmp105.Append("Level: ");
        Level.ToString(tmp105);
      }
      if((Entry != null) && __isset.entry)
      {
        if(0 < tmp106++) { tmp105.Append(", "); }
        tmp105.Append("Entry: ");
        Entry.ToString(tmp105);
      }
      tmp105.Append(')');
      return tmp105.ToString();
    }
  }

}
