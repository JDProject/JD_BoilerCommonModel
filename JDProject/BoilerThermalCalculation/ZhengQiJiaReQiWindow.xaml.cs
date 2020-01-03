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
    /// ZhengQiJiaReQiWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ZhengQiJiaReQiWindow : Window
    {
        ZQJRQReLiCanShuModel zQJRQReLiCanShuModel = new ZQJRQReLiCanShuModel();
        ZQJRQHuanReQiJieGouModel zQJRQHuanReQiJieGouModel = new ZQJRQHuanReQiJieGouModel();
        ZQJRQJiHeCanShuBaseModel zQJRQJiHeCanShuBaseModel = new ZQJRQJiHeCanShuBaseModel(gzlx.gg);
        ZQJRQJiHeCanShuModel_ms zQJRQJiHeCanShuModel_ms = new ZQJRQJiHeCanShuModel_ms(gzlx.ms);
        ZQJRQJiHeCanShuModel_fxhlg zQJRQJiHeCanShuModel_fxhlg = new ZQJRQJiHeCanShuModel_fxhlg(gzlx.fxhlg);
        ZQJRQJiHeCanShuModel_yxhlg zQJRQJiHeCanShuModel_yxhlg = new ZQJRQJiHeCanShuModel_yxhlg(gzlx.yxhlg);
        ZQJRQJiHeCanShuModel_qpg zQJRQJiHeCanShuModel_qpg = new ZQJRQJiHeCanShuModel_qpg(gzlx.qpg);
        ZQJRQJiHeCanShuModel_hbg zQJRQJiHeCanShuModel_hbg = new ZQJRQJiHeCanShuModel_hbg(gzlx.hbg);
        ZQJRQJiHeCanShuModel_mbg zQJRQJiHeCanShuModel_mbg = new ZQJRQJiHeCanShuModel_mbg(gzlx.m_bg);
        ZQJRQJiHeCanShuModel_lxxlpg zQJRQJiHeCanShuModel_lxxlpg = new ZQJRQJiHeCanShuModel_lxxlpg(gzlx.lxxlpg);


        public ZhengQiJiaReQiWindow()
        {
            InitializeComponent();
        }

        #region 事件

        //加载事件
        private void ZhengQiJiaReQi_Loaded(object sender, RoutedEventArgs e)
        {
            //部分参数显示
            IsDisplayParams(Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden);
            //数据绑定
            CtrlGrid_BoilerSet.DataContext = zQJRQReLiCanShuModel;
            CtrlGrid_hrqjg.DataContext = zQJRQHuanReQiJieGouModel;
            CtrlGrid_hrgjhcs.DataContext = zQJRQJiHeCanShuBaseModel;

        }

        //选择光管
        private void CtrlRB_gg_Checked(object sender, RoutedEventArgs e)
        {
            //部分参数显示
            IsDisplayParams(Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden);
            //数据绑定
            CtrlGrid_hrgjhcs.DataContext = zQJRQJiHeCanShuBaseModel;
        }

        //选择膜式
        private void CtrlRB_ms_Checked(object sender, RoutedEventArgs e)
        {
            //部分参数显示
            IsDisplayParams(Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden);
            //数据绑定
            CtrlGrid_hrgjhcs.DataContext = zQJRQJiHeCanShuModel_ms;
        }

        //选择方型横肋管
        private void CtrlRB_fxhlg_Checked(object sender, RoutedEventArgs e)
        {
            //部分参数显示
            IsDisplayParams(Visibility.Hidden, Visibility.Hidden, Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden);
            //数据绑定
            CtrlGrid_hrgjhcs.DataContext = zQJRQJiHeCanShuModel_fxhlg;
        }

        //圆型横肋管
        private void CtrlRB_yxhlg_Checked(object sender, RoutedEventArgs e)
        {
            //部分参数显示
            IsDisplayParams(Visibility.Hidden, Visibility.Hidden, Visibility.Visible, Visibility.Hidden, Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden);
            //数据绑定
            CtrlGrid_hrgjhcs.DataContext = zQJRQJiHeCanShuModel_yxhlg;
        }

        //鳍片管
        private void CtrlRB_qpg_Checked(object sender, RoutedEventArgs e)
        {
            //部分参数显示
            IsDisplayParams(Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden);
            //数据绑定
            CtrlGrid_hrgjhcs.DataContext = zQJRQJiHeCanShuModel_qpg;
        }

        //花瓣管
        private void CtrlRB_hbg_Checked(object sender, RoutedEventArgs e)
        {
            //部分参数显示
            IsDisplayParams(Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden);
            //数据绑定
            CtrlGrid_hrgjhcs.DataContext = zQJRQJiHeCanShuModel_hbg;
        }

        //膜—瓣管
        private void CtrlRB_mbg_Checked(object sender, RoutedEventArgs e)
        {
            //部分参数显示
            IsDisplayParams(Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden);
            //数据绑定
            CtrlGrid_hrgjhcs.DataContext = zQJRQJiHeCanShuModel_mbg;
        }

        //螺旋线肋片管
        private void CtrlRB_lxxlpg_Checked(object sender, RoutedEventArgs e)
        {
            //部分参数显示
            IsDisplayParams(Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Visible, Visibility.Visible, Visibility.Visible);
            //数据绑定
            CtrlGrid_hrgjhcs.DataContext = zQJRQJiHeCanShuModel_lxxlpg;
        }

        #endregion

        /// <summary>
        /// 是否显示部分参数
        /// </summary>
        /// <param name="δp">膜片厚度</param>
        /// <param name="hp">膜片高度</param>
        /// <param name="δl">肋片厚度</param>
        /// <param name="wl">肋片宽度</param>
        /// <param name="Dl">肋片外径</param>
        /// <param name="sl">肋片截距</param>
        /// <param name="hq">鳍片高度</param>
        /// <param name="δq">鳍片厚度</param>
        /// <param name="δb">瓣片厚度</param>
        /// <param name="hb">瓣片高度</param>
        /// <param name="lb">瓣片长度</param>
        /// <param name="sb">瓣片间隙</param>
        /// <param name="ssp">瓣片截距</param>
        /// <param name="hq_hp">环圈高度</param>
        /// <param name="hq_z">环圈树</param>
        /// <param name="lj_sp">螺距</param>
        public void IsDisplayParams(Visibility δp, Visibility hp, Visibility δl, Visibility wl, Visibility Dl, Visibility sl, Visibility hq, Visibility δq, Visibility δb, Visibility hb, Visibility lb, Visibility sb, Visibility ssp, Visibility hq_hp, Visibility hq_z, Visibility lj_sp)
        {
            if (Ctrl_P_δp == null)
                return;
            if (δp == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_δp))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_δp);
            else if(δp == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_δp))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_δp);

            if (hp == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_hp))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_hp);
            else if (hp == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_hp))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_hp);

            if (δl == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_δl))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_δl);
            else if (δl == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_δl))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_δl);

            if (wl == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_wl))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_wl);
            else if (wl == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_wl))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_wl);

            if (Dl == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_Dl))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_Dl);
            else if (Dl == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_Dl))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_Dl);

            if (sl == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_sl))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_sl);
            else if (sl == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_sl))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_sl);

            if (hq == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_hq))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_hq);
            else if (hq == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_hq))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_hq);

            if (δq == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_δq))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_δq);
            else if (δq == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_δq))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_δq);

            if (δb == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_δb))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_δb);
            else if (δb == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_δb))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_δb);

            if (hb == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_hb))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_hb);
            else if (hb == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_hb))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_hb);

            if (lb == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_lb))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_lb);
            else if (lb == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_lb))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_lb);

            if (sb == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_sb))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_sb);
            else if (sb == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_sb))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_sb);

            if (ssp == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_ssp))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_ssp);
            else if (ssp == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_ssp))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_ssp);

            if (hq_hp == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_hq_hp))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_hq_hp);
            else if (hq_hp == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_hq_hp))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_hq_hp);

            if (hq_z == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_hq_z))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_hq_z);
            else if (hq_z == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_hq_z))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_hq_z);

            if (lj_sp == Visibility.Visible && !CtrlWP_ParamPanel.Children.Contains(Ctrl_P_lj_sp))
                CtrlWP_ParamPanel.Children.Add(Ctrl_P_lj_sp);
            else if (lj_sp == Visibility.Hidden && CtrlWP_ParamPanel.Children.Contains(Ctrl_P_lj_sp))
                CtrlWP_ParamPanel.Children.Remove(Ctrl_P_lj_sp);
        }

        
    }
}
