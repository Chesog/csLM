using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        bool gameopen = true;
            Game game = new Game();
        do
        {
            gameopen = game.Menu();
        } while (gameopen);
    }
}

