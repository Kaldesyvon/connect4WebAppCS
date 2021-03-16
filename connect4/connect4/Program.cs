using connect4Core;

namespace connect4Console
{
    public class Program
    {
        static void Main()
        {
            var playfieldWidth = 7;
            var playfieldHeight = 6;
            var playfield = new Playfield(playfieldWidth, playfieldHeight);
            var consoleUi = new ConsoleUI(playfield);
            consoleUi.Play();
        }
    }
}