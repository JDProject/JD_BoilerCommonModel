using System;
using System.Collections.Generic;
using System.Text;

namespace JD_BoilerCommonModel.CommonModel
{
    #region 模拟屏式受热面角系数表
    /// <summary>
    /// 模拟屏式受热面角系数表帮助类
    /// </summary>
    public class CTableScreenAreaHeatTransferHelper
    {
        /// <summary>
        /// 表中数据集合
        /// </summary>
        private List<CTableScreenAreaHeatTransfer> TableList = new List<CTableScreenAreaHeatTransfer>();
        /// <summary>
        /// 构造函数
        /// </summary>
        public CTableScreenAreaHeatTransferHelper()
        {
            tableDataInit();
        }
        /// <summary>
        /// 初始化表格数据
        /// </summary>
        private void tableDataInit()
        {
            //n=1
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 2.5, 0.490, 0.490));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 5, 0.280, 0.280));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 7.5, 0.193, 0.193));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 10, 0.150, 0.150));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 12.5, 0.123, 0.123));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 15, 0.104, 0.104));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 17.5, 0.089, 0.089));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 20, 0.078, 0.078));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 25, 0.062, 0.062));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 30, 0.053, 0.053));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 35, 0.046, 0.046));
            TableList.Add(new CTableScreenAreaHeatTransfer(1, 40, 0.040, 0.040));
            //n=2
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 2.5, 0.192, 0.682));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 5, 0.155, 0.435));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 7.5, 0.122, 0.315));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 10, 0.100, 0.250));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 12.5, 0.084, 0.207));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 15, 0.071, 0.175));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 17.5, 0.061, 0.150));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 20, 0.054, 0.132));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 25, 0.043, 0.105));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 30, 0.037, 0.090));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 35, 0.032, 0.078));
            TableList.Add(new CTableScreenAreaHeatTransfer(2, 40, 0.029, 0.069));
            //n=3
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 2.5, 0.120, 0.802));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 5, 0.122, 0.557));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 7.5, 0.104, 0.418));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 10, 0.088, 0.338));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 12.5, 0.076, 0.283));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 15, 0.065, 0.240));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 17.5, 0.057, 0.207));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 20, 0.051, 0.183));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 25, 0.041, 0.146));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 30, 0.036, 0.126));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 35, 0.031, 0.109));
            TableList.Add(new CTableScreenAreaHeatTransfer(3, 40, 0.028, 0.097));
            //n=4
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 2.5, 0.075, 0.876));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 5, 0.095, 0.652));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 7.5, 0.088, 0.506));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 10, 0.078, 0.415));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 12.5, 0.069, 0.352));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 15, 0.060, 0.300));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 17.5, 0.053, 0.260));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 20, 0.048, 0.231));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 25, 0.039, 0.185));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 30, 0.034, 0.160));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 35, 0.030, 0.139));
            TableList.Add(new CTableScreenAreaHeatTransfer(4, 40, 0.027, 0.124));
            //n=5
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 5, 0.075, 0.727));
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 7.5, 0.075, 0.581));
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 10, 0.069, 0.485));
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 12.5, 0.062, 0.414));
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 15, 0.055, 0.356));
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 17.5, 0.050, 0.310));
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 20, 0.045, 0.276));
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 25, 0.037, 0.222));
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 30, 0.033, 0.192));
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 35, 0.029, 0.168));
            TableList.Add(new CTableScreenAreaHeatTransfer(5, 40, 0.026, 0.151));
            //n=6
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 5, 0.059, 0.786));
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 7.5, 0.063, 0.644));
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 10, 0.061, 0.545));
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 12.5, 0.056, 0.470));
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 15, 0.051, 0.407));
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 17.5, 0.046, 0.356));
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 20, 0.042, 0.318));
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 25, 0.036, 0.258));
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 30, 0.032, 0.224));
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 35, 0.028, 0.198));
            TableList.Add(new CTableScreenAreaHeatTransfer(6, 40, 0.026, 0.176));
            //n=7
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 5, 0.046, 0.832));
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 7.5, 0.054, 0.698));
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 10, 0.053, 0.599));
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 12.5, 0.051, 0.521));
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 15, 0.047, 0.454));
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 17.5, 0.043, 0.399));
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 20, 0.040, 0.358));
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 25, 0.034, 0.292));
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 30, 0.030, 0.254));
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 35, 0.027, 0.223));
            TableList.Add(new CTableScreenAreaHeatTransfer(7, 40, 0.025, 0.201));
            //n=8
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 5, 0.036, 0.868));
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 7.5, 0.046, 0.744));
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 10, 0.047, 0.646));
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 12.5, 0.046, 0.568));
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 15, 0.043, 0.497));
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 17.5, 0.040, 0.439));
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 20, 0.038, 0.396));
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 25, 0.032, 0.325));
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 30, 0.029, 0.284));
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 35, 0.026, 0.249));
            TableList.Add(new CTableScreenAreaHeatTransfer(8, 40, 0.024, 0.226));
            //n=9
            TableList.Add(new CTableScreenAreaHeatTransfer(9, 7.5, 0.039, 0.782));
            TableList.Add(new CTableScreenAreaHeatTransfer(9, 10, 0.042, 0.688));
            TableList.Add(new CTableScreenAreaHeatTransfer(9, 12.5, 0.042, 0.608));
            TableList.Add(new CTableScreenAreaHeatTransfer(9, 15, 0.040, 0.537));
            TableList.Add(new CTableScreenAreaHeatTransfer(9, 17.5, 0.038, 0.477));
            TableList.Add(new CTableScreenAreaHeatTransfer(9, 20, 0.035, 0.431));
            TableList.Add(new CTableScreenAreaHeatTransfer(9, 25, 0.031, 0.356));
            TableList.Add(new CTableScreenAreaHeatTransfer(9, 30, 0.028, 0.312));
            TableList.Add(new CTableScreenAreaHeatTransfer(9, 35, 0.025, 0.274));
            TableList.Add(new CTableScreenAreaHeatTransfer(9, 40, 0.023, 0.249));
            //n=10
            TableList.Add(new CTableScreenAreaHeatTransfer(10, 7.5, 0.033, 0.815));
            TableList.Add(new CTableScreenAreaHeatTransfer(10, 10, 0.037, 0.724));
            TableList.Add(new CTableScreenAreaHeatTransfer(10, 12.5, 0.038, 0.646));
            TableList.Add(new CTableScreenAreaHeatTransfer(10, 15, 0.037, 0.574));
            TableList.Add(new CTableScreenAreaHeatTransfer(10, 17.5, 0.035, 0.512));
            TableList.Add(new CTableScreenAreaHeatTransfer(10, 20, 0.033, 0.464));
            TableList.Add(new CTableScreenAreaHeatTransfer(10, 25, 0.029, 0.385));
            TableList.Add(new CTableScreenAreaHeatTransfer(10, 30, 0.027, 0.338));
            TableList.Add(new CTableScreenAreaHeatTransfer(10, 35, 0.024, 0.298));
            TableList.Add(new CTableScreenAreaHeatTransfer(10, 40, 0.023, 0.272));
            //n=12
            TableList.Add(new CTableScreenAreaHeatTransfer(12, 7.5, 0.024, 0.867));
            TableList.Add(new CTableScreenAreaHeatTransfer(12, 10, 0.029, 0.785));
            TableList.Add(new CTableScreenAreaHeatTransfer(12, 12.5, 0.031, 0.710));
            TableList.Add(new CTableScreenAreaHeatTransfer(12, 15, 0.031, 0.639));
            TableList.Add(new CTableScreenAreaHeatTransfer(12, 17.5, 0.030, 0.575));
            TableList.Add(new CTableScreenAreaHeatTransfer(12, 20, 0.029, 0.525));
            TableList.Add(new CTableScreenAreaHeatTransfer(12, 25, 0.027, 0.440));
            TableList.Add(new CTableScreenAreaHeatTransfer(12, 30, 0.025, 0.389));
            TableList.Add(new CTableScreenAreaHeatTransfer(12, 35, 0.023, 0.344));
            TableList.Add(new CTableScreenAreaHeatTransfer(12, 40, 0.021, 0.315));
            //n=14
            TableList.Add(new CTableScreenAreaHeatTransfer(14, 10, 0.022, 0.833));
            TableList.Add(new CTableScreenAreaHeatTransfer(14, 12.5, 0.025, 0.763));
            TableList.Add(new CTableScreenAreaHeatTransfer(14, 15, 0.026, 0.694));
            TableList.Add(new CTableScreenAreaHeatTransfer(14, 17.5, 0.026, 0.630));
            TableList.Add(new CTableScreenAreaHeatTransfer(14, 20, 0.026, 0.579));
            TableList.Add(new CTableScreenAreaHeatTransfer(14, 25, 0.024, 0.490));
            TableList.Add(new CTableScreenAreaHeatTransfer(14, 30, 0.023, 0.436));
            TableList.Add(new CTableScreenAreaHeatTransfer(14, 35, 0.021, 0.388));
            TableList.Add(new CTableScreenAreaHeatTransfer(14, 40, 0.020, 0.358));
            //n=16
            TableList.Add(new CTableScreenAreaHeatTransfer(16, 10, 0.017, 0.870));
            TableList.Add(new CTableScreenAreaHeatTransfer(16, 12.5, 0.021, 0.806));
            TableList.Add(new CTableScreenAreaHeatTransfer(16, 15, 0.022, 0.740));
            TableList.Add(new CTableScreenAreaHeatTransfer(16, 17.5, 0.023, 0.678));
            TableList.Add(new CTableScreenAreaHeatTransfer(16, 20, 0.023, 0.627));
            TableList.Add(new CTableScreenAreaHeatTransfer(16, 25, 0.022, 0.536));
            TableList.Add(new CTableScreenAreaHeatTransfer(16, 30, 0.021, 0.479));
            TableList.Add(new CTableScreenAreaHeatTransfer(16, 35, 0.020, 0.428));
            TableList.Add(new CTableScreenAreaHeatTransfer(16, 40, 0.019, 0.394));
            //n=18
            TableList.Add(new CTableScreenAreaHeatTransfer(18, 10, 0.013, 0.699));
            TableList.Add(new CTableScreenAreaHeatTransfer(18, 12.5, 0.017, 0.842));
            TableList.Add(new CTableScreenAreaHeatTransfer(18, 15, 0.019, 0.780));
            TableList.Add(new CTableScreenAreaHeatTransfer(18, 17.5, 0.020, 0.720));
            TableList.Add(new CTableScreenAreaHeatTransfer(18, 20, 0.020, 0.670));
            TableList.Add(new CTableScreenAreaHeatTransfer(18, 25, 0.020, 0.578));
            TableList.Add(new CTableScreenAreaHeatTransfer(18, 30, 0.020, 0.519));
            TableList.Add(new CTableScreenAreaHeatTransfer(18, 35, 0.018, 0.466));
            TableList.Add(new CTableScreenAreaHeatTransfer(18, 40, 0.018, 0.430));
            //n=20
            TableList.Add(new CTableScreenAreaHeatTransfer(20, 12.5, 0.014, 0.870));
            TableList.Add(new CTableScreenAreaHeatTransfer(20, 15, 0.016, 0.813));
            TableList.Add(new CTableScreenAreaHeatTransfer(20, 17.5, 0.018, 0.756));
            TableList.Add(new CTableScreenAreaHeatTransfer(20, 20, 0.018, 0.707));
            TableList.Add(new CTableScreenAreaHeatTransfer(20, 25, 0.018, 0.615));
            TableList.Add(new CTableScreenAreaHeatTransfer(20, 30, 0.018, 0.556));
            TableList.Add(new CTableScreenAreaHeatTransfer(20, 35, 0.017, 0.501));
            TableList.Add(new CTableScreenAreaHeatTransfer(20, 40, 0.017, 0.464));
            //n=25
            TableList.Add(new CTableScreenAreaHeatTransfer(25, 15, 0.011, 0.876));
            TableList.Add(new CTableScreenAreaHeatTransfer(25, 17.5, 0.012, 0.827));
            TableList.Add(new CTableScreenAreaHeatTransfer(25, 20, 0.013, 0.783));
            TableList.Add(new CTableScreenAreaHeatTransfer(25, 25, 0.015, 0.696));
            TableList.Add(new CTableScreenAreaHeatTransfer(25, 30, 0.015, 0.636));
            TableList.Add(new CTableScreenAreaHeatTransfer(25, 35, 0.015, 0.579));
            TableList.Add(new CTableScreenAreaHeatTransfer(25, 40, 0.014, 0.540));
            //n=30
            TableList.Add(new CTableScreenAreaHeatTransfer(30, 17.5, 0.009, 0.878));
            TableList.Add(new CTableScreenAreaHeatTransfer(30, 20, 0.010, 0.840));
            TableList.Add(new CTableScreenAreaHeatTransfer(30, 25, 0.012, 0.759));
            TableList.Add(new CTableScreenAreaHeatTransfer(30, 30, 0.012, 0.702));
            TableList.Add(new CTableScreenAreaHeatTransfer(30, 35, 0.012, 0.645));
            TableList.Add(new CTableScreenAreaHeatTransfer(30, 40, 0.012, 0.606));
            //n=35
            TableList.Add(new CTableScreenAreaHeatTransfer(35, 25, 0.009, 0.810));
            TableList.Add(new CTableScreenAreaHeatTransfer(35, 30, 0.010, 0.756));
            TableList.Add(new CTableScreenAreaHeatTransfer(35, 35, 0.010, 0.701));
            TableList.Add(new CTableScreenAreaHeatTransfer(35, 40, 0.010, 0.662));
            //n=40
            TableList.Add(new CTableScreenAreaHeatTransfer(40, 25, 0.007, 0.850));
            TableList.Add(new CTableScreenAreaHeatTransfer(40, 30, 0.008, 0.800));
            TableList.Add(new CTableScreenAreaHeatTransfer(40, 35, 0.009, 0.748));
            TableList.Add(new CTableScreenAreaHeatTransfer(40, 40, 0.009, 0.710));
            //n=45
            TableList.Add(new CTableScreenAreaHeatTransfer(45, 30, 0.006, 0.836));
            TableList.Add(new CTableScreenAreaHeatTransfer(45, 35, 0.007, 0.787));
            TableList.Add(new CTableScreenAreaHeatTransfer(45, 40, 0.008, 0.751));
            //n=50
            TableList.Add(new CTableScreenAreaHeatTransfer(50, 35, 0.006, 0.821));
            TableList.Add(new CTableScreenAreaHeatTransfer(50, 40, 0.007, 0.786));
            //n=55
            TableList.Add(new CTableScreenAreaHeatTransfer(55, 35, 0.005, 0.849));
            TableList.Add(new CTableScreenAreaHeatTransfer(55, 40, 0.006, 0.817));
            //n=60
            TableList.Add(new CTableScreenAreaHeatTransfer(60, 40, 0.005, 0.843));
        }
        /// <summary>
        /// 模拟表7-1,查询SigMaxp
        /// </summary>
        /// <param name="n"></param>
        /// <param name="SigMa1"></param>
        /// <param name="SigMaxp"></param>
        /// <returns></returns>
        public int GetSigMaxp(double n, double SigMa1, ref double xp, ref double SigMaxp)
        {
            int ret = -1;
            double xpTemp = 0;
            double SigMaxpTemp = 0;
            foreach (CTableScreenAreaHeatTransfer table in TableList)
            {
                ret = table.GetxpAndSigMaxp(n, SigMa1, ref xpTemp, ref SigMaxpTemp);
                if (0 == ret)
                {
                    xp = xpTemp;
                    SigMaxp = SigMaxpTemp;
                    return 0;
                }
            }
            return ret;
        }
    }

    /// <summary>
    /// 模拟屏式受热面角系数表中数据类
    /// </summary>
    public class CTableScreenAreaHeatTransfer
    {
        #region Properities
        /// <summary>
        /// SigMa1值
        /// </summary>
        private double dSigMa1;
        /// <summary>
        /// 管排序号n
        /// </summary>
        private double dn;
        /// <summary>
        /// 角系数xp
        /// </summary>
        private double dxp;
        /// <summary>
        /// 角系数和
        /// </summary>
        private double dSigMaxp;
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n"></param>
        /// <param name="SigMa1"></param>
        /// <param name="xp"></param>
        /// <param name="SigMaxp"></param>
        public CTableScreenAreaHeatTransfer(double n, double SigMa1, double xp, double SigMaxp)
        {
            dn = n;
            dSigMa1 = SigMa1;
            dxp = xp;
            dSigMaxp = SigMaxp;
        }
        /// <summary>
        /// 查找xp的值
        /// </summary>
        /// <param name="SigMa1"></param>
        /// <param name="n"></param>
        /// <param name="xp"></param>
        /// <param name="SigMaxp"></param>
        /// <returns></returns>
        public int GetxpAndSigMaxp(double SigMa1, double n, ref double xp, ref double SigMaxp)
        {
            if (dSigMa1 == SigMa1 && dn == n)
            {
                xp = dxp;
                SigMa1 = dSigMa1;
                return 0;
            }
            return -1;
        }
    }
    #endregion
    #region 钢种数据信息类
    /// <summary>
    /// 钢种数据帮助类
    /// </summary>
    public class CTableGangzhongDataHelper
    {
        #region  Private  Properties And Methoeds
        /// <summary>
        /// 钢种数据集合
        /// </summary>
        private List<CGangZhongData> gangZhongDatasList = new List<CGangZhongData>();
        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        private int DataInit()
        {
            gangZhongDatasList.Clear();
            AddGangZhong(EGangZhong.gz_Gang3, -3.32, 55.0, 0);
            AddGangZhong(EGangZhong.gz_Gang10_20, -2.47, 52.5, 0);
            AddGangZhong(EGangZhong.gz_12X1M_12XM, -2.47, 42.2, 300);
            AddGangZhong(EGangZhong.gz_12XM_15XM, -1.85, 38.7, 300);
            AddGangZhong(EGangZhong.gz_12_2MCP, -1.16, 33.6, 300);
            AddGangZhong(EGangZhong.gz_11X11B2M, -1.16, 24.0, 300);
            AddGangZhong(EGangZhong.gz_12X18H10T_12X18H12T, 1.62, 21.3, 400);
            AddGangZhong(EGangZhong.gz_12X14H14B2M, 1.51, 20.0, 400);
            AddGangZhong(EGangZhong.gz_09X14H19B25P, 1.51, 20.0, 400);
            return 0;
        }
        #endregion
        #region Public Methodes
        /// <summary>
        /// 默认构造方式
        /// </summary>
        public CTableGangzhongDataHelper()
        {
            DataInit();
        }
        /// <summary>
        /// 查询钢种数据
        /// </summary>
        /// <param name="gz">钢种类型</param>
        /// <param name="A">A</param>
        /// <param name="B">B</param>
        /// <param name="thcx">基准温度</param>
        /// <returns>是否查询成功（0：成功）</returns>
        public int GetGangZhongData(EGangZhong gz, ref double A, ref double B, ref double thcx)
        {
            foreach (CGangZhongData gzData in gangZhongDatasList)
            {
                if (gz == gzData.eGangZhong)
                {
                    A = gzData.A;
                    B = gzData.B;
                    thcx = gzData.thcx;
                    return 0;
                }
            }
            return -1;
        }
        /// <summary>
        /// 添加一种钢种数据
        /// </summary>
        /// <param name="gz">钢种类型</param>
        /// <param name="A">A</param>
        /// <param name="B">B</param>
        /// <param name="thcx">基准温度</param>
        /// <returns>是否添加成功（0：成功）</returns>
        public int AddGangZhong(EGangZhong gz, double A, double B, double thcx)
        {
            gangZhongDatasList.Add(new CGangZhongData(gz, A, B, thcx));
            return 0;
        }
        #endregion
    }
    #region 钢种数据类
    /// <summary>
    /// 钢种数据类
    /// </summary>
    public class CGangZhongData
    {
        #region 属性
        /// <summary>
        /// 钢种类型
        /// </summary>
        public EGangZhong eGangZhong
        {
            set; get;
        }
        /// <summary>
        /// A（W/(m*K2)）
        /// </summary>
        public double A
        {
            set; get;
        }
        /// <summary>
        /// B（W/(m*K2)）
        /// </summary>
        public double B
        {
            set; get;
        }
        /// <summary>
        /// 基准温度
        /// </summary>
        public double thcx
        {
            set; get;
        }
        #endregion
        /// <summary>
        /// 构造方式
        /// </summary>
        /// <param name="gz">钢种类型</param>
        /// <param name="da">A</param>
        /// <param name="db">B</param>
        /// <param name="dt">基准温度</param>
        public CGangZhongData(EGangZhong gz, double da, double db, double dt)
        {
            eGangZhong = gz;
            A = da;
            B = db;
            thcx = dt;
        }
    }
    /// <summary>
    /// 钢种类型
    /// </summary>
    public enum EGangZhong
    {
        gz_Gang3,
        gz_Gang10_20,
        gz_12X1M_12XM,
        gz_12XM_15XM,
        gz_12_2MCP,
        gz_11X11B2M,
        gz_12X18H10T_12X18H12T,
        gz_12X14H14B2M,
        gz_09X14H19B25P
    }
    #endregion
    #endregion
    #region 肋片有效系数计算
    /// <summary>
    /// 肋片有效系数计算帮助类
    /// </summary>
    public class CTableEHelper
    {
        #region Private  Properties And Methods
        private List<CTableEData> EDataList = new List<CTableEData>();
        private int DataInit()
        {
            EDataList.Clear();
            AddData(3.5, 0.75, 0.2, 1.007);
            AddData(3.5, 0.75, 0.26, 1.011);
            AddData(3.5, 0.75, 0.34, 1.017);
            AddData(3.5, 0.75, 0.4, 1.023);

            AddData(3.5, 1.0, 0.2,1.007);
            AddData(3.5, 1.0, 0.26,1.012);
            AddData(3.5, 1.0, 0.34,1.021);
            AddData(3.5, 1.0, 0.4,1.030);

            AddData(3.5, 1.25, 0.2,0.994);
            AddData(3.5, 1.25, 0.26,1.001);
            AddData(3.5, 1.25, 0.34,1.013);
            AddData(3.5, 1.25, 0.4,1.025);

            AddData(3.5, 1.5, 0.2,0.967);
            AddData(3.5, 1.5, 0.26,0.977);
            AddData(3.5, 1.5, 0.34,0.993);
            AddData(3.5, 1.5, 0.4,1.007);

            AddData(5.0, 0.75, 0.2, 0.967);
            AddData(5.0, 0.75, 0.26, 0.978);
            AddData(5.0, 0.75, 0.34, 0.993);
            AddData(5.0, 0.75, 0.4, 1.005);

            AddData(5.0, 1.0, 0.2,1.009);
            AddData(5.0, 1.0, 0.26,1.018);
            AddData(5.0, 1.0, 0.34,1.034);
            AddData(5.0, 1.0, 0.4,1.047);

            AddData(5.0, 1.25, 0.2,1.026);
            AddData(5.0, 1.25, 0.26,1.036);
            AddData(5.0, 1.25, 0.34,1.053);
            AddData(5.0, 1.25, 0.4,1.068);

            AddData(5.0, 1.5, 0.2,1.019);
            AddData(5.0, 1.5, 0.26,1.031);
            AddData(5.0, 1.5, 0.34,1.051);
            AddData(5.0, 1.5, 0.4,1.068);

            AddData(6.5, 0.75, 0.2, 0.924);
            AddData(6.5, 0.75, 0.26, 0.940);
            AddData(6.5, 0.75, 0.34, 0.961);
            AddData(6.5, 0.75, 0.4, 0.978);

            AddData(6.5, 1.0, 0.2,0.996);
            AddData(6.5, 1.0, 0.26,1.009);
            AddData(6.5, 1.0, 0.34,1.029);
            AddData(6.5, 1.0, 0.4,1.046);

            AddData(6.5, 1.25, 0.2,1.035);
            AddData(6.5, 1.25, 0.26,1.048);
            AddData(6.5, 1.25, 0.34,1.068);
            AddData(6.5, 1.25, 0.4,1.086);

            AddData(6.5, 1.5, 0.2,1.042);
            AddData(6.5, 1.5, 0.26,1.056);
            AddData(6.5, 1.5, 0.34,1.078);
            AddData(6.5, 1.5, 0.4,1.097);

            AddData(8.0, 0.75, 0.2, 0.878);
            AddData(8.0, 0.75, 0.26, 0.896);
            AddData(8.0, 0.75, 0.34, 0.921);
            AddData(8.0, 0.75, 0.4, 0.942);

            AddData(8.0, 1.0, 0.2,0.967);
            AddData(8.0, 1.0, 0.26,0.983);
            AddData(8.0, 1.0, 0.34,1.008);
            AddData(8.0, 1.0, 0.4,1.028);

            AddData(8.0, 1.25, 0.2,1.019);
            AddData(8.0, 1.25, 0.26,1.035);
            AddData(8.0, 1.25, 0.34,1.059);
            AddData(8.0, 1.25, 0.4,1.079);

            AddData(8.0, 1.5, 0.2,1.035);
            AddData(8.0, 1.5, 0.26,1.051);
            AddData(8.0, 1.5, 0.34,1.075);
            AddData(8.0, 1.5, 0.4,1.096);

            return 0;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// 获得肋片有效系数E
        /// </summary>
        /// <param name="dlb_b">lb_d</param>
        /// <param name="dhb_d">hb_d</param>
        /// <param name="dsp_d">sp_d</param>
        /// <param name="E">E</param>
        /// <returns>是否查询成功</returns>
        public int GetE(double dlb_b, double dhb_d, double dsp_d, ref double E)
        {
            foreach (CTableEData data in EDataList)
            {
                if (dlb_b == data.lb_d && dhb_d == data.hb_d && dsp_d == data.Sp_d)
                {
                    E = data.E;
                    return 0;
                }
            }
            return -1;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dlb_b">lb_d</param>
        /// <param name="dhb_d">hb_d</param>
        /// <param name="dsp_d">sp_d</param>
        /// <param name="E">E</param>
        /// <returns>是否添加成功</returns>
        public int AddData(double dlb_b, double dhb_d, double dsp_d, double dE)
        {
            EDataList.Add(new CTableEData(dlb_b, dhb_d, dsp_d, dE));
            return 0;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public CTableEHelper()
        {
            EDataList.Clear();
            DataInit();
        }
        #endregion
    }
    /// <summary>
    /// 肋片有效系数类
    /// </summary>
    public class CTableEData
    {
        #region Properties
        /// <summary>
        /// lb/d
        /// </summary>
        public double lb_d
        {
            set; get;
        }
        /// <summary>
        /// hb/d
        /// </summary>
        public double hb_d
        {
            set; get;
        }
        /// <summary>
        /// sp/d
        /// </summary>
        public double Sp_d
        {
            set; get;
        }
        /// <summary>
        /// E
        /// </summary>
        public double E
        {
            set; get;
        }
        #endregion
        #region Public Methods
        public CTableEData(double dlb_b, double dhb_d, double dsp_d, double dE)
        {
            this.lb_d = dlb_b;
            this.hb_d = dhb_d;
            this.Sp_d = dsp_d;
            this.E = dE;
        }
        #endregion
    }
    #endregion
}
