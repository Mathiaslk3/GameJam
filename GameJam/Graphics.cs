using System.Text;

namespace GameJam
{
    /// <summary>
    /// For drawing various console graphics
    /// </summary>
    internal class Graphics
    {
        private readonly char tl = '\u2554';    // '╔'
        private readonly char tr = '\u2557';    // '╗'
        private readonly char bl = '\u255A';    // '╚'
        private readonly char br = '\u255D';    // '╝'
        private readonly char hort = '\u2550';  // '═'
        private readonly char vert = '\u2551';  // '║'

        public int BufferHeight;
        public int BufferWidth;

        /// <summary>
        /// A struct for console colors
        /// </summary>
        public struct ConColor
        {
            public ConsoleColor foreground; // The foreground (text) color
            public ConsoleColor background; // The background color

            /// <summary>
            /// Creates a new instance of the <c>ConColor</c> struct with a given fore- and background color
            /// </summary>
            /// <param name="fore">The foreground color</param>
            /// <param name="back">The background color</param>
            public ConColor(ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
            { foreground = fore; background = back; }

            /// <summary>
            /// An easy method for getting the "flipped" version of the <c>ConColor</c>
            /// </summary>
            /// <returns>A <c>ConColor</c> instance with the background as foreground and vice versa</returns>
            public readonly ConColor Flip()
            { return new ConColor(background, foreground); }
        }
        private ConColor consoleColors; // A variable for keeping track of the currently
                                        // set fore- and background color

        /// <summary>
        /// Creates an instance of the Graphics class using a fore- and background <c>ConsoleColor</c> variable.
        /// It also sets the console's output's encoding to unicode in order to use the fancy box characters
        /// </summary>
        /// <param name="foreground">The foreground color that the console should use</param>
        /// <param name="background">The background color that the console should use</param>
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public Graphics(ConsoleColor foreground, ConsoleColor background)
        {
            BufferWidth = Console.BufferWidth = Console.WindowWidth;
            BufferHeight = Console.BufferHeight = Console.WindowHeight;

            Console.ForegroundColor = foreground;       // Set the foreground
            Console.BackgroundColor = background;       // and background colors
            Console.OutputEncoding = Encoding.Unicode;  // And set the encoding to unicode

            consoleColors.foreground = foreground;      // Set the consoleColors var to
            consoleColors.background = background;      // the onces that were given as parameters

            Console.Clear();                            // Finally clear the console to show the colors
        }

        /// <summary>
        /// Creates an instance of the Graphics class using a <c>ConColor</c> struct variable.
        /// It also sets the console's output's encoding to unicode in order to use the fancy box characters
        /// </summary>
        /// <param name="colors"></param>
        /// 
        [System.Runtime.Versioning.SupportedOSPlatform("windows")]
        public Graphics(ConColor colors)
        {
            BufferWidth = Console.BufferWidth = Console.WindowWidth;
            BufferHeight = Console.BufferHeight = Console.WindowHeight;

            // I don't feel like repeating myself, so I'm not going to...
            Console.ForegroundColor = colors.foreground;
            Console.BackgroundColor = colors.background;
            Console.OutputEncoding = Encoding.Unicode;

            consoleColors.foreground = colors.foreground;
            consoleColors.background = colors.background;

            Console.Clear();
        }

        /// <summary>
        /// Get the current foreground color
        /// </summary>
        /// <returns>The current console foreground color</returns>
        public ConsoleColor GetForeground()
        { return consoleColors.foreground; }

        /// <summary>
        /// Get the current background color
        /// </summary>
        /// <returns>The current console background color</returns>
        public ConsoleColor GetBackground()
        { return consoleColors.background; }

        /// <summary>
        /// Get the current fore- and background colors
        /// </summary>
        /// <returns>A <c>ConColor</c> struct with the fore- and background color</returns>
        public ConColor GetConsoleColors()
        { return consoleColors; }

        /// <summary>
        /// Get the center X and Y of the console window
        /// </summary>
        /// <returns>a <c>tuple</c> of two ints, the X and Y respectively</returns>
        public static (int, int) GetConsoleCenter()
        { return (Console.WindowWidth / 2, Console.WindowHeight / 2); }

