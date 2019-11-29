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
        /// <param name="dCsl">热有效系数：Csl</param>
        /// <param name="dCbg">热有效系数：Cbg</param>
        /// <param name="dCp">热有效系数：Cp</param>
        /// <param name="dycjg">烟窗结构ycjg</param>
        /// <param name="drlxs">燃料型式rlxs</param>
        /// <param name="dHslf">结果参数:Hslf</param>
        /// <param name="dHsl">结果参数:Hsl</param>
        /// <param name="dHp">结果参数:Hp</param>
        /// <param name="dHbg">结果参数:Hbg</param>
        /// <param name="dHt">结果参数:Ht</param>
        /// <param name="dBu">结果参数:Bu</param>
        /// <param name="dYcp">结果参数:Ycp</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        public static int CalculateEffectiveRadioArea(double dP,double dVf,double dVp,double dFslf,double dFbgf,double dFjmp,double dFbgp,double dFslp,double dFp,double dS1,double dA,double dB,double dXsl,double dXbg,double dXp,double dCsl,double dCbg,double dCp,double dycjg,double drlxs, out double dHslf,out double dHsl,out double dHp,out double dHbg,out double dHt,out double dBu,out double dYcp)
        {
            dHslf = 0;
            dHsl = 0;
            dHp = 0;
            dHbg = 0;
            dHt = 0;
            dBu = 0;
            dYcp = 0;
            return 0;
        }
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
        /// <returns></returns>
        public static int CalculateParameterM(double dNum, double dQ, double dQ2, double dH, int nglxs, double dVrH, double dVn2H, double dVro2H, double dR, int npzfs, int nrsqbz, out double dM)
        {
            dM = 0;
            return 0;
        }
    }
}
