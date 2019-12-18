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
        /// <param name="Fyc">烟窗，后续添加的参数</param>
        /// <param name="Hslf">结果参数:Hslf</param>
        /// <param name="Hsl">结果参数:Hsl</param>
        /// <param name="Hp">结果参数:Hp</param>
        /// <param name="Hbg">结果参数:Hbg</param>
        /// <param name="Ht">结果参数:Ht</param>
        /// <param name="Bu">结果参数:Bu</param>
        /// <param name="PeSaicp">结果参数:PeSaicp</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public static int CalculateEffectiveRadioArea(double p, double Vf, double Vp, double Fslf, double Fbgf, double Fjmp, double Fbgp, double Fslp, double Fp, double s1, double A, double b, double xsl, double xbg, double xp, double ZeTasl, double ZeTabg, double ZeTap, double ycjg, double rlxs, double Fyc, double rn, double rh2o, double Ttn, double Mui3n, double s, double glxs, double pzfs, double rmzl, ref double Hslf, ref double Hsl, ref double Hp, ref double Hbg, ref double Ht, ref double Bu, ref double PeSaicp)
        {
            int ret = 0;
            //Step1:计算炉膛自由容积的有效辐射层厚度Sf
            double sf = (3.6 * Vf) / (Fslf + Fbgf + Fjmp);
            //Step2:由p和Sf调用固体燃料辐射减弱系数计算模块(CalculateSolidFuelWeakenCoefficent)得到Kf
            double kf = 0;
            ret = CalculateSolidFuelWeakenCoefficent(rn, rh2o, p, Ttn, Mui3n, s, glxs, pzfs, rmzl, ref kf);
            if (0 != ret)
                return ret;
            //Step3:CalculateSolidFuelWeakenCoefficent炉膛自由容积黑度Af
            double af = 1 - Math.Exp(kf * p * sf);
            //Step4:计算屏间容积有效辐射厚度Sp
            double sp = 1.8 / (1 / A + 1 / s1 + 1 / b);
            //Step5:由p和Sp调用固体燃料辐射减弱系数计算模块(CalculateSolidFuelWeakenCoefficent)得到Kp
            double kp = 0;
            ret = CalculateSolidFuelWeakenCoefficent(rn, rh2o, p, Ttn, Mui3n, s, glxs, pzfs, rmzl, ref kp);
            if (0 != ret)
                return ret;
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
            double Fsl = Fslf + Fslp;
            double PeSaisl = (Fslf * xsl * ZeTasl + Fslp * xsl * Zslp * ZeTasl) / Fsl;
            //Step15:计算过热管有效辐射面积Hbg
            Hbg = Fbgf * xbg + Fbgp * xbg * Zbgp;
            //Step16:计算过热管热有效系数PeSaibg
            double Fbg = Fbgf + Fbgp;
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
            double PeSaiyc = xyc * Zetayc;
            //Step23:计算平均热有效系数PeSaicp
            PeSaicp = (PeSaisl * Fsl + PeSaibg * Fbg + PeSaip * Fp + dPeSaiyc * Fyc) / F1;
            //Step7:计算总的有效辐射面积Ht
            Ht = Hsl + Hp + Hbg + Hyc;
            return ret;
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
        public static int CalculateParameterM(double n, double hi, double Bi, double glxs, double VrH, double Vn2H, double Vro2H, double r, int pzfs, int rsqbz, double Ht, double R, out double M)
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
        private static int CalculateSolidFuelWeakenCoefficent(double rn, double rh2o, double p, double Ttn, double Mui3n, double s, double glxs, double pzfs, double rmzl, ref double K)
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
        /// <param name="rn">三原子气体的总容积份额Rn=rh2o+rro2</param>
        /// <param name="rh2o">烟气中水蒸气容积份额rh2o</param>
        /// <param name="p">炉膛内压力p(MPa)</param>
        /// <param name="Ttn">炉膛出口烟气温度Ttn(K)</param>
        /// <param name="s">有效辐射层厚度s</param>
        /// <param name="Alphat">炉膛出口过量空气系数Alphat</param>
        /// <param name="CH">燃料应用基碳氢比</param>
        /// <param name="glxs">锅炉形式glxs</param>
        /// <param name="pzfs">排渣方式pzfs</param>
        /// <param name="qyrl">气液燃料种类qyrl</param>
        /// <param name="K">辐射减弱系数K</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        private static int CalculateGasOrLiquidFuelWeakenCoefficent(double rn, double rh2o, double p, double Ttn, double s, double Alphat, double CH, double glxs, double pzfs, double qyrl, out double K)
        {
            int ret = 0;
            //Step1:燃烧产物气相的辐射减弱系数kr
            double kr = ((7.8 + 16 * rh2o) / Math.Sqrt(10 * p * rn * s) - 1) * (1 - 0.37 * Math.Pow(10, -3) * Ttn);
            //Step2:计算炭黑粒子的辐射减弱系数
            double kc = 0;
            if (2 >= Alphat)
            {
                kc = 1.2 / (1 + Math.Pow(Alphat, 2)) * Math.Pow(CH, 0.4) * (1.6 * Math.Pow(10, -3) * Ttn - 0.5);
            }
            else
            {
                kc = 0;
            }
            //Step3:计算m
            double m = 0;
            if (1 == qyrl)
            {
                m = 0.6;
            }
            else if (2 == qyrl)
            {
                m = 0.3;
            }
            else if (3 == qyrl)
            {
                m = 0.1;
            }
            else if (4 == qyrl)
            {
                m = 0;
            }
            else
            {
                ret = -1;
            }
            //Step4:计算k
            K = kr + m * kc;
            return ret;
        }
        #endregion

        #region 5.炉膛污染系数ZeTa计算
        /// <summary>
        /// 5.炉膛污染系数zeta计算
        /// </summary>
        /// <param name="gzlx">管子类型gzlx</param>
        /// <param name="pzfs">排渣方式pzfs</param>
        /// <param name="FT">灰熔点温度FT</param>
        /// <param name="glxs">锅炉型式glxs</param>
        /// <param name="rlxs">燃料型式rlxs</param>
        /// <param name="srfs">受热方式srfs</param>
        /// <param name="ZeTa">炉膛污染系数ZeTa</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        private static int CalculatePollutionCoefficient(double gzlx, double pzfs, double FT, double glxs, double rlxs, double srfs, out double ZeTa)
        {
            int ret = 0;
            //Step1:计算Zetasl
            double Zetasl = 0;
            if (4 == gzlx)
            {
                Zetasl = 0.1;
            }
            else if (3 == gzlx)
            {
                if (1 == pzfs)
                {
                    Zetasl = 0.2;
                }
                else
                {
                    Zetasl = 0.53 - 00.00025 * (FT - 50);
                }
            }
            else if ((1 == gzlx || 2 == gzlx) && 3 == glxs)
            {
                Zetasl = 0.6;
            }
            else if ((1 == gzlx || 2 == gzlx) && (1 == glxs || 2 == glxs) && 3 == rlxs)
            {
                Zetasl = 0.65;
            }
            else if ((1 == gzlx || 2 == gzlx) && (1 == glxs || 2 == glxs) && 2 == rlxs)
            {
                Zetasl = 0.55;
            }
            else
            {
                Zetasl = 0.45;
            }

            //Step2:计算ZeTa
            if (2 == srfs && 1 == gzlx)
            {
                ZeTa = Zetasl - 0.1;
            }
            else if (2 == srfs && 2 == gzlx)
            {
                ZeTa = Zetasl - 0.05;
            }
            else
            {
                ret = -1;
                ZeTa = 0;
            }
            return ret;
        }
        #endregion

        #region 6.水冷壁有效角系数计算
        /// <summary>
        /// 6.水冷壁有效角系数计算
        /// </summary>
        /// <param name="gzlx">管子类型gzlx</param>
        /// <param name="srfs">受热方式srfs</param>
        /// <param name="d">几何参数d</param>
        /// <param name="s">几何参数s</param>
        /// <param name="n">几何参数n</param>
        /// <param name="e">几何参数e</param>
        /// <param name="x">水冷壁有效角系数x</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        private static int CalculateWaterCooledWallEffiectiveCoefficient(double gzlx, double srfs, double d, double s, double n, double e, out double x)
        {
            int ret = 0;
            //Step:
            if (1 == gzlx && 1 == srfs)
            {
                if (e > 1.4 * d)
                {
                    x = 0.93286 + 0.20596 * s / d - 0.16542 * Math.Pow(s / d, 2) + 0.02977 * Math.Pow(s / d, 3) - 0.0017 * Math.Pow(s / d, 4);
                }
                else if (e == 0.8 * d)
                {
                    x = 1.05071 + 0.03159 * s / d - 0.09962 * Math.Pow(s / d, 2) + 0.01976 * Math.Pow(s / d, 3) - 0.0017 * Math.Pow(s / d, 4);
                }
                else if (e == 0.5 * d)
                {
                    x = 1.13143 + 0.08224 * s / d - 0.0625 * Math.Pow(s / d, 2) + 0.01455 * Math.Pow(s / d, 3) - 0.000909091 * Math.Pow(s / d, 4);
                }
                else if (0 == e)
                {
                    x = 1.36242 + 0.35628 * s / d - 0.01903 * Math.Pow(s / d, 2) + 0.01806 * Math.Pow(s / d, 3) - 0.0017 * Math.Pow(s / d, 4);
                }
                else
                {
                    ret = -1;
                    x = 0;
                }

            }
            else if (1 == gzlx && 2 == srfs)
            {
                x = 1 - Math.Sqrt(1 - Math.Pow(d / s, 2)) + d / s * Math.Atan(Math.Sqrt(Math.Pow(s / d, 2) - 1));
            }
            else
            {
                x = 1;
            }
            return ret;
        }
        #endregion

        #region 7.屏区容积与面积计算
        /// <summary>
        /// 7.屏区容积与面积计算
        /// </summary>
        /// <param name="W">炉膛宽度W</param>
        /// <param name="D">炉膛深度D</param>
        /// <param name="pwz">屏的位置pwz</param>
        /// <param name="n">n</param>
        /// <param name="s1">s1</param>
        /// <param name="s2">s2</param>
        /// <param name="N">N</param>
        /// <param name="A">A</param>
        /// <param name="Adx">Adx</param>
        /// <param name="Vp">屏区容积Vp</param>
        /// <param name="Fjmp">屏区与自由空间界面面积Fjmp</param>
        /// <param name="Fsbp">屏区水冷壁与过热管总面积Fsbp</param>
        /// <returns></returns>
        private static int CalculateScreenAreaVolumnAndArea(double W, double D, double pwz, double n, double s1, double s2, double N, double A, double Adx, ref double Vp, ref double Fjmp, ref double Fsbp, ref string sTipInfo)
        {
            int ret = 0;
            //Step1:计算管屏宽度b
            double b = (n - 1) * s2;
            //Step2:
            if ((4 == pwz || 6 == pwz || 7 == pwz) && 0.457 > s1)
            {
                ret = 1;
                sTipInfo = "换热器参数或选型有误，请增大s1或更换为半辐射换热器";
            }
            //Step3:计算S
            double S = 0;
            if (1 == pwz || 4 == pwz || 5 == pwz || 6 == pwz)
            {
                S = D;
            }
            else if (7 == pwz)
            {
                S = W;
            }
            else if (2 == pwz || 3 == pwz)
            {
                if (0 == N)
                {
                    ret = 1;
                    sTipInfo = "需要输入管屏片数";
                }
                else
                {
                    S = N * s1;
                }
            }
            //Step4:计算Vp
            Vp = A * b * S;
            //Step5:计算NN
            double NN = 0;
            if (0 == N)
            {
                NN = Math.Floor(S / s1) - 1;//int函数是向下取整
            }
            else
            {
                NN = N;
            }
            //Step6:计算Fp
            double Fp = 2 * b * Adx * NN;
            //Step7:计算Fsbp   Fjmp
            if (1 == pwz)
            {
                Fjmp = (A + b) * S;
                Fsbp = A * S + 2 * A * b + b * S;
            }
            else if (2 == pwz)
            {
                if (b < (W - s1))
                {
                    Fjmp = (A + S) * b + A * S;
                    Fsbp = A * S + A * b + b * S;
                }
                else
                {
                    Fjmp = (A + S) * W + A * S;
                    Fsbp = A * W + A * S + W * S;
                }
            }
            else if (3 == pwz)
            {
                if (b < (W - s1))
                {
                    Fjmp = 2 * (A + 0.5 * S) * b + A * S;
                    Fsbp = A * S + 2 * A * b + b * S;
                }
                else
                {
                    Fjmp = 2 * (A + 0.5 * S) * W + A * S;
                    Fsbp = 2 * A * W + A * S + W * S;
                }
            }
            else if (4 == pwz)
            {
                Fjmp = (A + b) * S;
                Fsbp = 2 * A * b + b * S;
            }
            else if (5 == pwz)
            {
                Fjmp = A * S;
                Fsbp = 2 * A * b + 2 * b * S + A * S;
            }
            else if (6 == pwz || 7 == pwz)
            {
                Fjmp = A * S;
                Fsbp = 2 * A * b + 2 * b * S;
            }
            else
            {
                ret = -1;
            }
            return ret;
        }
        #endregion

        #region  8.屏式换热器角系数计算
        /// <summary>
        /// 8.屏式换热器角系数计算
        /// </summary>
        /// <param name="pwz">屏的位置pwz</param>
        /// <param name="d">d</param>
        /// <param name="n">n</param>
        /// <param name="s1">s1</param>
        /// <param name="s2">s2</param>
        /// <param name="Xp">屏式换热器角系数Xp</param>
        /// <param name="SigMaXp">SigMaXp</param>
        /// <returns></returns>
        private static int CalculateScreenAreaHeatTransferCoefficient(double pwz, double d, double n, double s1, double s2, ref double xp, ref double SigMaxp)
        {
            int ret = 0;
            //Step:
            if (1 == pwz || 2 == pwz || 3 == pwz || 5 == pwz)
            {
                //此种情况下只有xp,没有SigMaxp
                xp = 1 - Math.Sqrt(1 - Math.Pow(d / s2, 2)) + d / s2 * Math.Atan(Math.Sqrt(Math.Pow(s2 / d, 2) - 1));
            }
            else if (4 == pwz || 6 == pwz || 7 == pwz)
            {
                if (s1 >= 0.457)
                {
                    //此种情况下只有xp,没有SigMaxp
                    xp = 1 - Math.Sqrt(1 - Math.Pow(d / s2, 2)) + d / s2 * Math.Atan(Math.Sqrt(Math.Pow(s2 / d, 2) - 1));
                }
                else
                {
                    //由排管数n和SigMa1查表获得SigMaxp
                    double SigMa1 = s1 / d;
                    CTableScreenAreaHeatTransferHelper tableHelper = new CTableScreenAreaHeatTransferHelper();
                    ret = tableHelper.GetSigMaxp(n, SigMa1, ref xp, ref SigMaxp);
                }
            }
            return ret;
        }

        #endregion

        #region 9.放热系数折算  烟气参数未确定
        /// <summary>
        /// 9.放热系数折算
        /// </summary>
        /// <param name="T1"></param>
        /// <param name="T2"></param>
        /// <param name="Alphan"></param>
        /// <param name="Alphak"></param>
        /// <param name="hrqxs"></param>
        /// <param name="gzlx"></param>
        /// <param name="csfs"></param>
        /// <param name="rlxs"></param>
        /// <param name="p"></param>
        /// <param name="s"></param>
        /// <param name="Tcp">平均温度</param>
        /// <param name="dNull">烟气参数</param>
        /// <param name="d">管束几何参数</param>
        /// <param name="l"></param>
        /// <param name="lb"></param>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <param name="s2"></param>
        /// <param name="DelTap"></param>
        /// <param name="DelTab"></param>
        /// <param name="SigMa1"></param>
        /// <param name="SigMa2"></param>
        /// <param name="hp"></param>
        /// <param name="D"></param>
        /// <param name="sp"></param>
        /// <param name="sb"></param>
        /// <param name="H"></param>
        /// <param name="Alpha1"></param>
        /// <param name="Psip"></param>
        /// <returns></returns>
        private static int CalculateHeatReleaseCoefficient(double T1, double T2, double Alphan, double Alphak, double hrqxs, double gzlx, double csfs, double rlxs, double p, double s, double Tcp, double Null, double , double l, double lb, double z1, double z2, double s2, double elTap, double elTab, double SigMa1, double SigMa2, double hp, double dyanqi, double sp, double sb, ref double H, ref double Alpha1, ref double Psip)
        {
            int ret = 0;

            H = 0;
            Alpha1 = 0;
            Psip = 0;
            return ret;
        }
        #endregion

        #region  10.燃烧产物辐射放热系数Alphan
        /// <summary>
        /// 10.燃烧产物辐射放热系数Alphan
        /// 换热器型式不为1的时候用
        /// </summary>
        /// <param name="rlxs">燃料型式rlxs</param>
        /// <param name="rmzl">燃煤种类rmzl</param>
        /// <param name="Twb">外壁温Twb</param>
        /// <param name="p"></param>
        /// <param name="s"></param>
        /// <param name="T3"></param>
        /// <param name="T4"></param>
        /// <param name="dNUll">烟气参数</param>
        /// <param name="lodelta">烟气空间的深度</param>
        /// <param name="Todelta">烟气温度</param>
        /// <param name="ln">烟气空间后管束深度ln</param>
        /// <param name="Qn"></param>
        /// <param name="dAlphan"></param>
        private static int CalculateRadiateHeaReleaseCoefficient(double rlxs, double rmzl, double Twb, double p, double s, double T3, double T4, double NUll, double lodelta, double Todelta, double hrqxs, double SigMaXp, double s1, double ln, out double Qn, ref double Alphan)
        {
            int ret = 0;
            Qn = 0;
            Alphan = 0;
            //Step1:计算Tcp
            double Tcp = (T3 + T4) / 2;
            //Step2:由Tcp p s 烟气参数调用燃料辐射减弱系数模块得到kcp
            double kcp = 0;

            //Step3:烟气流黑度a
            double a = 1 - Math.Exp(-1 * kcp * p * s);
            //Step4:a3是辐射受热面污染壁面的黑度，对锅炉受热面，a3=0.8
            double a3 = 0.8;
            //Step5:计算n
            double n = 0;
            if (1 == rlxs)
            {
                n = 4;
            }
            else
            {
                n = 3.6;
            }
            //Step6:计算Alphan1
            double Alphan1 = 5.67 * Math.Pow(10, -8) * (a3 + 1) / 2 * a * Math.Pow(T, 3) * ((1 - Math.Pow(Twb / T, n) / (1 - Twb / T));
            //Step7:计算koDelta
            double soDelta = 0;
            if (1 == hrqxs)
            {
                soDelta = 3.6 * lodelta;
                double koDelta = 0;
                if (1 == rlxs)
                {
                    //由ToDelta调用固体燃料辐射减弱系数计算模块，得到koDelta
                    ret = CalculateSolidFuelWeakenCoefficent(rn, rh2o, p, Ttn, Mui3n, s, glxs, pzfs, rmzl, ref koDelta);
                    if (0 != ret)
                    {
                        return ret;
                    }
                }
                else
                {
                    //由ToDelta调用气体或液体燃料辐射减弱系数计算模块，得到koDelta
                    ret = CalculateGasOrLiquidFuelWeakenCoefficent(rn, rh2o, p, Ttn, s, Alphat, CH, glxs, pzfs, qyrl, ref koDelta);
                    if (0 != ret)
                    {
                        return ret;
                    }
                }
                //确定烟气空间的黑度aoDelta
                double aoDelta = 1 - Math.Exp(-1 * koDelta * p * soDelta);
                Alphan = Alphan1 * (1 + (aoDelta / Alphan1) * (s1 / 2 * lodelta) * SigMaXp * (1 - Alphan1) * ((Math.Pow(Todelta, 4) - Math.Pow(Twb, 4)) / (Math.Pow(Tcp, 4) - Math.Pow(Twb, 4))));
            }
            else if (2 == hrqxs || 3 == hrqxs)
            {

                double A = 0;
                if (1 == rlxs && (1 == rmzl || 2 == rmzl))
                {
                    A = 0.4;
                }
                else if (1 == rlxs && (3 == rmzl || 4 == rmzl || 5 == rmzl || 6 == rmzl))
                {
                    A = 0.5;
                }
                else if (2 == rlxs || 3 == rlxs)
                {
                    A = 0.3;
                }
                Alphan = Alphan1 * (1 + A * Math.Pow(Todelta / 1000, 0.25) * Math.Pow(lodelta / ln, 0.07));
            }
            Qn = Alphan * ((Tcp - Twb) * Hn / Bp) * Math.Pow(10, 3);
            return ret;
        }
        #endregion

        #region 11.管外壁温度Twb
        /// <summary>
        /// 11.管外壁温度Twb
        /// </summary>
        /// <param name="hrqxs">换热器型式hrqxs</param>
        /// <param name="SRFS">受热方式SRFS</param>
        /// <param name="d"></param>
        /// <param name="DelTad"></param>
        /// <param name="l"></param>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <param name="i1"></param>
        /// <param name="dT1"></param>
        /// <param name="Alpha1"></param>
        /// <param name="H"></param>
        /// <param name="Twb"></param>
        /// <returns></returns>
        public static int CalculateOuterWallTemperature(double hrqxs, double SRFS, double d, double DelTad, double l, double z1, double z2, double i1, double T1, double Alpha1, double H, ref double Twb)
        {
            int ret = 0;
            double HBH = Math.PI * (d - 2 * DelTad) * l * z1 * z2;
            //由T1确认ils1????
            double ils1 = 0;
            double Alpha2 = 0;
            if (i1 < ils1)
            {
                1/Alpha2 = 0;
            }
            else if (i1 >= ils1)
            {
                //调用Alpha2计算模块17得到Alpha2
                Alpha2 = 0;
            }
            if (1 == hrqxs || 1 == SRFS)
            {
                //根据换热器参数，调用受热面污染系数计算模块13，得到epslion
                double epslion = 0;
                Twb = t + (epslion + 1 / Alpha2) * (Bp / H) * (Qn + Q) * Math.Pow(10, 3) + 273;
            }
            else if ((2 == hrqxs || 3 == hrqxs) && 2 == SRFS)
            {
                //根据换热器参数，调用受热面热利用系数计算模块14，得到psi
                double psi = 0;
                Twb = t + ((1 / psi) * ((1 / Alpha1) + ((1 / Alpha2) * (H / HBH)) - (1 / Alpha1))) * (Bp / H) * (Qn + Q) * Math.Pow(10, 3) + 273;
            }
            else
            {
                ret = -1;
            }
            return ret;
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
        public static int CalaulateHeatSurfaceUtilizationCoeddicient(double hrqxs, double pwz, double csfs, out double KeSai)
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
        public static int CalculateHeatingSurfacePollutionCoefficient(double hrqxs, double rlxs, double CaO, double chzz, double Alphat, double SRFS, out double EpsaiLen)
        {
            EpsaiLen = 0;
            return 0;
        }
        #endregion

        #region 14.热利用系数计算
        /// <summary>
        /// 14.热利用系数计算
        /// </summary>
        /// <param name="hrqxs"></param>
        /// <param name="rlxs"></param>
        /// <param name="gzlx"></param>
        /// <param name="CaO"></param>
        /// <param name="chzz"></param>
        /// <param name="gttjj"></param>
        /// <param name="PSai"></param>
        /// <returns></returns>
        public static int CalculateHeatCoefficient(double hrqxs, double rlxs, double gzlx, double CaO, double chzz, double gttjj, out double PSai)
        {
            PSai = 0;
            return 0;
        }
        #endregion

        #region 15.烟气流通截面积Fr
        /// <summary>
        /// 15.烟气流通截面积Fr
        /// </summary>
        /// <param name="gzlx">管子类型</param>
        /// <param name="csfs"></param>
        /// <param name="hrqxs">换热器型式</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <param name="SigMa1"></param>
        /// <param name="SigMa22"></param>
        /// <param name="Sp"></param>
        /// <param name="Hp"></param>
        /// <param name="D"></param>
        /// <param name="Fr"></param>
        /// <returns></returns>
        public static int CalculateFlueGasFlowArea(double gzlx, double csfs, double hrqxs, double d, double l, double z1, double z2, double SigMa1, double SigMa22, double Sp, double Hp, double D, out double Fr)
        {
            Fr = 0;
            return 0;
        }
        #endregion

        #region 16.烟气的对流放热系数计算
        /// <summary>
        /// 16.烟气的对流放热系数计算
        /// </summary>
        /// <param name="dgzlx">管子类型</param>
        /// <param name="xsfs"></param>
        /// <param name="hrqxs">换热器型式</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="Lb"></param>
        /// <param name="Z1"></param>
        /// <param name="S1"></param>
        /// <param name="S2"></param>
        /// <param name="DelTap"></param>
        /// <param name="DelTab"></param>
        /// <param name="Hp"></param>
        /// <param name="D"></param>
        /// <param name="Dp"></param>
        /// <param name="Sb"></param>
        /// <param name="T3"></param>
        /// <param name="T4"></param>
        /// <param name="Fr"></param>
        /// <param name="Qr"></param>
        /// <param name="Null"></param>
        /// <param name="Alphak"></param>
        /// <returns></returns>
        public static int CalculateFlueGasFlowHeatCoeffiient(double gzlx, double xsfs, double hrqxs, double d, double l, double Lb, double Z1, double S1, double S2, double DelTap, double DelTab, double Hp, double D, double Dp, double Sb, double T3, double T4, double Fr, double Qr, double Null, out double Alphak)
        {
            Alphak = 0;
            return 0;
        }
        #endregion

        #region 17.管壁向水和蒸汽的放热系数Alpha2
        /// <summary>
        /// 17.管壁向水和蒸汽的放热系数Alpha2
        /// </summary>
        /// <param name="dP1"></param>
        /// <param name="P2"></param>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <param name="d">管子外径d</param>
        /// <param name="SigMa">管子壁厚SigMa</param>
        /// <param name="G">工质流量G</param>
        /// <param name="Alpha2">管壁向水和蒸汽的放热系数Alpha2</param>
        /// <returns></returns>
        public static int CalculateWaterAngGasHeatCoefficient(double P1, double P2, double i1, double i2, double d, double SigMa, double G, out double Alpha2)
        {
            Alpha2 = 0;
            return 0;
        }
        #endregion

        #region 18.温压换算系数DelTaT计算
        /// <summary>
        /// 18.温压换算系数DelTaT计算
        /// </summary>
        /// <param name="dT1"></param>
        /// <param name="T2"></param>
        /// <param name="T3"></param>
        /// <param name="T4"></param>
        /// <param name="gsbz"></param>
        /// <param name="ns"></param>
        /// <param name="nn"></param>
        /// <param name="nx"></param>
        /// <param name="ljxs"></param>
        /// <param name="dlzjg"></param>
        /// <param name="DelTat"></param>
        /// <returns></returns>
        public static int CalculateTemperaturePressureConvertCoefficient(double T1, double T2, double T3, double T4, double gsbz, double ns, double nn, double nx, double ljxs, double dlzjg, out double DelTat)
        {
            DelTat = 0;
            return 0;
        }
        #endregion
    }
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
}
