using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



class Castle
{
    private enum options {Enter , Leave , Fight , Search , Error }
    private List<Encounters> encounters;
    private int lastEncounter;
    private options currentOption;
    private enum OnEnterOption {Leave , Fight , Error };
    private enum EndFightOption { Leave, Search, Error };

    public Castle(int EncountersAmount)
    {
        encounters = new List<Encounters>();
        for (int i = 0; i < EncountersAmount; i++)
        {
            encounters.Add(new Encounters(6));
        }
        lastEncounter = 0;
        currentOption = options.Enter;
    }
    public BinaryWriter Save (BinaryWriter bw)
    {
        bw.Write(encounters.Count);
        for (int i = 0; i < encounters.Count; i++)
        {
            bw = encounters[i].Save(bw);
        }
        bw.Write(lastEncounter);
        bw.Write((int)currentOption);
        return bw;
    }
    public BinaryReader Load (BinaryReader br)
    {
        int EncounterCout = br.ReadInt32();
        for (int i = 0; i < EncounterCout; i++)
        {
            br = encounters[i].Load(br);
        }
        lastEncounter = br.ReadInt32();
        currentOption = (options)br.ReadInt32();
        return br;
    }
    public Player stayinCastle(Player player)
    {
        switch (currentOption)
        {
            case options.Enter:
                Enter();
                break;
            case options.Leave:
                player = Leave(player);
                break;
            case options.Fight:
                player = Fight(player);
                break;
            case options.Search:
                Search();
                break;
            default:
                Console.WriteLine("ERROR");
                break;
        }
        return player;
    }
    public void Enter()
    {
        Console.WriteLine("You have enter the Castle");
        OnEnterOption onEnterOption;
        Console.WriteLine("Que Decides?");
        Console.WriteLine("Leave = 0 - Fight = 1");
        int imput = Convert.ToInt32(Console.ReadLine());
        if (imput >= 0 && imput < (int)OnEnterOption.Error)
        {
            onEnterOption = (OnEnterOption)imput;
        }
        else
        {
            onEnterOption = OnEnterOption.Error;
        }
        switch (onEnterOption)
        {
            case OnEnterOption.Leave:
                currentOption = options.Leave;
                break;
            case OnEnterOption.Fight:
                currentOption = options.Fight;
                break;
            default:
                Console.WriteLine("ERROR");
                break;
        }
    }
    public Player Fight(Player player)
    {
        encounters[lastEncounter].Fight(player);
        if (encounters[lastEncounter].enemies.Count == 0)
        {
            lastEncounter++;
            EndFightOption endFightOption;
            Console.WriteLine("Que Decides?");
            Console.WriteLine("Leave = 0 - Search = 1");
            int imput = Convert.ToInt32(Console.ReadLine());
            if (imput >= 0 && imput < (int)EndFightOption.Error)
            {
                endFightOption = (EndFightOption)imput;
            }
            else
            {
                endFightOption = EndFightOption.Error;
            }
            switch (endFightOption)
            {
                case EndFightOption.Leave:
                    currentOption = options.Leave;
                    break;
                case EndFightOption.Search:
                    currentOption = options.Search;
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }

        }
        return player;
    }
    public Player Leave(Player player)
    {
        player.GoToVillage();
        return player;
    }
    public void Search()
    {

    }
}

