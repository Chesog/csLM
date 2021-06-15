using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Encounters
{
    public List<Enemies> enemies;
    public Encounters(int maxEnemiesinFight)
    {
        enemies = new List<Enemies>();
        Random random = new Random();
        int EnemiesinFight = random.Next(1, maxEnemiesinFight);
        for (int i = 0; i < EnemiesinFight; i++)
        {
            enemies.Add(new Enemies("Goblin", 20, 0, 5));
            enemies.Add(new Enemies("Orc", 100, 0, 50));
            enemies.Add(new Enemies("Wolf", 30, 0, 3));
            enemies.Add(new Enemies("Lich", 20, 100, 5));
        }
    }
}

