namespace GameJam
{
    internal class Room
    {
        public static string[] RoomDirections = { "nord", "syd", "øst", "vest" };

        public string Name;
        public string Description;
        public Room[] AdjecentRooms; // 0 1 2 3 = N S E W
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

        public Room(string name, string description, Room[] adjecentRooms)
        {
            Name = name;
            Description = description;
            CrewInRoom = new();
            AdjecentRooms = adjecentRooms;
        }
    }
}
