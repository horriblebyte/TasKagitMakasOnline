using System;
using ServerTKM.Enums;

namespace ServerTKM.Classes.Models {
    public class Player {
        public string PlayerID { get; set; }
        public Client Connection { get; set; }
        public Room CurrentRoom { get; set; }
        public DateTime PlayerLoginDate { get; set; }
        public bool IsValidated { get; set; }
        public AttackType SelectedAttack { get; set; }
        public int Score { get; set; }
    }
}