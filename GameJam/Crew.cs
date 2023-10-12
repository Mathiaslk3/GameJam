namespace GameJam
{
    internal class Crew
    {
        public string Name;
        public string Rank;
        public bool IsDead;
        public ConsoleColor NameColor;
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

        public Crew(string name, string rank, Room startRoom)
        {
            Name = name;
            Rank = rank;
            CurrentRoom = startRoom;
            Dialog = new()
            {
                ResponseDict = new()
                {
                    { string.Empty, "Godav du, hvad laver du?" },
                    { "Ikke en skid", "Skide godt" },
                    { "Din mor", "D... DU DÆLME SMART!" },
                    { "Får tæsk af JBro", "Det kan jo ske" },
                    { "Tjo", "!" },
                    { "Undskyld", "!" },
                    { ":)", "!" }
                },

                NPCDict = new()
                {
                    { "Godav du, hvad laver du?", new[] { "Ikke en skid", "Din mor", "Får tæsk af JBro" } },
                    { "D... DU DÆLME SMART!", new[] { "Tjo", "Undskyld", ":)" } },
                    { "Skide godt", new[] { "!" } },
                    { "Det kan jo ske", new[] { "Får tæsk af JBro", "Din mor" } }
                }
            };
        }

        public void HaveDialog()
        {
            bool dialogRunning = true;
            string lastResponse = string.Empty;
            (int dialogX, int dialogY) = Console.GetCursorPosition();

            while (dialogRunning)
            {
                string dialog;
                string[] responses;

                dialog = Dialog.GetResponseDialog(lastResponse);
                if (dialog == "!")
                { break; }

                Console.SetCursorPosition(dialogX, dialogY);
                Console.WriteLine($"{dialog}\n");
                (dialogX, dialogY) = Console.GetCursorPosition();

                responses = Dialog.GetResponses(dialog);
                if (responses[0] == "!")
                { break; }

                int responseY = Program.g.BufferHeight - (responses.Length + 2);
                int responseIndex = Program.g.GetMarkedMenuInput(responses, true, true, 0, responseY);
                lastResponse = responses[responseIndex];

                for (int y = Program.g.BufferHeight-1; y >= responseY; y--)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write(new string(' ', Program.g.BufferWidth));
                }
            }
        }
    }
}
