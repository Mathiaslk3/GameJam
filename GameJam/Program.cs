using System.Net.NetworkInformation;

namespace GameJam
{
	internal class Program
	{
		static readonly Dialog tmpDialog = new();

		static void Main(string[] args)
        {
            tmpDialog.ResponseDict = new()
            {
                { string.Empty, "Godav du, hvad laver du?" },
                { "Ikke en skid", "Skide godt" },
                { "Din mor", "D... DU DÆLME SMART!" },
                { "Får tæsk af JBro", "Det kan jo ske" },
				{ "Tjo", "!" },
				{ "Undskyld", "!" },
				{ ":)", "!" }
            };

            tmpDialog.NPCDict = new()
			{
				{ "Godav du, hvad laver du?", new[] { "Ikke en skid", "Din mor", "Får tæsk af JBro" } },
				{ "D... DU DÆLME SMART!", new[] { "Tjo", "Undskyld", ":)" } },
				{ "Skide godt", new[] { "!" } },
				{ "Det kan jo ske", new[] { "!" } }
			};

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
		}
	}
}