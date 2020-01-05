﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JD_BoilerCommonModel.CommonModel
{
    /// <summary>
    /// 锅炉热力计算通用模ddd型
    /// </summary>
    public class CCommonModelCalaulate : ICommonModelCalaulate
    {
        #region 1.有效辐射面积计算 参数注释不全
        /// <summary>
        /// 1.有效辐射面积计算
        /// </summary>
        /// <param name="p">压力</param>
        /// <param name="Vf">炉膛自由容积</param>
        /// <param name="Vp">屏区容积</param>
        /// <param name="Fslf">自由容积水冷壁面积</param>
        /// <param name="Fbgf">过热管面积</param>
        /// <param name="Fjmp">屏区与自由空间界面面积</param>
        /// <param name="Fbgp">屏区过热管面积</param>
        /// <param name="Fslp">屏区水冷壁面积</param>
        /// <param name="Fp">屏面积</param>
        /// <param name="s1">屏参数_节距</param>
        /// <param name="A">屏参数_高度</param>
        /// <param name="b">屏参数_宽度</param>
        /// <param name="xsl">水冷壁角系数</param>
        /// <param name="xbg">过热管角系数</param>
        /// <param name="xp">角系数</param>
        /// <param name="ZeTasl">水冷壁热有效系数</param>
        /// <param name="ZeTabg">过热管热有效系数</param>
        /// <param name="ZeTap">热有效系数</param>
        /// <param name="ycjg">烟窗结构</param>
        /// <param name="rlxs">燃料型式(1:煤,2:重油)</param>
        /// <param name="Fyc">出口烟窗面积</param>
        /// <param name="rn">调用固体燃料辐射减弱系数计算模块:三原子气体的总容积份额</param>
        /// <param name="rh2o">调用固体燃料辐射减弱系数计算模块:烟气中水蒸气容积份额</param>
        /// <param name="Ttn">调用固体燃料辐射减弱系数计算模块:炉膛出口烟气温度</param>
        /// <param name="Mui3n">调用固体燃料辐射减弱系数计算模块:烟气飞灰浓度</param>
        /// <param name="s">调用固体燃料辐射减弱系数计算模块:效辐射层厚度</param>
        /// <param name="glxs">调用固体燃料辐射减弱系数计算模块:锅炉形式（1:煤粉炉,2:循环流化床,3:链条炉,4:油气炉）</param>
        /// <param name="pzfs">调用固体燃料辐射减弱系数计算模块:排渣方式（1:固体排渣,2:液体排渣）</param>
        /// <param name="rmzl">调用固体燃料辐射减弱系数计算模块:燃煤种类（1:无烟煤屑,2:烟煤,3:贫煤,4:褐煤,5:页岩,6:泥煤）</param>
        /// <param name="V1">炉膛自由容积</param>
        /// <param name="PeSaip"></param>
        /// <param name="Hslf">返回值:炉膛自由容积有效辐射面积</param>
        /// <param name="Hsl">返回值:水冷壁有效辐射面积</param>
        /// <param name="Hp">返回值:</param>
        /// <param name="Hbg">返回值:过热管有效辐射面积</param>
        /// <param name="Ht">返回值:总的有效辐射面积</param>
        /// <param name="Bu">返回值:平均热有效系数</param>
        /// <param name="PeSaicp">返回值:屏的热有效系数</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateEffectiveRadioArea(double p, double Vf, double Vp, double Fslf, double Fbgf, double Fjmp, double Fbgp, double Fslp, double Fp, double s1, double A, double b, double xsl, double xbg, double xp, double ZeTasl, double ZeTabg, double ZeTap, double ycjg, double rlxs, double Fyc, double rn, double rh2o, double Ttn, double Mui3n, double s, double glxs, double pzfs, double rmzl, double V1, double PeSaip, ref double Hslf, ref double Hsl, ref double Hp, ref double Hbg, ref double Ht, ref double Bu, ref double PeSaicp)
        {
            //Step1:计算炉膛自由容积的有效辐射层厚度Sf
            double sf = (3.6 * Vf) / (Fslf + Fbgf + Fjmp);
            //Step2:由p和Sf调用固体燃料辐射减弱系数计算模块(CalculateSolidFuelWeakenCoefficent)得到Kf
            double kf = 0;
            int ret = CalculateSolidFuelWeakenCoefficent(rn, rh2o, p, Ttn, Mui3n, s, glxs, pzfs, rmzl, ref kf);
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
            //Step19:计算根据烟窗后的设备得到BaiTa,计算Zetayc
            double Zetayc = 0;
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
                else
                {
                    return -1;
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
            else
            {
                return -2;
            }
            //Step20:参照锅炉热力计算标准6-06（p34）
            double xyc = 1;
            //Step21:计算烟窗有效辐射面积Hyc
            double Hyc = xyc * Fyc;
            //Step22:计算烟窗热有效系数PeSaiyc
            double PeSaiyc = xyc * Zetayc;
            //Step23:计算平均热有效系数PeSaicp
            double F1 = Fsl + Fbg + Fp + Fyc;//炉墙总面积
            PeSaicp = (PeSaisl * Fsl + PeSaibg * Fbg + PeSaip * Fp + PeSaiyc * Fyc) / F1;
            //Step7:计算总的有效辐射面积Ht
            Ht = Hsl + Hp + Hbg + Hyc;
            return 0;
        }
        #endregion

        #region 2.炉膛参数M计算 求和公式，参数注释不全
        /// <summary>
        /// 2.炉膛参数M计算
        /// </summary>
        /// <param name="arranges">燃烧器布局参数</param>
        /// <param name="glxs">锅炉形式（1:煤粉炉,2:循环流化床,3:链条炉,4:油气炉）</param>
        /// <param name="VrH">炉膛出口烟气容积</param>
        /// <param name="Vn2H">炉膛出口烟气N2容积</param>
        /// <param name="Vro2H">炉膛出口烟气RO2容积</param>
        /// <param name="r">烟气再循环系数</param>
        /// <param name="pzfs">排渣方式（1:固体排渣,2:液体排渣）</param>
        /// <param name="rsqbz">燃烧器布置形式</param>
        /// <param name="Htao"></param>
        /// <param name="R"></param>
        /// <param name="F1">炉墙总面积</param>
        /// <param name="Qir">低位发热量</param>
        /// <param name="M">返回值:炉膛参数</param>
        /// <returns></returns>
        public int CalculateParameterM(List<CHeaterArrange> arranges, double glxs, double VrH, double Vn2H, double Vro2H, double r, int pzfs, int rsqbz, double Htao, double R, double F1, double Qir, ref double M)
        {
            //Step1:燃烧器平均布置标高
            double dTemp1 = 0;
            double dTemp2 = 0;
            int count = arranges.Count;
            for (int i = 0; i < count; i++)
            {
                double ni = arranges[i].n;
                double hi = arranges[i].h;
                double bi = arranges[i].b;
                dTemp1 += ni * bi * Qir * hi;
                dTemp2 += ni * bi * Qir;
            }
            double htao = dTemp1 / dTemp2;
            //Step2:计算燃烧器相对标高Xt
            double Xt = 0;
            if (3 == glxs)
            {
                Xt = 0;
            }
            else
            {
                Xt = htao / Htao;
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
                    return -2;
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
                return -3;
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
                return -4;
            }
            return 0;
        }
        #endregion

        #region 3.固体燃料辐射减弱系数K计算 OK
        /// <summary>
        /// 3.固体燃料辐射减弱系数K计算
        /// </summary>
        /// <param name="rn">三原子气体的总容积份额rn=rh2o+rro2</param>
        /// <param name="rh2o">烟气中水蒸气容积份额</param>
        /// <param name="p">炉膛内压力</param>
        /// <param name="Ttn">炉膛出口烟气温度</param>
        /// <param name="Mui3n">烟气飞灰浓度</param>
        /// <param name="s">有效辐射层厚度</param>
        /// <param name="glxs">锅炉形式（1:煤粉炉,2:循环流化床,3:链条炉,4:油气炉）</param>
        /// <param name="pzfs">排渣方式（1:固体排渣,2:液体排渣）</param>
        /// <param name="rmzl">燃煤种类（1:无烟煤屑,2:烟煤,3:贫煤,4:褐煤,5:页岩,6:泥煤）</param>
        /// <param name="K">辐射减弱系数</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateSolidFuelWeakenCoefficent(double rn, double rh2o, double p, double Ttn, double Mui3n, double s, double glxs, double pzfs, double rmzl, ref double K)
        {
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
                    return -1;
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
                    return -2;
                }
            }
            else
            {
                return -3;
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
                    return -4;
                }
            }
            else
            {
                kjtMuijt = 0;
            }
            K = kr + k3nMui3n + kjtMuijt;
            return 0;
        }
        #endregion

        #region 4.气体或液体燃料辐射减弱系数K计算 OK
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
        /// <param name="glxs">锅炉形式（1:煤粉炉,2:循环流化床,3:链条炉,4:油气炉）</param>
        /// <param name="pzfs">排渣方式（1:固体排渣,2:液体排渣）</param>
        /// <param name="qyrl">气液燃料种类（1:重油,2:轻质油）</param>
        /// <param name="K">返回值:辐射减弱系数K</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateGasOrLiquidFuelWeakenCoefficent(double rn, double rh2o, double p, double Ttn, double s, double Alphat, double CH, double glxs, double pzfs, double qyrl, ref double K)
        {
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
                return -1;
            }
            //Step4:计算k
            K = kr + m * kc;
            return 0;
        }
        #endregion

        #region 5.炉膛污染系数ZeTa计算 OK
        /// <summary>
        /// 5.炉膛污染系数zeta计算
        /// </summary>
        /// <param name="gzlx">管子类型（1:光管式,2:膜式）</param>
        /// <param name="pzfs">排渣方式（1:固体排渣,2:液体排渣）</param>
        /// <param name="FT">灰熔点温度</param>
        /// <param name="glxs">锅炉形式（1:煤粉炉,2:循环流化床,3:链条炉,4:油气炉）</param>
        /// <param name="rlxs">燃料型式(1:煤,2:重油)</param>
        /// <param name="SRFS">受热方式（1:单面,2:双面）</param>
        /// <param name="ZeTa">返回值:炉膛污染系数ZeTa</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculatePollutionCoefficient(double gzlx, double pzfs, double FT, double glxs, double rlxs, double SRFS, ref double ZeTa)
        {
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
            if (2 == SRFS && 1 == gzlx)
            {
                ZeTa = Zetasl - 0.1;
            }
            else if (2 == SRFS && 2 == gzlx)
            {
                ZeTa = Zetasl - 0.05;
            }
            else
            {
                return -1;
            }
            return 0;
        }
        #endregion

        #region 6.水冷壁有效角系数计算 OK
        /// <summary>
        /// 6.水冷壁有效角系数计算
        /// </summary>
        /// <param name="gzlx">管子类型（1:光管式,2:膜式）</param>
        /// <param name="SRFS">受热方式（1:单面,2:双面）</param>
        /// <param name="d">几何参数d</param>
        /// <param name="s">几何参数s</param>
        /// <param name="n">几何参数n</param>
        /// <param name="e">几何参数e</param>
        /// <param name="x">返回值:水冷壁有效角系数x</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateWaterCooledWallEffiectiveCoefficient(double gzlx, double SRFS, double d, double s, double n, double e, ref double x)
        {
            if (1 == gzlx && 1 == SRFS)
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
                    return -1;
                }

            }
            else if (1 == gzlx && 2 == SRFS)
            {
                x = 1 - Math.Sqrt(1 - Math.Pow(d / s, 2)) + d / s * Math.Atan(Math.Sqrt(Math.Pow(s / d, 2) - 1));
            }
            else
            {
                x = 1;
            }
            return 0;
        }
        #endregion

        #region 7.屏区容积与面积计算 OK
        /// <summary>
        /// 7.屏区容积与面积计算
        /// </summary>
        /// <param name="W">炉膛宽度W</param>
        /// <param name="D">炉膛深度D</param>
        /// <param name="pwz">屏的位置屏的位置（1:前屏,2:侧面屏,3:双侧面屏,4:后屏,5:大屏,6:水平横屏,7:水平纵屏）</param>
        /// <param name="n">n</param>
        /// <param name="s1">s1</param>
        /// <param name="s2">s2</param>
        /// <param name="N">N</param>
        /// <param name="A">A</param>
        /// <param name="Adx">Adx</param>
        /// <param name="Vp">屏区容积Vp</param>
        /// <param name="Fjmp">屏区与自由空间界面面积Fjmp</param>
        /// <param name="Fsbp">屏区水冷壁与过热管总面积Fsbp</param>
        /// <param name="sTipInfo">错误信息</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateScreenAreaVolumnAndArea(double W, double D, double pwz, double n, double s1, double s2, double N, double A, double Adx, ref double Vp, ref double Fjmp, ref double Fsbp, ref string sTipInfo)
        {
            //Step1:计算管屏宽度b
            double b = (n - 1) * s2;
            //Step2:
            if ((4 == pwz || 6 == pwz || 7 == pwz) && 0.457 > s1)
            {
                sTipInfo = "换热器参数或选型有误，请增大s1或更换为半辐射换热器";
                return -1;
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
                    sTipInfo = "需要输入管屏片数";
                    return -2;
                }
                else
                {
                    S = N * s1;
                }
            }
            else
            {
                return -3;
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
                return -4;
            }
            return 0;
        }
        #endregion

        #region  8.屏式换热器角系数计算 OK
        /// <summary>
        /// 8.屏式换热器角系数计算
        /// </summary>
        /// <param name="pwz">屏的位置屏的位置（1:前屏,2:侧面屏,3:双侧面屏,4:后屏,5:大屏,6:水平横屏,7:水平纵屏）</param>
        /// <param name="d">d</param>
        /// <param name="n">n</param>
        /// <param name="s1">s1</param>
        /// <param name="s2">s2</param>
        /// <param name="xp">返回值:屏式换热器角系数Xp</param>
        /// <param name="SigMaxp">返回值:SigMaXp</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateScreenAreaHeatTransferCoefficient(double pwz, double d, double n, double s1, double s2, ref double xp, ref double SigMaxp)
        {
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
                    int ret = tableHelper.GetSigMaxp(n, SigMa1, ref xp, ref SigMaxp);
                    if (0 != ret)
                    {
                        return -1;
                    }
                }
            }
            else
            {
                return -2;
            }
            return 0;
        }

        #endregion

        #region 9.放热系数折算   注释不全
        /// <summary>
        ///  9.放热系数折算 
        /// </summary>
        /// <param name="gz">刚种类型</param>
        /// <param name="T1"></param>
        /// <param name="T2"></param>
        /// <param name="Alphan">燃烧产物辐射放热系数</param>
        /// <param name="Alphak"></param>
        /// <param name="hrqxs">换热器型式（1:屏式,2:顺列管束,3:错列管束）</param>
        /// <param name="gzlx">管子类型（1:光管式,2:膜式）</param>
        /// <param name="csfs">烟气冲刷方式（1:横向,2:纵向,3:混合）</param>
        /// <param name="rlxs">燃料型式(1:煤,2:重油)</param>
        /// <param name="p"></param>
        /// <param name="s"></param>
        /// <param name="Tcp"></param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="lb"></param>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <param name="s2"></param>
        /// <param name="delTap"></param>
        /// <param name="delTab"></param>
        /// <param name="SigMa1"></param>
        /// <param name="SigMa2"></param>
        /// <param name="hp"></param>
        /// <param name="D"></param>
        /// <param name="sp"></param>
        /// <param name="sb"></param>
        /// <param name="th"></param>
        /// <param name="Enn"></param>
        /// <param name="Hrp"></param>
        /// <param name="rmzl">Add_调用辐射放热系数模块计算Alphan 燃煤种类（1:无烟煤屑,2:烟煤,3:贫煤,4:褐煤,5:页岩,6:泥煤）</param>
        /// <param name="T3"></param>
        /// <param name="T4"></param>
        /// <param name="lodelta"></param>
        /// <param name="Todelta"></param>
        /// <param name="SigMaXp"></param>
        /// <param name="s1"></param>
        /// <param name="ln"></param>
        /// <param name="rn"></param>
        /// <param name="rh2o"></param>
        /// <param name="Ttn"></param>
        /// <param name="Mui3n"></param>
        /// <param name="glxs">锅炉形式（1:煤粉炉,2:循环流化床,3:链条炉,4:油气炉）</param>
        /// <param name="pzfs">排渣方式（1:固体排渣,2:液体排渣）</param>
        /// <param name="Alphat"></param>
        /// <param name="CH"></param>
        /// <param name="qyrl">气液燃料种类（1:重油,2:轻质油）</param>
        /// <param name="T"></param>
        /// <param name="Hn"></param>
        /// <param name="Bp"></param>
        /// <param name="Fr">Add调用对流换热系数模块16计算Alphak</param>
        /// <param name="Qr"></param>
        /// <param name="hb"></param>
        /// <param name="z"></param>
        /// <param name="lpDelTa"></param>
        /// <param name="pwz">调用受热面利用系数计算模块_屏的位置屏的位置（1:前屏,2:侧面屏,3:双侧面屏,4:后屏,5:大屏,6:水平横屏,7:水平纵屏）</param>
        /// <param name="SRFS">H调用管外壁温度计算模块得到Twb_1_受热方式（1:单面,2:双面）</param>
        /// <param name="i1"></param>
        /// <param name="Q"></param>
        /// <param name="t"></param>
        /// <param name="H"></param>
        /// <param name="bIsWet"></param>
        /// <param name="DelTad"></param>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="i2"></param>
        /// <param name="SigMa"></param>
        /// <param name="G"></param>
        /// <param name="gzyh"></param>
        /// <param name="CaO"></param>
        /// <param name="chzz"></param>
        /// <param name="gttjj"></param>
        /// <param name="Alpha1">返回值:</param>
        /// <param name="Psip">返回值:</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateHeatReleaseCoefficient(EGangZhong gz, double T1, double T2, double Alphan, double Alphak, double hrqxs, double gzlx, double csfs, double rlxs, double p, double s, double Tcp, double d, double l, double lb, double z1, double z2, double s2, double delTap, double delTab, double SigMa1, double SigMa2, double hp, double D, double sp, double sb, double th, double Enn, double Hrp,/*Add_调用辐射放热系数模块计算Alphan*/ double rmzl, double T3, double T4, double lodelta, double Todelta, double SigMaXp, double s1, double ln, double rn, double rh2o, double Ttn, double Mui3n, double glxs, double pzfs, double Alphat, double CH, double qyrl, double T, double Hn, double Bp,/*Add调用对流换热系数模块16计算Alphak*/ double Fr, double Qr, double hb, double z, double lpDelTa,/*Add 调用受热面利用系数计算模块*/double pwz, /*Add H调用管外壁温度计算模块得到Twb_1*/double SRFS, double DelTad, double i1, double Q, double t, bool bIsWet, double P1, double P2, double i2, double SigMa, double G, double gzyh, double CaO, double chzz, double gttjj, ref double H, ref double Alpha1, ref double Psip)
        {
            double tpdelta = (T1 + T2) / 2 + 100;
            //由tpdelta确定肋片等的导热系数LamdapDelta
            CTableGangzhongDataHelper gangzhongDataHelper = new CTableGangzhongDataHelper();
            double A = 0, B = 0, thcx = 0;
            int ret = gangzhongDataHelper.GetGangZhongData(gz, ref A, ref B, ref thcx);
            if (0 != ret)
            {
                return ret;
            }
            double LamdapDelta = A * (1 - thcx) + B;
            //假定
            double Twb = tpdelta;
            bool bneedContinue = true;//是否继续循环
            bool bError = false;//计算过程是否由错误出现
            do
            {
                //调用辐射放热系数模块计算Alphan
                Alphan = 0;
                double Qn = 0;
                ret = CalculateRadiateHeaReleaseCoefficient(rlxs, rmzl, Twb, p, s, T3, T4, lodelta, Todelta, hrqxs, SigMaXp, s1, ln, rn, rh2o, Ttn, Mui3n, glxs, pzfs, Alphat, CH, qyrl, T, Hn, Bp, ref Qn, ref Alphan);
                if (0 != ret)
                {
                    return ret;
                }
                //调用对流换热系数模块16计算Alphak
                Alphak = 0;
                string sInfo = "";
                ret = CalculateFlueGasFlowHeatCoeffiient(gzlx, csfs, hrqxs, d, l, lb, z1, z2, s1, s2, delTab, delTab, hp, D, sp, sb, T3, T4, Fr, Qr, th, hb, z, lpDelTa, Hrp, ref Alphak, ref sInfo);
                if (0 != ret)
                {
                    return ret;
                }

                if (1 == gzlx)
                {
                    H = Math.PI * d * l * z1 * z2;
                    Psip = 1;
                    //调用受热面利用系数计算模块，得到KeSai
                    double KeSai = 0;
                    ret = CalaulateHeatSurfaceUtilizationCoeddicient(hrqxs, pwz, csfs, ref KeSai);
                    if (0 != ret)
                    {
                        return ret;
                    }
                    Alpha1 = KeSai * (Alphak + Alphan);
                }
                else if (2 == gzlx || 5 == gzlx)
                {
                    if (2 == gzlx)
                    {
                        hp = (s2 - d) / 2;
                    }
                    double Htaop = 2 * d * l * Math.Acos(delTap / (2 * d)) * z1 * z2;
                    double HpDelta = (2 * delTap * l + 4 * hp * l) * z1 * z2;
                    H = Htaop + HpDelta;
                    Psip = H / (Math.PI * d * l * z1 * z2);
                    double PhiTaop = 0;
                    double PhipDelta = 0;
                    double m = 0;
                    double E = 0;
                    if (1 == csfs)
                    {
                        PhiTaop = 1.08;
                        PhipDelta = 0;
                        if (2 == hrqxs)
                        {
                            PhipDelta = 1 - 0.12 / (SigMa2 - 1);
                        }
                        else if (3 == hrqxs && 5.0 >= SigMa1 && 0.75 <= SigMa2)
                        {
                            PhipDelta = 1 - (0.05 * Math.Pow(SigMa1 * Math.Pow(SigMa2, 0.5), 0.8) - 0.03) / (2 * SigMa1 - 1);
                        }
                        else if (3 == hrqxs && 5.0 < SigMa1)
                        {
                            double SigMa2_1 = 2 * SigMa2;
                            PhipDelta = 1 - 0.12 / (SigMa2_1 - 1);
                        }
                        else
                        {
                            bError = true;
                        }
                    }
                    else if (2 == csfs)
                    {
                        PhiTaop = 1.0;
                        PhipDelta = 1.0;
                    }
                    else
                    {
                        bError = true;
                    }
                    m = Math.Sqrt((2 * (PhipDelta * Alphak + Alphan)) / (delTap * LamdapDelta));

                    E = th * (m * hp) / (m * hp);
                    Alpha1 = (Htaop / H) * (PhiTaop * Alphak + Alphan) + (HpDelta * E / H) * (PhipDelta * Alphak + Alphan);
                }
                else if (3 == gzlx || 4 == gzlx)
                {
                    double hp_1 = 0;
                    double D_1 = 0;
                    double m = 0;
                    double E = 0;
                    if (3 == gzlx)
                    {
                        Psip = 2 * (Math.Pow(D, 2) - 0.785 * Math.Pow(d, 2) + 2 * D * delTap) / (Math.PI * d * sp) + 1 - delTap / sp;
                        hp_1 = 0.5 * (1.13 * D - d);
                        D_1 = 1.13D;
                    }
                    else if (4 == gzlx)
                    {
                        Psip = 2 * (Math.Pow(D, 2) - 0.785 * Math.Pow(d, 2) + 2 * D * delTap) / (Math.PI * d * sp) + 1 - delTap / sp;
                        hp_1 = 0.5 * (D - d);
                        D_1 = D;
                    }
                    double Htaop = (H / Psip) * (1 - delTap / sp);
                    double HpDelta = H - Htaop;
                    H = Psip * Math.PI * d * l * z1 * z2;
                    m = Math.Sqrt(2 * Alphak / (delTap * LamdapDelta));
                    double PhiE = 1 - 0.058 * m * hp;
                    //
                    E = 323;//根据D_1/D、m*hp_1，按线算图6确定肋片有效系数E
                    Alpha1 = (Htaop / H + HpDelta / H * E * PhiE) * Alphak;
                }
                else if (6 == gzlx || 7 == gzlx)
                {

                    double Phi = 2 * Math.Acos(sb / (2 * d));
                    // double hb = 0;
                    double Rc = Math.Sqrt((360 / (Phi * Math.PI)) * ((lb / 2) * hb + (Math.Pow(d, 2) / 8) * Math.Sin(Phi)));
                    double D_1 = 2 * Rc;
                    double hb_1 = Rc - 0.5 * d;
                    double HpDelta = 2 * (l / sp) * z1 * z2 * (lb * hb - (Phi / 360) * (Math.PI * Math.Pow(d, 2) / 2) + (Math.Pow(d, 2) / 4) * Math.Sin(Phi) + (lb + hb - d * Math.Sin(Phi / 2)) * delTab);
                    double Htaop = Math.PI * d * l * z1 * z2 * (1 - (delTab / sp) * (Phi / 180));
                    Psip = (HpDelta + Hrp) / (Math.PI * d * l * z1 * z2);
                    double m = Math.Sqrt((2 * Alphak) / (delTap * LamdapDelta));
                    //根据D_1/d、m*hb_1，按线算图6确定肋片有效系数E
                    double E = 0;
                    //根据lb/d、hb_1/d、sp/d，按表7 - 3确定系数PhiE
                    double PhiE = 0;
                    if (6 == gzlx)
                    {
                        Alpha1 = (Htaop / H + HpDelta / H * E * PhiE) * Alphak;
                    }
                    else if (7 == gzlx)
                    {
                        double m_1 = Math.Sqrt((2 * Alphak) / (delTap * LamdapDelta));
                        E = th * (m_1 * hp) / (m_1 * hp);
                        double Hnn = 4 * hp * l * z1 * z2;
                        double Htaop_1 = Htaop - 2 * delTap * l * z1 * z2;
                        double H_1 = HpDelta + Hnn + Htaop_1;
                        Alpha1 = (Htaop / H + (Hnn / H) * Enn + (HpDelta / H) * E * PhiE) * Alphak;
                    }
                }
                //由Alpha1、H调用管外壁温度计算模块得到Twb_1
                double Twb_1 = 0;
                ret = CalculateOuterWallTemperature(hrqxs, SRFS, d, DelTad, l, z1, z2, i1, T1, Alpha1, H, Qn, Bp, Q, t, bIsWet, P1, P2, i2, SigMa, G, gzyh, rlxs, CaO, chzz, Alphat, gzlx, gttjj, ref Twb);
                if (0 != ret)
                {
                    return ret;
                }
                if (0.001 < Math.Abs((Twb - Twb_1) / Twb_1))
                {
                    Twb = Twb_1;
                }
                else
                {
                    bneedContinue = false;
                }
            } while (bneedContinue && !bError);
            return 0;
        }
        #endregion

        #region  10.燃烧产物辐射放热系数Alphan 参数注释不全
        /// <summary>
        /// 10.燃烧产物辐射放热系数Alphan
        /// </summary>
        /// <param name="rlxs">燃料型式(1:煤,2:重油)</param>
        /// <param name="rmzl">燃煤种类（1:无烟煤屑,2:烟煤,3:贫煤,4:褐煤,5:页岩,6:泥煤）</param>
        /// <param name="Twb">外壁温</param>
        /// <param name="p">压力</param>
        /// <param name="s"></param>
        /// <param name="T3"></param>
        /// <param name="T4"></param>
        /// <param name="lodelta">烟气空间的深度</param>
        /// <param name="Todelta">烟气温度</param>
        /// <param name="hrqxs">换热器型式（1:屏式,2:顺列管束,3:错列管束）</param>
        /// <param name="SigMaXp"></param>
        /// <param name="s1"></param>
        /// <param name="ln">调用气体燃料辐射减弱系数模块:烟气空间后管束深度</param>
        /// <param name="rn">调用气体燃料辐射减弱系数模块:三原子气体的总容积份额R</param>
        /// <param name="rh2o">调用气体燃料辐射减弱系数模块:烟气中水蒸气容积份额</param>
        /// <param name="Ttn">调用气体燃料辐射减弱系数模块:炉膛出口烟气温度</param>
        /// <param name="Mui3n"></param>
        /// <param name="glxs">锅炉形式（1:煤粉炉,2:循环流化床,3:链条炉,4:油气炉）</param>
        /// <param name="pzfs">排渣方式（1:固体排渣,2:液体排渣）</param>
        /// <param name="Alphat"></param>
        /// <param name="CH"></param>
        /// <param name="qyrl">气液燃料种类（1:重油,2:轻质油）</param>
        /// <param name="T"></param>
        /// <param name="Hn"></param>
        /// <param name="Bp"></param>
        /// <param name="Qn"></param>
        /// <param name="Alphan">燃烧产物辐射放热系数</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateRadiateHeaReleaseCoefficient(double rlxs, double rmzl, double Twb, double p, double s, double T3, double T4, double lodelta, double Todelta, double hrqxs, double SigMaXp, double s1, double ln, double rn, double rh2o, double Ttn, double Mui3n, double glxs, double pzfs, double Alphat, double CH, double qyrl, double T, double Hn, double Bp, ref double Qn, ref double Alphan)
        {
            //Step1:计算Tcp
            double Tcp = (T3 + T4) / 2;
            //Step2:由Tcp p s 烟气参数调用燃料辐射减弱系数模块得到kcp：气体
            double kcp = 0;
            int ret = CalculateGasOrLiquidFuelWeakenCoefficent(rn, rh2o, p, Ttn, s, Alphat, CH, glxs, pzfs, qyrl, ref kcp);
            if (0 != ret)
            {
                return ret;
            }
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
            double Alphan1 = 5.67 * Math.Pow(10, -8) * (a3 + 1) / 2 * a * Math.Pow(T, 3) * ((1 - Math.Pow(Twb / T, n) / (1 - Twb / T)));
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
            return 0;
        }
        #endregion

        #region 11.管外壁温度Twb 参数注释不全
        /// <summary>
        /// 11.管外壁温度Twb
        /// </summary>
        /// <param name="hrqxs">换热器型式（1:屏式,2:顺列管束,3:错列管束）</param>
        /// <param name="SRFS">受热方式（1:单面,2:双面）</param>
        /// <param name="d"></param>
        /// <param name="DelTad"></param>
        /// <param name="l"></param>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <param name="i1"></param>
        /// <param name="T1"></param>
        /// <param name="Alpha1"></param>
        /// <param name="H"></param>
        /// <param name="Qn"></param>
        /// <param name="Bp"></param>
        /// <param name="Q"></param>
        /// <param name="t"></param>
        /// <param name="bIsWet"></param>
        /// <param name="Twb"></param>
        /// <param name="P1">调用Alpha2计算模块17</param>
        /// <param name="P2">调用Alpha2计算模块17</param>
        /// <param name="i2">调用Alpha2计算模块17</param>
        /// <param name="SigMa">调用Alpha2计算模块17</param>
        /// <param name="G">调用Alpha2计算模块17</param>
        /// <param name="gzyh">调用Alpha2计算模块17</param>
        /// <param name="G">调用Alpha2计算模块17</param>
        /// <param name="rlxs">调用受热面污染系数计算模块13</param>
        /// <param name="CaO">调用受热面污染系数计算模块13</param>
        /// <param name="chzz">调用受热面污染系数计算模块13</param>
        /// <param name="Alphat">调用受热面污染系数计算模块13</param>
        /// <param name="gzlx">调用受热面热利用系数计算模块14</param>
        /// <param name="gttjj">调用受热面热利用系数计算模块14</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateOuterWallTemperature(double hrqxs, double SRFS, double d, double DelTad, double l, double z1, double z2, double i1, double T1, double Alpha1, double H, double Qn, double Bp, double Q, double t, bool bIsWet, double P1, double P2, double i2, double SigMa, double G, double gzyh, double rlxs, double CaO, double chzz, double Alphat, double gzlx, double gttjj, ref double Twb)
        {
            double HBH = Math.PI * (d - 2 * DelTad) * l * z1 * z2;
            double Alpha2 = 0;
            int ret = 0;
            if (!bIsWet)//湿蒸汽
            {
                //1 / Alpha2 = 0; 无穷大
                Alpha2 = double.PositiveInfinity;
            }
            else if (bIsWet)//干蒸汽
            {
                //调用Alpha2计算模块17得到Alpha2
                ret = CalculateWaterAngGasHeatCoefficient(P1, P2, i1, i2, d, SigMa, G, l, z1, z2, gzyh, hrqxs, SRFS, DelTad, T1, Alpha1, H, Qn, Bp, Q, t, bIsWet, rlxs, CaO, chzz, Alphat, gzlx, gttjj, ref Alpha2);
                if (0 != ret)
                {
                    return ret;
                }
            }
            if (1 == hrqxs || 1 == SRFS)
            {
                //根据换热器参数，调用受热面污染系数计算模块13，得到epslion
                double epslion = 0;
                ret = CalculateHeatingSurfacePollutionCoefficient(hrqxs, rlxs, CaO, chzz, Alphat, SRFS, ref epslion);
                if (0 != ret)
                {
                    return ret;
                }
                Twb = t + (epslion + 1 / Alpha2) * (Bp / H) * (Qn + Q) * Math.Pow(10, 3) + 273;
            }
            else if ((2 == hrqxs || 3 == hrqxs) && 2 == SRFS)
            {
                //根据换热器参数，调用受热面热利用系数计算模块14，得到psi
                double psi = 0;
                ret = CalculateHeatCoefficient(hrqxs, rlxs, gzlx, CaO, chzz, gttjj, Alphat, ref psi);
                if (0 != ret)
                {
                    return ret;
                }
                Twb = t + ((1 / psi) * ((1 / Alpha1) + ((1 / Alpha2) * (H / HBH)) - (1 / Alpha1))) * (Bp / H) * (Qn + Q) * Math.Pow(10, 3) + 273;
            }
            else
            {
                return -1;
            }
            return 0;
        }
        #endregion

        #region 12.受热面利用系数KeSai计算 OK
        /// <summary>
        /// 12.受热面利用系数KeSai计算
        /// </summary>
        /// <param name="hrqxs">换热器型式（1:屏式,2:顺列管束,3:错列管束）</param>
        /// <param name="pwz">屏的位置（1:前屏,2:侧面屏,3:双侧面屏,4:后屏,5:大屏,6:水平横屏,7:水平纵屏）</param>
        /// <param name="csfs">烟气冲刷方式（1:横向,2:纵向,3:混合）</param>
        /// <param name="KeSai">受热面利用系数</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalaulateHeatSurfaceUtilizationCoeddicient(double hrqxs, double pwz, double csfs, ref double KeSai)
        {
            if (1 == hrqxs)
            {
                if (1 == pwz || 2 == pwz || 3 == pwz)
                {
                    KeSai = 0.6;
                }
                else if (4 == pwz)
                {
                    KeSai = 0.8;
                }
                else if (5 == pwz)
                {
                    KeSai = 0.7;
                }
                else
                {
                    KeSai = 1.0;
                }
            }
            else if ((2 == hrqxs || 3 == hrqxs) && 3 == csfs)
            {
                KeSai = 0.95;
            }
            else
            {
                KeSai = 1.0;
            }
            return 0;
        }
        #endregion

        #region 13.对流受热面污染系数EpsaiLen计算 图形公式
        /// <summary>
        /// 13.对流受热面污染系数EpsaiLen计算
        /// </summary>
        /// <param name="hrqxs">换热器型式（1:屏式,2:顺列管束,3:错列管束）</param>
        /// <param name="rlxs">燃料型式(1:煤,2:重油)</param>
        /// <param name="CaO">氧化钙</param>
        /// <param name="chzz">吹灰装置（1:有,2:无）</param>
        /// <param name="Alphat"></param>
        /// <param name="SRFS">受热方式（1:单面,2:双面）</param>
        /// <param name="EpsaiLen">返回值:对流受热面污染系数</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateHeatingSurfacePollutionCoefficient(double hrqxs, double rlxs, double CaO, double chzz, double Alphat, double SRFS, ref double EpsaiLen)
        {
            if (1 == hrqxs)
            {
                if (1 == rlxs)
                {
                    if (0.13 > CaO)
                    {
                        //按曲线1计算 拟合公式未知
                        EpsaiLen = sad;
                    }
                    else if (0.13 <= CaO && 0 == chzz)
                    {
                        //按曲线2计算
                        EpsaiLen = sad;
                    }
                    else if (0.13 <= CaO && 1 == chzz)
                    {
                        //按曲线3计算
                        EpsaiLen = sad;
                    }
                }
                else if (2 == rlxs)
                {
                    if (1.03 > Alphat)
                    {
                        EpsaiLen = 0.0025;
                    }
                    else
                    {
                        EpsaiLen = 0.005;
                    }
                }
                else if (3 == rlxs)
                {
                    EpsaiLen = 0.0015;
                }
            }
            else if (2 == hrqxs || 3 == hrqxs)
            {
                if (1 == SRFS && 1 == rlxs)
                {
                    EpsaiLen = 0.005;
                }
                else if (1 == SRFS && 2 == rlxs)
                {
                    EpsaiLen = 0.003;
                }
            }
            return 0;
        }
        #endregion

        #region 14.热利用系数计算
        /// <summary>
        /// 14.热利用系数计算
        /// </summary>
        /// <param name="hrqxs">换热器型式（1:屏式,2:顺列管束,3:错列管束）</param>
        /// <param name="rlxs">燃料型式(1:煤,2:重油)</param>
        /// <param name="gzlx">管子类型（1:光管式,2:膜式）</param>
        /// <param name="CaO">氧化钙</param>
        /// <param name="chzz">吹灰装置（0:无,1:有）</param>
        /// <param name="gttjj">添加固体添加剂（0:无,1:有）</param>
        /// <param name="PeSai">返回值:热利用系数计算</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateHeatCoefficient(double hrqxs, double rlxs, double gzlx, double CaO, double chzz, double gttjj, double Alphat, ref double PeSai)
        {
            if (1 == rlxs)
            {
                if (1 == gzlx || 2 == gzlx || 5 == gzlx || 6 == gzlx || 7 == gzlx)
                {
                    if (0.13 > CaO || 1 == chzz)
                    {
                        //按曲线1计算
                        PeSai = ddddd;
                    }
                    else if (0.13 <= CaO && 0 == chzz)
                    {
                        //按曲线2计算
                        PeSai = ddddd;
                    }
                }
                else if (3 == gzlx || 4 == gzlx)
                {
                    //按曲线1计算
                    PeSai = ddddd;
                }
            }
            else if (2 == rlxs)
            {
                if ((0 == gttjj && 1.03 > Alphat) || (1 == gttjj && 1 == chzz))
                {
                    if (2 == hrqxs)
                    {
                        PeSai = 0.65;
                    }
                    else if (3 == hrqxs)
                    {
                        PeSai = 0.6;
                    }
                }
                else if ((0 == gttjj && 1.03 < Alphat) || (1 == gttjj && 0 == chzz))
                {
                    if (2 == hrqxs)
                    {
                        PeSai = 0.6;
                    }
                    else if (3 == hrqxs)
                    {
                        PeSai = 0.55;
                    }
                }
            }
            else if (3 == rlxs)
            {
                if (1 == hrqxs)
                {
                    PeSai = 0.75;
                }
                else
                {
                    PeSai = 0.8;
                }
            }
            else
            {
                return -1;
            }
            return 0;
        }
        #endregion

        #region 15.烟气流通截面积Fr 参数注释不全
        /// <summary>
        /// 15.烟气流通截面积Fr
        /// </summary>
        /// <param name="gzlx">管子类型（1:光管式,2:膜式）</param>
        /// <param name="csfs">烟气冲刷方式（1:横向,2:纵向,3:混合）</param>
        /// <param name="hrqxs">换热器型式（1:屏式,2:顺列管束,3:错列管束）</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <param name="SigMa1"></param>
        /// <param name="SigMa2"></param>
        /// <param name="sp"></param>
        /// <param name="hp"></param>
        /// <param name="D"></param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="DelTap"></param>
        /// <param name="Fr">返回值:烟气流通截面积</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateFlueGasFlowArea(double gzlx, double csfs, double hrqxs, double d, double l, double z1, double z2, double SigMa1, double SigMa2, double sp, double hp, double D, double s1, double s2, double DelTap, ref double Fr)
        {
            int ret = 0;
            if ((1 == gzlx || 2 == gzlx) && 1 == csfs)
            {
                if (2 == hrqxs)
                {
                    Fr = (z1 + 1) * s1 * (l + s1) - z1 * l * d;
                }
                else if (3 == hrqxs && 1.7 < ((SigMa1 - 1) / (SigMa2 - 1)))
                {
                    Fr = 2 * ((Math.Sqrt(Math.Pow(0.5 * SigMa1, 2) + Math.Pow(SigMa2, 2)) - 1) / (SigMa1 - 1)) * ((z1 + 1) * s1 * (l + s1) - z1 * l * d);
                }
            }
            else if ((3 == gzlx || 4 == gzlx) && 1 == csfs)
            {
                if (2 == hrqxs)
                {
                    Fr = (1 - 1 / SigMa1 * (1 + 2 * (D / sp) * (DelTap / d))) * (z1 + 1) * s1 * (l + s1);
                }
                else if (3 == hrqxs && 1.7 < ((SigMa1 - 1) / (SigMa2 - 1)))
                {
                    Fr = 2 * ((Math.Sqrt(Math.Pow(0.5 * SigMa1, 2) + Math.Pow(SigMa2, 2)) - 1) / (SigMa1 - 1)) * (1 - 1 / SigMa1 * (1 + 2 * (D / sp) * (DelTap / d))) * (z1 + 1) * s1 * (l + s1);
                }
            }
            else if (1 == gzlx && 2 == csfs)
            {
                Fr = (z1 + 1) * (z2 + 1) * s1 * s2 - z1 * z2 * (Math.PI * Math.Pow(d, 2) / 4);
            }
            else if (2 == gzlx || 2 == csfs)
            {
                Fr = (z1 + 1) * (z2 + 1) * s1 * s2 - z1 * z2 * ((Math.PI * Math.Pow(d, 2) / 4) + (s2 - d) * DelTap);
            }
            else if (5 == gzlx || 2 == csfs)
            {
                Fr = (z1 + 1) * (z2 + 1) * s1 * s2 - z1 * z2 * ((Math.PI * Math.Pow(d, 2) / 4) + 2 * hp * DelTap);
            }
            return ret;
        }
        #endregion

        #region 16.烟气的对流放热系数计算
        /// <summary>
        /// 16.烟气的对流放热系数计算
        /// </summary>
        /// <param name="gzlx">管子类型（1:光管式,2:膜式）</param>
        /// <param name="csfs">烟气冲刷方式（1:横向,2:纵向,3:混合）</param>
        /// <param name="hrqxs">换热器型式（1:屏式,2:顺列管束,3:错列管束）</param>
        /// <param name="d"></param>
        /// <param name="l"></param>
        /// <param name="lb"></param>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="DelTap"></param>
        /// <param name="DelTab"></param>
        /// <param name="hp"></param>
        /// <param name="D"></param>
        /// <param name="Sp"></param>
        /// <param name="Sb"></param>
        /// <param name="T3"></param>
        /// <param name="T4"></param>
        /// <param name="Fr"></param>
        /// <param name="Qr"></param>
        /// <param name="th"></param>
        /// <param name="hb"></param>
        /// <param name="z"></param>
        /// <param name="lpDelTa"></param>
        /// <param name="Hrp"></param>
        /// <param name="Alphak">返回值:烟气的对流放热系数计算</param>
        /// <param name="sInfo">错误信息</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateFlueGasFlowHeatCoeffiient(double gzlx, double csfs, double hrqxs, double d, double l, double lb, double z1, double z2, double s1, double s2, double DelTap, double DelTab, double hp, double D, double Sp, double Sb, double T3, double T4, double Fr, double Qr, double th, double hb, double z, double lpDelTa, double Hrp, ref double Alphak, ref string sInfo)
        {
            //平均温度
            double T_1 = (T3 + T4) / 2;
            double v = 0, Rou = 0, Lamda = 0, cp = 0;//由T_1确定，
            //平均温度下烟气的普朗特数
            double Pr = v * Rou * cp / Lamda;
            //烟气的计算速度
            double w = Qr / (Rou * Fr);
            double SigMa1 = s1 / d;
            double SigMa2 = s2 / d;
            //横向冲刷顺列光管管束和屏
            if (1 == gzlx && 1 == csfs && (1 == hrqxs || 2 == hrqxs))
            {
                double Cs = 0;
                double Cz = 0;
                if (2 <= SigMa2 && 1.5 >= SigMa1)
                {
                    Cs = 1;
                }
                else if (2 > SigMa1 && 3 < SigMa2)
                {
                    SigMa1 = 3;
                    Cs = Math.Pow(1 + (2 * SigMa1 - 3) * Math.Pow(1 - 0.5 * SigMa2, 3), -2);
                }
                if (10 > z2)
                {
                    Cz = 0.91 + 0.125 * (z2 - 2);
                }
                else if (10 <= z2)
                {
                    Cz = 1;
                }
                Alphak = 0.2 * Cs * Cz * (Lamda / d) * Math.Pow(w * d / v, 0.65) * Math.Pow(Pr, 0.33);
            }
            //横向冲刷错列光管管束   和上一个条件一样？？？？？
            else if (1 == gzlx && 1 == csfs && (1 == hrqxs || 2 == hrqxs))
            {
                double Cs = 0;
                double Cz = 0;
                double Phi = (SigMa1 - 1) / (Math.Sqrt(Math.Pow(0.5 * SigMa1, 2) + Math.Pow(SigMa2, 2) - 1));
                if (0.1 <= Phi && 1.7 >= Phi)
                {
                    Cs = 0.95 * Math.Pow(Phi, 0.1);
                }
                else if (1.7 < Phi && 4.5 >= Phi && 3 > SigMa1)
                {
                    Cs = 0.77 * Math.Pow(Phi, 0.5);
                }
                else if (1.7 < Phi && 4.5 >= Phi && 3 <= SigMa1)
                {
                    Cs = 0.95 * Math.Pow(Phi, 0.1);
                }
                else if (0.1 > Phi || 4.5 < Phi)
                {
                    sInfo = "管束不合理";
                    return -1;
                }
                if (10 > z2 && 3 > SigMa1)
                {
                    Cz = 3.12 * Math.Pow(z2, 0.05) - 2.5;
                }
                else if (10 > z2 && 3 <= SigMa1)
                {
                    Cz = 4.0 * Math.Pow(z2, 0.02) - 3.2;
                }
                else if (10 <= z2)
                {
                    Cz = 1;
                }
                Alphak = 0.36 * Cs * Cz * (Lamda / d) * Math.Pow(w * d / v, 0.6) * Math.Pow(Pr, 0.330);
            }
            //横向冲刷膜式和鳍片式顺列管束和屏
            else if ((2 == gzlx || 5 == gzlx) && 1 == csfs && (1 == hrqxs || 2 == hrqxs))
            {
                double Cs = 0;
                double Cz = 0;
                if (1.45 <= SigMa2 && 3.5 >= SigMa2 && 3.0 >= SigMa1)
                {
                    Cs = 0.64;
                }
                else if (1.45 <= SigMa2 && 3.5 >= SigMa2 && 3.0 < SigMa1 && 5.0 >= SigMa1)
                {
                    Cs = 0.64 - 0.035 * (SigMa1 - 3.0);
                }
                else if (1.45 <= SigMa2 && 3.5 >= SigMa2 && 5.0 < SigMa1)
                {
                    Cs = 0.57;
                }
                else if (1.45 > SigMa2 || 3.5 < SigMa2)
                {
                    sInfo = "管束不合理";
                    return -1;
                }
                if (8 > z2)
                {
                    Cz = 1.0 + 0.017 * (8 - z2);
                }
                else if (8 <= z2)
                {
                    Cz = 1;
                }
                Alphak = 0.1 * Cs * Cz * (Lamda / d) * Math.Pow(w * d / v, 0.75) * Math.Pow(Pr, 0.33);
            }
            //横向冲刷膜式和鳍片式错列管束
            else if ((2 == gzlx || 5 == gzlx) && 1 == csfs && 3 == hrqxs)
            {
                double Cs = 0;
                double Cz = 0;
                Cs = 0.78 * (Math.Pow(SigMa1, -1.2) * ((SigMa1 - 1) / (Math.Sqrt(Math.Pow(SigMa1, 2) + 4 * Math.Pow(SigMa2, 2) - 2)) + 1));
                if (6 > z2 && 3 > SigMa1)
                {
                    Cz = 1.0 - 0.017 * (8 - z2);
                }
                else if (8 > z2 && 3 <= SigMa1)
                {
                    Cz = 1.0 - 0.0083 * (8 - z2);
                }
                else if (8 <= z2)
                {
                    Cz = 1;
                }
                Alphak = 0.14 * Cs * Cz * (Lamda / d) * Math.Pow(w * d / v, 0.75) * Math.Pow(Pr, 0.33);
            }
            //横向冲刷错列和顺列布置的、带有圆形（包括螺旋-带状肋片）和正方型横肋管束
            else if ((3 == gzlx || 4 == gzlx) && 1 == csfs && (2 == hrqxs || 3 == hrqxs))
            {
                double Cs = 0;
                double Cz = 0;
                double Psip = 0;
                double x = 0;
                double Phi = 0;
                double n = 0;
                if (3 == gzlx)
                {
                    Psip = 2 * (Math.Pow(D, 2) - 0.785 * Math.Pow(d, 2) + 2 * D * DelTap) / (Math.PI * d * Sp) + 1 - DelTap / Sp;
                }
                else if (4 == gzlx)
                {
                    Psip = (1 / 2 * d * Sp) * (Math.Pow(D, 2) - Math.Pow(d, 2) + 2 * D * DelTap) + 1 - DelTap / Sp;
                }
                if (2 == hrqxs)
                {
                    x = 4 * (Psip / 7 + 2 - SigMa2);
                }
                else if (3 == hrqxs)
                {
                    x = SigMa1 / SigMa2 - 1.26 / Psip - 2;
                }
                Phi = th * x;
                Cs = (1.36 - Phi) * (11 / (Psip + 8) - 0.14);
                n = 0.7 + 0.08 * Phi * 0.005 * Psip;
                if (8 > z2 && 2 > SigMa1 / SigMa2)
                {
                    Cz = 3.15 * Math.Pow(z2, 0.05) - 2.5;
                }
                else if (8 > z2 && 2 <= SigMa1 / SigMa2)
                {
                    Cz = 3.5 * Math.Pow(z2, 0.03) - 2.72;
                }
                else if (8 <= z2)
                {
                    Cz = 1;
                }
                Alphak = 0.113 * Cs * Cz * (Lamda / d) * Math.Pow(w * d / v, n) * Math.Pow(Pr, 0.33);
            }
            //横向冲刷瓣形肋片错列管束
            else if (6 == gzlx && 1 == csfs && 3 == hrqxs)
            {
                double Cs = 0;
                double Cz = 0;
                double Phi = 2 * Math.Acos(Sb / d);
                double HpDelta = 2 * (l / Sp) * z1 * z2 * (lpDelTa * hp - (Phi / 360) * (Math.PI * Math.Pow(d, 2) / 2) + (Math.Pow(d, 2) / 4) * Math.Sin(Phi) + (lpDelTa + hp + d * Math.Sin(Phi / 2) * DelTap));
                double Htaop = Math.PI * d * l * z1 * z2 * (1 - (DelTap / Sp) * (Phi / 180));
                double Psip = (HpDelta + Hrp) / Math.PI * d * l * z1 * z2;
                double x = SigMa1 / SigMa2 - 1.26 / Psip - 2;
                double Phi_1 = th * x;
                Cs = (1.36 - Phi_1) * (11 / (Psip + 8) - 0.14);
                double n = 0.7 + 0.08 * Phi_1 + 0.005 * Psip;
                if (8 > z2 && 2 > SigMa1 / SigMa2)
                {
                    Cz = 3.15 * Math.Pow(z2, 0.05) - 2.5;
                }
                else if (8 > z2 && 2 <= SigMa1 / SigMa2)
                {
                    Cz = 3.5 * Math.Pow(z2, 0.03) - 2.72;
                }
                else if (8 <= z2)
                {
                    Cz = 1;
                }
                Alphak = 0.113 * Cs * Cz * (Lamda / d) * Math.Pow(w * d / v, n) * Math.Pow(Pr, 0.33);
            }
            //横向冲刷瓣式与膜-瓣式肋化错列管束
            else if ((6 == gzlx || 7 == gzlx) && 1 == csfs && 3 == hrqxs)
            {
                double Cs = 0;
                double Cz = 0;
                double Htaop = 0;
                double Psip = 0;
                double Phi = 2 * Math.Acos(Sb / d);
                double HpDelta = 2 * (l / Sp) * z1 * z2 * (lb * hb - (Phi / 360) * (Math.PI * Math.Pow(d, 2) / 2) + (Math.Pow(d, 2) / 4) * Math.Sin(Phi) + (lb + hb - d * Math.Sin(Phi / 2) * DelTab));

                if (6 == gzlx)
                {
                    Htaop = Math.PI * d * l * z1 * z2 * (1 - (DelTab / Sp) * (Phi / 180));
                    Psip = (HpDelta + Hrp) / (Math.PI * d * l * z1 * z2);
                }
                else if (7 == gzlx)
                {
                    Hrp = Math.PI * d * l * z1 * z2 * (1 - (DelTab / Sp) * (Phi / 180)) - 2 * DelTap * l * z1 * z2;
                    Psip = (HpDelta + 4 * hp * l * z1 * z2 + Hrp) / (Math.PI * d * l * z1 * z2);
                }
                double x = SigMa1 / SigMa2 - 1.26 / Psip - 2;
                double Phi_1 = th * x;
                Cs = (1.36 - Phi_1) * (11 / (Psip + 8) - 0.14);
                double n = 0.7 + 0.08 * Phi_1 * 0.005 * Psip;
                if (8 > z2 && 2 > SigMa1 / SigMa2)
                {
                    Cz = 3.15 * Math.Pow(z2, 0.05) - 2.5;
                }
                else if (8 > z2 && 2 <= SigMa1 / SigMa2)
                {
                    Cz = 3.5 * Math.Pow(z2, 0.03) - 2.72;
                }
                else if (8 < z2)
                {
                    Cz = 1;
                }
                if (6 == gzlx)
                {
                    Alphak = 0.113 * Cs * Cz * (Lamda / d) * Math.Pow(w * d / v, n) * Math.Pow(Pr, 0.33);
                }
                else if (7 == gzlx)
                {
                    Alphak = 0.09 * Cs * Cz * (Lamda / d) * Math.Pow(w * d / v, n) * Math.Pow(Pr, 0.33);
                }
            }
            //横向冲刷带金属螺旋线肋片错列管束
            else if (8 == gzlx && 1 == csfs && 1 == hrqxs)
            {
                Alphak = 2.55 * (Lamda / Sp) * Math.Pow(SigMa1, 0.2) * Math.Pow(SigMa2, -0.1) * Math.Pow(Math.PI * d / (z * hp), 0.36) * Math.Pow(d / Sp, -0.6) * Math.Pow(w * Sp / v, 0.46) * Math.Pow(Pr, 0.33);
            }
            //纵向冲刷管束
            else if (2 == csfs)
            {
                double dEpsilon = (4 * (s1 * z1 * s2 * z2 - z1 * z2 * (Math.PI * Math.Pow(d, 2) / 4))) / (2 * (s1 * z1 + s2 * z2) + z1 * z2 * Math.PI * d);
                double C1 = 0;
                if (1 == hrqxs && 50 <= l / d)
                {
                    C1 = 1.0;
                }
                else
                {
                    C1 = 12;//图11计算
                }
                Alphak = 0.023 * (Lamda / d) * Math.Pow(w * dEpsilon / v, 0.8) * Math.Pow(Pr, 0.4) * C1;
            }
            return 0;
        }
        #endregion

        #region 17.管壁向水和蒸汽的放热系数Alpha2
        /// <summary>
        /// 17.管壁向水和蒸汽的放热系数Alpha2
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <param name="d"></param>
        /// <param name="SigMa"></param>
        /// <param name="G"></param>
        /// <param name="l"></param>
        /// <param name="z1"></param>
        /// <param name="z2"></param>
        /// <param name="gzyh"></param>
        /// <param name="hrqxs">调用壁温计算模块</param>
        /// <param name="SRFS">调用壁温计算模块</param>
        /// <param name="DelTad">调用壁温计算模块</param>
        /// <param name="T1">调用壁温计算模块</param>
        /// <param name="Alpha1">调用壁温计算模块</param>
        /// <param name="H">调用壁温计算模块</param>
        /// <param name="Qn">调用壁温计算模块</param>
        /// <param name="Bp">调用壁温计算模块</param>
        /// <param name="Q">调用壁温计算模块</param>
        /// <param name="t">调用壁温计算模块</param>
        /// <param name="bIsWet">调用壁温计算模块</param>
        /// <param name="rlxs">调用壁温计算模块</param>
        /// <param name="CaO">调用壁温计算模块</param>
        /// <param name="chzz">调用壁温计算模块</param>
        /// <param name="Alphat">调用壁温计算模块</param>
        /// <param name="gzlx">调用壁温计算模块</param>
        /// <param name="gttjj">调用壁温计算模块</param>
        /// <param name="Alpha2"></param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateWaterAngGasHeatCoefficient(double P1, double P2, double i1, double i2, double d, double SigMa, double G, double l, double z1, double z2, double gzyh, double hrqxs, double SRFS, double DelTad, double T1, double Alpha1, double H, double Qn, double Bp, double Q, double t, bool bIsWet, double rlxs, double CaO, double chzz, double Alphat, double gzlx, double gttjj, ref double Alpha2)
        {
            double di = d - 2 * SigMa;
            double P = (P1 + P2) / 2;
            double i = (i1 + i2) / 2;
            //由P i 确定工质的平均导热系数Lambda 运动粘度v 密度Rou  比热容Cp 干度x
            double Lamda = 0;
            double v = 0;
            double Rou = 0;
            double Cp = 0;
            double x = 0;

            //对于压力P的饱和蒸汽焓is_2、蒸汽密度Rou_2与饱和水焓is_1、水密度Rou_1
            double is_2 = 0;
            double Rou_2 = 0;
            double is_1 = 0;
            double Rou_1 = 0;

            double w = 4 * G / (Rou * Math.PI * Math.Pow(di, 2));
            double Re = w * d / v;
            double Pr = v * Rou * Cp / Lamda;
            double qi = (G * (i2 - i1)) / (Math.PI * di * l * z1 * z2);
            if ((22 >= P && i <= is_1) || (22 >= P && i > is_2) || (22 < P && 2800 < i) || (22 < P && 840 > i))
            {
                if (Math.Pow(10, 6) < Re)
                {
                    Alpha2 = 0.023 * (Lamda / d) * Math.Pow(Re, 0.8) * Math.Pow(Pr, 0.4);
                }
                else
                {
                    Alpha2 = 0.0133 * (Lamda / d) * Math.Pow(Re, 0.81) * Math.Pow(Pr, 1 / 3);
                }
            }
            else if (22 >= P && (i > is_1 && i < is_2))
            {
                double wo_1 = (w * Rou * (1 - x)) / Rou_1;
                double wo_2 = w * Rou * x / Rou_2;
                double Wcm = wo_1 + wo_2;
                //按照P对应的饱和水参数，计算
                w = 4 * G / (Rou * Math.PI * Math.Pow(di, 2));
                double Res = w * d / v;
                double Prs = v * Rou * Cp / Lamda;
                double Alphak = 0.023 * (Lamda / d) * Math.Pow(Res, 0.8) * Math.Pow(Prs, 0.4);
                double Alpha0 = 4.34 * Math.Pow(qi, 0.7) * (Math.Pow(P, 0.14) + 1.37 * Math.Pow(10, -2) * Math.Pow(P, 2));
                double r = is_2 - is_1;
                double Alphaq = Math.Sqrt(Math.Pow(Alphak, 2) + 0.5 * Math.Pow(Alpha0, 2) * (1 + 7 * Math.Pow(10, -9) * Math.Pow(r * Wcm * Rou_1 / qi, 1.5)));
                if (1 == gzyh)
                {
                    Alpha2 = 1 / ((0.46 / Alphaq) + 0.43 * Math.Pow(10, -4));
                }
                else if (0 == gzyh)
                {
                    Alpha2 = Alphaq;
                }
            }
            else if (22 < P && (840 < i && 2800 > i) && 0.39 >= (qi * Math.Pow(10, -3)) / (w * Rou))
            {
                //调用壁温计算模块得到Tib以及对应的Pr1
                double Tib = 0;
                double Pr1 = 0;
                int ret = CalculateOuterWallTemperature(hrqxs, SRFS, d, DelTad, l, z1, z2, i1, T1, Alpha1, H, Qn, Bp, Q, t, bIsWet, P1, P2, i2, SigMa, G, gzyh, rlxs, CaO, chzz, Alphat, gzlx, gttjj, ref Tib);
                if (0 != ret)
                {
                    return ret;
                }
                double Prmin = 0;
                if (Pr1 > Pr)
                {
                    Prmin = Pr;
                }
                else
                {
                    Prmin = Pr1;
                }
                Alpha2 = 0.023 * (Lamda / di) * Math.Pow(Re, 0.8) * Math.Pow(Prmin, 0.8);
            }
            else if (22 < P && (840 < i && 2800 > i) && 0.39 < (qi * Math.Pow(10, -3)) / (w * Rou))
            {
                //由P、i=840计算物性参数，得到对应的Pr840和Re840
                double Pr840 = 0;
                double Re840 = 0;
                double Lamda840 = 0;
                double Alpha840 = 0.023 * (Lamda840 / di) * Math.Pow(Re840, 0.8) * Math.Pow(Pr840, 0.4);
                double A = 2;//由线算图确定
                Alpha2 = Alpha840;
            }
            return 0;
        }
        #endregion

        #region 18.温压换算系数DelTaT计算
        /// <summary>
        /// 18.温压换算系数DelTaT计算
        /// </summary>
        /// <param name="T1"></param>
        /// <param name="T2"></param>
        /// <param name="T3"></param>
        /// <param name="T4"></param>
        /// <param name="gsbz">管束布置（1:顺流,2:逆流,3:串联中出中进布置,4:串联进中出中布置,5:平行混流布置,6:十字交叉顺流布置,7:十字交叉逆流布置）</param>
        /// <param name="ns"></param>
        /// <param name="nn"></param>
        /// <param name="nx"></param>
        /// <param name="ljxs">十字交叉管束联接型式（1:C型,2:CZ或ZC型）</param>
        /// <param name="dlzjg">十字叫擦汗管束导流罩型式（1:双通道导流罩,2:三通道导流罩）</param>
        /// <param name="H"></param>
        /// <param name="Hs"></param>
        /// <param name="DelTat">返回值:</param>
        /// <param name="Psi">返回值:</param>
        /// <param name="sInfo">错误信息</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public int CalculateTemperaturePressureConvertCoefficient(double T1, double T2, double T3, double T4, double gsbz, double ns, double nn, double nx, double ljxs, double dlzjg, ref double DelTat, double H, double Hs, ref double Psi, ref string sInfo)
        {
            //纯顺流温压计算
            if (1 == gsbz)
            {
                if ((T3 - T1) > (T4 - T2))
                {
                    DelTat = ((T3 - T1) - (T4 - T2)) / Math.Log((T3 - T1) / (T4 - T2));
                }
                else
                {
                    DelTat = ((T4 - T2) - (T3 - T1)) / Math.Log((T4 - T2) / (T3 - T1));
                }
            }
            //纯逆流换算系数计算
            else if (2 == gsbz)
            {
                Psi = 1.0;
            }
            //串联混合流换算系数计算
            else if (3 == gsbz || 4 == gsbz)
            {
                double A = Hs / H;
                double tao1 = 0, tao2 = 0;
                if (3 == gsbz)
                {
                    tao1 = T3 - T4;
                    tao2 = T2 - T1;
                }
                else if (4 == gsbz)
                {
                    tao1 = T2 - T1;
                    tao2 = T3 - T4;
                }
                double P = tao2 / (T3 - T1);
                double R = tao1 / tao2;
                //由A、P和R，根据线算图19可以确定修正系数Psi
                Psi = 12;//????
            }
            //平行混合流换算系数计算
            else if (5 == gsbz)
            {
                double tao1 = T3 - T4;
                double tao2 = T2 - T1;
                double taoDelta;
                double taoM;
                if (tao1 > tao2)
                {
                    taoDelta = tao1;
                    taoM = tao2;
                }
                else
                {
                    taoDelta = tao2;
                    taoM = tao1;
                }
                double B = (H - Hs) / Hs;
                double P = taoM / (T3 - T1);
                double R = taoDelta / taoM;
                //由B、P、R和nn、ns，根据线算图20可以确定修正系数
                if (0.7 <= B && 1.5 >= B)
                {
                    if (2 == nn && 2 == ns)
                    {
                        //Psi线算图20曲线1计算
                        Psi = Psi1;
                    }
                    else if (3 == nn && 2 == ns)
                    {
                        //Psi线算图20曲线2计算
                        Psi = Psi2;
                    }
                    else if (2 * ns == nn)
                    {
                        //Psi线算图20曲线3计算
                        Psi = Psi3;
                    }
                    else if (3 == nn && 1 == ns)
                    {
                        //Psi线算图20曲线4计算
                        Psi = Psi4;
                    }
                    else if (2 == nn && 0 == ns)
                    {
                        //Psi线算图20曲线5计算
                        Psi = Psi5;
                    }
                    else if (3 < nn && ns > nn / 2)
                    {
                        Psi = 0.5 * Psi2 + 0.5 * Psi3;
                    }
                    else if (3 < nn && ns < nn / 2)
                    {
                        Psi = 0.5 * Psi3 + 0.5 * Psi4;
                    }
                    else if (0.7 > B && 1.5 < B)
                    {
                        double Mui = Math.Sqrt(Math.Pow(R, 2) + 1 - 2 * R * (2 * B / (B + 1) - 1));
                        Psi = Mui * Math.Log10((1 - P) / (1 - P * R)) / ((R - 1) * Math.Log10((2 - P * (R + 1 - Mui)) / (2 - P * (R + 1 + Mui))));
                    }
                }
            }
            //交叉混合流换算系数计算
            else if (6 == gsbz || 7 == gsbz)
            {
                double tao1 = T3 - T4;
                double tao2 = T2 - T1;
                double taoDelta = 0;
                double taoM = 0;
                if (tao1 > tao2)
                {
                    taoDelta = tao1;
                    taoM = tao2;
                }
                else
                {
                    taoDelta = tao2;
                    taoM = tao1;
                }
                double P = taoM / (T3 - T1);
                double R = taoDelta / taoM;
                //由P、R和nx、ljxs，根据线算图21可以确定修正系数Psi
                if (7 == gsbz)
                {
                    if (1 == nx)
                    {
                        //Psi线算图21曲线1计算
                    }
                    else if (2 == nx && 1 == ljxs)
                    {
                        // Psi线算图21曲线2计算
                    }
                    else if (3 == nx && 1 == ljxs)
                    {
                        // Psi线算图21曲线3计算
                    }
                    else if (4 == nx && 1 == ljxs)
                    {
                        // Psi线算图21曲线4计算
                    }
                    else if (3 == nx && 2 == ljxs)
                    {
                        // Psi线算图21曲线5计算
                    }
                    else if (2 == nx && 3 == ljxs && 1 == dlzjg)
                    {
                        // Psi线算图21曲线6计算
                    }
                    else if (2 == nx && 3 == ljxs && 2 == dlzjg)
                    {
                        // Psi线算图21曲线7计算
                    }
                    else if (3 == nx && 3 == ljxs && 1 == dlzjg)
                    {
                        // Psi线算图21曲线8计算
                    }
                    else if (3 == nx && 3 == ljxs && 2 == dlzjg)
                    {
                        // Psi线算图21曲线9计算
                    }
                    else
                    {
                        sInfo = "设置参数有误，二次十字交叉不区分是否混合，三次十字交叉逆流无导流罩影响的数据";
                    }
                }
                else if (6 == gsbz)
                {
                    if (2 == nx && 1 == ljxs)
                    {
                        //线算图21曲线10计算
                    }
                    else if (2 == nx && 3 == ljxs && 2 == dlzjg)
                    {
                        //线算图21曲线11计算
                    }
                    else if (3 == nx && 1 == ljxs)
                    {
                        //线算图21曲线12计算
                    }
                    else if (3 == nx && 3 == ljxs && 2 == dlzjg)
                    {
                        //线算图21曲线13计算
                    }
                    else
                    {
                        sInfo = "设置参数有误，三次十字交叉顺流均为三通道，且不区分是否混合";
                    }
                }

                if ((T3 - T2) > (T4 - T1))
                {
                    DelTat = Psi * (((T3 - T2) - (T4 - T1)) / Math.Log((T3 - T2) / (T4 - T1)));
                }
                else
                {
                    DelTat = Psi * (((T4 - T1) - (T3 - T2)) / Math.Log((T4 - T1) / (T3 - T2)));
                }
            }
            return 0;
        }
        #endregion
    }

}
