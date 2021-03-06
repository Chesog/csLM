using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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
            enemies.Add(new Enemies("Orc", 200, 0, 15));
            enemies.Add(new Enemies("Wolf", 50, 0, 10));
            enemies.Add(new Enemies("Lich", 100, 0, 20));
        }
    }
    public Encounters()
    {

    }
    public BinaryWriter Save (BinaryWriter bw)
    {
        bw.Write(enemies.Count);
        for (int i = 0; i < enemies.Count; i++)
        {
            bw = enemies[i].Save(bw);
        }
        return bw;
    }
    public BinaryReader Load (BinaryReader br)
    {
        int EnemiesCount = br.ReadInt32();
        enemies = new List<Enemies>();
        for (int i = 0; i < EnemiesCount; i++)
        {
            Enemies enemy = new Enemies();
            br = enemy.Load(br);
            enemies.Add(enemy);
        }
        return br;
    }
    public Player Fight(Player player)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            player = enemies[i].AttackPlayer(player);
        }
        enemies = player.Dodamage(enemies);
        List<Enemies> enemyAlive = new List<Enemies>();
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].isDead())
            {
                enemyAlive.Add(enemies[i]);
            }
        }
        enemies = enemyAlive;
        return player;
    }
}

