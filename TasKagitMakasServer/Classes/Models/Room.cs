using System;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ServerTKM.Classes.Models {
    public class Room {
        public string RoomID { get; set; }
        public List<Player> RoomPlayerList { get; set; }
        public DateTime RoomCreateDate { get; set; }
        public int RoomLimit { get; } = 2;
    }
}