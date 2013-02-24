﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Network;
using Milkshake.Communication.Outgoing.World;

namespace Milkshake.Tools.Update
{

    



    public class UpdateReader
    {
        public static void Boot()
        {
            List<string> logs = Directory.GetFiles(Environment.CurrentDirectory + "/Logs").ToList();
            
            logs.ForEach(log => 
            {
                Console.WriteLine("Reading: " + log.Split('/')[log.Split('/').Length - 1]);
                ProccessLog(Helper.StringToByteArray(File.ReadAllText(log)));
            });
          
        }

        public static void ProccessLog(byte[] data)
        {
            PacketReader reader = new PacketReader(data);

            Console.WriteLine("  Block Count: " + reader.ReadUInt32());
            Console.WriteLine("  HasTransport: " + reader.ReadByte());
            Console.WriteLine("  UpdateType: " + reader.ReadByte());
            Console.WriteLine("  GUID: " + reader.ReadUInt16());
            Console.WriteLine("  ObjectType: " + reader.ReadByte());

            ObjectUpdateFlags updateFlags = (ObjectUpdateFlags)reader.ReadByte();

            Console.WriteLine("  Update Flags");
            updateFlags.GetIndividualFlags().ToList().ForEach(a => Console.WriteLine("   - " + a.ToString()));
        }
    }

   

}
