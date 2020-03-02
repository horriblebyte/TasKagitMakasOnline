using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading.Tasks;
using ClientTKM.Classes;
using ClientTKM.Enums;

namespace ClientTKM.Utils {
    public class AllUtils {

        public static AttackType MyAttack;
        public static AttackType OpponentAttack;

        public static string MyID = string.Empty;

        public static int MyScore = 0;
        public static int OpponentScore = 0;

        /// <summary>
        /// Hamle koduna göre hamlenin adını döndürür.
        /// </summary>
        /// <param name="attackCode">Hamlenin kodu.</param>
        public static string GetAttackNameFromCode(ushort attackCode) {
            switch (attackCode) {
                case 1:
                    return "Taş";
                case 2:
                    return "Kağıt";
                case 3:
                    return "Makas";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Hamle koduna göre hamlenin görselini döndürür.
        /// </summary>
        /// <param name="attackType">Hamlenin kodu.</param>
        /// <returns></returns>
        public static Image GetAttackImageFromCode(int attackType) {
            switch (attackType) {
                case 1:
                    return Properties.Resources.Rock;
                case 2:
                    return Properties.Resources.Paper;
                case 3:
                    return Properties.Resources.Scissors;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Hamlelerin birbirine açıklamasını döndürür.
        /// </summary>
        public static string GetAttackCommentaryFromCode(string attackType) {
            switch (Convert.ToInt32(attackType)) {
                case 0:
                    return "Berabere!\nRuh ikizinizi bulmuş olabilir misiniz?";
                case 1:
                    return "Taş, Makas'ı kırar.";
                case 2:
                    return "Kağıt, Taş'ı kaplar.";
                case 3:
                    return "Makas, Kağıt'ı keser.";
                default:
                    return null;
            }
        }
    }
}