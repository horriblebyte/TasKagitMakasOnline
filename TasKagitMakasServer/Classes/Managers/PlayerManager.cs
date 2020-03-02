using System;
using ServerTKM.Enums;
using ServerTKM.Utils;
using System.Threading.Tasks;
using ServerTKM.Classes.Models;
using System.Collections.Generic;

namespace ServerTKM.Classes.Managers {
    public class PlayerManager {

        /// <summary>
        /// Tüm oyuncuların depolandığı listedir.
        /// </summary>
        public static List<Player> PlayerList = new List<Player>();

        /// <summary>
        /// Oluşturulacak olan Player için benzersiz bir ID üretir.
        /// </summary>
        /// <returns>Player ID</returns>
        private static string GeneratePlayerID() {
            Random random = new Random();
            int randomPlayerID = random.Next(10000, 99999);
            lock (PlayerList) {
                for (int i = 0; i < PlayerList.Count; ++i) {
                    Player currentPlayer = PlayerList[i];
                    if (currentPlayer.PlayerID == randomPlayerID.ToString())
                        GeneratePlayerID();
                }
            }
            return randomPlayerID.ToString();
        }

        /// <summary>
        /// Yeni bir Player oluşturur ve döndürür.
        /// </summary>
        /// <param name="clientObject">Player nesnesinin temsil edeceği Client objesidir.</param>
        /// <returns></returns>
        public static Player CreatePlayer(Client clientObject) {
            lock (PlayerList) {
                Player newPlayer = new Player() {
                    PlayerID = GeneratePlayerID(),
                    Connection = clientObject,
                    CurrentRoom = new Room(),
                    PlayerLoginDate = DateTime.Now
                };
                ValidatePlayer(newPlayer);
                PlayerList.Add(newPlayer);
                return newPlayer;
            }
        }

        /// <summary>
        /// Sunucuyla bağlantı kuran istemcinin bize ait olup olmadığını teyit eder.
        /// </summary>
        /// <param name="playerObject">Teyidi yapılacak olan objedir.</param>
        public static async void ValidatePlayer(Player playerObject) {
            await Task.Delay(1000);
            if (playerObject.IsValidated == false)
                AllUtils.Disconnect(playerObject, true);
        }

        /// <summary>
        /// Belirtilen oyuncuyu oyuncu listesinden çıkartır.
        /// </summary>
        /// <param name="playerObject">Çıkarılması istenen oyuncudur.</param>
        public static void RemovePlayer(Player playerObject) {
            //Her ihtimale karşı önce listeyi kilitliyoruz sonra içinde dönüyoruz.
            lock (PlayerList) {
                //Listedeki oyuncu sayısı kadar listede dönüyoruz.
                for (int i = 0; i < PlayerList.Count; ++i) {
                    Player currentPlayer = PlayerList[i];
                    //Eğer oyuncu listede bulunuyorsa,
                    if (currentPlayer == playerObject) {
                        //Listeden siliyoruz.
                        PlayerList.Remove(currentPlayer);
                        //Eğer oyuncunun bir odası varsa,
                        if (currentPlayer.CurrentRoom.RoomID != null)
                            //Odadan çıkışını yapıyoruz.
                            ExitRoom(currentPlayer);
                    }
                }
            }
        }

        /// <summary>
        /// Listedeki oyuncuların skorlarını sıfırlar.
        /// </summary>
        public static void ResetScores(List<Player> playerList) {
            lock (playerList) {
                for (int i = 0; i < playerList.Count; ++i) {
                    Player currentPlayer = playerList[i];
                    currentPlayer.Score = 0;
                }
            }
        }

