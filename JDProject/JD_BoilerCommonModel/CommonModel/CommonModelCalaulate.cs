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
        /// <param name="dP">压力p</param>
        /// <param name="dVf">炉膛自由容积Vf</param>
        /// <param name="dVp">屏区面积Vp</param>
        /// <param name="dFslf">自由容积水冷壁面积Fslf</param>
        /// <param name="dFbgf">自由容积过热管面积Fbgf</param>
        /// <param name="dFjmp">屏区与自由空间界面面积Fjmp</param>
        /// <param name="dFbgp">屏区过热管面积Fbgp</param>
        /// <param name="dFslp">屏区水冷壁面积Fslp</param>
        /// <param name="dFp">屏面积Fp</param>
        /// <param name="dS1">屏参数：节距s1</param>
        /// <param name="dA">屏参数：高度A</param>
        /// <param name="dB">屏参数：宽度b</param>
        /// <param name="dXsl">角系数：Xsl</param>
        /// <param name="dXbg">角系数：Xbg</param>
        /// <param name="dXp">角系数：Xp</param>
        /// <param name="dZeTasl">热有效系数：ZETAsl</param>
        /// <param name="dZeTabg">热有效系数：ZETAbg</param>
        /// <param name="dZeTap">热有效系数：ZETAp</param>
        /// <param name="dycjg">烟窗结构ycjg</param>
        /// <param name="drlxs">燃料型式rlxs</param>
        /// <param name="dHslf">结果参数:Hslf</param>
        /// <param name="dHsl">结果参数:Hsl</param>
        /// <param name="dHp">结果参数:Hp</param>
        /// <param name="dHbg">结果参数:Hbg</param>
        /// <param name="dHt">结果参数:Ht</param>
        /// <param name="dBu">结果参数:Bu</param>
        /// <param name="dPeAicp">结果参数:PSAIcp</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public static int CalculateEffectiveRadioArea(double dP, double dVf, double dVp, double dFslf, double dFbgf, double dFjmp, double dFbgp, double dFslp, double dFp, double dS1, double dA, double dB, double dXsl, double dXbg, double dXp, double dZeTasl, double dZeTapbg, double dZeTap, double dycjg, double drlxs, out double dHslf, out double dHsl, out double dHp, out double dHbg, out double dHt, out double dBu, out double dPsAicp)
        {
            dHslf = 0;
            dHsl = 0;
            dHp = 0;
            dHbg = 0;
            dHt = 0;
            dBu = 0;
            dPsAicp = 0;
            return 0;
        }
        #endregion

        #region 2.炉膛参数M计算
        /// <summary>
        /// 炉膛参数M计算
        /// </summary>
        /// <param name="dNum">燃烧器布局参数：数量</param>
        /// <param name="dQ">燃烧器布局参数：燃料量</param>
        /// <param name="dQ2">燃烧器布局参数：热量</param>
        /// <param name="dH">燃烧器布局参数：高度</param>
        /// <param name="nglxs">锅炉形式glxs</param>
        /// <param name="dVrH">炉膛出口烟气容积VrH</param>
        /// <param name="dVn2H">Vn2H</param>
        /// <param name="dVro2H">Vro2H</param>
        /// <param name="dR">烟气再循环系数r</param>
        /// <param name="npzfs">排渣方式pzfs</param>
        /// <param name="nrsqbz">燃烧器布置形式rsqbz</param>
        /// <param name="dM">炉膛参数M</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public static int CalculateParameterM(double dNum, double dQ, double dQ2, double dH, int nglxs, double dVrH, double dVn2H, double dVro2H, double dR, int npzfs, int nrsqbz, out double dM)
        {
            dM = 0;
            return 0;
        }
        #endregion

        #region 3.固体燃料辐射减弱系数K计算
        /// <summary>
        /// 固体燃料辐射减弱系数K计算
        /// </summary>
        /// <param name="dRn">三原子气体的总容积份额Rn=Rh2o+Rro2</param>
        /// <param name="dRh2o">烟气中水蒸气容积份额Rh2o</param>
        /// <param name="dP">炉膛内压力P(MPa)</param>
        /// <param name="dTtn">炉膛出口烟气温度Ttn(K)</param>
        /// <param name="dMui3n">烟气飞灰浓度Mui3n</param>
        /// <param name="ds">有效辐射层厚度s</param>
        /// <param name="dglxs">锅炉形式glxs</param>
        /// <param name="dpzfs">排渣方式pzfs</param>
        /// <param name="drmzl">燃煤种类rmzl</param>
        /// <param name="dK">辐射减弱系数K</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        private static int CalculateSolidFuelWeakenCoefficent(double dRn,double dRh2o,double dP,double dTtn,double dMui3n,double ds,double dglxs,double dpzfs,double drmzl,out double dK)
        {
            dK = 0;
            return 0;
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
        private static int CalculateGasOrLiquidFuelWeakenCoefficent(double dRn, double dRh2o, double dP, double dTtn, double ds,double dAlphat, double dCH,double dglxs,double dpzfs,double dqyrl,out double dK)
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
        private static int CalculatePollutionCoefficient(double dgzlx,double dpzfs,double dFT,double dglxs,double drlxs,double dsrfs,out double dZeTa)
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
        private static int CalculateScreenAreaVolumnAndArea(double dW,double dD,double dpwz,double dn,double ds1,double ds2,double dN,double dA,double dAdx,out double dVp,out double dFjmp,out double dFsbp)
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
        private static int CalculateScreenAreaHeatTransferCoefficient(double dpwz,double dd, double dn, double ds1, double ds2,out double dXp,out double dSigMaXp)
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
        private static int CalculateHeatReleaseCoefficient(double dT1,double dT2,double dAlphan,double dAlphak,double dhrqxs,double dgzlx,double dcsfs,double drlxs,double dp,double ds,double dTcp,double dNull,double dd,double  dl,double dlb,double dz1,double dz2,double ds2,double dDelTap,double dDelTab,double dSigMa1,double dSigMa2,double dhp,double dD,double dsp,double dsb,out double dH,out double dAlpha1,out double dPsip)
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
        private static int CalculateRadiateHeaReleaseCoefficient(double drlxs, double drmzl, double dTwb, double dp, double ds, double dT3, double dT4, double dNUll, double dlodelta, double dTodelta, double dln,out double Qn,out double dAlphan)
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
        private static int CalculateRadiateHeaReleaseCoefficient(double drlxs, double drmzl, double dTwb, double dp, double ds, double dT3, double dT4, double dNUll, double dlodelta, double dTodelta,double dSigMaXp, double ds1, out double dQn, out double dAlphan ,double dhrqxs= 1)
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
    }
}
