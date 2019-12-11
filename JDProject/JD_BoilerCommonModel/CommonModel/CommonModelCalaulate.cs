using System;
using System.Collections.Generic;
using System.Text;

namespace JD_BoilerCommonModel.CommonModel
{
    /// <summary>
    /// 锅炉热力计算通用模型
    /// </summary>
    public class CCommonModelCalaulate
    {
        #region 1.有效辐射面积计算
        /// <summary>
        /// 有效辐射面积计算
        /// </summary>
        /// <param name="p">压力p</param>
        /// <param name="Vf">炉膛自由容积Vf</param>
        /// <param name="Vp">屏区面积Vp</param>
        /// <param name="Fslf">自由容积水冷壁面积Fslf</param>
        /// <param name="Fbgf">自由容积过热管面积Fbgf</param>
        /// <param name="Fjmp">屏区与自由空间界面面积Fjmp</param>
        /// <param name="Fbgp">屏区过热管面积Fbgp</param>
        /// <param name="Fslp">屏区水冷壁面积Fslp</param>
        /// <param name="Fp">屏面积Fp</param>
        /// <param name="s1">屏参数：节距s1</param>
        /// <param name="A">屏参数：高度A</param>
        /// <param name="b">屏参数：宽度b</param>
        /// <param name="xsl">角系数：Xsl</param>
        /// <param name="xbg">角系数：Xbg</param>
        /// <param name="xp">角系数：Xp</param>
        /// <param name="ZeTasl">热有效系数：ZETAsl</param>
        /// <param name="ZeTabg">热有效系数：ZETAbg</param>
        /// <param name="ZeTap">热有效系数：ZETAp</param>
        /// <param name="ycjg">烟窗结构ycjg</param>
        /// <param name="rlxs">燃料型式rlxs</param>
        /// <param name="Hslf">结果参数:Hslf</param>
        /// <param name="Hsl">结果参数:Hsl</param>
        /// <param name="Hp">结果参数:Hp</param>
        /// <param name="Hbg">结果参数:Hbg</param>
        /// <param name="Ht">结果参数:Ht</param>
        /// <param name="Bu">结果参数:Bu</param>
        /// <param name="PeSaicp">结果参数:PeSaicp</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public static int CalculateEffectiveRadioArea(double p, double Vf, double Vp, double Fslf, double Fbgf, double Fjmp, double Fbgp, double Fslp, double Fp, double s1, double A, double b, double xsl, double xbg, double xp, double ZeTasl, double ZeTabg, double ZeTap, double ycjg, double rlxs, out double Hslf, out double Hsl, out double Hp, out double Hbg, out double Ht, out double Bu, out double PeSaicp)
        {
            //Step1:计算炉膛自由容积的有效辐射层厚度Sf
            double sf = (3.6 * Vf) / (Fslf + Fbgf + Fjmp);
            //Step2:由p和Sf调用固体燃料辐射减弱系数计算模块(CalculateSolidFuelWeakenCoefficent)得到Kf
            double kf = 0;
            // CalculateSolidFuelWeakenCoefficent(,)参数不全Hxp20191208
            //Step3:CalculateSolidFuelWeakenCoefficent炉膛自由容积黑度Af
            double af = 1 - Math.Exp(kf * p * sf);
            //Step4:计算屏间容积有效辐射厚度Sp
            double sp = 1.8 / (1 / A + 1 / s1 + 1 / b);
            //Step5:由p和Sp调用固体燃料辐射减弱系数计算模块(CalculateSolidFuelWeakenCoefficent)得到Kp
            double kp = 0;
            CalculateSolidFuelWeakenCoefficent();
            //Step6:计算炉膛屏区黑度Ap
            double ap = 1 - Math.Exp(kp * p * sp);
            //Step7:计算Bu
            Bu = (Vf * (1 - af) + Vp * (1 - ap)) / V1;
            //Step8:计算辐射角系数Cslp
            double Cslp = Math.Sqrt(Math.Pow(b / s1, 2) + 1) - b / s1;
            double Cp = 1 - Cslp;
            //Step9:计算屏的曝光不均匀系数Zp
            double zp = ap / af + Cp * (1 - ap);
            //Step10:计算计算屏区水冷壁曝光不均匀系数Zslp
            double Zslp = ap / af + Cslp * (1 - ap);
            //Step11:计算屏区过热管曝光不均匀系数Zbgp
            double Zbgp = ap / af + Cslp * (1 - ap);
            //Step12:计算炉膛自由容积有效辐射面积Hslf
            Hslf = Fslf * xsl;
            //Step13:计算水冷壁有效辐射面积Hsl
            Hsl = Hslf + Fslp * xsl * Zslp;
            //Step14:计算水冷壁热有效系数PeSaisl
            double PeSaisl = (Fslf * xsl * ZeTasl + Fslp * xsl * Zslp * ZeTasl) / Fsl;
            //Step15:计算过热管有效辐射面积Hbg
            Hbg = Fbgf * xbg + Fbgp * xbg * Zbgp;
            //Step16:计算过热管热有效系数PeSaibg
            double PeSaibg = (Fbgf * xbg * ZeTabg + Fbgp * xbg * Zbgp * ZeTabg) / Fbg;
            //Step17:计算屏的有效辐射面积Hp
            Hp = Fp * xp * zp;
            //Step18:计算屏的热有效系数PeSaip
            PeSaicp = xp * zp * ZeTap;
            //Step19:计算根据烟窗后的设备得到BaiTa
            double Zetayc = -1;
            if (0 == ycjg)
            {
                Zetayc = 0.5;
            }
            else if (1 == ycjg)
            {
                if (1 == rlxs)
                {
                    Zetayc = 0.6 * ZeTasl;
                }
                else if (2 == rlxs || 3 == rlxs)
                {
                    Zetayc = 0.8 * ZeTasl;
                }
            }
            else if (2 == ycjg)
            {
                Zetayc = 0.9 * ZeTasl;
            }
            else if (3 == ycjg)
            {
                Zetayc = ZeTasl;
            }
            //Step20:参照锅炉热力计算标准6-06（p34）
            double xyc = 1;
            //Step21:计算烟窗有效辐射面积Hyc
            double Hyc = xyc * Fyc;
            //Step22:计算烟窗热有效系数PeSaiyc
            double dPeSaiyc = xyc * Zetayc;
            //Step23:计算平均热有效系数PeSaicp
            PeSaicp = (PeSaisl * Fsl + PeSaibg * Fbg + PeSaip * Fp + dPeSaiyc * Fyc) / F1;
            //Step7:计算总的有效辐射面积Ht
            Ht = Hsl + Hp + Hbg + Hyc;
            return 0;
        }
        #endregion

