using System;
using System.Text;
using ServerTKM.Utils;
using System.Net.Sockets;
using System.Threading.Tasks;
using ServerTKM.Classes.Models;
using ServerTKM.Classes.Managers;

namespace ServerTKM.Classes {
    public class Receiver {
        public static void Receive(Player playerObject) {
            if (playerObject.Connection.ClientSocket.Connected)
                playerObject.Connection.ClientSocket.BeginReceive(playerObject.Connection.ReceiveByteBuffer, 0, playerObject.Connection.ReceiveByteBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), playerObject);
        }

        private static void ReceiveCallback(IAsyncResult ar) {
            Player currentPlayer = (Player)ar.AsyncState;
            int receivedBytesLength = 0;
            try {
                receivedBytesLength = currentPlayer.Connection.ClientSocket.EndReceive(ar);
            } catch (Exception) {
                Logger.LogError(string.Format("{0} ID'li oyuncunun istemcisi zorla kapatıldı!", currentPlayer.PlayerID));
                //Çıkan oyuncuyu, oyuncu listesinden siliyoruz.
                PlayerManager.RemovePlayer(currentPlayer);
                return;
            }
            if (receivedBytesLength <= 0) {
                AllUtils.Disconnect(currentPlayer, false);
            } else {
                string receivedText = Encoding.Default.GetString(currentPlayer.Connection.ReceiveByteBuffer, 0, receivedBytesLength);
                Logger.LogInfo(string.Format("[RECEIVE] Alınan veri: [{0}], Uzunluk: [{1}], Player ID: [{2}]", receivedText, receivedBytesLength, currentPlayer.PlayerID));
                //Gelen datayı işlenmesi için ilgili methoda yönlendiriyoruz.
                DataHandler.HandleReceivedData(currentPlayer, receivedText);
            }
            //Tekrar dinleyerek sonsuz bir döngü oluşturuyoruz.
            Receive(currentPlayer);
        }
    }
}