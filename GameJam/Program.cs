using NAudio.Wave;

namespace GameJam
{
	internal class Program
	{
		static readonly Dialog tmpDialog = new();

		static void Main(string[] args)
        {
            Console.WriteLine("Click any button to start the game (Go fullscreen please)");
            Console.ReadKey();
            Console.Clear(); 

            string mp3FilePath = @"C:\Users\Bruger\Desktop\TestRep\TestRep\Test\Test\StarWars.mp3"; 

            using (var audioFileReader = new AudioFileReader(mp3FilePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFileReader);
                outputDevice.Play();

                int left = 80; // Set the column position
                int top = 25;  // Set the row position

                Console.SetCursorPosition(left, top); // Set the cursor position
                Console.WriteLine("Der var engang et rumskib. Langt, langt ude i fremtiden... ");
                Thread.Sleep(5000);
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine(@"
                                                            ██╗░░██╗░█████╗░██████╗░████████╗░█████╗░░░░░░██╗███╗░░██╗  ██╗░░██╗██╗░░░██╗██████╗░████████╗
                                                            ██║░██╔╝██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗░░░░░██║████╗░██║  ██║░██╔╝██║░░░██║██╔══██╗╚══██╔══╝
                                                            █████═╝░███████║██████╔╝░░░██║░░░███████║░░░░░██║██╔██╗██║  █████═╝░██║░░░██║██████╔╝░░░██║░░░
                                                            ██╔═██╗░██╔══██║██╔═══╝░░░░██║░░░██╔══██║██╗░░██║██║╚████║  ██╔═██╗░██║░░░██║██╔══██╗░░░██║░░░
                                                            ██║░╚██╗██║░░██║██║░░░░░░░░██║░░░██║░░██║╚█████╔╝██║░╚███║  ██║░╚██╗╚██████╔╝██║░░██║░░░██║░░░
                                                            ╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░░░░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░╚═╝░░╚══╝  ╚═╝░░╚═╝░╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░ 
                    ");
                Thread.Sleep(7500);
                string[] textLines = {
            "","","","","","","       (Tryk på hvilken somhelst knap får at gå videre)         ","","","","",""      ,
            "        Du beslutter dig at tage sagen i egne hænder, ved at bruge en af dine geniale opfindelser      ",
            "                    Det ligner at han er blevel slået ihjel i den forgangne uge                        ",
            "                 Men ligepludselig... finder i Kaptajn Kurt død i rumskibets lounge                    ",
            "                Du kan faktisk ikke huske hvad der er sket, hele  den forgangne uge.\n                 ",
            "                   hvilket måske kan forklare det mærkelige tidsspring. Eller...?                      ",
            "                 En tur igennem et ormehul plejer ikke at være så voldsomt som dette,                  ",
            "                 Du kigger nu på dit ur, og ser at i er sendt... en uge? frem i tiden.\n               ",
            "                 i suget ind i et ormehul og i opdager at i er en uge ude i fremtiden.                 ",
            "                  Men lige pludselig mens i er fløjet forbi asteroide beltet bliver                   ",
            "                          Og It-tekniker Jan, som styrer skibets system.                               ",
            "        Med dig på skibet er der: Kaptajn Kurt,  Mekaniker Lars, som styrer skibets maskineri ,        ",
            "              Lasten skal leveres til Doug Dimmadome, ejeren af Dimmsdale Dimmadome.\n                 ",
            "Du er en videnskabsmand på et rumskib, som skal levere vigtig last til månen Titan på planeten Saturn. "
        };
                Console.ReadKey();
                // Set the console to fullscreen mode
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

                for (int i = textLines.Length - 1; i >= 0; i--)
                {
                    // Set the cursor position and print the line
                    Console.SetCursorPosition(60, Console.WindowHeight - 1);
                    Console.WriteLine(textLines[i]);

                    if (i > 0)
                    {
                        Thread.Sleep(2000); // Delay for 2,5 second
                        Console.SetCursorPosition(0, Console.WindowHeight - 1);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, Console.WindowHeight - 1);
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
            Thread.Sleep(5000);

            string introText = "Du vågner brat i dit kammer på rumskibet da du pludselig hører jeres mekaniker, Lars, banke hårdt på din dør. \n\n 'Kaptajnen er død, skynd dig ud' råber han. \n\n ";

            foreach (char introChar in introText)
            {
                Thread.Sleep(100);
                Console.Write(introChar);
            }

            string introText2 = "Du nægter at tro på at Kaptajnen er død... det hele gik jo så hurtigt...\n Du sidder der og prøver at tænke tilbage men kan ikke\n\n *der banked endnu hårdere på døren* \n\n 'Jeg kommer nu!!' siger du imens du ellers har glædet dig til, at blive betalt stort efter i har afleveret lasten...";

            foreach (char introChar in introText2)
            {
                Thread.Sleep(100);
                Console.Write(introChar);
            }

            Console.Clear();
            Console.ReadKey();

            Console.WriteLine("Godav du, hvad laver du?\n\n 1.Ikke en skid \n 2.Din Mor \n 3.Får tæsk af JBro");
			Console.WriteLine("\n Tryk på 1,2 eller 3 for vælge det givende svar: ");

            string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
                    string answer = "Skide godt";

                    foreach (char answerChar in answer)
                    {
                        Thread.Sleep(100);
                        Console.Write(answerChar);
                    }
                    Console.ReadKey();
                    break;
                case "2":
                    string answer2 = "D... DU DÆLME SMART!";

                    foreach (char answerChar in answer2)
                    {
                        Thread.Sleep(100);
                        Console.Write(answerChar);
                    }
                    Console.ReadKey();
                    break;
                case "3":
                    string answer3 = "Det kan ske";

                    foreach (char answerChar in answer3)
                    {
                        Thread.Sleep(100);
                        Console.Write(answerChar);
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Det er ikke et svar...");
                    break;

            }
			/*
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
			*/
            }
		}
	}