        #region 2.炉膛参数M计算
        /// <summary>
        /// 炉膛参数M计算
        /// </summary>
        /// <param name="Num">燃烧器布局参数：数量</param>
        /// <param name="Q">燃烧器布局参数：燃料量</param>
        /// <param name="Q2">燃烧器布局参数：热量</param>
        /// <param name="H">燃烧器布局参数：高度</param>
        /// <param name="glxs">锅炉形式glxs</param>
        /// <param name="VrH">炉膛出口烟气容积VrH</param>
        /// <param name="Vn2H">Vn2H</param>
        /// <param name="Vro2H">Vro2H</param>
        /// <param name="r">烟气再循环系数r</param>
        /// <param name="pzfs">排渣方式pzfs</param>
        /// <param name="rsqbz">燃烧器布置形式rsqbz</param>
        /// <param name="M">炉膛参数M</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public static int CalculateParameterM(double Num, double Q, double Q2, double H, double glxs, double VrH, double Vn2H, double Vro2H, double r, int pzfs, int rsqbz, out double M)
        {
            int ret = 0;
            //Step1:燃烧器平均布置标高
            double ht = 0;//?
            //Step2:计算燃烧器相对标高Xt
            double Xt = 0;
            if (3 == glxs)
            {
                Xt = 0;
            }
            else
            {
                Xt = ht / Ht;
            }
            //Step3:炉内烟气惰性成分参数Rv
            double rv = (VrH * (1 + r)) / (Vn2H + Vro2H);
            //Step4:计算M0
            double M0 = 0;
            if (0 == pzfs && 1 == glxs)
            {
                if (1 == rsqbz)
                {
                    M0 = 0.42;
                }
                else if (2 == rsqbz || 3 == rsqbz)
                {
                    M0 = 0.46;
                }
                else
                {
                    ret = -2;
                }
            }
            else if (1 == pzfs && 1 == glxs)
            {
                M0 = 0.44;
            }
            else if (3 == glxs)
            {
                M0 = 0.46;
            }
            else if (1 == rsqbz && 4 == glxs)
            {
                M0 = 0.40;
            }
            else if (4 == rsqbz && 4 == glxs)
            {
                M0 = 0.36;
            }
            else
            {
                ret = -3;
            }

            //Step5:计算M
            if (1 == glxs || 2 == glxs)
            {
                M = M0 * (1 - 0.4 * Xt) * Math.Pow(rv, 1 / 3);
            }
            else if (3 == glxs)
            {
                M = M0 * (1 + R / F1) * Math.Pow(rv, 1 / 3);
            }
            else
            {
                M = ret = -4;
            }
            return ret;
        }
        #endregion

