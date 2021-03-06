/*
 * Copyright (c) Citrix Systems, Inc.
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 
 *   1) Redistributions of source code must retain the above copyright
 *      notice, this list of conditions and the following disclaimer.
 * 
 *   2) Redistributions in binary form must reproduce the above
 *      copyright notice, this list of conditions and the following
 *      disclaimer in the documentation and/or other materials
 *      provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
 * FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
 * COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 * STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 * OF THE POSSIBILITY OF SUCH DAMAGE.
 */


using System;
using System.Collections;
using System.Collections.Generic;

using CookComputing.XmlRpc;


namespace XenAPI
{
    public partial class VM_metrics : XenObject<VM_metrics>
    {
        public VM_metrics()
        {
        }

        public VM_metrics(string uuid,
            long memory_actual,
            long VCPUs_number,
            Dictionary<long, double> VCPUs_utilisation,
            Dictionary<long, long> VCPUs_CPU,
            Dictionary<string, string> VCPUs_params,
            Dictionary<long, string[]> VCPUs_flags,
            string[] state,
            DateTime start_time,
            DateTime install_time,
            DateTime last_updated,
            Dictionary<string, string> other_config)
        {
            this.uuid = uuid;
            this.memory_actual = memory_actual;
            this.VCPUs_number = VCPUs_number;
            this.VCPUs_utilisation = VCPUs_utilisation;
            this.VCPUs_CPU = VCPUs_CPU;
            this.VCPUs_params = VCPUs_params;
            this.VCPUs_flags = VCPUs_flags;
            this.state = state;
            this.start_time = start_time;
            this.install_time = install_time;
            this.last_updated = last_updated;
            this.other_config = other_config;
        }

        /// <summary>
        /// Creates a new VM_metrics from a Proxy_VM_metrics.
        /// </summary>
        /// <param name="proxy"></param>
        public VM_metrics(Proxy_VM_metrics proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public override void UpdateFrom(VM_metrics update)
        {
            uuid = update.uuid;
            memory_actual = update.memory_actual;
            VCPUs_number = update.VCPUs_number;
            VCPUs_utilisation = update.VCPUs_utilisation;
            VCPUs_CPU = update.VCPUs_CPU;
            VCPUs_params = update.VCPUs_params;
            VCPUs_flags = update.VCPUs_flags;
            state = update.state;
            start_time = update.start_time;
            install_time = update.install_time;
            last_updated = update.last_updated;
            other_config = update.other_config;
        }

        internal void UpdateFromProxy(Proxy_VM_metrics proxy)
        {
            uuid = proxy.uuid == null ? null : (string)proxy.uuid;
            memory_actual = proxy.memory_actual == null ? 0 : long.Parse((string)proxy.memory_actual);
            VCPUs_number = proxy.VCPUs_number == null ? 0 : long.Parse((string)proxy.VCPUs_number);
            VCPUs_utilisation = proxy.VCPUs_utilisation == null ? null : Maps.convert_from_proxy_long_double(proxy.VCPUs_utilisation);
            VCPUs_CPU = proxy.VCPUs_CPU == null ? null : Maps.convert_from_proxy_long_long(proxy.VCPUs_CPU);
            VCPUs_params = proxy.VCPUs_params == null ? null : Maps.convert_from_proxy_string_string(proxy.VCPUs_params);
            VCPUs_flags = proxy.VCPUs_flags == null ? null : Maps.convert_from_proxy_long_string_array(proxy.VCPUs_flags);
            state = proxy.state == null ? new string[] {} : (string [])proxy.state;
            start_time = proxy.start_time;
            install_time = proxy.install_time;
            last_updated = proxy.last_updated;
            other_config = proxy.other_config == null ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
        }

        public Proxy_VM_metrics ToProxy()
        {
            Proxy_VM_metrics result_ = new Proxy_VM_metrics();
            result_.uuid = (uuid != null) ? uuid : "";
            result_.memory_actual = memory_actual.ToString();
            result_.VCPUs_number = VCPUs_number.ToString();
            result_.VCPUs_utilisation = Maps.convert_to_proxy_long_double(VCPUs_utilisation);
            result_.VCPUs_CPU = Maps.convert_to_proxy_long_long(VCPUs_CPU);
            result_.VCPUs_params = Maps.convert_to_proxy_string_string(VCPUs_params);
            result_.VCPUs_flags = Maps.convert_to_proxy_long_string_array(VCPUs_flags);
            result_.state = state;
            result_.start_time = start_time;
            result_.install_time = install_time;
            result_.last_updated = last_updated;
            result_.other_config = Maps.convert_to_proxy_string_string(other_config);
            return result_;
        }

        /// <summary>
        /// Creates a new VM_metrics from a Hashtable.
        /// </summary>
        /// <param name="table"></param>
        public VM_metrics(Hashtable table)
        {
            uuid = Marshalling.ParseString(table, "uuid");
            memory_actual = Marshalling.ParseLong(table, "memory_actual");
            VCPUs_number = Marshalling.ParseLong(table, "VCPUs_number");
            VCPUs_utilisation = Maps.convert_from_proxy_long_double(Marshalling.ParseHashTable(table, "VCPUs_utilisation"));
            VCPUs_CPU = Maps.convert_from_proxy_long_long(Marshalling.ParseHashTable(table, "VCPUs_CPU"));
            VCPUs_params = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "VCPUs_params"));
            VCPUs_flags = Maps.convert_from_proxy_long_string_array(Marshalling.ParseHashTable(table, "VCPUs_flags"));
            state = Marshalling.ParseStringArray(table, "state");
            start_time = Marshalling.ParseDateTime(table, "start_time");
            install_time = Marshalling.ParseDateTime(table, "install_time");
            last_updated = Marshalling.ParseDateTime(table, "last_updated");
            other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
        }

