using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



class Player
{
    private string name;
    private int MaxLife;
    private int Life;
    private int MaxMana;
    private int Mana;
    private int minAttk;
    private int maxAttk;
    private Locations Location;
    public Player(string name , int MaxLife , int MaxMana,int minAttk, int maxAttk , Locations spawnpoint)
    {
        this.name = name;
        this.MaxLife = MaxLife;
        this.Life = MaxLife;
        this.MaxMana = MaxMana;
        this.minAttk = minAttk;
        this.maxAttk = maxAttk;
        this.Mana = MaxMana;

        Location = spawnpoint;
    }
    public BinaryWriter save(BinaryWriter bw)
    {
        bw.Write(name);
        bw.Write(MaxLife);
        bw.Write(Life);
        bw.Write(MaxMana);
        bw.Write(Mana);
        bw.Write(minAttk);
        bw.Write(maxAttk);
        bw.Write((int)Location);
        return bw;
    }
    public void Heal()
    {
        Life = MaxLife;
    }
    public void Heal(int amount)
    {
        Life += amount;
        if (Life > MaxLife)
        {
            Life = MaxLife;
        }
    }
    public void RestoreMana()
    {
        Mana = MaxMana;
    }
    public void RestoreMana(int amount)
    {
        Mana += amount;
        if (Mana > MaxMana)
        {
            Mana = MaxMana;
        }
    }
    public void ReciveDamage(int amount)
    {
        Life -= amount;
        if (Life <= 0 )
        {
            Console.WriteLine("OMG , HE DEAD");
            GoToVillage();
        }
    }
    public List<Enemies> Dodamage(List<Enemies> enemies)
    {
        Random random = new Random();
        int damage = random.Next(minAttk, maxAttk);
        Console.WriteLine("Selec an enemy");
        for (int i = 0; i < enemies.Count; i++)
        {
            Console.WriteLine("Enemy N°: " + i);
            Console.WriteLine(enemies[i].GetStatus());
        }
        Console.WriteLine("Attack!!");
        Console.WriteLine("Select an index from 0 to" + (enemies.Count - 1));
        int imput = Convert.ToInt32(Console.ReadLine());
        if (imput >= 0  && imput < enemies.Count)
        {
            enemies[imput].DodamageToEnemy(damage);
        }
        else
        {
            Console.WriteLine("MISS");
        }
        return enemies;

    }

    public Locations GetLocations()
    {
        return Location;
    }
    public void GoToShop()
    {
        Location = Locations.Shop;
    }
    public void GoToCastle()
    {
        Location = Locations.Castle;
    }
    public void GoToVillage()
    {
        Location = Locations.Village;
    }
    public void GoToForest()
    {
        Location = Locations.Forest;
    }

}

