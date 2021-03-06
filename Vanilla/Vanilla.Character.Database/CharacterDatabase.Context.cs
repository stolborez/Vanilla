﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class CharacterDatabase : DbContext
    {
        public CharacterDatabase()
            : base("name=CharacterDatabase")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<auction> auctions { get; set; }
        public virtual DbSet<bugreport> bugreports { get; set; }
        public virtual DbSet<character_action> character_action { get; set; }
        public virtual DbSet<character_aura> character_aura { get; set; }
        public virtual DbSet<character_battleground_data> character_battleground_data { get; set; }
        public virtual DbSet<character_gifts> character_gifts { get; set; }
        public virtual DbSet<character_homebind> character_homebind { get; set; }
        public virtual DbSet<character_instance> character_instance { get; set; }
        public virtual DbSet<character_inventory> character_inventory { get; set; }
        public virtual DbSet<character_pet> character_pet { get; set; }
        public virtual DbSet<character_queststatus> character_queststatus { get; set; }
        public virtual DbSet<character_reputation> character_reputation { get; set; }
        public virtual DbSet<character_skills> character_skills { get; set; }
        public virtual DbSet<character_social> character_social { get; set; }
        public virtual DbSet<character_spell> character_spell { get; set; }
        public virtual DbSet<character_spell_cooldown> character_spell_cooldown { get; set; }
        public virtual DbSet<character_stats> character_stats { get; set; }
        public virtual DbSet<character_ticket> character_ticket { get; set; }
        public virtual DbSet<character_tutorial> character_tutorial { get; set; }
        public virtual DbSet<character> characters { get; set; }
        public virtual DbSet<corpse> corpses { get; set; }
        public virtual DbSet<creature_respawn> creature_respawn { get; set; }
        public virtual DbSet<game_event_status> game_event_status { get; set; }
        public virtual DbSet<gameobject_respawn> gameobject_respawn { get; set; }
        public virtual DbSet<group_instance> group_instance { get; set; }
        public virtual DbSet<group_member> group_member { get; set; }
        public virtual DbSet<group> groups { get; set; }
        public virtual DbSet<guild> guilds { get; set; }
        public virtual DbSet<guild_eventlog> guild_eventlog { get; set; }
        public virtual DbSet<guild_rank> guild_rank { get; set; }
        public virtual DbSet<instance> instances { get; set; }
        public virtual DbSet<instance_reset> instance_reset { get; set; }
        public virtual DbSet<item_instance> item_instance { get; set; }
        public virtual DbSet<item_loot> item_loot { get; set; }
        public virtual DbSet<item_text> item_text { get; set; }
        public virtual DbSet<mail> mails { get; set; }
        public virtual DbSet<mail_items> mail_items { get; set; }
        public virtual DbSet<pet_aura> pet_aura { get; set; }
        public virtual DbSet<pet_spell> pet_spell { get; set; }
        public virtual DbSet<pet_spell_cooldown> pet_spell_cooldown { get; set; }
        public virtual DbSet<petition> petitions { get; set; }
        public virtual DbSet<petition_sign> petition_sign { get; set; }
        public virtual DbSet<world> worlds { get; set; }
        public virtual DbSet<character_honor_cp> character_honor_cp { get; set; }
        public virtual DbSet<guild_member> guild_member { get; set; }
        public virtual DbSet<saved_variables> saved_variables { get; set; }
    }
}
