using System;
using System.Windows.Input;

namespace Sulmar.WPFMVVM.Common
{

    //komneda przelotka

    public class RelayCommand : ICommand  //relay służy do wywoływania komend po kliknięciu w przycisk
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> execute;  //delegat typowany readonly można go zainicjalizować tylko w konstruktorze lub w jego deklaracji, nie można go później zmieniać

        private readonly Func<object, bool> canExecute;  //delegat w którym możesz określić wynik  1 parametr - co przychodzi, 2 parametr - co zwraca

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute; // przekazuje akcję do wykonania do zapamiętania
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute.Invoke(parameter);  // invoke służy do jawnego wywoływania metody
        }

        public void Execute(object parameter)
        {
            if(execute != null)             // sprawdza czy jest przekazana jakaś akcja
            execute.Invoke(parameter);  // wywołujemy metody przekazane przez Action


            // execute?.Invoke(parameter);   // można stosować zamiennie od C# 6.0

        }
    }
}
