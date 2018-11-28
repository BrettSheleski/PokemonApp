using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokemonApi.Mobile
{
    public class AsyncCommand : Command
    {
        public AsyncCommand(Func<Task> asyncFunc) : base(async () => await asyncFunc())
        {

        }

    }

    public class AsyncCommand<T> : ICommand
    {
        public AsyncCommand(Func<T, Task> asyncFunc)
        {
            this.AsyncFunc = asyncFunc;
        }

        public Func<T, Task> AsyncFunc { get; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await AsyncFunc((T)parameter);
        }
    }
}
