using System;

namespace PokemonApi.Mobile
{
    internal class ViewModelAttribute : Attribute
    {
        static readonly Type ViewModelBaseType = typeof(ViewModels.ViewModelBase);

        public ViewModelAttribute(Type vmType)
        {
            if (!ViewModelType.IsAssignableFrom(vmType))
                throw new ArgumentException("vmType must inherit from ViewModelBase");

            this.ViewModelType = vmType;
        }

        public Type ViewModelType { get; }
    }
}