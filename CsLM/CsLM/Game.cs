using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



class Game
{
    private int menu;
    private string name;
    private int MaxLife;
    private int MaxMana;
    private Locations PlayerLocation;
    

    
    public Game()
    {
        Player player = new Player(name,MaxLife,MaxMana,Locations.Forest);
        Village village = new Village();
        Castle castle = new Castle(6);
        

    }
    public bool Play()
    {
        Menu menu = new Menu();
        return true;
    }
    
}

