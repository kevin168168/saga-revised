using Saga.Network.Packets;
using System;

namespace Saga.Packets
{
    /// <summary>
    ///
    /// </summary>
    /// <remarks>
    /// This packet sent by the user to indicate he or she want to delete
    /// the obtain the item from the selected mail.
    /// </remarks>
    /// <id>
    /// 0C04
    /// </id>
    internal class CMSG_GETITEMATTACHMENT : RelayPacket
    {
        public CMSG_GETITEMATTACHMENT()
        {
            this.data = new byte[4];
        }

        public uint MailId
        {
            get { return BitConverter.ToUInt32(this.data, 0); }
        }

        public uint ItemId
        {
            get { return BitConverter.ToUInt32(this.data, 4); }
        }

        #region Conversions

        public static explicit operator CMSG_GETITEMATTACHMENT(byte[] p)
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

            CMSG_GETITEMATTACHMENT pkt = new CMSG_GETITEMATTACHMENT();
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