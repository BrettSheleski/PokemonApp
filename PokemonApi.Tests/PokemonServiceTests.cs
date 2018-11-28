using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokemonApi.Tests
{
    [TestClass]
    public class PokemonServiceTests
    {
        [TestMethod]
        public async Task GetPokemonById()
        {
            // Setup
            var service = new PokemonService();
            int pikachuId = 25;

            // act
            Pokemon pokemon = await service.GetPokemonByIdAsync(pikachuId, CancellationToken.None);

            // verify
            Assert.IsNotNull(pokemon);
            Assert.IsTrue(pokemon.Id == pikachuId);
            Assert.IsTrue(pokemon.Name == "pikachu");
        }

        [TestMethod]
        public async Task GetPokemonList()
        {
            // Setup
            var service = new PokemonService();

            // act
            ResultList<ModelRetriever<Pokemon>> pokemonList = await service.GetPokemonListAsync(CancellationToken.None);

            // verify
            Assert.IsNotNull(pokemonList);
            Assert.IsTrue(pokemonList.Count > 10);
            Assert.IsTrue(pokemonList.Results.Count > 10);
        }

        [TestMethod]
        public async Task GetAllPokemon()
        {
            // Setup
            var service = new PokemonService();
            ResultList<ModelRetriever<Pokemon>> pokemonList = await service.GetPokemonListAsync(CancellationToken.None);
            CancellationToken cancellationToken = CancellationToken.None;

            // act
            List<Task<Pokemon>> tasks = pokemonList.Results.Select(r => r.GetAsync(cancellationToken)).ToList();
            await Task.WhenAll(tasks);
            Pokemon[] pokemons = tasks.Select(x => x.Result).ToArray();

            // verify
            Assert.IsNotNull(pokemons);
            Assert.IsTrue(pokemons.Length > 10);
        }

        [TestMethod]
        public async Task GetMoveById()
        {
            // Setup
            int moveId = 1;
            var service = new PokemonService();

            // act
            Move move = await service.GetMoveByIdAsync(moveId, CancellationToken.None);

            // verify
            Assert.IsNotNull(move);
            Assert.IsTrue(move.Id == moveId);
            Assert.IsTrue(move.Name == "pound");
        }

        [TestMethod]
        public async Task GetPokedexIndex()
        {
            // Setup
            var service = new PokemonService();

            // act
            ResultList<ModelRetriever<Pokedex>> results = await service.GetPokedexListAsync(CancellationToken.None);

            // verify
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 10);

            foreach(var thing in results.Results)
            {
                Assert.IsNotNull(thing.Name);
            }
        }

        [TestMethod]
        public async Task GetPokedexById()
        {
            // Setup
            var service = new PokemonService();
            int id = 1;

            // act
            Pokedex pokedex = await service.GetPokedexByIdAsync(id, CancellationToken.None);

            // verify
            Assert.IsNotNull(pokedex);
            Assert.IsTrue(pokedex.Name == "national");
        }
    }
}
