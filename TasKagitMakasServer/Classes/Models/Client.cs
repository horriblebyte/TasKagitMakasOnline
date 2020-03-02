using System;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ServerTKM.Classes.Models {
    public class Client {
        // İstemci soketi.
        public Socket ClientSocket = null;
        // Alıcı byte tamponunun boyutu.
        public const int ReceiveByteBufferSize = 1024;
        // Alıcı byte tamponu.
        public byte[] ReceiveByteBuffer = new byte[ReceiveByteBufferSize];
    }
}