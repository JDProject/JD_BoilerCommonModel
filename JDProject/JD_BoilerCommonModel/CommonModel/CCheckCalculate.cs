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
    }
}
