using System;
using System.Text;
using ServerTKM.Enums;
using ServerTKM.Utils;
using ServerTKM.Classes.Models;
using System.Collections.Generic;

namespace ServerTKM.Classes.Managers {
    public class GameManager {
        public static void TryStartGame(Player playerObject) {
            //Eğer odadaki kişi sayısı odanın limitiyle eşdeğerse, kapışma başlayabilir demektir.
            if (playerObject.CurrentRoom.RoomPlayerList.Count == playerObject.CurrentRoom.RoomLimit) {
                //Böylelikle, ilgili odadaki tüm oyunculara "OYUN BAŞLADI" bilgisini gönderiyoruz.
                Sender.SendToList(string.Format("{0}", (ushort)Opcode.GAME_STARTED), playerObject.CurrentRoom.RoomPlayerList);
                //Kapışmanın başladığına dair bir mesaj yazdırıyoruz.
                Logger.LogFightInfo(string.Format("{0} ID'li odada kapışma başladı!", playerObject.CurrentRoom.RoomID));
            }
        }
        public static void SetPlayerAttack(Player playerObject, string attackType) {
            //İstemciden bize gelen hamle kodunu parse etmeye çalışıyoruz. Parse edilemezse 0 döner.
            ushort attackCode = ushort.TryParse(attackType, out attackCode) ? attackCode : (ushort)0;
            //Hamle kodu 0 değilse, Player'ın hamlesini o kodla eşleşen hamle olarak tanımlıyoruz.
            if (attackCode != 0)
                playerObject.SelectedAttack = (AttackType)attackCode;
            //Yaptığı hamleyi istemcinin kendisine bildiriyoruz.
            Sender.Send(string.Format("{0}\t{1}", (ushort)Opcode.ATTACK_ACCEPTED, (ushort)playerObject.SelectedAttack), playerObject);
            //Sunucuya bilgi mesajı yazdırıyoruz.
            Logger.LogFightInfo(string.Format("{0} ID'li oyuncu, {1} ID'li odada {2} hamlesini kullandı.", playerObject.PlayerID, playerObject.CurrentRoom.RoomID, AllUtils.GetAttackNameFromCode((ushort)playerObject.SelectedAttack)));
            HandleGame(playerObject.CurrentRoom.RoomPlayerList);
        }

        private static void HandleGame(List<Player> playerList) {
            if (playerList.Count != 2)
                return;

            lock (playerList) {
                for (int i = 0; i < playerList.Count; ++i) {
                    Player currentPlayer = playerList[i];
                    if (currentPlayer.SelectedAttack == 0)
                        return;
                }
                //Program bu noktaya gelirse, hamle kullanmayan oyuncu kalmamış demektir.
                DetermineWinner(playerList[0], playerList[1]);
            }
        }

        /// <summary>
        /// Kazananı belirleyen metottur.
        /// </summary>
        private static void DetermineWinner(Player playerObject1, Player playerObject2) {
            string WinnerID = string.Empty, AttackCommentary = string.Empty;
            if (playerObject1.SelectedAttack == AttackType.ROCK) {
                if (playerObject2.SelectedAttack == AttackType.ROCK) {
                    //BERABERE!
                    WinnerID = string.Empty;
                    AttackCommentary = "0";
                } else if (playerObject2.SelectedAttack == AttackType.PAPER) {
                    //KAĞIT TAŞ'I KAPLAR. OYUNCU 2 KAZANDI!
                    playerObject2.Score++;
                    WinnerID = playerObject2.PlayerID;
                    AttackCommentary = "2";
                } else if (playerObject2.SelectedAttack == AttackType.SCISSORS) {
                    //TAŞ MAKASI KIRAR. OYUNCU 1 KAZANDI!
                    playerObject1.Score++;
                    WinnerID = playerObject1.PlayerID;
                    AttackCommentary = "1";
                }
            } else if (playerObject1.SelectedAttack == AttackType.PAPER) {
                if (playerObject2.SelectedAttack == AttackType.ROCK) {
                    //KAĞIT TAŞ'I KAPLAR. OYUNCU 1 KAZANDI!
                    playerObject1.Score++;
                    WinnerID = playerObject1.PlayerID;
                    AttackCommentary = "2";
                } else if (playerObject2.SelectedAttack == AttackType.PAPER) {
                    //BERABERE!
                    WinnerID = string.Empty;
                    AttackCommentary = "0";
                } else if (playerObject2.SelectedAttack == AttackType.SCISSORS) {
                    //MAKAS KAĞIT'I KESER. OYUNCU 2 KAZANDI!
                    playerObject2.Score++;
                    WinnerID = playerObject2.PlayerID;
                    AttackCommentary = "3";
                }
            } else if (playerObject1.SelectedAttack == AttackType.SCISSORS) {
                if (playerObject2.SelectedAttack == AttackType.ROCK) {
                    //TAŞ MAKAS'I KIRAR. OYUNCU 2 KAZANDI!
                    playerObject2.Score++;
                    WinnerID = playerObject2.PlayerID;
                    AttackCommentary = "1";
                } else if (playerObject2.SelectedAttack == AttackType.PAPER) {
                    //MAKAS KAĞIT'I KESER. OYUNCU 1 KAZANDI!
                    playerObject1.Score++;
                    WinnerID = playerObject1.PlayerID;
                    AttackCommentary = "3";
                } else if (playerObject2.SelectedAttack == AttackType.SCISSORS) {
                    //BERABERE!
                    WinnerID = string.Empty;
                    AttackCommentary = "0";
                }
            }
            SendGameResult(WinnerID, playerObject1, playerObject2, AttackCommentary);
        }

        private static void SendGameResult(string WinnerID, Player playerObject1, Player playerObject2, string AttackComment) {
            //İlk paket Player 1'e gider.
            Sender.Send(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", (ushort)Opcode.GAME_END, WinnerID, playerObject1.Score.ToString(), playerObject2.Score.ToString(), (ushort)playerObject2.SelectedAttack, AttackComment), playerObject1);
            //İkinci paket Player 2'ye gider.
            Sender.Send(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", (ushort)Opcode.GAME_END, WinnerID, playerObject2.Score.ToString(), playerObject1.Score.ToString(), (ushort)playerObject1.SelectedAttack, AttackComment), playerObject2);
            playerObject1.SelectedAttack = 0;
            playerObject2.SelectedAttack = 0;
        }
    }
}