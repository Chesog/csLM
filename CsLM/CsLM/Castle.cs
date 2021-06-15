using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Castle
{
    private List<Encounters> encounters;
    public Castle(int EncountersAmount)
    {
        encounters = new List<Encounters>();
        for (int i = 0; i < EncountersAmount; i++)
        {
            encounters.Add(new Encounters(6));
        }
    }
}