        public bool DeepEquals(VM_metrics other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Helper.AreEqual2(this._uuid, other._uuid) &&
                Helper.AreEqual2(this._memory_actual, other._memory_actual) &&
                Helper.AreEqual2(this._VCPUs_number, other._VCPUs_number) &&
                Helper.AreEqual2(this._VCPUs_utilisation, other._VCPUs_utilisation) &&
                Helper.AreEqual2(this._VCPUs_CPU, other._VCPUs_CPU) &&
                Helper.AreEqual2(this._VCPUs_params, other._VCPUs_params) &&
                Helper.AreEqual2(this._VCPUs_flags, other._VCPUs_flags) &&
                Helper.AreEqual2(this._state, other._state) &&
                Helper.AreEqual2(this._start_time, other._start_time) &&
                Helper.AreEqual2(this._install_time, other._install_time) &&
                Helper.AreEqual2(this._last_updated, other._last_updated) &&
                Helper.AreEqual2(this._other_config, other._other_config);
        }

        public override string SaveChanges(Session session, string opaqueRef, VM_metrics server)
        {
            if (opaqueRef == null)
            {
                System.Diagnostics.Debug.Assert(false, "Cannot create instances of this type on the server");
                return "";
            }
            else
            {
                if (!Helper.AreEqual2(_other_config, server._other_config))
                {
                    VM_metrics.set_other_config(session, opaqueRef, _other_config);
                }

                return null;
            }
        }

