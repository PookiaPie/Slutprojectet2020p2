using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Slutprojectet2020
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient("https://pokeapi.co/api/v2/"); //object som reagerar som en client

            Pokemon pn = new Pokemon(); 

            Console.WriteLine(@"
*Intense Pokemon Music Playing*

A pokemon fighter have exposed you! 
Which pokemon will you get out!?
[Choose pokemon]
");

            string np = pn.choosePokemon;       //gör så att man kan välja sin pokemon
            np = Console.ReadLine();
            Console.WriteLine("You Choose " + np);

            RestRequest request = new RestRequest("pokemon/" + np);
            IRestResponse response = client.Get(request);
            //använder min klient för att hämta den här requesten. 
            Pokemon p = JsonConvert.DeserializeObject<Pokemon>(response.Content);
            //ta den här json stringen och utgå från denna
            

            Console.WriteLine(p.Name + " (" + p.BaseExperience + ")" + @"
Theese are your abilities: ");
            
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Ability " + i + " " + p.Moves[i].MoveMove.Name);
            }

            Console.ReadLine();

        }
    }
}