        /// <summary>
        /// Set the foreground color of the console
        /// </summary>
        /// <param name="fore">The foreground color</param>
        /// <param name="setConsole">Whether or not the console should "refresh"</param>
        public void SetForeground(ConsoleColor fore, bool setConsole)
        {
            consoleColors.foreground = fore;
            if (setConsole)
            {
                Console.ForegroundColor = fore;
                Console.Clear();
            }
        }

        /// <summary>
        /// Set the background color of the console
        /// </summary>
        /// <param name="back">The background color</param>
        /// <param name="setConsole">Whether or not the console should "refresh"</param>
        public void SetBackground(ConsoleColor back, bool setConsole)
        {
            consoleColors.background = back;
            if (setConsole)
            {
                Console.BackgroundColor = back;
                Console.Clear();
            }
        }

        /// <summary>
        /// Set both the fore- and background color of the console
        /// </summary>
        /// <param name="cColor">The colors to set as the consoles colors</param>
        /// <param name="setConsole">Whether or not the console should "refresh"</param>
        public void SetConsoleColors(ConColor cColor, bool setConsole)
        {
            consoleColors = cColor;
            if (setConsole)
            {
                Console.ForegroundColor = cColor.foreground;
                Console.BackgroundColor = cColor.background;
                Console.Clear();
            }
        }

        /// <summary>
        /// Write a character at a certain position without moving the cursor afterwards
        /// </summary>
        /// <param name="x">The X position</param>
        /// <param name="y">The Y position</param>
        /// <param name="chr">The character to write</param>
        private static void WriteNoMove(int x, int y, char chr)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(chr + "\b");
        }

        /// <summary>
        /// Write a given string as "marked"
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="markedColor">The color to write the text with</param>
        public void WriteColor(string text, ConColor markedColor)
        {
            // Set the colors to equal the markedColor colors
            // and then write the text
            Console.ForegroundColor = markedColor.foreground;
            Console.BackgroundColor = markedColor.background;
            Console.WriteLine(text);

            // Reset the colors
            Console.ForegroundColor = consoleColors.foreground;
            Console.BackgroundColor = consoleColors.background;
        }

