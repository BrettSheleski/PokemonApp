using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApi.Mobile.Pages.Move
{
    public class MoveViewModel : ViewModelBase
    {
        public MoveViewModel(PokemonService pokemonService)
        {
            this.PokemonService = pokemonService;
        }

        public ModelRetriever<PokemonApi.Move> Retriever { get; set; }
        public bool IsLoading { get => _isLoading; set => SetProperty(out _isLoading, value); }
        public PokemonService PokemonService { get; }
        public PokemonApi.Move Move { get => _move; set => SetProperty(out _move, value); }

        private PokemonApi.Move _move;


        private bool _isLoading;

        public async override Task InitializeAsync(CancellationToken cancellationToken)
        {
            await base.InitializeAsync(cancellationToken);

            this.Move = await this.Retriever.GetAsync(cancellationToken);



        }
    }
}
