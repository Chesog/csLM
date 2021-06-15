using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Village
{
    Shop shop = new Shop();
    public void Rest(Player player)
    {
        player.Heal();
        player.RestoreMana();
    }
}

