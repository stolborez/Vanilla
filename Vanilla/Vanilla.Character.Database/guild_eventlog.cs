//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vanilla.Character.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class guild_eventlog
    {
        public long guildid { get; set; }
        public long LogGuid { get; set; }
        public bool EventType { get; set; }
        public long PlayerGuid1 { get; set; }
        public long PlayerGuid2 { get; set; }
        public byte NewRank { get; set; }
        public decimal TimeStamp { get; set; }
    }
}