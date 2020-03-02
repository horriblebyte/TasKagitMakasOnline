using System;
using ServerTKM.Classes.Models;
using System.Collections.Generic;

namespace ServerTKM.Classes.Managers {
    public class RoomManager {

        /// <summary>
        /// Tüm odaların depolandığı listedir.
        /// </summary>
        public static List<Room> RoomList = new List<Room>();

        /// <summary>
        /// Oluşturulacak olan odalar için benzersiz bir oda kodu üretir ve döndürür.
        /// </summary>
        /// <returns>Room ID</returns>
        private static string GenerateRoomID() {
            //Rastgele numara oluşturabilmek için randomNumber referansımıza Random sınıfından yeni bir nesne türettik.
            Random randomNumber = new Random();
            //Oluşturduğumuz rastgele numarayı değişkenimize aktardık.
            int randomRoomID = randomNumber.Next(10000, 99999);
            //Oda listemizin içinde, aynı ID var mı yok mu kontrol edebilmek için dönmemiz gerek.
            //Haliyle, her ihtimale karşı önce listeyi kilitliyoruz sonra döngüye başlıyoruz.
            lock (RoomList) {
                //Listedeki oda sayısı kadar dönüyoruz.
                for (int i = 0; i < RoomList.Count; ++i) {
                    //currentRoom referansına, oda listesinde olup index'e karşılık gelen odayı tanımlıyoruz.
                    Room currentRoom = RoomList[i];
                    //Eğer bu odanın ID'si ürettiğimiz numarayla eşleşiyorsa,
                    if (currentRoom.RoomID == randomRoomID.ToString())
                        //Yeniden ID üretiyoruz.
                        GenerateRoomID();
                }
            }
            //Her şey tamamsa, ürettiğimiz ID'yi döndürüyoruz.
            return randomRoomID.ToString();
        }
        /// <summary>
        /// Bir oda oluşturur ve oluşturduğu odayı döndürür.
        /// </summary>
        /// <returns>Room</returns>
        public static Room CreateRoom() {
            //Odayı oluşturmadan önce oda listesini kilitliyoruz.
            lock (RoomList) {
                //newRoom referansımız için Room sınıfından yeni bir nesne türetiyoruz.
                Room newRoom = new Room() {
                    //Odanın ID'sini üreten metodu tetikliyoruz.
                    RoomID = GenerateRoomID(),
                    //Odadaki oyuncuların depolanması için boş bir liste oluşturuyoruz.
                    RoomPlayerList = new List<Player>(),
                    //Odanın oluşturulma tarihini tanımlıyoruz.
                    RoomCreateDate = DateTime.Now
                };
                //Oluşan odanın referansını oda listesine ekliyoruz.
                RoomList.Add(newRoom);
                //Son olarak oluşan odayı döndürüyoruz.
                return newRoom;
            }
        }

        /// <summary>
        /// Herhangi bir odayı ID'sine göre arar. Bulursa odayı döndürür. Bulamazsa null döndürür.
        /// </summary>
        /// <param name="roomID">Oda ID'si</param>
        /// <returns></returns>
        public static Room GetRoom(string roomID) {
            //Odayı oluşturmadan önce oda listesini kilitliyoruz.
            lock (RoomList) {
                //Listedeki oda sayısı kadar dönüyoruz.
                for (int i = 0; i < RoomList.Count; ++i) {
                    //currentRoom referansına, oda listesinde olup index'e karşılık gelen odayı tanımlıyoruz.
                    Room currentRoom = RoomList[i];
                    //Eğer bu odanın ID'si gönderilen numarayla eşleşiyorsa,
                    if (currentRoom.RoomID == roomID)
                        //Oda bulunmuş demektir. Bulunan odayı döndürüyoruz.
                        return currentRoom;
                }
                //Döngüden çıkarsa oda bulunamadı demektir. null döndürüyoruz.
                return null;
            }
        }

        /// <summary>
        /// İstenen odanın silinmesini sağlar.
        /// </summary>
        /// <param name="roomObject">Silinecek oda</param>
        public static void RemoveRoom(Room roomObject) {
            //Odayı silmeden önce oda listesini kilitliyoruz.
            lock (RoomList) {
                //Listedeki oda sayısı kadar dönüyoruz.
                for (int i = 0; i <= RoomList.Count; ++i) {
                    //currentRoom referansına, oda listesinde olup index'e karşılık gelen odayı tanımlıyoruz.
                    Room currentRoom = RoomList[i];
                    //Eğer bu oda, silinmesi istenen oda ile eşleşiyorsa,
                    if (currentRoom == roomObject) {
                        //Odayı listeden siliyoruz.
                        RoomList.Remove(currentRoom);
                        //Ekrana uyarı mesajı yazdırıyoruz.
                        Logger.LogWarning(string.Format("{0} ID'li oda sunucu tarafından silindi.", currentRoom.RoomID));
                        //Amacımıza ulaştığımıza göre döngüden çıkabiliriz.
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Toplam oda sayısını döndürür.
        /// </summary>
        /// <returns></returns>
        public static string GetRoomCount() {
            return RoomList.Count.ToString();
        }
    }
}