﻿namespace Vanilla.World.Communication.Outgoing.World.Movement
{
    #region

    using System;

    using Vanilla.Core.Opcodes;
    using Vanilla.World.Communication.Outgoing.World.Update;
    using Vanilla.World.Game.Entitys;

    #endregion

    public class PSMoveKnockBack : ServerPacket
    {
        #region Constructors and Destructors

        public PSMoveKnockBack(PlayerEntity player, float vcos, float vsin, float horizontalSpeed, float verticalSpeed)
            : base(WorldOpcodes.SMSG_MOVE_KNOCK_BACK)
        {
            byte[] packedGUID = PSUpdateObject.GenerateGuidBytes(player.ObjectGUID.RawGUID);
            PSUpdateObject.WriteBytes(this, packedGUID);
            Write((UInt32)0); // Sequence
            Write(vcos);
            Write(vsin);
            Write(horizontalSpeed);
            Write(verticalSpeed);
        }

        #endregion
    }
}