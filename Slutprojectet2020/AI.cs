using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojectet2020
{
    class AI : Pokemon
    {
        public AI()
        {
            strength = generator.Next(50, 100);
            deffens = generator.Next(10, 70);
        }

        public string choosePokemonAI;
    }
}