        #region 3.固体燃料辐射减弱系数K计算
        /// <summary>
        /// 固体燃料辐射减弱系数K计算
        /// </summary>
        /// <param name="rn">三原子气体的总容积份额rn=rh2o+rro2</param>
        /// <param name="rh2o">烟气中水蒸气容积份额rh2o</param>
        /// <param name="p">炉膛内压力p(MPa)</param>
        /// <param name="Ttn">炉膛出口烟气温度Ttn(K)</param>
        /// <param name="Mui3n">烟气飞灰浓度Mui3n</param>
        /// <param name="s">有效辐射层厚度s</param>
        /// <param name="glxs">锅炉形式glxs</param>
        /// <param name="pzfs">排渣方式pzfs</param>
        /// <param name="rmzl">燃煤种类rmzl</param>
        /// <param name="K">辐射减弱系数K</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        private static int CalculateSolidFuelWeakenCoefficent(double rn, double rh2o, double p, double Ttn, double Mui3n, double s, double glxs, double pzfs, double rmzl, out double K)
        {
            int ret = 0;
            //Step1:燃烧产物气相的辐射减弱系数kr
            double kr = ((7.8 + 16 * rh2o) / Math.Sqrt(10 * p * rn * s) - 1) * (1 - 0.37 * Ttn * Math.Pow(10, -3));
            //Step2:计算A3n
            double A3n = 0;
            if (0 == pzfs)
            {
                if (1 == rmzl)
                {
                    A3n = 1.0;
                }
                else if (2 == rmzl || 3 == rmzl)
                {
                    A3n = 0.8;
                }
                else if (4 == rmzl || 5 == rmzl)
                {
                    A3n = 0.75;
                }
                else if (6 == rmzl)
                {
                    A3n = 0.6;
                }
                else
                {
                    ret = -1;
                }
            }
            else if (1 == pzfs)
            {
                if (1 == rmzl)
                {
                    A3n = 1.1;
                }
                else if (2 == rmzl || 3 == rmzl)
                {
                    A3n = 0.9;
                }
                else if (4 == rmzl || 5 == rmzl)
                {
                    A3n = 0.85;
                }
                else if (6 == rmzl)
                {
                    A3n = 0.7;
                }
                else
                {
                    ret = -2;
                }
            }
            //Step3:计算灰粒子辐射减弱系数k3nMui3n
            double k3nMui3n = (Math.Pow(10, 4) * A3n / Math.Pow((Math.Pow(Ttn, 2)), 1 / 3)) * (Mui3n / (1 + 1.2 * Math.Pow(Mui3n, s)));
            //Step3:计算kjtMuijt
            double kjtMuijt = 0;
            if (1 == glxs || 2 == glxs)
            {
                if (1 == rmzl || 3 == rmzl)
                {
                    kjtMuijt = 0.25;
                }
                else if (2 == rmzl)
                {
                    kjtMuijt = 0.1;
                }
                else
                {
                    ret = -3;
                }
            }
            else
            {
                kjtMuijt = 0;
            }
            K = kr + k3nMui3n + kjtMuijt;
            return ret;
        }
        #endregion

