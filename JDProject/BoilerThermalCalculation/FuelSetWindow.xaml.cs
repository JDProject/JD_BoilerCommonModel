using BoilerThermalCalculation.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BoilerThermalCalculation
{
    /// <summary>
    /// FuelSetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FuelSetWindow : Window
    {
        FuelSetViewModel fuelSetView = new FuelSetViewModel();
        public FuelSetWindow()
        {
            InitializeComponent();
        }

        //加载事件
        private void FuelSet_Loaded(object sender, RoutedEventArgs e)
        {
            CtrlGrid_FuelProperty.DataContext = fuelSetView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
