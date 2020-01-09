using System;
using System.Collections.Generic;
using System.Text;

namespace JD_BoilerCommonModel.CommonModel
{
    interface ICommonModelCalaulate
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
        int CalculateEffectiveRadioArea(double p, double Vf, double Vp, double Fslf, double Fbgf, double Fjmp, double Fbgp, double Fslp, double Fp, double s1, double A, double b, double xsl, double xbg, double xp, double ZeTasl, double ZeTabg, double ZeTap, double ycjg, double rlxs, double Fyc, double rn, double rh2o, double Ttn, double Mui3n, double s, double glxs, double pzfs, double rmzl, double V1, double PeSaip, ref double Hslf, ref double Hsl, ref double Hp, ref double Hbg, ref double Ht, ref double Bu, ref double PeSaicp);
        #endregion
        #region 2.炉膛参数M计算 求和公式，参数注释不全
        /// <summary>
        /// 2.炉膛参数M计算
        /// </summary>
        /// <param name="n">燃烧器布局参数_数量</param>
        /// <param name="hi">燃烧器布局参数_标高</param>
        /// <param name="Bi">燃烧器布局参数_燃料量</param>
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
        int CalculateParameterM(List<CHeaterArrange> arranges, double glxs, double VrH, double Vn2H, double Vro2H, double r, int pzfs, int rsqbz, double Htao, double R, double F1, double Qir, ref double M);
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
        int CalculateSolidFuelWeakenCoefficent(double rn, double rh2o, double p, double Ttn, double Mui3n, double s, double glxs, double pzfs, double rmzl, ref double K);

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
        int CalculateGasOrLiquidFuelWeakenCoefficent(double rn, double rh2o, double p, double Ttn, double s, double Alphat, double CH, double glxs, double pzfs, double qyrl, ref double K);

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
        int CalculatePollutionCoefficient(double gzlx, double pzfs, double FT, double glxs, double rlxs, double SRFS, ref double ZeTa);
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
         int CalculateWaterCooledWallEffiectiveCoefficient(double gzlx, double SRFS, double d, double s, double n, double e, ref double x);

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
        int CalculateScreenAreaVolumnAndArea(double W, double D, double pwz, double n, double s1, double s2, double N, double A, double Adx, ref double Vp, ref double Fjmp, ref double Fsbp, ref string sTipInfo);

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
        int CalculateScreenAreaHeatTransferCoefficient(double pwz, double d, double n, double s1, double s2, ref double xp, ref double SigMaxp);
        #endregion

        #region 9.放热系数折算  
        /// <summary>
        ///  9.放热系数折算 
        /// </summary>
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
        /// <param name="rmzl">燃煤种类（1:无烟煤屑,2:烟煤,3:贫煤,4:褐煤,5:页岩,6:泥煤）</param>
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
        /// <param name="Fr"></param>
        /// <param name="Qr"></param>
        /// <param name="hb"></param>
        /// <param name="z"></param>
        /// <param name="pwz">屏的位置屏的位置（1:前屏,2:侧面屏,3:双侧面屏,4:后屏,5:大屏,6:水平横屏,7:水平纵屏）</param>
        /// <param name="SRFS">受热方式（1:单面,2:双面）</param>
        /// <param name="i1"></param>
        /// <param name="Q"></param>
        /// <param name="t"></param>
        /// <param name="H"></param>
        /// <param name="Alpha1">返回值:</param>
        /// <param name="Psip">返回值:</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        int CalculateHeatReleaseCoefficient(EGangZhong gz, double T1, double T2, double Alphan, double Alphak, double hrqxs, double gzlx, double csfs, double rlxs, double p, double s, double Tcp, double d, double l, double lb, double z1, double z2, double s2, double delTap, double delTab, double SigMa1, double SigMa2, double hp, double D, double sp, double sb, double th, double Enn, double Hrp,/*Add_调用辐射放热系数模块计算Alphan*/ double rmzl, double T3, double T4, double lodelta, double Todelta, double SigMaXp, double s1, double ln, double rn, double rh2o, double Ttn, double Mui3n, double glxs, double pzfs, double Alphat, double CH, double qyrl, double T, double Hn, double Bp,/*Add调用对流换热系数模块16计算Alphak*/ double Fr, double Qr, double hb, double z, double lpDelTa,/*Add 调用受热面利用系数计算模块*/double pwz, /*Add H调用管外壁温度计算模块得到Twb_1*/double SRFS, double DelTad, double i1, double Q, double t, bool bIsWet, double P1, double P2, double i2, double SigMa, double G, double gzyh, double CaO, double chzz, double gttjj, ref double H, ref double Alpha1, ref double Psip);

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
        int CalculateRadiateHeaReleaseCoefficient(double rlxs, double rmzl, double Twb, double p, double s, double T3, double T4, double lodelta, double Todelta, double hrqxs, double SigMaXp, double s1, double ln, double rn, double rh2o, double Ttn, double Mui3n, double glxs, double pzfs, double Alphat, double CH, double qyrl, double T, double Hn, double Bp, ref double Qn, ref double Alphan);

