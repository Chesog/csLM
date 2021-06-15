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
    private int maxMana;
    private int Mana;
    private int Defence;
    public Enemies(string name,int maxLife,int maxMana,int Defence)
    {
        this.name = name;
        this.maxLife = maxLife;
        this.Life = maxLife;
        this.maxMana = maxMana;
        this.Mana = maxMana;
        this.Defence = Defence;
    }
}

