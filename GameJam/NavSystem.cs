using System.Diagnostics.Tracing;

namespace GameJam
{
    internal class NavSystem
    {
        public Room[] Rooms;
        private Player _player;

        public NavSystem(Room[] rooms)
        { Rooms = rooms; }

        public NavSystem(List<Room> rooms)
        { Rooms = rooms.ToArray(); }

        public void Start(Player player)
        {
            _player = player;
            Console.Clear();

            Graphics.ConColor resetCol = Program.g.GetConsoleColors();
            int promptY = Program.g.BufferHeight - 3;
            while (true)
            {
                string roomText = string.Empty;

                Program.g.SetConsoleColors(new Graphics.ConColor(ConsoleColor.White), false);
                Console.Write("\n> ");

                string prompt = Console.ReadLine().Trim().ToLower();
                string[] words = prompt.Split(' ');

                Console.Write("\n");
                Program.g.SetConsoleColors(resetCol, false);

                Room cRoom = player.CurrentRoom;
                roomText += $"{cRoom.Description}\n\n";

                for (int i = 0; i < cRoom.AdjecentRooms.Length; i++)
                {
                    if (cRoom.AdjecentRooms[i] != null)
                    { roomText += $"Til {Room.RoomDirections[i]} kan du se {cRoom.AdjecentRooms[i].Name.ToLower()}\n"; }
                }

                string[] crewNames = Array.Empty<string>();
                if (cRoom.CrewInRoom.Count != 0)
                {
                    roomText += "\nI rummet står ";
                    crewNames = cRoom.CrewInRoom.Select(c => c.Name.ToLower()).ToArray();
                }

                int cursorY = Console.GetCursorPosition().Top;
                if (cursorY >= promptY)
                {
                    int diff = cursorY - promptY;
                    Console.Write(new string('\n', diff));
                    Console.SetCursorPosition(0, promptY);
                }

                if (words.Contains("clear"))
                { Console.Clear(); }
                
                else if (Room.RoomDirections.Contains(prompt))
                {
                    int dirIndex = Array.IndexOf(Room.RoomDirections, prompt);
                    if (player.CurrentRoom.AdjecentRooms[dirIndex] != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.AdjecentRooms[dirIndex];
                        cRoom = player.CurrentRoom;
                    }
                }
                else if (crewNames != Array.Empty<string>() && words.Any(new string[] { "snak", "talk" }.Contains))
                {
                    var foundNames = words.Where(w => crewNames.Contains(w));
                    try
                    {
                        string name = foundNames.First();
                        int nameIndex = Array.IndexOf(player.CurrentRoom.CrewInRoom.Select(n => n.Name.ToLower()).ToArray(), name);
                        player.CurrentRoom.CrewInRoom[nameIndex].HaveDialog();
                    } catch (Exception)
                    { continue; }
                }

                if (words.Any(new string[] { "look", "se", "kig" }.Contains) || Room.RoomDirections.Contains(prompt))
                {
                    roomText = string.Empty;
                    roomText += $"{cRoom.Description}\n\n";

                    for (int i = 0; i < cRoom.AdjecentRooms.Length; i++)
                    {
                        if (cRoom.AdjecentRooms[i] != null)
                        { roomText += $"Til {Room.RoomDirections[i]} kan du se {cRoom.AdjecentRooms[i].Name.ToLower()}\n"; }
                    }

                    crewNames = Array.Empty<string>();
                    if (cRoom.CrewInRoom.Count != 0)
                    {
                        roomText += "\nI rummet står ";
                        crewNames = cRoom.CrewInRoom.Select(c => c.Name.ToLower()).ToArray();
                    }

                    Console.Write(roomText);
                    if (cRoom.CrewInRoom.Count != 0)
                    {
                        for (int j = 0; j < cRoom.CrewInRoom.Count; j++)
                        {
                            Crew crew = cRoom.CrewInRoom[j];

                            if (j < cRoom.CrewInRoom.Count - 2)
                            { Program.g.WriteColor(crew.Name, false, crew.NameColor); Console.Write(", "); }
                            else if (j == cRoom.CrewInRoom.Count - 2)
                            { Program.g.WriteColor(crew.Name, false, crew.NameColor); Console.Write(" og "); }
                            else
                            { Program.g.WriteColor(crew.Name, false, crew.NameColor); Console.WriteLine("."); }
                        }
                    }
                }
            }
        }
    }
}
