namespace GameJam
{
    internal class Crew
    {
        public string Name;
        public string Rank;
        public bool IsDead;
        public Graphics.ConColor NameColor;
        public Dialog Dialog;

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

        public Crew(string name, string rank, ConsoleColor nameColor, Room startRoom)
        {
            Name = name;
            Rank = rank;
            NameColor = new Graphics.ConColor(nameColor);
            CurrentRoom = startRoom;
            Dialog = new()
            {
                ResponseDict = new()
                {
                    { string.Empty, "Godav du, hvad laver du?" },
                    { "Ikke en skid", "Skide godt" },
                    { "Din mor", "Det gør ondt at høre dig udtrykke dig på den måde. Jeg troede, vi havde et gensidigt forhold præget af respekt\n\tog tillid. Lad os huske på, at vores ord har magt, og at de kan skabe dybe sår. Lad os vælge at udtrykke os med\n\tomtanke og kærlighed" },
                    { "Får tæsk af JBro", "Det kan jo ske" },
                    { "Tjo", "!" },
                    { "Undskyld", "!" },
                    { ":)", "!" }
                },

                NPCDict = new()
                {
                    { "Godav du, hvad laver du?", new[] { "Ikke en skid", "Din mor", "Får tæsk af JBro" } },
                    { "Det gør ondt at høre dig udtrykke dig på den måde. Jeg troede, vi havde et gensidigt forhold præget af respekt\n\tog tillid. Lad os huske på, at vores ord har magt, og at de kan skabe dybe sår. Lad os vælge at udtrykke os med\n\tomtanke og kærlighed", new[] { "Tjo", "Undskyld", ":)" } },
                    { "Skide godt", new[] { "!" } },
                    { "Det kan jo ske", new[] { "Får tæsk af JBro", "Din mor" } }
                }
            };
        }

        public void HaveDialog()
        {
            Console.Clear();
            string lastResponse = string.Empty;

            while (true)
            {
                string dialog;
                string[] responses;

                dialog = Dialog.GetResponseDialog(lastResponse);
                if (dialog == "!") { break; }

                responses = Dialog.GetResponses(dialog);
                if (responses[0] == "!") { break; }

                dialog = $"\t{dialog}\n----------------------------------\n";

                if (lastResponse != string.Empty)
                {
                    Program.g.WriteColor("Dig", true, new Graphics.ConColor(ConsoleColor.Green));
                    Console.WriteLine($"\t{lastResponse}\n----------------------------------\n");
                }

                Program.g.WriteColor(this.Name, true, this.NameColor);
                Console.WriteLine(dialog);
                (_, int dialogY) = Console.GetCursorPosition();

                int responseY = Program.g.BufferHeight - (responses.Length + 2);
                if (dialogY >= responseY)
                {
                    int diff = dialogY - responseY;
                    Console.Write(new string('\n', diff));
                }

                int resIndex = Program.g.GetMarkedMenuInput(responses, true, true, 0, responseY);
                if (resIndex == responses.Length - 1) { break; }
                lastResponse = responses[resIndex];

                for (int y = Program.g.BufferHeight - 1; y >= responseY; y--)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write(new string(' ', Program.g.BufferWidth));
                }

                Console.SetCursorPosition(0, dialogY);
            }

            Console.Clear();
        }
    }
}
