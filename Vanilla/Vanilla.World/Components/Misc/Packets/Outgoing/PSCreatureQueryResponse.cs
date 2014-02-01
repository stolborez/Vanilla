﻿namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using System;

    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Game.Entity.Object.Creature;
    using Vanilla.World.Game.Entity.Object.Unit;

    public class PSCreatureQueryResponse : WorldPacket
    {
        public PSCreatureQueryResponse(uint entry, CreatureEntity entity)
            : base(WorldOpcodes.SMSG_CREATURE_QUERY_RESPONSE)
        {
            this.Write(entry);
            this.WriteCString(entity.Name);
            this.WriteNullByte(3); // Name2,3,4

            if (entity.Template.Subname == "\\N")
            {
                this.WriteNullByte(1);
            }
            else
            {
                this.WriteCString(entity.Template.Subname);
            }

            this.Write((UInt32)entity.Template.TypeFlags);
            this.Write((UInt32)entity.Template.Type);
            this.Write((UInt32)entity.Template.Family);
            this.Write((UInt32)entity.Template.Rank);
            this.WriteNullUInt(1);

            this.Write((UInt32)entity.Template.PetSpellDataId);
            this.Write((UInt32)entity.Creature.ModelID);
            this.Write((UInt16)entity.Template.Civilian);
        }
    }
}