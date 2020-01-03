using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerThermalCalculation.model
{
    //燃煤种类
    public enum rlxs
    {
        wym=0,//无烟煤
        ym,   //烟煤
        pm,   //贫煤
        hm,//褐煤
        yy,//页岩
        nm//泥煤
    }

    //固体添加剂
    public enum gttjj
    {
        with=0, //有
        without //没有
    }

    //锅炉型式
    public enum glxs
    {
        mfl=0,  //煤粉炉
        xhlhc,//循环流化床
        ltl,//链条炉
        yql//油气炉
    }

    //燃烧器布置方式
    public enum rsqbz
    {
        dmqqbz = 0,//单面前墙布置
        qxbz,//切向布置
        dcbz,//对冲布置
        ldbz//炉低布置
    }

    //排渣方式
    public enum pzfs
    {
        gtpz = 0,//固态排渣
        ytpz//液态排渣
    }

    //烟窗结构
    public enum ycjg
    {
        ycckmysrm = 0,//烟窗出口没有受热面
        ycckyp,//烟窗出口有屏
        ycckynzg,//烟窗出口有凝渣管
        ycckygs//烟窗出口有管束
    }

    //管子氧化程度
    public enum gzyh
    {
        wyh = 0,//无氧化
        yyh//已养化
    }

    //吹灰装置
    public enum chzz
    {
        with = 0, //有
        without //没有
    }

    //换热器类型
    public enum gzlx
    {
        gg = 0,//光管
        ms,//膜式
        fgnhtl,//覆盖耐火涂料
        fgnhz,//覆盖耐火砖
        fxhlg,//方型横肋管
        yxhlg,//圆型横肋管
        qpg,//鳍片管
        hbg,//花瓣管
        m_bg,//膜_瓣管
        lxxlpg//螺旋线肋片管
    }

    //受热方式
    public enum srfs
    {
        dm = 0, //单面
        sm //双面
    }

    //换热管类型
    public enum pwz
    {
        qp = 0, //前屏
        dcp,//单侧屏
        scp,//双侧屏
        hp,//后屏
        dp,//大屏
        sphp,//水平横屏
        spzp//水平纵屏
    }

    //管束布置方式
    public enum gsbz
    {
        sl = 0, //顺流
        nl,//逆流
        clzczj,//串联中出中进
        clczjz,//串联出中进中
        pxhl,//平行混流
        szjcsl,//十字交叉顺流
        szjcnl//十字交叉逆流
    }

    //换热器型式
    public enum hrqxs
    {
        pshrq = 0, //屏式换热器
        slgshrq, //顺列管束换热器
        clgshrq //错列管束换热器
    }

    //烟气冲刷方式
    public enum csfs
    {
        hxcs = 0, //横向冲刷
        zxcs, //纵向冲刷
        hhcs //混合冲刷
    }

    //十字交叉联接型式
    public enum ljxs
    {
        Cx = 0, //C型
        CZorZC, //CZ或ZC型
        Zx //Z型
    }

    //十字交叉导流罩型式
    public enum dlzjg
    {
        tddlz2 = 0, //双通道导流罩
        tddlz3 //三通道导流罩
    }
}
