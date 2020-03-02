using System;
using System.Text;
using System.Net.Sockets;

namespace ClientTKM.Classes {
    public class Sender {
        /// <summary>
        /// Belirtilen veriyi, sunucuya gönderir.
        /// </summary>
        /// <param name="sendData">Gönderilecek olan veridir.</param>
        /// <param name="socketObject">Verinin gönderileceği sokettir.</param>
        public static void Send(string sendData, Socket socketObject) {
            byte[] sendByteBuffer = Encoding.Default.GetBytes(sendData);
            if (socketObject.Connected)
                socketObject.BeginSend(sendByteBuffer, 0, sendByteBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), socketObject);
        }

        private static void SendCallback(IAsyncResult ar) {
            try {
                Socket socketObject = (Socket)ar.AsyncState;
                socketObject.EndSend(ar);
            } catch (Exception appException) {
                throw appException;
            }
        }
    }
}