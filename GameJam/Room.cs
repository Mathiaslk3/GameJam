namespace GameJam
{
    internal class Room
    {
        public string Name;
        public string Description;
        private List<Crew> _crewInRoom;

        public List<Crew> CrewInRoom
        {
            get
            { return _crewInRoom; }
            set
            {
                _crewInRoom = value;
                foreach (var c in value)
                { c.CurrentRoom = this; }
            }
        }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            CrewInRoom = new();
        }
    }
}
