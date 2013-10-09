﻿namespace Vanilla.World.Communication.Outgoing.World.Update
{
    #region

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Vanilla.Core.Extensions;
    using Vanilla.World.Game.Constants.Game.Update;
    using Vanilla.World.Game.Entitys;

    #endregion

    public abstract class UpdateBlock
    {
        #region Fields

        internal BinaryWriter Writer;

        #endregion

        #region Constructors and Destructors

        public UpdateBlock()
        {
            this.Writer = new BinaryWriter(new MemoryStream());
        }

        #endregion

        #region Public Properties

        public byte[] Data { get; internal set; }
        public string Info { get; internal set; }

        #endregion

        #region Public Methods and Operators

        public void Build()
        {
            this.BuildData();

            this.Data = (this.Writer.BaseStream as MemoryStream).ToArray();
            this.Info = this.BuildInfo();
        }

        public abstract void BuildData();

        public abstract string BuildInfo();

        #endregion
    }

    public class OutOfRangeBlock : UpdateBlock
    {
        #region Fields

        public List<ObjectEntity> Entitys;

        #endregion

        #region Constructors and Destructors

        public OutOfRangeBlock(List<ObjectEntity> entitys)
        {
            this.Entitys = entitys;

            this.Build(); // ):
        }

        #endregion

        #region Public Methods and Operators

        public override void BuildData()
        {
            this.Writer.Write((byte)ObjectUpdateType.UPDATETYPE_OUT_OF_RANGE_OBJECTS);
            this.Writer.Write((uint)this.Entitys.Count);

            foreach (ObjectEntity entity in this.Entitys)
            {
                this.Writer.WritePackedUInt64(entity.ObjectGUID.RawGUID);
            }
        }

        public override string BuildInfo()
        {
            return "[OutOfRange] "
                   + string.Join(", ", this.Entitys.ToArray().ToList().ConvertAll(e => e.Name).ToArray());
        }

        #endregion
    }

    public class CreateGOBlock : UpdateBlock
    {
        #region Constructors and Destructors

        public CreateGOBlock(GOEntity entity)
        {
            this.Entity = entity;

            this.Build();
        }

        #endregion

        #region Public Properties

        public GOEntity Entity { get; private set; }

        #endregion

        #region Public Methods and Operators

        public override void BuildData()
        {
            this.Writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);

            this.Writer.WritePackedUInt64(this.Entity.ObjectGUID.RawGUID);

            this.Writer.Write((byte)TypeID.TYPEID_GAMEOBJECT);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_TRANSPORT | ObjectUpdateFlag.UPDATEFLAG_ALL
                                           | ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION;

            this.Writer.Write((byte)updateFlags);

            // Position
            this.Writer.Write((float)this.Entity.GameObject.X);
            this.Writer.Write((float)this.Entity.GameObject.Y);
            this.Writer.Write((float)this.Entity.GameObject.Z);

            this.Writer.Write((float)0); // R

            this.Writer.Write((uint)0x1); // Unkown... time?
            this.Writer.Write((uint)0); // Unkown... time?

            this.Entity.WriteUpdateFields(this.Writer);
        }

        public override string BuildInfo()
        {
            return "[CreateGO] " + this.Entity.GameObjectTemplate.Name;
        }

        #endregion
    }

    public class CreateUnitBlock : UpdateBlock
    {
        #region Constructors and Destructors

        public CreateUnitBlock(UnitEntity entity)
        {
            this.Entity = entity;

            this.Build();
        }

        #endregion

        #region Public Properties

        public UnitEntity Entity { get; private set; }

        #endregion

        #region Public Methods and Operators

        public override void BuildData()
        {
            this.Writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);

            this.Writer.WritePackedUInt64(this.Entity.ObjectGUID.RawGUID);

            this.Writer.Write((byte)TypeID.TYPEID_UNIT);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_ALL | ObjectUpdateFlag.UPDATEFLAG_LIVING
                                           | ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION;

            this.Writer.Write((byte)updateFlags);
            this.Writer.Write((UInt32)0x00000000); // MovementFlags

            this.Writer.Write((UInt32)Environment.TickCount); // Time

            // Position
            this.Writer.Write(this.Entity.X);
            this.Writer.Write(this.Entity.Y);
            this.Writer.Write(this.Entity.Z);
            this.Writer.Write(this.Entity.R); // R

            // Movement speeds
            this.Writer.Write((float)0); // ????

            this.Writer.Write(2.5f); // MOVE_WALK
            this.Writer.Write((float)7); // MOVE_RUN
            this.Writer.Write(4.5f); // MOVE_RUN_BACK
            this.Writer.Write(4.72f); // MOVE_SWIM
            this.Writer.Write(2.5f); // MOVE_SWIM_BACK
            this.Writer.Write(3.14f); // MOVE_TURN_RATE

            this.Writer.Write(0x1); // Unkown...

            this.Entity.Scale = 1;
            this.Entity.WriteUpdateFields(this.Writer);
        }

        public override string BuildInfo()
        {
            return "[CreateUnit] " + this.Entity.Name;
        }

        #endregion
    }
}