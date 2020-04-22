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
            //skapar AI
            RestClient clientAI = new RestClient("https://pokeapi.co/api/v2/"); //object som reagerar som en client
            RestRequest request2 = new RestRequest("pokemon/bulbasaur");
            IRestResponse response2 = clientAI.Get(request2);
            //använder min klient för att hämta den här requesten. 
            Pokemon AI = JsonConvert.DeserializeObject<Pokemon>(response2.Content);
            //ta den här json stringen och utgå från denna
            

            Console.WriteLine(@"
*Intense Pokemon Music Playing*

A pokemon fighter have exposed you! 
Which pokemon will you get out!?
[Choose pokemon]
");
            Player pn = new Player();
            string np = pn.choosePokemonPlayer;       //gör så att man kan välja sin pokemon
            np = "";

            while (np.Length == 0)                                                                      //ifall namnet är likamed 0  kommer denna loppen forsätta tills man skriver in något slags namn.
            {
                np = Console.ReadLine();                                                                //användarnamnet som användaren får skriva in. Den kommer repiteras och förnyas så att användarnamnets inte sparas. 
                if (np.Length == 0)
                {
                    Console.WriteLine("Pleace choose a pokemon");
                }
            }
            Console.WriteLine("You Choose " + np);

            //Skapar Spelarens pokemon
            RestClient client = new RestClient("https://pokeapi.co/api/v2/");
            RestRequest request = new RestRequest("pokemon/" + np);
            IRestResponse response = client.Get(request);
            Pokemon p = JsonConvert.DeserializeObject<Pokemon>(response.Content);
            

            Console.WriteLine(p.Name + " (" + p.BaseExperience + ")" + @"
Theese are your abilities: ");
            for (int i = 0; i < 3; i++) //for loop som kör 4 gånger för att lista 4 abilities.
            {
                Console.WriteLine(i + 1 + ") " + p.Moves[i].MoveMove.Name);
            }

            Console.WriteLine(@"
You are fighting " + AI.Name + " (" + AI.BaseExperience + ")" + @"
Theese are your aponments abilities: ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i + 1 + ") " + AI.Moves[i].MoveMove.Name);
            }

            Console.WriteLine("Fight!");







            Console.ReadLine();
        }
    }
}