        public static VM_metrics get_record(Session session, string _vm_metrics)
        {
            return new VM_metrics((Proxy_VM_metrics)session.proxy.vm_metrics_get_record(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse());
        }

        public static XenRef<VM_metrics> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<VM_metrics>.Create(session.proxy.vm_metrics_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        public static string get_uuid(Session session, string _vm_metrics)
        {
            return (string)session.proxy.vm_metrics_get_uuid(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse();
        }

        public static long get_memory_actual(Session session, string _vm_metrics)
        {
            return long.Parse((string)session.proxy.vm_metrics_get_memory_actual(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse());
        }

        public static long get_VCPUs_number(Session session, string _vm_metrics)
        {
            return long.Parse((string)session.proxy.vm_metrics_get_vcpus_number(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse());
        }

        public static Dictionary<long, double> get_VCPUs_utilisation(Session session, string _vm_metrics)
        {
            return Maps.convert_from_proxy_long_double(session.proxy.vm_metrics_get_vcpus_utilisation(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse());
        }

        public static Dictionary<long, long> get_VCPUs_CPU(Session session, string _vm_metrics)
        {
            return Maps.convert_from_proxy_long_long(session.proxy.vm_metrics_get_vcpus_cpu(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse());
        }

        public static Dictionary<string, string> get_VCPUs_params(Session session, string _vm_metrics)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_metrics_get_vcpus_params(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse());
        }

        public static Dictionary<long, string[]> get_VCPUs_flags(Session session, string _vm_metrics)
        {
            return Maps.convert_from_proxy_long_string_array(session.proxy.vm_metrics_get_vcpus_flags(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse());
        }

        public static string[] get_state(Session session, string _vm_metrics)
        {
            return (string [])session.proxy.vm_metrics_get_state(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse();
        }

        public static DateTime get_start_time(Session session, string _vm_metrics)
        {
            return session.proxy.vm_metrics_get_start_time(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse();
        }

        public static DateTime get_install_time(Session session, string _vm_metrics)
        {
            return session.proxy.vm_metrics_get_install_time(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse();
        }

        public static DateTime get_last_updated(Session session, string _vm_metrics)
        {
            return session.proxy.vm_metrics_get_last_updated(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse();
        }

        public static Dictionary<string, string> get_other_config(Session session, string _vm_metrics)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_metrics_get_other_config(session.uuid, (_vm_metrics != null) ? _vm_metrics : "").parse());
        }

        public static void set_other_config(Session session, string _vm_metrics, Dictionary<string, string> _other_config)
        {
            session.proxy.vm_metrics_set_other_config(session.uuid, (_vm_metrics != null) ? _vm_metrics : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        public static void add_to_other_config(Session session, string _vm_metrics, string _key, string _value)
        {
            session.proxy.vm_metrics_add_to_other_config(session.uuid, (_vm_metrics != null) ? _vm_metrics : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        public static void remove_from_other_config(Session session, string _vm_metrics, string _key)
        {
            session.proxy.vm_metrics_remove_from_other_config(session.uuid, (_vm_metrics != null) ? _vm_metrics : "", (_key != null) ? _key : "").parse();
        }

        public static List<XenRef<VM_metrics>> get_all(Session session)
        {
            return XenRef<VM_metrics>.Create(session.proxy.vm_metrics_get_all(session.uuid).parse());
        }

        public static Dictionary<XenRef<VM_metrics>, VM_metrics> get_all_records(Session session)
        {
            return XenRef<VM_metrics>.Create<Proxy_VM_metrics>(session.proxy.vm_metrics_get_all_records(session.uuid).parse());
        }

        private string _uuid;
        public virtual string uuid {
             get { return _uuid; }
             set { if (!Helper.AreEqual(value, _uuid)) { _uuid = value; Changed = true; NotifyPropertyChanged("uuid"); } }
         }

        private long _memory_actual;
        public virtual long memory_actual {
             get { return _memory_actual; }
             set { if (!Helper.AreEqual(value, _memory_actual)) { _memory_actual = value; Changed = true; NotifyPropertyChanged("memory_actual"); } }
         }

        private long _VCPUs_number;
        public virtual long VCPUs_number {
             get { return _VCPUs_number; }
             set { if (!Helper.AreEqual(value, _VCPUs_number)) { _VCPUs_number = value; Changed = true; NotifyPropertyChanged("VCPUs_number"); } }
         }

        private Dictionary<long, double> _VCPUs_utilisation;
        public virtual Dictionary<long, double> VCPUs_utilisation {
             get { return _VCPUs_utilisation; }
             set { if (!Helper.AreEqual(value, _VCPUs_utilisation)) { _VCPUs_utilisation = value; Changed = true; NotifyPropertyChanged("VCPUs_utilisation"); } }
         }

        private Dictionary<long, long> _VCPUs_CPU;
        public virtual Dictionary<long, long> VCPUs_CPU {
             get { return _VCPUs_CPU; }
             set { if (!Helper.AreEqual(value, _VCPUs_CPU)) { _VCPUs_CPU = value; Changed = true; NotifyPropertyChanged("VCPUs_CPU"); } }
         }

        private Dictionary<string, string> _VCPUs_params;
        public virtual Dictionary<string, string> VCPUs_params {
             get { return _VCPUs_params; }
             set { if (!Helper.AreEqual(value, _VCPUs_params)) { _VCPUs_params = value; Changed = true; NotifyPropertyChanged("VCPUs_params"); } }
         }

        private Dictionary<long, string[]> _VCPUs_flags;
        public virtual Dictionary<long, string[]> VCPUs_flags {
             get { return _VCPUs_flags; }
             set { if (!Helper.AreEqual(value, _VCPUs_flags)) { _VCPUs_flags = value; Changed = true; NotifyPropertyChanged("VCPUs_flags"); } }
         }

        private string[] _state;
        public virtual string[] state {
             get { return _state; }
             set { if (!Helper.AreEqual(value, _state)) { _state = value; Changed = true; NotifyPropertyChanged("state"); } }
         }

        private DateTime _start_time;
        public virtual DateTime start_time {
             get { return _start_time; }
             set { if (!Helper.AreEqual(value, _start_time)) { _start_time = value; Changed = true; NotifyPropertyChanged("start_time"); } }
         }

        private DateTime _install_time;
        public virtual DateTime install_time {
             get { return _install_time; }
             set { if (!Helper.AreEqual(value, _install_time)) { _install_time = value; Changed = true; NotifyPropertyChanged("install_time"); } }
         }

        private DateTime _last_updated;
        public virtual DateTime last_updated {
             get { return _last_updated; }
             set { if (!Helper.AreEqual(value, _last_updated)) { _last_updated = value; Changed = true; NotifyPropertyChanged("last_updated"); } }
         }

        private Dictionary<string, string> _other_config;
        public virtual Dictionary<string, string> other_config {
             get { return _other_config; }
             set { if (!Helper.AreEqual(value, _other_config)) { _other_config = value; Changed = true; NotifyPropertyChanged("other_config"); } }
         }


    }
}
