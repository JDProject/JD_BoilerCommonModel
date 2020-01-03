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
    public partial class BoilerSetWindow : Window
    {
        LTRLCSViewModel lTRLCSViewModel = new LTRLCSViewModel();
        GLJGXSViewModel gLJGXSViewModel = new GLJGXSViewModel();
        LTJHCSViewModel lTJHCSViewModel = new LTJHCSViewModel();
        ZJViewModel zJViewModel = new ZJViewModel();
        public BoilerSetWindow()
        {
            InitializeComponent();
        }

        #region 事件

        //加载事件
        private void BoilerSet_Loaded(object sender, RoutedEventArgs e)
        {
            CtrlGrid_BoilerSet.DataContext = lTRLCSViewModel;
            CtrlGrid_BoilerStructureType.DataContext = gLJGXSViewModel;
            CtrlGrid_LuTangJiHeCanShu.DataContext = lTJHCSViewModel;
            CtrlGrid_ExpertParameters.DataContext = zJViewModel;
        }

        //添加层
        private void CtrlBut_EP_AddLayout_Click(object sender, RoutedEventArgs e)
        {

        }

        //层验证
        private void CtrlBut_EP_LayoutYan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CtrlBut_EP_DYan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CtrlBut_EP_HYan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CtrlBut_EP_hycYan_Click(object sender, RoutedEventArgs e)
        {

        }


        #endregion

        
    }
}
