using BoilerThermalCalculation.model;
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
    /// BoilerSetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class QuanFuSheJiaReQiWindow : Window
    {
        BiMianGuoReQi biMianGuoReQi = new BiMianGuoReQi();
        List<PSJiHeCanShuModel> shuModels = new List<PSJiHeCanShuModel>();
        public QuanFuSheJiaReQiWindow()
        {
            InitializeComponent();
        }

        #region 事件

        //加载
        private void QuanFuSheJiaReQi_Loaded(object sender, RoutedEventArgs e)
        {
            //viewmodel
            CtrlGrid_BoilerSet.DataContext = biMianGuoReQi;
            CtrlLB_Group.ItemsSource = shuModels;
        }

        //列表选择事件
        private void CtrlLB_Group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PSJiHeCanShuModel pSJiHe = (PSJiHeCanShuModel)CtrlLB_Group.SelectedItem;

            CtrlGrid_jhcs.DataContext = pSJiHe;
        }

        //添加组
        private void Ctrl_tjz_Click(object sender, RoutedEventArgs e)
        {

        }

        //删除组
        private void Ctrl_scz_Click(object sender, RoutedEventArgs e)
        {

        }


        #endregion

        
    }
}
