using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Player
{
    private string name;
    private int MaxLife;
    private int Life;
    private int MaxMana;
    private int Mana;
    private Locations location;
    public Player(string name , int MaxLife , int MaxMana)
    {
        this.name = name;
        this.MaxLife = MaxLife;
        this.MaxMana = MaxMana;
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
}