        #region 4.气体或液体燃料辐射减弱系数K计算
        /// <summary>
        ///  气体或液体燃料辐射减弱系数K计算
        /// </summary>
        /// <param name="dRn">三原子气体的总容积份额Rn=Rh2o+Rro2</param>
        /// <param name="dRh2o">烟气中水蒸气容积份额Rh2o</param>
        /// <param name="dP">炉膛内压力P(MPa)</param>
        /// <param name="dTtn">炉膛出口烟气温度Ttn(K)</param>
        /// <param name="ds">有效辐射层厚度s</param>
        /// <param name="dAlphat">炉膛出口过量空气系数Alphat</param>
        /// <param name="dCH">燃料应用基碳氢比</param>
        /// <param name="dglxs">锅炉形式glxs</param>
        /// <param name="dpzfs">排渣方式pzfs</param>
        /// <param name="dqyrl">气液燃料种类qyrl</param>
        /// <param name="dK">辐射减弱系数K</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        private static int CalculateGasOrLiquidFuelWeakenCoefficent(double dRn, double dRh2o, double dP, double dTtn, double ds, double dAlphat, double dCH, double dglxs, double dpzfs, double dqyrl, out double dK)
        {
            dK = 0;
            return 0;
        }
        #endregion

        #region 5.炉膛污染系数ZeTa计算
        /// <summary>
        /// 5.炉膛污染系数zeta计算
        /// </summary>
        /// <param name="dgzlx">管子类型gzlx</param>
        /// <param name="dpzfs">排渣方式pzfs</param>
        /// <param name="dFT">灰熔点温度FT</param>
        /// <param name="dglxs">锅炉型式glxs</param>
        /// <param name="drlxs">燃料型式rlxs</param>
        /// <param name="dsrfs">受热方式srfs</param>
        /// <param name="dZeTa">炉膛污染系数ZeTa</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        private static int CalculatePollutionCoefficient(double dgzlx, double dpzfs, double dFT, double dglxs, double drlxs, double dsrfs, out double dZeTa)
        {
            dZeTa = 0;
            return 0;
        }
        #endregion

        #region 6.水冷壁有效角系数计算
        /// <summary>
        /// 6.水冷壁有效角系数计算
        /// </summary>
        /// <param name="dgzlx">管子类型gzlx</param>
        /// <param name="dsrfs">受热方式srfs</param>
        /// <param name="dd">几何参数d</param>
        /// <param name="ds">几何参数s</param>
        /// <param name="dn">几何参数n</param>
        /// <param name="de">几何参数e</param>
        /// <param name="dx">水冷壁有效角系数x</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        private static int CalculateWaterCooledWallEffiectiveCoefficient(double dgzlx, double dsrfs, double dd, double ds, double dn, double de, out double dx)
        {
            dx = 0;
            return 0;
        }
        #endregion

        #region 7.屏区容积与面积计算
        /// <summary>
        /// 7.屏区容积与面积计算
        /// </summary>
        /// <param name="dW">炉膛宽度W</param>
        /// <param name="dD">炉膛深度D</param>
        /// <param name="dpwz">屏的位置pwz</param>
        /// <param name="dn">n</param>
        /// <param name="ds1">s1</param>
        /// <param name="ds2">s2</param>
        /// <param name="dN">N</param>
        /// <param name="dA">A</param>
        /// <param name="dAdx">Adx</param>
        /// <param name="dVp">屏区容积Vp</param>
        /// <param name="dFjmp">屏区与自由空间界面面积Fjmp</param>
        /// <param name="dFsbp">屏区水冷壁与过热管总面积Fsbp</param>
        /// <returns></returns>
        private static int CalculateScreenAreaVolumnAndArea(double dW, double dD, double dpwz, double dn, double ds1, double ds2, double dN, double dA, double dAdx, out double dVp, out double dFjmp, out double dFsbp)
        {
            dVp = 0;
            dFjmp = 0;
            dFsbp = 0;
            return 0;
        }
        #endregion

