using System;
using System.Text;
using System.Threading.Tasks;

namespace ClientTKM.Enums {
    public enum Opcode {
        PLAYER_ID = 998,
        EXIT_APP = 999,
        ROOM_CODE = 1000,
        JOIN_ROOM = 1001,
        ROOM_IS_SAME = 1002,
        ROOM_IS_FULL = 1003,
        ROOM_NOT_FOUND = 1004,
        GAME_STARTED = 1005,
        OPPONENT_IS_LEFT = 1006,
        ATTACK_REQUEST = 1007,
        ATTACK_ACCEPTED = 1008,
        GAME_END = 1009
    }
}