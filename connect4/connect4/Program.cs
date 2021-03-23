using connect4Core.Core;

namespace connect4Console
{
    public class Program
    {
        private static void Main()
        {
            const int playfieldWidth = 7;
            const int playfieldHeight = 6;
            var playfield = new Playfield(playfieldWidth, playfieldHeight);
            var consoleUi = new ConsoleUi(playfield);
            // Red player is first
            consoleUi.Play(Color.Red);
        }
    }
}