        #region  8.屏式换热器角系数计算
        /// <summary>
        /// 8.屏式换热器角系数计算
        /// </summary>
        /// <param name="dpwz">屏的位置pwz</param>
        /// <param name="dd">d</param>
        /// <param name="dn">n</param>
        /// <param name="ds1">s1</param>
        /// <param name="ds2">s2</param>
        /// <param name="dXp">屏式换热器角系数Xp</param>
        /// <param name="dSigMaXp">SigMaXp</param>
        /// <returns></returns>
        private static int CalculateScreenAreaHeatTransferCoefficient(double dpwz, double dd, double dn, double ds1, double ds2, out double dXp, out double dSigMaXp)
        {
            dXp = 0;
            dSigMaXp = 0;
            return 0;
        }
        #endregion

        #region 9.放热系数折算  烟气参数未确定
        /// <summary>
        /// 9.放热系数折算
        /// </summary>
        /// <param name="dT1"></param>
        /// <param name="dT2"></param>
        /// <param name="dAlphan"></param>
        /// <param name="dAlphak"></param>
        /// <param name="dhrqxs"></param>
        /// <param name="dgzlx"></param>
        /// <param name="dcsfs"></param>
        /// <param name="drlxs"></param>
        /// <param name="dp"></param>
        /// <param name="ds"></param>
        /// <param name="dTcp">平均温度</param>
        /// <param name="dNull">烟气参数</param>
        /// <param name="dd">管束几何参数</param>
        /// <param name="dl"></param>
        /// <param name="dlb"></param>
        /// <param name="dz1"></param>
        /// <param name="dz2"></param>
        /// <param name="ds2"></param>
        /// <param name="dDelTap"></param>
        /// <param name="dDelTab"></param>
        /// <param name="dSigMa1"></param>
        /// <param name="dSigMa2"></param>
        /// <param name="dhp"></param>
        /// <param name="dD"></param>
        /// <param name="dsp"></param>
        /// <param name="dsb"></param>
        /// <param name="dH"></param>
        /// <param name="dAlpha1"></param>
        /// <param name="dPsip"></param>
        /// <returns></returns>
        private static int CalculateHeatReleaseCoefficient(double dT1, double dT2, double dAlphan, double dAlphak, double dhrqxs, double dgzlx, double dcsfs, double drlxs, double dp, double ds, double dTcp, double dNull, double dd, double dl, double dlb, double dz1, double dz2, double ds2, double dDelTap, double dDelTab, double dSigMa1, double dSigMa2, double dhp, double dD, double dsp, double dsb, out double dH, out double dAlpha1, out double dPsip)
        {
            dH = 0;
            dAlpha1 = 0;
            dPsip = 0;
            return 0;
        }
        #endregion

        #region  10.燃烧产物辐射放热系数Alphan
        /// <summary>
        /// 10.燃烧产物辐射放热系数Alphan
        /// 换热器型式不为1的时候用
        /// </summary>
        /// <param name="drlxs">燃料型式rlxs</param>
        /// <param name="drmzl">燃煤种类rmzl</param>
        /// <param name="dTwb">外壁温Twb</param>
        /// <param name="dp"></param>
        /// <param name="ds"></param>
        /// <param name="dT3"></param>
        /// <param name="dT4"></param>
        /// <param name="dNUll">烟气参数</param>
        /// <param name="dlodelta">烟气空间的深度</param>
        /// <param name="dTodelta">烟气温度</param>
        /// <param name="dln">烟气空间后管束深度ln</param>
        /// <param name="Qn"></param>
        /// <param name="dAlphan"></param>
        private static int CalculateRadiateHeaReleaseCoefficient(double drlxs, double drmzl, double dTwb, double dp, double ds, double dT3, double dT4, double dNUll, double dlodelta, double dTodelta, double dln, out double Qn, out double dAlphan)
        {
            dQn = 0;
            dAlphan = 0;

            return 0;
        }
        /// <summary>
        /// 10.燃烧产物辐射放热系数Alphan
        /// 换热器型式=1的时候用
        /// </summary>
        /// <param name="drlxs">燃料型式rlxs</param>
        /// <param name="drmzl">燃煤种类rmzl</param>
        /// <param name="dTwb">外壁温Twb</param>
        /// <param name="dp"></param>
        /// <param name="ds"></param>
        /// <param name="dT3"></param>
        /// <param name="dT4"></param>
        /// <param name="dNUll">烟气参数</param>
        /// <param name="dlodelta">烟气空间的深度</param>
        /// <param name="dTodelta">烟气温度</param>
        /// <param name="dSigMaXp"></param>
        /// <param name="ds1"></param>
        /// <param name="Qn"></param>
        /// <param name="dAlphan"></param>
        /// <returns></returns>
        private static int CalculateRadiateHeaReleaseCoefficient(double drlxs, double drmzl, double dTwb, double dp, double ds, double dT3, double dT4, double dNUll, double dlodelta, double dTodelta, double dSigMaXp, double ds1, out double dQn, out double dAlphan, double dhrqxs = 1)
        {
            dQn = 0;
            dAlphan = 0;

            return 0;
        }

