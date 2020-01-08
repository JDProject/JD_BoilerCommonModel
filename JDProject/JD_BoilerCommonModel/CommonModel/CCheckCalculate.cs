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
        #region 2.2锅炉热力设计计算  得到排眼焓？？？？
        public int BoilerHeatDesignCalculate(double QT, double Ta, double q5, double etak, double Bp, double Qsl, double ypy, double Hyc, double TT_1,/*调用M模块计算M Add Start*/ List<CHeaterArrange> arranges, double glxs, double VrH, double Vn2H, double Vro2H, double r, int pzfs, int rsqbz, double Htao, double R, double F1, double Qir,/*调用有效辐射面积计算模块 Add Start*/ double p, double Vf, double Vp, double Fslf, double Fbgf, double Fjmp, double Fbgp, double Fslp, double Fp, double s1, double A, double b, double xsl, double xbg, double xp, double ZeTasl, double ZeTabg, double ZeTap, double ycjg, double rlxs, double Fyc, double rn, double rh2o, double Ttn, double Mui3n, double s, double rmzl, double V1, double PeSaip)
        {
            //假定炉膛出口烟温TT_2  ，得到IT_2
            double TT_2 = 0;
            double IT_2 = sss;
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
                //输出调整比例系数(Qsl_1 - Qsl) / Qsl_1，手动调节水冷壁几何参数，重新计算,直到dTempResult<=0.001
                return -1;//给出dTempResult
            }
            double BuAvg = 1.6 * Math.Log((1.4 * Math.Pow(Bu, 2) + Bu + 2) / (1.4 * Math.Pow(Bu, 2) - Bu + 2));
            double F1_1 = (Phi * Bp * Vccp) / (5.67 * Math.Pow(10, -11) * PeSaicp * Math.Pow(Ta, -3)) * Math.Pow((Ta / TT_1 - 1) / (M * Math.Pow(BuAvg, 0.3)), -0.6);
            dTempRestult = Math.Abs((F1_1 - F1) / F1_1);
            if (0.001 < dTempRestult)
            {
                //给定调整比例系数F1_1/F1 ，手动调整壁面过热器、屏式过热器以及炉墙几何参数，重新计算，直到给出dTempResult<=0.001
                return -1;//给出dTempResult
            }
            double Qp = Hp * ypy * qn;
            double Qbg = Hbg * ypy * qn;
            double Qyc = Hyc * ypy * qn;
            return 0;
        }
        #endregion
        #region 2.3锅炉热力校验计算  得到排眼焓？？？？
        public int BoilerHeatCheckCalculate(double QT, double Ta, double q5, double etak, double ypy, double Hyc, double Qsl, /*调用M模块计算M Add Start*/ List<CHeaterArrange> arranges, double glxs, double VrH, double Vn2H, double Vro2H, double r, int pzfs, int rsqbz, double Htao, double R, double F1, double Qir,/*调用有效辐射面积计算模块 Add Start*/ double p, double Vf, double Vp, double Fslf, double Fbgf, double Fjmp, double Fbgp, double Fslp, double Fp, double s1, double A, double b, double xsl, double xbg, double xp, double ZeTasl, double ZeTabg, double ZeTap, double ycjg, double rlxs, double Fyc, double rn, double rh2o, double Ttn, double Mui3n, double s, double rmzl, double V1, double PeSaip)
        {
            //假定TT_2,,得到IT_2
            double TT_2 = 0;
            double IT_2 = dddd;
            double Phi = 0;
            bool bContinue = true;
            double yf = 0, qn = 0;
            double Hslf = 0, Hsl = 0, Hp = 0, Hbg = 0, HT = 0, Bu = 0, PeSaicp = 0;
            do
            {
                double Vccp = (QT - IT_2) / (Ta - TT_2);
                Phi = 1 - q5 / (etak + q5);
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
                yf = (1 - (HT - Hslf) * ypy / HT) * (HT / Hslf);
                qn = Phi * (QT - IT_2) / HT;
                double Qsl_1 = Hslf * yf * qn + (Hsl - Hslf) * ypy * qn;
                double dTempRestult = Math.Abs((Qsl_1 - Qsl) / Qsl_1);
                if (0.0001 < dTempRestult)
                {
                    return -1;//给出dTempResult
                }
                double BuAvg = 1.6 * Math.Log((1.4 * Math.Pow(Bu, 2) + Bu + 2) / (1.4 * Math.Pow(Bu, 2) - Bu + 2));
                double TT_1 = Ta / (1 + M * Math.Pow(BuAvg, 0.3) * Math.Pow((5.67 * Math.Pow(10, -11) * PeSaicp * F1 * Math.Pow(Ta, 3)), 0.6));
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
            yf = (1 - (HT - Hslf) * ypy / HT) * (HT / Hslf);
            qn = Phi * (QT - IT_2) / HT;
            double Qp = Hp * ypy * qn;
            double Qbg = Hbg * ypy * qn;
            double Qyc = Hyc * ypy * qn;
            return 0;
        }
        #endregion
        #region 3.2壁面换热器参数计算 未实现
        public int WallHeatExchangeParameterCalculate()
        {
            //3.2
            return 0;
        }
        #endregion
        #region 4.3屏区参数计算 是否需要
        //4.3
        #endregion
        #region 5.2能量分配（公用方法） 22
        public int EnergyAssignment(double s1, double s2, double Z1, double Z2, double d, double gzlx, double hrqxs, double fsrcd, double Qyc, double Bp, double D1, double H1, double H2)
        {
            double sigMa1 = s1 / d;
            double sigMa2 = s2 / d;
            if ((1 == gzlx && 2 == hrqxs && 3 < sigMa1 && 1.5 > sigMa2) || (2 == gzlx && 3 < sigMa2 && 2 > sigMa2))
            {
                hrqxs = 1;
            }
            double SigMaxp = 0;
            if (1 == hrqxs)
            {
                //由Z1和SigMa1 SigMaxp
                SigMaxp = sss;
                7 - 1
            }
            else
            {
                //由Z2和SigMa2 SigMaxp
                SigMaxp = sss;
                7 - 2
            }
            //调用有效辐射层厚度s或烟气流黑度a计算模块，得到黑度a
            double a = sss;
            double Qn = 0, Q4n = 0;
            if (0 == fsrcd)
            {
                Qn = Qyc / Bp;
                Q4n = 0;
            }
            else
            {
                Qn = Qyc * SigMaxp * (1 - a) / Bp;
                Q4n = Qyc * (1 - SigMaxp * (1 - a)) / Bp;
            }
            double Qt = D1 * (H2 - H1) / Bp;
            double Q = Qt - Qn;
            return 0;
        }
        #endregion
        #region 传热系数（公用方法）11
        public int HeatTransferCofficientCalculate(double hrqxs)
        {//5.3
            double Psi = 0;
            double Epsilon = 0;
            if (1 == hrqxs)
            {
                Psi = 1.0;
                //由rlxs、CaO、chzz、AlphaT、SRFS、调用对流受热污染系数得到Epsilon
            }
            else
            {
                Epsilon = 0;
                //由hrqxs、rlxs、gzlx、CaO、chzz、gttjj调用热利用系数得到Psi
            }
            //由hrqxs、pwz、csfs 调用受热面利用系数计算模块，得到xi
            double xi = 0;
            double HBH = Math.PI * (d - 2 * Deltad) * l * z1 * z2;
            //调用辐射放热系数模块alphan计算
            double alphan = 0;
            //调用对流换热系数模块alphak计算
            double alphat = 0;

            double alpha1 = 0, H = 0;
            //屏
            if (1 == hrqxs)
            {
                if (1 == gzlx)
                {
                    x = 1 - Math.Sqrt(1 - Math.Pow(d / s2, 2)) + d / s2 * Math.Atan(Math.Sqrt(Math.Pow(s2 / d, 2) - 1));
                    alpha1 = xi * (alphak * Math.PI / (2 * sigMa2 * x) + alphan);
                    H = Math.PI * d * l * z1 * z2;
                }
                else if (2 == gzlx)
                {
                    alpha1 = xi * (alphak * (0.57 / sigMa2 + 1) + alphan);
                    H = 2 * l * z1 * z2 * (d * Math.Acos(Deltap / (2 * d)) + 2 * Deltap * l + 4 * hp * l);
                }
            }
            //管束
            else if (2 == hrqxs && 3 == hrqxs)
            {
                //根据管束几何参数，调用放热系数折算模块，得到alpha1,H
            }
            //调用管内换热系数计算模块，得到alpha2

            //传热系数K
            double K = Psi * alpha1 / (1 + (1 + Qn / Q) * (Epsilon + H / (alpha2 * HBH)) * alpha1);
            return 0;
        }
        #endregion
        #region 换热器热力设计计算 11
        public int HeatExchangerDesignCalculate()
        {//5.5
            double P2 = P1 - DeltaPw;
            double P4 = p3 - Deltapf;
            //由P1，T1 得到H1;
            double H1 = 0;
            //由P2，T2 得到H2;
            double H2 = 0;
            //由P3，T3 及烟气成分得到H3;
            double H3 = 0;
            //由P4，T4 得到H4;
            double H4 = 0;
            double Qt = H2 - H1;
            //调用能量分配模块，得到Qn,Qn4  Qt Q

            //根据设置好的结构参数，调用传热系数计算模块，得到传热系数H K
            double K = 0;
            double H = 0;
            //调用温压计算模块，得到Deltat
            double Deltat = 0;
            double H_1 = Qt * Bp / (H * Deltat);
            double dTempResult = Math.Abs((H - H_1) / H_1);
            if (0.001 < dTempResult)
            {
                //手动按偏差比例调整换热器结构参数
            }
            else
            {
                //确定结构参数和Qn4
            }
            return 0;
        }
        #endregion
        #region 换热器热力校核计算 11
        public int HeatExchangerCheckCalculate(double P1, double T1, double P3, double T3, double Gw, double Gf, double DeltaPw, double DeltaPf, List<CHeaterArrange> heaterArranges, double glxs, double rlxs, double pzfs, double rmzl, double qyrl, double Qyc, ref double T2, ref double T4, ref double Qn, ref double Q4n, ref double Qt, ref double Q)
        {//5.6
            bool bContinue = true;
            T2 = 0;//假定T2初值，默认为设计值
            double P2 = P1 - DeltaPw;
            double P4 = P3 - DeltaPf;
            //由P1，T1 得到H1;
            double H1 = 0;
            //由P2，T2 得到H2;
            double H2 = 0;
            //由P3，T3 及烟气成分得到H3;
            double H3 = 0;
            //由P4，T4 得到H4;
            double H4 = 0;
            Qt = H2 - H1;
            do
            {
                //调用能量分配模块，得到Qn,Qn4  Qt Q

                //根据设置好的结构参数，调用传热系数计算模块，得到传热系数H K
                double K = 0;
                double H = 0;
                //调用温压计算模块，得到Deltat
                double Deltat = 0;
                double Qt_1 = K * H * Deltat / Bp;
                double H2_1 = Qt_1 + H1;
                //由H2_1得到T2_1;
                double T2_1 = 0;
                T2 = T2_1;
                double dTempResult = Math.Abs((T2 - T2_1) / T2_1);
                if (0.001 >= dTempResult)
                {
                    bContinue = false;
                }
            }
            while (bContinue);

            return 0;
        }
        #endregion
        #region 省煤器换热系数计算 11
        public int EconomizerHeatExchangeCofficientCalculate(double P1, double P2, double T1, double T2, double P3, double P4, double T3, double T4, double Gf, double hrqxs, double rlxs, double chfs, double l, double n1, double n2, ref double K, ref double Hyq)
        {//6.2

            //Step 1:污染系数计算
            double a = 0;
            if (1 == chfs)
            {
                if (1 == rlxs)
                {
                    a = 0.1;
                }
                else if (2 == rlxs)
                {
                    a = 0.25;
                }
            }
            else if (2 == chfs)
            {
                if (1 == rlxs)
                {
                    a = 0.05;
                }
                else if (2 == rlxs)
                {
                    a = 0.2;
                }
            }
            //Step 2:几何参数计算
            double d1 = 0, d2 = 0, Hd = 0, Flt = 0;
            if (1 == hrqxs)
            {
                d1 = 0.15;
                d2 = 0.15;
                if (1.5 == l)
                {
                    Hd = 2.18;
                    Flt = 0.088;
                }
                else if (2 == l)
                {
                    Hd = 2.95;
                    Flt = 0.12;
                }
                else if (2.5 == l)
                {
                    Hd = 3.72;
                    Flt = 0.152;
                }
                else if (3 == l)
                {
                    Hd = 4.49;
                    Flt = 0.184;
                }
            }
            else if (2 == hrqxs)
            {
                d1 = 0.15;
                d2 = 0.15;
                if (2 == l)
                {
                    Hd = 3.14;
                    Flt = 0.12;
                }
                else if (3 == l)
                {
                    Hd = 4.78;
                    Flt = 0.184;
                }
            }
            else if (3 == hrqxs)
            {
                d1 = 0.243;
                d2 = 0.288;
                if (0.199 == l)
                {
                    Hd = 5.5;
                    Flt = 0.21;
                }
            }
            //烟气侧有效换热面积
            Hyq = n1 * n2 * Hd;
            //烟气侧流通面积
            Fyq = n1 * n2 * Flt;
            //烟气流速
            wyq = Gf / (Rou3 * Fyq);
            //省煤器宽度
            Wyq1 = n1 * d1;
            //省煤器高度
            Wyq2 = n2 * d2;

            //Step 3:换热系数计算
            //由Wyq 和hrqxs,得到KH
            KH = Sos;
            //由
            Tyq = 0.5 * (T3 + T4);
            //利用线算图 5 可以得到温度修正系数
            double CT = ss;
            //换热系数
            K = KH * CT * (1 - a);
            return 0;
        }

        #endregion
        #region 省煤器设计计算 11
        public int EconomizerDesignCalculate(double P1, double P2, double T1, double T2, double P3, double P4, double T3, double Gw, double Gf, double rlxs)
        {//6.3
            P2 = P1 * (1 - xi1);//P2=P1-DeltaPw
            P4 = P3 * (1 - xi3);//P4=P3-Deltafw
            //手动设置hrqxs,chfs,l,n1,n2
            T2 = T3 - DeltaT1;
            //由P1 T1 得到H1
            double H1 = 0;
            //由P2 T2 得到H2
            double H2 = 0;
            //由P3 T3 得到H3
            double H3 = 0;
            //由H1，H2 H3 Gw Gf得到H4 ,由H4得到T4
            double H4 = (H2 - H1) * Gw / Gf;

            //换热量Qt
            double Qt = H2 - H1;

            //调用省煤器换热系数计算模块，得到K Hyq

            //调用温压计算模块，按纯逆流计算，得到Deltat

            //计算所需有效换热面积
            Hyq_1 = Qt * Bp / (K * Deltat);
            double dTempResult = Math.Abs((Hyq - Hyq_1) / Hyq_1);
            if (0.001 < dTempResult)
            {
                //手动按偏差比例调整换热器结构参数
            }
            //确定省煤器结构参数
            return 0;
        }
        #endregion
        #region 省煤器校核计算 11
        public int EconomizerCheckCalculate(double P1, double P2, double T1, double P3, double P4, double T3, double Gw, double Gf, double rlxs, double hrqxs, double chfs, double l, double n1, double n2, ref double T2, ref double T4, ref double Qt)
        {//6.4
         //假定T2初值（默认为设计值）
            P2 = P1 * (1 - xi1);//P2=P1-DeltaPw
            P4 = P3 * (1 - xi3);//P4=P3-Deltafw
            //手动设置hrqxs,chfs,l,n1,n2
            T2 = T3 - DeltaT1;
            //由P1 T1 得到H1
            double H1 = 0;
            //由P2 T2 得到H2
            double H2 = 0;
            //由P3 T3 得到H3
            double H3 = 0;
            //由H1，H2 H3 Gw Gf得到H4 ,由H4得到T4
            double H4 = (H2 - H1) * Gw / Gf;

            //换热量Qt
            double Qt = H2 - H1;
            bool bContinue = true;
            do
            {
                //调用省煤器换热系数计算模块，得到K Hyq

                //调用温压计算模块，按纯逆流计算，得到Deltat

                //计算换热量
                double Qt_1 = K * Deltat * Hyq / Bp;
                H2_1 = Qt_1 + H1;
                //由H2_1  得到T2_1
                double dTempResult = Math.Abs((T2 - T2_1) / T2_1);
                if (0.001 >= dTempResult)
                {
                    bContinue = false;
                }
                else
                {
                    T2 = T2_1;
                }
            }
            while (bContinue);
            //确定 T2  T4  Qt;
            return 0;
        }
        #endregion
        #region 管式空预热器换热系数计算 11
        public int TubularPreheaterCofficientCalaulate(double P1, double P2, double T1, double T2, double P3, double P4, double T3, double T4, double Gf, double hrqxs, double rlxs, double yqgn, double l, double z1, double z2, ref double K)
        {//7.2
            double Fr = 0;
            double csfs = 0;
            double alpha1 = 0;
            double alpha2 = 0;
            double alphan = 0;
            if (1 == yqgn)
            {
                //由 P1、 P2、T1 、T2 和空气参数，调用烟气流通截面积计算模块，得到Fr
                Fr = eee;
                csfs = 1;
                //调用对流换热系数模块计算alpha1
                alpha1 = oo;
            }
            else
            {
                //由 P3、 P4、T3 、T4 和空气参数，调用烟气流通截面积计算模块，得到Fr
                Fr = eee;
                csfs = 2;
                if (300 < (T1 + T2) / 2)
                {
                    //调用辐射放热系数模块计算alphan
                    alphan = dd;
                }
            }
            //调用辐射放热系数模块计算alphak
            double alphak = 0;
            //由 hrqxs、rlxs 、gzlx 、CaO 、chzz 、gttjj ，调用热利用系数计算模块，得到Psi
            double Psi = 0;
            //由 hrqxs、 csfs，调用受热面利用系数计算模块，得到xi
            double xi = 0;
            alpha1 = xi * (alphak + alphan);
            if (2 == yqgn)
            {
                //由 P1、 P2、T1 、T2 和空气参数，调用烟气流通截面积计算模块，得到Fr
                Fr = eee;
                csfs = 1;
                //调用对流换热系数模块计算alpha2
            }
            else
            {
                //由 P3、 P4、T3 、T4 和空气参数，调用烟气流通截面积计算模块，得到Fr
                Fr = eee;
                csfs = 2;
                if (300 < (T3 + T4) / 2)
                {
                    //调用辐射放热系数模块计算alphan
                }
            }
            //调用辐射放热系数模块计算alphak
            double alphak = 0;
            //由 hrqxs、rlxs 、gzlx 、CaO 、chzz 、gttjj ，调用热利用系数计算模块，得到Psi
            double Psi = 0;
            //由 hrqxs、 csfs，调用受热面利用系数计算模块，得到xi
            double xi = 0;
            alpha2 = xi * (alphak + alphan);
            K = psi * alpha1 / (1 + alpha1 / alpha2);

            return 0;
        }
        #endregion
        #region 管式空预器设计计算 11
        public int TubularPreheaterDesignCalculate(double P1, double P2, double T1, double T2, double P3, double P4, double T3, double T4, double Ga, double Gf, double rlxs, double ljxs, double ns)
        {//7.3

            P2 = P1 * (1 - xi1);//或者P2 = P1 - DeltaPw;
            P4 = P3 * (1 - xi3);//或者P4 = P3 - DeltaPf;
            //手动设置hrqxs,yqgn,nx,gzlx,d,Sigmad，s1,s2,l,z1,z2

            T2 = T3 - DeltaT1;

            //由P1  T1得到H1
            double H1 = 0;
            //由P2  T2得到H2
            double H2 = 0;
            //由P3  T3 烟气成分得到H3
            double H3 = 0;

            //由H1  H2  H3  Gw Gf得到H4,由H4得到T4
            H4 = (H2 - H1) * Gw / Gf;
            T4 = 0;
            double F = Math.PI * (d - SigMad) * l * z1 * z2;
            //调用管式空气预热器换热系数计算模块，得到K
            double K = ss;
            //调用温压计算模块，按纯逆流计算，得到Delta
            double Delta = ss;
            //计算所需有效换热面积
            F_1 = Qt * Bp / (K * Delta);
            double dTempResult = Math.Abs((F - F_1) / F_1);
            if (0.001 < dTempResult)
            {
                //手动按偏差比例调正换热器结构参数

            }
            //直到dTempResult<=0.001
            //确定管式空气预热器结构参数
            return 0;
        }
        #endregion
        #region 管式空预器校核计算 11
        public int TubularPreheaterCheckCalaulate(double P1, double P2, double T1, double P3, double P4, double T3, double Ga, double Gf, double hrqxs, double yqgn, double ljxs, double nx, double gzlx, double d, double SigMad, double s1, double s2, double l, double z1, double z2, ref double T2, ref double T4, ref double Qt)
        {
            //假定T2初值，默认为设计值
            P2 = P1 * (1 - xi1);//或者P2 = P1 - DeltaPw;
            P4 = P3 * (1 - xi3);//或者P4 = P3 - DeltaPf;
            //手动设置hrqxs,yqgn,nx,gzlx,d,Sigmad，s1,s2,l,z1,z2

            T2 = T3 - DeltaT1;

            //由P1  T1得到H1
            double H1 = 0;
            //由P2  T2得到H2
            double H2 = 0;
            //由P3  T3 烟气成分得到H3
            double H3 = 0;

            //由H1  H2  H3  Gw Gf得到H4,由H4得到T4
            H4 = (H2 - H1) * Gw / Gf;
            T4 = 0;
            //换热量
            Qt = H2 - H1;
            double F = Math.PI * (d - SigMad) * l * z1 * z2;
            bool bContinue = true;
            do
            {
                //调用管式空气预热器换热系数计算模块，得到K
                double K = ss;
                //调用温压计算模块，按纯逆流计算，得到Delta
                double Delta = ss;
                //计算换热量

                double dTempResult = Math.Abs((T2 - T2_1) / T2_1);
                if (0.001 >= dTempResult)
                {
                    bContinue = false;
                }
                else
                {
                    T2 = T2_1;
                }
            }
            while (bContinue);
            //确定T2, T4 Qt
            return 0;
        }
        #endregion
    }
}
