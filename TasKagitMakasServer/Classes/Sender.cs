using System;
using System.Text;
using System.Net.Sockets;
using ServerTKM.Classes.Models;
using System.Collections.Generic;

namespace ServerTKM.Classes {
    public class Sender {

        /// <summary>
        /// Belirtilen veriyi, belirtilen oyuncuya gönderir.
        /// </summary>
        /// <param name="sendData">Gönderilecek olan veridir.</param>
        /// <param name="playerObject">Verinin gönderileceği nesnedir.</param>
        public static void Send(string sendData, Player playerObject) {
            byte[] sendByteBuffer = Encoding.Default.GetBytes(sendData);
            playerObject.Connection.ClientSocket.BeginSend(sendByteBuffer, 0, sendByteBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), playerObject);
            Logger.LogInfo(string.Format("[SEND] Gönderilen veri: [{0}], Uzunluk: [{1}], Player ID: [{2}]", sendData, sendByteBuffer.Length, playerObject.PlayerID));
        }

        /// <summary>
        /// Belirtilen veriyi, belirtilen oyunculara tek tek gönderir.
        /// </summary>
        /// <param name="sendData">Gönderilecek olan veridir.</param>
        /// <param name="playerList">Verinin gönderileceği oyuncuların listesidir.</param>
        public static void SendToList(string sendData, List<Player> playerList) {
            byte[] sendByteBuffer = Encoding.Default.GetBytes(sendData);
            lock (playerList) {
                for (int i = 0; i < playerList.Count; ++i) {
                    Player currentPlayer = playerList[i];
                    currentPlayer.Connection.ClientSocket.BeginSend(sendByteBuffer, 0, sendByteBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), currentPlayer);
                    Logger.LogInfo(string.Format("[SEND] Gönderilen veri: [{0}], Uzunluk: [{1}], Player ID: [{2}]", sendData, sendByteBuffer.Length, currentPlayer.PlayerID));
                }
            }
        }

        private static void SendCallback(IAsyncResult ar) {
            try {
                Player currentPlayer = (Player)ar.AsyncState;
                currentPlayer.Connection.ClientSocket.EndSend(ar);
            } catch (Exception appException) {
                Logger.LogError(string.Format("SendCallback() Hata: {0}", appException.Message));
            }
        }
    }
}