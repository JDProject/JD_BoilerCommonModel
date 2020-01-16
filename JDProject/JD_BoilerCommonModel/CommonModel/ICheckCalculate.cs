using System;
using System.Collections.Generic;
using System.Text;

namespace JD_BoilerCommonModel.CommonModel
{
    /// <summary>
    /// 界面验证计算
    /// </summary>
    interface ICheckCalculate
    {
        /// <summary>
        /// 验证变形、软化温度
        /// </summary>
        /// <param name="ST">软化温度</param>
        /// <param name="DT">变形温度</param>
        /// <param name="TT_2">炉膛出口烟气温度</param>
        /// <param name="ycjg">烟窗结构</param>
        /// <param name="sTipInfo">提示信息</param>
        /// <returns>验证是否成功（0:成功）</returns>
        int CheckSTDT(double ST, double DT, double TT_2, double ycjg, ref string sTipInfo);
        /// <summary>
        /// 验证宽度和深度，计算qa
        /// </summary>
        /// <param name="W">容积宽度</param>
        /// <param name="D">容积深度</param>
        /// <param name="Bp">燃料消耗量</param>
        /// <param name="Qnetar">燃料低位发热量</param>
        /// <param name="qamax">炉膛截面最大热负荷</param>
        /// <param name="qamin">炉膛截面最小热负荷</param>
        /// <param name="sTipInfo">提示信息</param>
        /// <returns>验证是否成功（0:成功）</returns>
        int CheckWidthDepth(double W,  double D, double Bp, double Qnetar, double qamax, double qamin, ref string sTipInfo);
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
        int CheckHeight(double H, double W, double D, double Bp, double Qnetar, double qvmax, double qvmin, ref string sTipInfo);
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
        int CheckExitHeight(double hyc, double D, double VT_2, double cycmax, double cycmin, ref string sTipInfo);
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
        int CheckHeaterArrang(List<CHeaterArrange> arranges, double Bp, double Qnetar, double W, double D, double qrmax, double qrmin, ref string sTipInfo);
        /// <summary>
        /// 验证换热面积是否合理
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
        int CheckHeaterArea(double D, double hyc, double W, double H, double Fsl, double Fbg, double Fp, ref string sTipInfo);

    }

    /// <summary>
    /// 燃烧器布置类
    /// </summary>
   public class CHeaterArrange
    {
        /// <summary>
        /// 层序
        /// </summary>
        public int m
        {
            set; get;
        }
        /// <summary>
        /// 数目
        /// </summary>
        public int n
        {
            set; get;
        }
        /// <summary>
        /// 标高
        /// </summary>
        public double h
        {
            set; get;
        }
        /// <summary>
        /// 燃料量
        /// </summary>
        public double b
        {
            set; get;
        }
        public CHeaterArrange(int dm, int dn, double dh, double db)
        {
            m = dm;
            n = dn;
            h = dh;
            b = db;
        }
    }
}
