﻿namespace GameJam
{
    internal class Player
    {
        public int TimeCharge;
        public Dictionary<string, object> Inventory;
        public Room CurrentRoom;

        public Player(Room startRoom)
        {
            TimeCharge = 3;
            Inventory = new();
            CurrentRoom = startRoom;
        }
    }
}
