using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



class Enemies
{
    private string name;
    private int maxLife;
    private int Life;
    private int minattk;
    private int maxattk;
    public Enemies()
    {

    }
    public Enemies(string name, int maxLife, int minattk, int maxattk)
    {
        this.name = name;
        this.maxLife = maxLife;
        this.Life = maxLife;
        this.minattk = minattk;
        this.maxattk = maxattk;
    }
    public BinaryWriter Save(BinaryWriter bw)
    {
        bw.Write(name);
        bw.Write(maxLife);
        bw.Write(Life);
        bw.Write(minattk);
        bw.Write(maxattk);
        return bw;
    }
    public BinaryReader Load (BinaryReader br)
    {
        name = br.ReadString();
        maxLife = br.ReadInt32();
        Life = br.ReadInt32();
        minattk = br.ReadInt32();
        maxattk = br.ReadInt32();
        return br;
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

