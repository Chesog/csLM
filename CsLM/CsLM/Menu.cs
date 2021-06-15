using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



class Menu
{
    private int menu;
    
    public  Menu ()
    {
        string[] lines = File.ReadAllLines("./Menuintro/menu.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            Console.WriteLine(lines[i]);
        }
        int respuesta = Convert.ToInt32(Console.ReadLine());

        switch (respuesta)
        {
            case 1:
                menu = 1;
                break;
            case 2:
                menu = 1;
                break;
            case 3:
                menu = 1;
                break;
            case 4:
                Console.WriteLine("La Marca Te consume");
                Console.ReadKey();
                menu = 0;
                break;
            default:
                break;
        }
        if (menu == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