        #endregion

        #region 11.管外壁温度Twb
        /// <summary>
        /// 11.管外壁温度Twb
        /// </summary>
        /// <param name="dhrqxs">换热器型式hrqxs</param>
        /// <param name="dSRFS">受热方式SRFS</param>
        /// <param name="dd"></param>
        /// <param name="dDelTad"></param>
        /// <param name="dl"></param>
        /// <param name="dz1"></param>
        /// <param name="dz2"></param>
        /// <param name="di1"></param>
        /// <param name="dT1"></param>
        /// <param name="dAlpha1"></param>
        /// <param name="dH"></param>
        /// <param name="dTwb"></param>
        /// <returns></returns>
        public static int CalculateOuterWallTemperature(double dhrqxs, double dSRFS, double dd, double dDelTad, double dl, double dz1, double dz2, double di1, double dT1, double dAlpha1, double dH, out double dTwb)
        {
            dTwb = 0;
            return 0;
        }
        #endregion

        #region 12.受热面利用系数KeSai计算
        /// <summary>
        /// 12.受热面利用系数KeSai计算
        /// </summary>
        /// <param name="dhrqxs">换热器型式hrqxs</param>
        /// <param name="dpwz"></param>
        /// <param name="dcsfs"></param>
        /// <param name="dKeSai"></param>
        /// <returns></returns>
        public static int CalaulateHeatSurfaceUtilizationCoeddicient(double dhrqxs, double dpwz, double dcsfs, out double dKeSai)
        {
            dKeSai = 0;
            return 0;
        }
        #endregion

        #region 13.对流受热面污染系数EpsaiLen计算
        /// <summary>
        /// 13.对流受热面污染系数EpsaiLen计算
        /// </summary>
        /// <param name="dhrqxs">换热器型式hrqxs</param>
        /// <param name="drlxs"></param>
        /// <param name="dCaO"></param>
        /// <param name="dchzz"></param>
        /// <param name="dAlphat"></param>
        /// <param name="dSRFS"></param>
        /// <param name="dEpsaiLen"></param>
        /// <returns></returns>
        public static int CalculateHeatingSurfacePollutionCoefficient(double dhrqxs, double drlxs, double dCaO, double dchzz, double dAlphat, double dSRFS, out double dEpsaiLen)
        {
            dEpsaiLen = 0;
            return 0;
        }
        #endregion

        #region 14.热利用系数计算
        /// <summary>
        /// 14.热利用系数计算
        /// </summary>
        /// <param name="dhrqxs"></param>
        /// <param name="drlxs"></param>
        /// <param name="dgzlx"></param>
        /// <param name="dCaO"></param>
        /// <param name="dchzz"></param>
        /// <param name="dgttjj"></param>
        /// <param name="dPSai"></param>
        /// <returns></returns>
        public static int CalculateHeatCoefficient(double dhrqxs, double drlxs, double dgzlx, double dCaO, double dchzz, double dgttjj, out double dPSai)
        {
            dPSai = 0;
            return 0;
        }
        #endregion

