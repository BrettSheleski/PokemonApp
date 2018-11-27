using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Mobile.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(out T field, T value, [CallerMemberName]string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
