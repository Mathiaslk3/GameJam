namespace GameJam
{
	internal class Program
	{
		//static readonly Dialog tmpDialog = new();
		public static Graphics g;

		static void Main(string[] args)
        {
			g = new(ConsoleColor.Gray, ConsoleColor.Black);

            Crew gamer = new("Karl", "Gamer", new("Stue", "...det en stue"));
			gamer.HaveDialog();
			/*
			string lastResponse = string.Empty;
			while(true)
			{
				Console.Clear();
				string dialog;
				string[] responses;

				dialog = tmpDialog.GetResponseDialog(lastResponse);
				if (dialog == "!")
				{ break; }

                Console.WriteLine($"{dialog}\n");

                responses = tmpDialog.GetResponses(dialog);
				if (responses[0] == "!")
				{ break; }

                for (int i = 0; i < responses.Length; i++)
				{ Console.WriteLine($"{i+1}: {responses[i]}"); }

				char responseIndex = Console.ReadKey().KeyChar;
				lastResponse = responses[int.Parse(responseIndex.ToString())-1];
            }
			*/
		}
	}
}