        /// <summary>
        /// Belirtilen odaya giriş yapmayı dener.
        /// </summary>
        /// <param name="playerObject">Odaya giriş yapacak olan babayiğit.</param>
        /// <param name="roomID">Giriş yapılmak istenen odanın ID'si.</param>
        public static void JoinRoom(Player playerObject, string roomID) {
            //Yeni bir referans oluşturuyoruz, getroom metodu ile nesnesini döndürüyoruz.
            Room roomObject = RoomManager.GetRoom(roomID);
            //Eğer girmek istenen oda null değilse (öyle bir oda varsa),
            if (roomObject != null) {
                //Eğer player'ın oda id'si girilmek istenen odanın id'si ile uyuşmuyorsa,
                if (playerObject.CurrentRoom.RoomID != roomObject.RoomID) {
                    //Eğer girilmek istenen odadaki oyuncu sayısı odanın limitinden küçükse,
                    if (roomObject.RoomPlayerList.Count < roomObject.RoomLimit) {
                        //Eğer player'ın önceki odası null değilse (bir odası varsa),
                        if (playerObject.CurrentRoom.RoomID != null) {
                            //Odadan çıkışını yapıyoruz.
                            ExitRoom(playerObject);
                            //Girdiği yeni odanın kodunu gönderiyoruz.
                            Sender.Send(string.Format("{0}\t{1}", (int)Opcode.ROOM_CODE, roomObject.RoomID), playerObject);
                        }
                        //Sonra yeni odaya girişini yapıyoruz.
                        //Bulunduğu odayı, girmek istediği oda olarak güncelliyoruz.
                        playerObject.CurrentRoom = roomObject;
                        //Bulunduğu odadaki oyuncu listesine kendisini ekliyoruz.
                        playerObject.CurrentRoom.RoomPlayerList.Add(playerObject);
                        //Odaya girdiğine dair bir bilgi mesajı yazdırıyoruz.
                        Logger.LogWarning(string.Format("{0} ID'li oyuncu, {1} ID'li odaya başarılı bir şekilde giriş yaptı...", playerObject.PlayerID, roomID));
                        //Oyunu başlatmayı deniyoruz.
                        GameManager.TryStartGame(playerObject);
                    } else {
                        //Program bu noktaya gelirse, oda dolu demektir.
                        Sender.Send(string.Format("{0}", (int)Opcode.ROOM_IS_FULL), playerObject);
                        Logger.LogWarning(string.Format("{0} ID'li oda dolu...", roomID));
                    }
                } else {
                    //Program bu noktaya gelirse, oyuncu zaten o odada demektir.
                    Sender.Send(string.Format("{0}", (int)Opcode.ROOM_IS_SAME), playerObject);
                    Logger.LogWarning(string.Format("{0} ID'li oyuncu, zaten {1} ID'li odada...", playerObject.PlayerID, roomID));
                }
            } else {
                //Program bu noktaya gelirse, oda bulunamadı demektir.
                Sender.Send(string.Format("{0}", (int)Opcode.ROOM_NOT_FOUND), playerObject);
                Logger.LogWarning(string.Format("{0} ID'li oda bulunamadı...", roomID));
            }
        }

        /// <summary>
        /// Belirtilen oyuncunun odadan çıkarılması sağlanır.
        /// </summary>
        /// <param name="playerObject">Oyuncu</param>
        public static void ExitRoom(Player playerObject) {
            //Bulunduğu odanın listesinden sildik.
            playerObject.CurrentRoom.RoomPlayerList.Remove(playerObject);
            //Çıkma işleminden sonra odada 1 kişi kalmışsa, kapışma terk edilmiş demektir.
            if (playerObject.CurrentRoom.RoomPlayerList.Count == 1) {
                //Bu yüzden odada kalan kişiyi bulup rakibin ayrıldığı bilgisini vermeliyiz.
                Sender.SendToList(string.Format("{0}", (int)Opcode.OPPONENT_IS_LEFT), playerObject.CurrentRoom.RoomPlayerList);
                //Odada kalanı bulup skorunu sıfırlamalıyız.
                ResetScores(playerObject.CurrentRoom.RoomPlayerList);
                Logger.LogFightInfo(string.Format("{0} ID'li odadaki kapışma sona erdi.", playerObject.CurrentRoom.RoomID));
            } else if (playerObject.CurrentRoom.RoomPlayerList.Count == 0)
                //Çıkma işleminden sonra odada 0 kişi kalmışsa, oda komple silinebilir.
                RoomManager.RemoveRoom(playerObject.CurrentRoom);
        }

        /// <summary>
        /// Toplam oyuncu sayısını döndürür.
        /// </summary>
        /// <returns></returns>
        public static string GetPlayerCount() {
            return PlayerList.Count.ToString();
        }
    }
}