        #endregion

        #region 11.管外壁温度Twb 参数注释不全+一公式
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
        /// <param name="Twb"></param>
        /// <returns>是否计算成功（0表示成功）</returns>
         int CalculateOuterWallTemperature(double hrqxs, double SRFS, double d, double DelTad, double l, double z1, double z2, double i1, double T1, double Alpha1, double H, double Qn, double Bp, double Q, double t, bool bIsWet, double P1, double P2, double i2, double SigMa, double G, double gzyh, double rlxs, double CaO, double chzz, double Alphat, double gzlx, double gttjj, ref double Twb);

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
        int CalaulateHeatSurfaceUtilizationCoeddicient(double hrqxs, double pwz, double csfs, ref double KeSai);

        #endregion

        #region 13.对流受热面污染系数EpsaiLen计算
        /// <summary>
        /// 13.对流受热面污染系数EpsaiLen计算
        /// </summary>
        /// <param name="hrqxs">换热器型式（1:屏式,2:顺列管束,3:错列管束）</param>
        /// <param name="rlxs">燃料型式(1:煤,2:重油)</param>
        /// <param name="CaO">氧化钙</param>
        /// <param name="chzz">吹灰装置（1:有,2:无）</param>
        /// <param name="Alphat"></param>
        /// <param name="SRFS">受热方式（1:单面,2:双面）</param>
        /// <param name="Epsilon">返回值:对流受热面污染系数</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        int CalculateHeatingSurfacePollutionCoefficient(double hrqxs, double rlxs, double CaO, double chzz, double Alphat, double SRFS, ref double Epsilon);

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
        int CalculateHeatCoefficient(double hrqxs, double rlxs, double gzlx, double CaO, double chzz, double gttjj, double Alphat, ref double PeSai);

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
        int CalculateFlueGasFlowArea(double gzlx, double csfs, double hrqxs, double d, double l, double z1, double z2, double SigMa1, double SigMa2, double sp, double hp, double D, double s1, double s2, double DelTap, ref double Fr);

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
        /// <param name="Alphak">返回值:烟气的对流放热系数计算</param>
        /// <param name="sInfo">错误信息</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        int CalculateFlueGasFlowHeatCoeffiient(double gzlx, double csfs, double hrqxs, double d, double l, double lb, double z1, double z2, double s1, double s2, double DelTap, double DelTab, double hp, double D, double Sp, double Sb, double T3, double T4, double Fr, double Qr, double th, double hb, double z, double lpDelTa, double Hrp, ref double Alphak, ref string sInfo);

        #endregion

        #region 17.管壁向水和蒸汽的放热系数Alpha2
        /// <summary>
        /// 17.管壁向水和蒸汽的放热系数Alpha2
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <param name="d">管子外径d</param>
        /// <param name="SigMa">管子壁厚SigMa</param>
        /// <param name="G">工质流量G</param>
        /// <param name="Alpha2">管壁向水和蒸汽的放热系数Alpha2</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        int CalculateWaterAngGasHeatCoefficient(double P1, double P2, double i1, double i2, double d, double SigMa, double G, double l, double z1, double z2, double gzyh, double hrqxs, double SRFS, double DelTad, double T1, double Alpha1, double H, double Qn, double Bp, double Q, double t, bool bIsWet, double rlxs, double CaO, double chzz, double Alphat, double gzlx, double gttjj, ref double Alpha2);

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
        /// <param name="DelTat">返回值:</param>
        /// <param name="Psi">返回值:</param>
        /// <param name="sInfo">错误信息</param>
        /// <returns>是否计算成功（0表示成功）</returns>
        int CalculateTemperaturePressureConvertCoefficient(double T1, double T2, double T3, double T4, double gsbz, double ns, double nn, double nx, double ljxs, double dlzjg, ref double DelTat, double H, double Hs, ref double Psi, ref string sInfo);
        #endregion
    }
}
