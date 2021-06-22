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
    private Forest forest;
    private Locations location;



    public Game()
    {
        bool load;
        string[] lines = File.ReadAllLines("./Menuintro/menu.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            Console.WriteLine(lines[i]);
        }
        int respuesta = Convert.ToInt32(Console.ReadLine());

        switch (respuesta)
        {
            case 1:
                StartNewGame();
                break;
            case 2:
                LoadGame();
                break;
            case 3:
                Creditos();
                break;
            case 4:
                Console.WriteLine("La Marca Te consume");
                Console.ReadKey();
                break;
            default:
                break;

                if (load)
                {
                    LoadGame();
                }
                else
                {
                    StartNewGame();
                }
        }
    }
    public void LoadGame()
    {
        Load();
        village = new Village();
        forest = new Forest();
    }
    public void StartNewGame()
    {
        player = new Player(name, MaxLife, MaxMana, minAttk, maxAttk, Locations.Forest);
        village = new Village();
        castle = new Castle(6);

    }
    public void Creditos()
    {

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
    public void Save()
    {
        Stream save = File.Open("./Saves/MySave.sav", FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(save);
        bw = player.save(bw);
        bw = castle.Save(bw);
        bw.Close();
        save.Close();
    }
    public void Load()
    {
        if (File.Exists("./Saves/MySave.sav"))
        {
            Stream file = File.Open("./Saves/MySave.sav", FileMode.Open);
            BinaryReader br = new BinaryReader(file);
            player = new Player();
            br = player.Load(br);
            castle = new Castle();
            br = castle.Load(br);
            br.Close();
            file.Close();
        }
    }

}

