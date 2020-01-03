using BoilerThermalCalculation.model;
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
    /// BoilerSetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BiMianHuanReQiWindow : Window
    {
        ReLiCanShuBaseModel reLiCanShuBaseModel = new ReLiCanShuBaseModel();
        BiMianGuoReQi biMianGuoReQi = new BiMianGuoReQi();
        public List<JiHeCanShuModel> shuModels = new List<JiHeCanShuModel>();
        public BiMianHuanReQiWindow()
        {
            InitializeComponent();
        }

        #region 事件

        //加载事件
        private void BiMianHuanReQi_Loaded(object sender, RoutedEventArgs e)
        {
            //工质温度显示
            gzwd_Diaplay(Visibility.Hidden);
            //viewmodel
            CtrlGrid_BoilerSet.DataContext = reLiCanShuBaseModel;

            CtrlLB_Group.ItemsSource = shuModels;
        }

        //添加组
        private void Ctrl_tjz_Click(object sender, RoutedEventArgs e)
        {

        }

        //删除组
        private void Ctrl_scz_Click(object sender, RoutedEventArgs e)
        {

        }

        //列表选择事件
        private void CtrlLB_Group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            JiHeCanShuModel jiHeCanShu = (JiHeCanShuModel)CtrlLB_Group.SelectedItem;

            CtrlGrid_jhcs.DataContext = jiHeCanShu;
        }

        //选择水冷壁
        private void CtrlRB_FP_ShuiLengBi_Checked(object sender, RoutedEventArgs e)
        {
            if (CtrlLab_gzckwd == null)
                return;

            //工质温度显示
            gzwd_Diaplay(Visibility.Hidden);
            //数据绑定
            CtrlGrid_BoilerSet.DataContext = reLiCanShuBaseModel;
        }

        //选择壁面过热器
        private void CtrlRB_FP_BiMianGuoReQi_Checked(object sender, RoutedEventArgs e)
        {
            if (CtrlLab_gzckwd == null)
                return;

            //工质温度显示
            gzwd_Diaplay(Visibility.Visible);
            //数据绑定
            CtrlGrid_BoilerSet.DataContext = biMianGuoReQi;
        }

        #endregion

        //工质温度显示
        public void gzwd_Diaplay(Visibility display)
        {
            if (CtrlLab_gzckwd == null)
                return;

            CtrlLab_gzckwd.Visibility = display;
            CtrlTB_gzckwd.Visibility = display;
            CtrlLab_gzckwdUnit.Visibility = display;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        
    }
}
