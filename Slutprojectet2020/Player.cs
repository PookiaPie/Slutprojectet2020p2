using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojectet2020
{
    class Player: Pokemon
    {
        public Player()
        {
            strength = generator.Next(60, 100);
            deffens = generator.Next(10, 60);
            hp = generator.Next(70, 100);
        }

        public string choosePokemonPlayer;
        //Detta gör så att det inte blir samma pokemons för playern och AIn
    }
}
