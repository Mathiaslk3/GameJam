namespace GameJam
{
    internal class Crew
    {
        public string Name;
        public string Rank;
        public bool Dead;
        private Room _currentRoom;

        public Room CurrentRoom
        {
            get
            { return _currentRoom; }
            set
            {
                if (!value.CrewInRoom.Contains(this))
                { value.CrewInRoom.Add(this); }

                _currentRoom = value;
            }
        }

        public Crew(string name, string rank, Room startRoom)
        {
            Name = name;
            Rank = rank;
            CurrentRoom = startRoom;
        }
    }
}
