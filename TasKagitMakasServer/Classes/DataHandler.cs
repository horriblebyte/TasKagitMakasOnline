using ServerTKM.Enums;
using ServerTKM.Utils;
using ServerTKM.Classes.Models;
using ServerTKM.Classes.Managers;

namespace ServerTKM.Classes {
    public class DataHandler {
        public static void HandleReceivedData(Player playerObject, string receivedData) {
            //Gelen verileri bölüyoruz.
            string[] splittedData = receivedData.Split('\t');
            //Bölünmüş verinin ilk kısmı opcode'u temsil eder. ushort'a çevirmeye çalışıyoruz.
            ushort clientOpcode = ushort.TryParse(splittedData[0], out clientOpcode) ? clientOpcode : (ushort)0;
            //Opcode 0'a eşitse yanlışlık var demektir. İstemci uzaklaştırılıyor.
            if (clientOpcode == 0) {
                AllUtils.Disconnect(playerObject, true);
                return;
            }

            switch (clientOpcode) {
                case (ushort)Opcode.EXIT_APP:
                    Logger.LogWarning(string.Format("{0} ID'li oyuncu, çıkış yapmayı talep etti...", playerObject.PlayerID));
                    AllUtils.Disconnect(playerObject, false);
                    break;

                case (ushort)Opcode.ROOM_CODE:
                    playerObject.IsValidated = true;
                    //Oyuncuya, kendi player id'sini gönderiyoruz.
                    Sender.Send(string.Format("{0}\t{1}", (ushort)Opcode.PLAYER_ID, playerObject.PlayerID), playerObject);
                    Logger.LogWarning(string.Format("{0} ID'li oyuncu, oda oluşturma talebi gönderdi...", playerObject.PlayerID));
                    Room roomObject1 = RoomManager.CreateRoom();
                    Sender.Send(string.Format("{0}\t{1}", (int)Opcode.ROOM_CODE, roomObject1.RoomID), playerObject);
                    Logger.LogWarning(string.Format("{0} ID'li oyuncu için bir oda oluşturuldu. Oda ID: {1}", playerObject.PlayerID, roomObject1.RoomID));
                    break;

                case (ushort)Opcode.JOIN_ROOM:
                    Logger.LogWarning(string.Format("{0} ID'li oyuncu, {1} ID'li odaya girmeyi talep etti...", playerObject.PlayerID, splittedData[1]));
                    PlayerManager.JoinRoom(playerObject, splittedData[1]);
                    break;

                case (ushort)Opcode.ATTACK_REQUEST:
                    GameManager.SetPlayerAttack(playerObject, splittedData[1]);
                    break;

                default:
                    Logger.LogError(string.Format("Opcode bulunamadı: {0}, Oyuncu: {1}", clientOpcode, playerObject.PlayerID));
                    AllUtils.Disconnect(playerObject, true);
                    break;
            }
        }
    }
}