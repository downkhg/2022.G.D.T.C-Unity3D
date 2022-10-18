using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonGame
{
    class Pokemon
    {
        public string strName;
        public int nHP;
        public int nDemage;
        public Pokemon(string name, int hp, int dem)
        {
            strName = name;
            nHP = hp;
            nDemage = dem;
        }
        public void Attack(Pokemon target)
        {
            target.nHP = target.nHP - this.nDemage;
        }
        public bool Death()
        {
            if (nHP > 0)
                return false;
            else
                return true;
        }
        public void Display(string msg)
        {
            Console.WriteLine("##### " + msg + " #######");
            Console.WriteLine("Name:" + strName);
            Console.WriteLine("Demage:" + nDemage);
            Console.WriteLine("HP:" + nHP);
            Console.WriteLine("###################");
        }
    }

    class Tranner
    {
        List<Pokemon> listMonsters = new List<Pokemon>();

        public void Catch(Pokemon pokemon)
        {
            listMonsters.Add(pokemon);
        }

        public Pokemon Throw(int idx)
        {
            return listMonsters[idx];
        }

        public Pokemon Throw(string name)
        {
            return listMonsters.Find(pokemon => pokemon.strName == name);
        }
    }

    static class PokemonGame
    {
        static void GameMain()
        {
            Tranner tranner = new Tranner();

            tranner.Catch(new Pokemon("이상해씨", 100, 10));

            List<Pokemon> listMonsters = new List<Pokemon>();
            listMonsters.Add(new Pokemon("slime", 100, 10));
            listMonsters.Add(new Pokemon("skeleton", 100, 10));
            listMonsters.Add(new Pokemon("zombie", 100, 10));
            listMonsters.Add(new Pokemon("dragon", 100, 10));
            Pokemon myPokemon = tranner.Throw(0);
            Pokemon catchPokemon = listMonsters[0];
            tranner.Catch(catchPokemon);
        }
    }
}
