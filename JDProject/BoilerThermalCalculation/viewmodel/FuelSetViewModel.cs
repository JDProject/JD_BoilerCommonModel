using BoilerThermalCalculation.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace BoilerThermalCalculation.viewmodel
{
    public class FuelSetViewModel
    {
        FuelSetModel fuelSetModel = null;
        //private DeletgateCommand<string> addCommand;
        public FuelSetViewModel()
        {
            fuelSetModel = new FuelSetModel();
        }

        #region Public Properties
        public rlxs erlxs
        {
            get { return fuelSetModel.erlxs; }
            set { fuelSetModel.erlxs = value; }
        }
        public string DT
        {
            get { return fuelSetModel.DT; }
            set { fuelSetModel.DT = value; }
        }
        public string ST
        {
            get { return fuelSetModel.ST; }
            set { fuelSetModel.ST = value; }
        }
        public string FT
        {
            get { return fuelSetModel.FT; }
            set { fuelSetModel.FT = value; }
        }
        public gttjj egttjj
        {
            get { return fuelSetModel.egttjj; }
            set { fuelSetModel.egttjj = value; }
        }
        public string Qnetar
        {
            get { return fuelSetModel.Qnetar; }
            set { fuelSetModel.Qnetar = value; }
        }
        #endregion

        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        if (addCommand == null)
        //        {
        //            addCommand = new DeletgateCommand<string>( CanAdd);
        //        }
        //        return addCommand;

        //    }
        //}

        //private static bool CanAdd(string num)
        //{
        //    return true;
        //}
    }

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    public class DeletgateCommand<T> : ICommand
    {
        private readonly Action<T> _executeMethod = null;
        private readonly Func<T, bool> _canExecuteMethod = null;

        public DeletgateCommand(Action<T> executeMethod)
            : this(null)
        { }

        public DeletgateCommand(Func<T, bool> canExecuteMethod)
        {
            _canExecuteMethod = canExecuteMethod;
        }

        #region ICommand 成员
        /// <summary>
        ///  Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(T parameter)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter);
            }
            return true;

        }

        /// <summary>
        ///  Execution of the command
        /// </summary>
        public void Execute(T parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter);
            }
        }

        #endregion


        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #region ICommand 成员

        public bool CanExecute(object parameter)
        {
            if (parameter == null && typeof(T).IsValueType)
            {
                return (_canExecuteMethod == null);

            }

            return CanExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }

        #endregion
    }

    public class CheckConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? false : value.Equals(parameter);
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