        /// <summary>
        /// Draw a simple box at a given location with a given size
        /// </summary>
        /// <param name="startX">The X position</param>
        /// <param name="startY">The Y position</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void DrawBox(int startX, int startY, int width, int height)
        {
            // Get what the end X and Y is
            int endX = width + startX;
            int endY = height + startY;

            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    Console.SetCursorPosition(x, y);    // Start by setting the cursor

                    // Check all the corners
                    if (x == startX && y == startY)     // If x and y equal the start x and y
                    { WriteNoMove(x, y, tl); }          // we are in the top left corner
                    else if (x == endX && y == startY)  // If x equals end x and y equals start y
                    { WriteNoMove(x, y, tr); }          // we are in the top right corner
                    else if (x == startX && y == endY)  // If x equals start x and y equals end y
                    { WriteNoMove(x, y, bl); }          // we are in the bottom left corner
                    else if (x == endX && y == endY)    // If x and y equal the end x and y
                    { WriteNoMove(x, y, br); }          // we ar ein the bottom right corner
                    else                                // Otherwise... we aren't in any corner
                    {
                        if (x == startX || x == endX)       // If x is either at the start or the end
                        { WriteNoMove(x, y, vert); }        // we draw a vertical line
                        else if (y == startY || y == endY)  // If y is at either the top or the bottom
                        { WriteNoMove(x, y, hort); }        // we draw a horizontal line
                    }
                }
            }
        }

        /// <summary>
        /// Draw a box at a given position which contains a given text
        /// </summary>
        /// <param name="x">The X position</param>
        /// <param name="y">The Y position</param>
        /// <param name="text">The text to write in the middel of the box</param>
        /// <param name="centered">Whether or not the text should be centered</param>
        public void DrawBox(int x, int y, string text, bool centered, bool fillWidth)
        {
            StringBuilder sb = new();
            string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int longest = 0;

            foreach (string line in lines)
            {
                if (line.Length > longest)
                { longest = line.Length; }
            }
            int width = longest + 2; // extra space on each side

            string hortLine = fillWidth ? new string(hort, BufferWidth-2) : new string(hort, width);
            //for (int i = 0; i < width; i++)
            //{ hortLine += hort; }
            sb.AppendLine(tl + hortLine + tr);

            foreach (string line in lines)
            {
                string startSpace = "";
                string endSpace = "";

                if (centered)
                {
                    float fSpaces = (width - line.Length) / 2.0f;
                    int iSpaces = Convert.ToInt32(fSpaces);

                    // For handling uneven amount of chars
                    if (fSpaces > iSpaces)
                    { iSpaces++; }

                    for (int i = 0; i < iSpaces; i++)
                    {
                        startSpace += " ";

                        if (!(iSpaces > fSpaces && i == iSpaces - 1))
                        { endSpace += " "; }
                    }
                }
                else
                {
                    startSpace = " ";
                    endSpace = new string(' ', longest - line.Length + 1);
                }

                string finalLine = vert + startSpace + line + endSpace + vert;
                if (fillWidth)
                {
                    if (finalLine.Length < BufferWidth)
                    { endSpace += new string(' ', BufferWidth - finalLine.Length); }
                }

                sb.AppendLine(vert + startSpace + line + endSpace + vert);
            }

            sb.AppendLine(bl + hortLine + br);
            string[] box = sb.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string b in box)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(b);
                y++;
            }
        }

        /// <summary>
        /// Draw a "marked menu", aka a menu where the currently highlighted option is "marked"
        /// by flipping the fore- and background console colors, at a given X and Y position
        /// </summary>
        /// <param name="options">The different options the menu should contain</param>
        /// <param name="marked">Which index of the <c>options</c> should be marked</param>
        /// <param name="x">The X position</param>
        /// <param name="y">The Y position</param>
        /// 
        public void DrawMarkedMenu(string[] options, int marked, bool boxed, bool fillWidth, int x = -1, int y = -1)
        {
            if (x == -1)
            { (x, _) = Console.GetCursorPosition(); }
            if (y == -1)
            { (_, y) = Console.GetCursorPosition(); }

            if (boxed)
            {
                DrawBox(x, y, string.Join("\n", options), false, fillWidth);
                x+=2; y++;
            }

            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                if (i == marked)
                { WriteColor(options[i], consoleColors.Flip()); }
                else
                { Console.Write(options[i]); }
            }
        }

        /// <summary>
        /// Get input while being able to control a max amount of chars, and whether or not
        /// the input is a password, and should therefore be consealed as one
        /// </summary>
        /// <param name="maxSize">The max amount of chars the user can write</param>
        /// <param name="isPassword">Whether or not the input should be "hidden"</param>
        /// <returns></returns>
        public string GetBufferedInput(int maxSize, bool isPassword)
        {
            string input = string.Empty;
            ConsoleKeyInfo cki = new();

            while (cki.Key != ConsoleKey.Enter)
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                { break; }
                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        Console.Write("\b \b");
                        input = input[..^1];
                    }
                }
                else if (char.IsAscii(cki.KeyChar)
                    && input.Length < maxSize)
                {
                    Console.Write(isPassword ? '\u25CF' : cki.KeyChar);
                    input += cki.KeyChar;
                }
            }

            return input;
        }

        /// <summary>
        /// Draw a "marked menu" and get the chosen index.
        /// See <see cref="DrawMarkedMenu(string[], int)"/> for further information on the drawing of said menu
        /// </summary>
        /// <param name="options">The different options the menu should contain</param>
        /// <param name="x">(optional) The X position</param>
        /// <param name="y">(optional) The Y position</param>
        /// <returns>The index of the string from the <c>options</c> array that was chosen</returns>
        public int GetMarkedMenuInput(string[] options, bool boxed, bool fillWidth, int x = -1, int y = -1)
        {
            ConsoleKeyInfo cki = new();
            int marked = 0;

            if (x == -1)
            { (x, _) = Console.GetCursorPosition(); }
            if (y == -1)
            { (_, y) = Console.GetCursorPosition(); }

            while (cki.Key != ConsoleKey.Enter)
            {
                DrawMarkedMenu(options, marked, boxed, fillWidth, x, y);
                Console.SetCursorPosition(0, 0);

                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.UpArrow)
                {
                    marked = marked == 0 ? options.Length - 1 : marked - 1;
                    if (string.IsNullOrEmpty(options[marked]))
                    { marked--; }
                }
                else if (cki.Key == ConsoleKey.DownArrow)
                {
                    marked = marked == options.Length - 1 ? 0 : marked + 1;
                    if (string.IsNullOrEmpty(options[marked]))
                    { marked++; }
                }
                else if (cki.Key == ConsoleKey.Enter)
                { break; }
            }

            return marked;
        }
    }
}
