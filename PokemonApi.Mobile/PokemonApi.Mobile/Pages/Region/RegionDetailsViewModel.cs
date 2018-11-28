using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApi.Mobile.Pages.Region
{
    public class RegionDetailsViewModel : ViewModelBase
    {
        private PokemonApi.Region _region;

        public ModelRetriever<PokemonApi.Region> Retriever { get; set; }
        public PokemonApi.Region Region { get => _region; set => SetProperty(out _region, value); }

        public async override Task InitializeAsync(CancellationToken cancellationToken)
        {
            await base.InitializeAsync(cancellationToken);

            this.Region = await Retriever.GetAsync(cancellationToken);

        }
    }
}
