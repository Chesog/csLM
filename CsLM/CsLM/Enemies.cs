using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Enemies
{
    private string name;
    private int maxLife;
    private int Life;
    private int minattk;
    private int maxattk;
    public Enemies(string name, int maxLife, int minattk, int maxattk)
    {
        this.name = name;
        this.maxLife = maxLife;
        this.Life = maxLife;
        this.minattk = minattk;
        this.maxattk = maxattk;
    }
    public Player AttackPlayer(Player player)
    {
        Random random = new Random();
        int damage = random.Next(minattk, maxattk);
        player.ReciveDamage(damage);
        return player;
    }
    public string GetStatus()
    {
        string status = "";
        status += "Name:" + name + "\n";
        status += "Life:" + Life + "\n";
        return status;
    }
    public void DodamageToEnemy(int amount)
    {
        Life -= amount;
        if (Life <= 0)
        {
            Console.WriteLine("F" + name);
        }
    }
    public bool isDead()
    {
        return Life <= 0;
    }
}

