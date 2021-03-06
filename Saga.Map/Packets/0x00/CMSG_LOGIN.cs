using Saga.Network.Packets;
using System;

namespace Saga.Shared.PacketLib.Login
{
    internal class CMSG_LOGIN : RelayPacket
    {
        public CMSG_LOGIN()
        {
            this.Cmd = 0x0701;
            this.Id = 0x0001;
            this.data = new byte[6];
        }

        public byte GmLevel
        {
            get
            {
                return this.data[0];
            }
        }

        public byte Gender
        {
            get
            {
                return this.data[1];
            }
        }

        public uint CharacterId
        {
            get
            {
                return BitConverter.ToUInt32(this.data, 2);
            }
        }

        #region Conversions

        public static explicit operator CMSG_LOGIN(byte[] p)
        {
            /*
            // Creates a new byte with the length of data
            // plus 4. The first size bytes are used like
            // [PacketSize][PacketId][PacketBody]
            //
            // Where Packet Size equals the length of the
            // Packet body, Packet Identifier, Packet Size
            // Container.
            */

            CMSG_LOGIN pkt = new CMSG_LOGIN();
            pkt.data = new byte[p.Length - 14];
            pkt.session = BitConverter.ToUInt32(p, 2);
            Array.Copy(p, 6, pkt.cmd, 0, 2);
            Array.Copy(p, 12, pkt.id, 0, 2);
            Array.Copy(p, 14, pkt.data, 0, p.Length - 14);
            return pkt;
        }

        #endregion Conversions
    }
}