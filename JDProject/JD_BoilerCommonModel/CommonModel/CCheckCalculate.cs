using System;
using System.Collections.Generic;
using System.Text;

namespace JD_BoilerCommonModel.CommonModel
{
    /// <summary>
    /// 界面数据验证类
    /// </summary>
    public class CCheckCalculate : ICheckCalculate
    {
        #region 验证变形、软化温度CheckSTDT
        /// <summary>
        /// 验证变形、软化温度
        /// </summary>
        /// <param name="ST">软化温度</param>
        /// <param name="DT">变形温度</param>
        /// <param name="TT_2">炉膛出口烟气温度</param>
        /// <param name="ycjg">烟窗结构</param>
        /// <param name="sTipInfo">提示信息</param>
        /// <returns>验证是否成功（0:成功）</returns>
        public int CheckSTDT(double ST, double DT, double TT_2, double ycjg, ref string sTipInfo)
        {
            if (100 > ST - DT)
            {
                if (TT_2 < ST - 100)
                {
                    sTipInfo = "提示1";
                    return -1;
                }
            }
            else
            {
                if (TT_2 < DT)
                {
                    sTipInfo = "提示2";
                    return -2;
                }
            }
            if (1 == ycjg)
            {
                if (TT_2 < DT - 50)
                {
                    sTipInfo = "提示3";
                    return -3;
                }
            }
            return 0;
        }
        #endregion
        #region 验证宽度和深度，计算qa
        /// <summary>
        /// 验证宽度和深度CheckWidthDepth，计算qa
        /// </summary>
        /// <param name="W">容积宽度</param>
        /// <param name="D">容积深度</param>
        /// <param name="Bp">燃料消耗量</param>
        /// <param name="Qnetar">燃料低位发热量</param>
        /// <param name="qamax">炉膛截面最大热负荷</param>
        /// <param name="qamin">炉膛截面最小热负荷</param>
        /// <param name="sTipInfo">提示信息</param>
        /// <returns>验证是否成功（0:成功）</returns>
        public int CheckWidthDepth(double W, double D, double Bp, double Qnetar, double qamax, double qamin, ref string sTipInfo)
        {
            double qa = Bp * Qnetar / (W * D);
            if (qamax < qa)
            {
                sTipInfo = "请减少宽度和深度";
            }
            else if (qamin > qa)
            {
                sTipInfo = "请增大宽度和深度";
            }
            else
            {
                sTipInfo = "宽度和深度设置合理";
            }
            return 0;
        }
        #endregion
        #region 验证高度CheckHeight，计算qv
        /// <summary>
        /// 验证高度，计算qv
        /// </summary>
        /// <param name="H">容积高度</param>
        /// <param name="W">容积宽度</param>
        /// <param name="D">容积深度</param>
        /// <param name="Bp">燃料消耗量</param>
        /// <param name="Qnetar">燃料低位发热量</param>
        /// <param name="qvmax">炉膛容积最大热负荷</param>
        /// <param name="qvmin">炉膛容积最小热负荷</param>
        /// <param name="sTipInfo">提示信息</param>
        /// <returns>验证是否成功（0:成功）</returns>
        public int CheckHeight(double H, double W, double D, double Bp, double Qnetar, double qvmax, double qvmin, ref string sTipInfo)
        {
            double qv = Bp * Qnetar / (W * D * H);
            if (qvmax < qv)
            {
                sTipInfo = "请减少锅炉高度";
            }
            else if (qvmin > qv)
            {
                sTipInfo = "请增加锅炉高度";
            }
            else
            {
                sTipInfo = "锅炉高度设置合理";
            }
            return 0;
        }
        #endregion
        #region 验证出口烟窗高度是否合理CheckExitHeight
        /// <summary>
        /// 验证出口烟窗高度是否合理
        /// </summary>
        /// <param name="hyc">出口烟窗高度</param>
        /// <param name="D">容积深度</param>
        /// <param name="VT_2"></param>
        /// <param name="cycmax">烟气最大流速</param>
        /// <param name="cycmin">烟气最小流速</param>
        /// <param name="sTipInfo">错误信息</param>
        /// <returns>验证是否成功（0:成功）</returns>
        public int CheckExitHeight(double hyc, double D, double VT_2, double cycmax, double cycmin, ref string sTipInfo)
        {
            double cyc = VT_2 / (D * hyc);
            if (cycmax < cyc)
            {
                sTipInfo = "请减少出口烟窗高度";
            }
            else if (cycmin > cyc)
            {
                sTipInfo = "请增大出口烟窗高度";
            }
            else
            {
                sTipInfo = "出口烟窗高度设置合理";
            }
            return 0;
        }
        #endregion
        #region 验证燃烧器布置是否合理CheckHeaterArrang
        /// <summary>
        /// 验证燃烧器布置是否合理
        /// </summary>
        /// <param name="arranges">燃烧器布局参数</param>
        /// <param name="Bp">燃料消耗量</param>
        /// <param name="Qnetar">燃料低位发热量</param>
        /// <param name="W">容积宽度</param>
        /// <param name="D">容积深度</param>
        /// <param name="qrmax">炉膛燃烧器区域壁面最大热负荷</param>
        /// <param name="qrmin">炉膛燃烧器区域壁面最小热负荷</param>
        /// <param name="sTipInfo">提示信息</param>
        /// <returns>验证是否成功（0:成功）</returns>
        public int CheckHeaterArrang(List<CHeaterArrange> arranges, double Bp, double Qnetar, double W, double D, double qrmax, double qrmin, ref string sTipInfo)
        {
            int m = arranges.Count;
            double dTemp = 0;
            //求和
            for (int i = 0; i < m; i++)
            {
                double ni = arranges[i].n;
                double bi = arranges[i].b;
                dTemp += ni * bi * Bp * Qnetar;
            }
            double hm = arranges[m - 1].h;
            double h1 = arranges[0].h;
            double qr = dTemp / (2 * (W + D) * (hm - h1));
            if (qrmax < qr)
            {
                sTipInfo = "燃烧器布置过密";
            }
            else if (qrmin > qr)
            {
                sTipInfo = "燃烧器布置过稀";
            }
            else
            {
                sTipInfo = "燃烧器布置合理";
            }
            return 0;
        }
        #endregion
        #region 验证换热面积是否合理CheckHeaterArea
        /// <summary>
        /// 验证换热面积是否合理CheckHeaterArea
        /// </summary>
        /// <param name="D">容积深度</param>
        /// <param name="hyc">出口烟窗高度</param>
        /// <param name="W">容积宽度</param>
        /// <param name="H">容积高度</param>
        /// <param name="Fsl">水冷壁总面积</param>
        /// <param name="Fbg">壁面过热管总面积</param>
        /// <param name="Fp">屏区容积</param>
        /// <param name="sTipInfo">错误信息</param>
        /// <returns>验证是否成功（0:成功）</returns>
        public int CheckHeaterArea(double D, double hyc, double W, double H, double Fsl, double Fbg, double Fp, ref string sTipInfo)
        {
            double Fyc = D * hyc;
            double Fck = 2 * W * D + 2 * W * H + 2 * D * H;
            double F1 = Fsl + Fbg + Fp + Fyc;
            if (F1 < 0.8 * Fck)
            {
                sTipInfo = "换热面积过小";
            }
            else if (F1 > 1.5 * Fck)
            {
                sTipInfo = "换热面积过大或与炉膛不匹配";
            }
            else
            {
                sTipInfo = "换热面积基本合理";
            }
            return 0;
        }
        #endregion
        #region 锅炉热力设计计算
        public int BoilerHeatDesignCalculate(double Bp, double Qsl)
        {
            double TT_2 = 0;
            double IT_2 = 0;
            double Vccp = (QT - IT_2) / (Ta - TT_2);
            double Phi = 1 - q5 / (etak + q5);
            ICommonModelCalaulate commonModelCalaulate = new CCommonModelCalaulate();
            //List < CHeaterArrange > arranges, double glxs, double VrH, double Vn2H, double Vro2H, double r, int pzfs, int rsqbz, double Htao, double R, double F1, double Qir
            double M = 0;
            //调用M模块计算M
            int ret = commonModelCalaulate.CalculateParameterM(arranges, glxs, VrH, Vn2H, Vro2H, r, pzfs, rsqbz, Htao, R, F1, Qir, ref M);
            if (0 != ret)
            {
                return ret;
            }
            //调用有效辐射面积计算模块
            //double p, double Vf, double Vp, double Fslf, double Fbgf, double Fjmp, double Fbgp, double Fslp, double Fp, double s1, double A, double b, double xsl, double xbg, double xp, double ZeTasl, double ZeTabg, double ZeTap, double ycjg, double rlxs, double Fyc, double rn, double rh2o, double Ttn, double Mui3n, double s, double glxs, double pzfs, double rmzl, double V1, double PeSaip, ref double Hslf, ref double Hsl, ref double Hp, ref double Hbg, ref double Ht, ref double Bu, ref double PeSaicp
            double Hslf = 0, Hsl = 0, Hp = 0, Hbg = 0, HT = 0, Bu = 0, PeSaicp = 0;
            ret = commonModelCalaulate.CalculateEffectiveRadioArea(p, Vf, Vp, Fslf, Fbgf, Fjmp, Fbgp, Fslp, Fp, s1, A, b, xsl, xbg, xp, ZeTasl, ZeTabg, ZeTap, ycjg, rlxs, Fyc, rn, rh2o, Ttn, Mui3n, s, glxs, pzfs, rmzl, V1, PeSaip, ref Hslf, ref Hsl, ref Hp, ref Hbg, ref HT, ref Bu, ref PeSaicp);
            if (0 != ret)
            {
                return ret;
            }
            double yf = (1 - (HT - Hslf) * ypy / HT) * (HT / Hslf);
            double qn = Phi * (QT - IT_2) / HT;
            double Qsl_1 = Hslf * yf * qn + (Hsl - Hslf) * ypy * qn;
            double dTempRestult = Math.Abs((Qsl_1 - Qsl) / Qsl_1);
            if (0.0001 < dTempRestult)
            {
                return -1;//给出dTempResult
            }
            double BuAvg = 1.6 * Math.Log((1.4 * Math.Pow(Bu, 2) + Bu + 2) / (1.4 * Math.Pow(Bu, 2) - Bu + 2));
            double F1_1 = (Phi * Bp * Vccp) / (5.67 * Math.Pow(10, -11) * PeSaicp * Math.Pow(Ta, -3)) * Math.Pow((Ta / TT_1 - 1) / (M * Math.Pow(BuAvg, 0.3)), -0.6);
            dTempRestult = Math.Abs((F1_1 - F1) / F1_1);
            if (0.001 < dTempRestult)
            {
                return -1;//给出dTempResult
            }
            double Qp = Hp * ypy * qn;
            double Qbg = Hbg * ypy * qn;
            double Qyc = Hyc * ypy * qn;
            return 0;
        }
        #endregion
        #region 锅炉热力校验计算
        public int BoilerHeatCheckCalculate()
        {
            double TT_2 = 0;
            double TT_1 = 0;
            double IT_2 = 0;
            bool bContinue = true;
                double Hslf = 0, Hsl = 0, Hp = 0, Hbg = 0, HT = 0, Bu = 0, PeSaicp = 0;
            do
            {
                double Vccp = (QT - IT_2) / (Ta - TT_2);
                double Phi = 1 - q5 / (etak + q5);
                ICommonModelCalaulate commonModelCalaulate = new CCommonModelCalaulate();
                //List < CHeaterArrange > arranges, double glxs, double VrH, double Vn2H, double Vro2H, double r, int pzfs, int rsqbz, double Htao, double R, double F1, double Qir
                double M = 0;
                //调用M模块计算M
                int ret = commonModelCalaulate.CalculateParameterM(arranges, glxs, VrH, Vn2H, Vro2H, r, pzfs, rsqbz, Htao, R, F1, Qir, ref M);
                if (0 != ret)
                {
                    return ret;
                }
                //调用有效辐射面积计算模块
                //double p, double Vf, double Vp, double Fslf, double Fbgf, double Fjmp, double Fbgp, double Fslp, double Fp, double s1, double A, double b, double xsl, double xbg, double xp, double ZeTasl, double ZeTabg, double ZeTap, double ycjg, double rlxs, double Fyc, double rn, double rh2o, double Ttn, double Mui3n, double s, double glxs, double pzfs, double rmzl, double V1, double PeSaip, ref double Hslf, ref double Hsl, ref double Hp, ref double Hbg, ref double Ht, ref double Bu, ref double PeSaicp
                ret = commonModelCalaulate.CalculateEffectiveRadioArea(p, Vf, Vp, Fslf, Fbgf, Fjmp, Fbgp, Fslp, Fp, s1, A, b, xsl, xbg, xp, ZeTasl, ZeTabg, ZeTap, ycjg, rlxs, Fyc, rn, rh2o, Ttn, Mui3n, s, glxs, pzfs, rmzl, V1, PeSaip, ref Hslf, ref Hsl, ref Hp, ref Hbg, ref HT, ref Bu, ref PeSaicp);
                if (0 != ret)
                {
                    return ret;
                }
                double yf = (1 - (HT - Hslf) * ypy / HT) * (HT / Hslf);
                double qn = Phi * (QT - IT_2) / HT;
                double Qsl_1 = Hslf * yf * qn + (Hsl - Hslf) * ypy * qn;
               double dTempRestult = Math.Abs((Qsl_1 - Qsl) / Qsl_1);
                if (0.0001 < dTempRestult)
                {
                    return -1;//给出dTempResult
                }
                double BuAvg = 1.6 * Math.Log((1.4 * Math.Pow(Bu, 2) + Bu + 2) / (1.4 * Math.Pow(Bu, 2) - Bu + 2));
                 TT_1 = Ta / (1 + M * Math.Pow(BuAvg, 0.3) * Math.Pow((5.67 * Math.Pow(10, -11) * PeSaicp * F1 * Math.Pow(Ta, 3)), 0.6));
                dTempRestult = Math.Abs(TT_1 - TT_2);
                if (20 < dTempRestult)
                {
                    TT_2 = TT_1;
                }
                else
                {
                    bContinue = false;
                }
            }
            while (bContinue);
            double yf = (1 - (HT - Hslf) * ypy / HT) * (HT / Hslf);
            double qn = Phi * (QT - IT_2) / HT;
            double Qp = Hp * ypy * qn;
            double Qbg = Hbg * ypy * qn;
            double Qyc = Hyc * ypy * qn;
            return 0;
        }
        #endregion
        #region 壁面换热器参数计算
        public int WallHeatExchangeParameterCalculate()
        {
            //3.2
            return 0;
        }
        #endregion

