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
    private int minAttk;
    private int maxAttk;
    private Player player;
    private Village village;
    private Castle castle;
    private Menu Menu;
    private Locations location;
    

    
    public Game()
    {
        player = new Player(name,MaxLife,MaxMana,minAttk,maxAttk,Locations.Forest);
        village = new Village();
        castle = new Castle(6);
        Menu = new Menu();
        
    }
    
    public bool Play()
    {
        switch (player.GetLocations())
        {
            case Locations.Forest:
                player.GoToForest();
                break;
            case Locations.Castle:
                player = castle.stayinCastle(player);
                break;
            case Locations.Village:
                player = village.Stay(player);
                break;
            case Locations.Shop:
                player.GoToShop();
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
        return true;
    }
    
}

