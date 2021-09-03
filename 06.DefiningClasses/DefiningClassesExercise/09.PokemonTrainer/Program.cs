using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (command != "Tournament")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = commandArgs[0];
                string pokemonName = commandArgs[1];
                string pokemonElement = commandArgs[2];
                int pokemonHealth = int.Parse(commandArgs[3]);

                Pokemon currentPokemon = new Pokemon()
                {
                    Name = pokemonName,
                    Element = pokemonElement,
                    Health = pokemonHealth
                };

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                    trainers[trainerName].Pokemons.Add(currentPokemon);
                }
                else
                {
                    trainers[trainerName].Pokemons.Add(currentPokemon);
                }

                command = Console.ReadLine();
            }

            string newCommand = Console.ReadLine();

            while (newCommand != "End")
            {
                string element = newCommand;

                foreach (var trainer in trainers)
                {
                    bool hasPokemon = false;

                    foreach (var pokemon in trainer.Value.Pokemons)
                    {
                        if (pokemon.Element == element)
                        {
                            hasPokemon = true;
                            break;
                        }
                    }

                    if (hasPokemon)
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }

                    trainer.Value.Pokemons = trainer.Value.Pokemons.Where(p => p.Health > 0).ToList();
                }

                newCommand = Console.ReadLine();
            }

            foreach (var trainer in trainers.Values.OrderByDescending(b => b.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