        #region 15.烟气流通截面积Fr
        /// <summary>
        /// 15.烟气流通截面积Fr
        /// </summary>
        /// <param name="dgzlx">管子类型</param>
        /// <param name="dcsfs"></param>
        /// <param name="dhrqxs">换热器型式</param>
        /// <param name="dd"></param>
        /// <param name="dl"></param>
        /// <param name="dz1"></param>
        /// <param name="dz2"></param>
        /// <param name="dSigMa1"></param>
        /// <param name="dSigMa22"></param>
        /// <param name="dSp"></param>
        /// <param name="dHp"></param>
        /// <param name="dD"></param>
        /// <param name="dFr"></param>
        /// <returns></returns>
        public static int CalculateFlueGasFlowArea(double dgzlx, double dcsfs, double dhrqxs, double dd, double dl, double dz1, double dz2, double dSigMa1, double dSigMa22, double dSp, double dHp, double dD, out double dFr)
        {
            dFr = 0;
            return 0;
        }
        #endregion

        #region 16.烟气的对流放热系数计算
        /// <summary>
        /// 16.烟气的对流放热系数计算
        /// </summary>
        /// <param name="dgzlx">管子类型</param>
        /// <param name="dxsfs"></param>
        /// <param name="dhrqxs">换热器型式</param>
        /// <param name="dd"></param>
        /// <param name="dl"></param>
        /// <param name="dLb"></param>
        /// <param name="dZ1"></param>
        /// <param name="dS1"></param>
        /// <param name="dS2"></param>
        /// <param name="dDelTap"></param>
        /// <param name="dDelTab"></param>
        /// <param name="dHp"></param>
        /// <param name="dD"></param>
        /// <param name="dDp"></param>
        /// <param name="dSb"></param>
        /// <param name="dT3"></param>
        /// <param name="dT4"></param>
        /// <param name="dFr"></param>
        /// <param name="dQr"></param>
        /// <param name="dNull"></param>
        /// <param name="dAlphak"></param>
        /// <returns></returns>
        public static int CalculateFlueGasFlowHeatCoeffiient(double dgzlx, double dxsfs, double dhrqxs, double dd, double dl, double dLb, double dZ1, double dS1, double dS2, double dDelTap, double dDelTab, double dHp, double dD, double dDp, double dSb, double dT3, double dT4, double dFr, double dQr, double dNull, out double dAlphak)
        {
            dAlphak = 0;
            return 0;
        }
        #endregion

        #region 17.管壁向水和蒸汽的放热系数Alpha2
        /// <summary>
        /// 17.管壁向水和蒸汽的放热系数Alpha2
        /// </summary>
        /// <param name="dP1"></param>
        /// <param name="dP2"></param>
        /// <param name="di1"></param>
        /// <param name="di2"></param>
        /// <param name="dd">管子外径d</param>
        /// <param name="dSigMa">管子壁厚SigMa</param>
        /// <param name="dG">工质流量G</param>
        /// <param name="dAlpha2">管壁向水和蒸汽的放热系数Alpha2</param>
        /// <returns></returns>
        public static int CalculateWaterAngGasHeatCoefficient(double dP1, double dP2, double di1, double di2, double dd, double dSigMa, double dG, out double dAlpha2)
        {
            dAlpha2 = 0;
            return 0;
        }
        #endregion

        #region 18.温压换算系数DelTaT计算
        /// <summary>
        /// 18.温压换算系数DelTaT计算
        /// </summary>
        /// <param name="dT1"></param>
        /// <param name="dT2"></param>
        /// <param name="dT3"></param>
        /// <param name="dT4"></param>
        /// <param name="dgsbz"></param>
        /// <param name="dns"></param>
        /// <param name="dnn"></param>
        /// <param name="dnx"></param>
        /// <param name="dljxs"></param>
        /// <param name="ddlzjg"></param>
        /// <param name="dDelTat"></param>
        /// <returns></returns>
        public static int CalculateTemperaturePressureConvertCoefficient(double dT1, double dT2, double dT3, double dT4, double dgsbz, double dns, double dnn, double dnx, double dljxs, double ddlzjg, out double dDelTat)
        {
            dDelTat = 0;
            return 0;
        }
        #endregion
    }
}