        #region 屏区参数计算 是否需要
        //4.3
        #endregion

        #region 能量分配（公用方法）
        public int EnergyAssignment()
        {
            //5.2
            return 0;
        }
        #endregion
        #region 传热系数（公用方法）
        public int HeatTransferCofficientCalculate()
        {//5.3
            return 0;
        }
        #endregion
        #region 换热器热力设计计算
        public int HeatExchangerDesignCalculate()
        {//5.5
            return 0;
        }
        #endregion
        #region 换热器热力校核计算
        public int HeatExchangerCheckCalculate()
        {//5.6
            return 0;
        }
        #endregion
        #region 省煤器换热系数计算
        public int EconomizerHeatExchangeCofficientCalculate()
        {//6.2

            //Step 1:污染系数计算

            //Step 2:几何参数计算

            //Step 3:换热系数计算
            return 0;
        }

        #endregion
        #region 省煤器设计计算
        public int EconomizerDesignCalculate()
        {//6.3
            return 0;
        }
        #endregion

        #region 省煤器校核计算
        public int EconomizerCheckCalculate()
        {//6.4
            return 0;
        }
        #endregion

        #region 管式空预热器换热系数计算
        public int TubularPreheaterCofficientCalaulate()
        {//7.2
            return 0;
        }
        #endregion

        #region 管式空预器设计计算
        public int TubularPreheaterDesignCalculate()
        {//7.3
            return 0;
        }
        #endregion
        #region 管式空预器校核计算
        public int TubularPreheaterCheckCalaulate()
        {
            return 0;
        }
        #endregion
    }
}
