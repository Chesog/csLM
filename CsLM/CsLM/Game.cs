using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



class Game
{
    
    public Game()
    {
        Player player = new Player();
        Village village = new Village();
        Gameplay gameplay = new Gameplay();
        Shop shop = new Shop();

    }
    public bool Menu()
    {
        try
        {
            StreamReader sr = new StreamReader("./Menuintro/menu");
            string line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
            
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }


        return true;
    }
}

