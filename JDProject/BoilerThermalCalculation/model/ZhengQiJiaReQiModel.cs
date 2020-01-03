using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerThermalCalculation.model
{

    //热力参数
    public class ZQJRQReLiCanShuModel
    {
        public ZQJRQReLiCanShuModel()
        {
            gzysxs = "";
            gzys = "";
            yqysxs = "";
            yqys = "";
            gzckwd = "";
            ckdc = "";
            yqckwd = "";
        }

        public ZQJRQReLiCanShuModel(string _gzysxs, string _gzys,string _yqysxs, string _yqys, string _gzckwd, string _ckdc, string _yqckwd)
        {
            gzysxs = _gzysxs;
            gzys = _gzys;
            yqysxs = _yqysxs;
            yqys = _yqys;
            gzckwd = _gzckwd;
            ckdc = _ckdc;
            yqckwd = _yqckwd;
        }

        public string gzysxs { get; set; }//工质压损系数
        public string gzys { get; set; }//工质压损
        public string yqysxs { get; set; }//烟气压损系数
        public string yqys { get; set; }//烟气压损
        public string gzckwd { get; set; }//工质压损系数
        public string ckdc { get; set; }//出口端差
        public string yqckwd { get; set; }//烟气出口温度
    }

    //换热器型式
    public class ZQJRQHuanReQiJieGouModel
    {
        public ZQJRQHuanReQiJieGouModel()
        {
            egsbz = gsbz.sl;
            ehrqxs = hrqxs.pshrq;
            ecsfs = csfs.hxcs;
            ns = "";
            nn = "";
            szjcsl_nx = "";
            szjcnl_nx = "";
            eljxs = ljxs.Cx;
            edlzjg = dlzjg.tddlz2;
        }

        public ZQJRQHuanReQiJieGouModel(gsbz _egsbz, hrqxs _ehrqxs, csfs _ecsfs, string _ns, string _nn, string _szjcsl_nx, string _szjcnl_nx, ljxs _eljxs, dlzjg _edlzjg)
        {
            egsbz = _egsbz;
            ehrqxs = _ehrqxs;
            ecsfs = _ecsfs;
            ns = _ns;
            nn = _nn;
            szjcsl_nx = _szjcsl_nx;
            szjcnl_nx = _szjcnl_nx;
            eljxs = _eljxs;
            edlzjg = _edlzjg;
        }

        public gsbz egsbz { get; set; }//管束布置方式
        public hrqxs ehrqxs { get; set; }//换热器型式
        public csfs ecsfs { get; set; }//烟气冲刷方式
        public string ns { get; set; }//顺流行程数
        public string nn { get; set; }//逆流行程数
        public string szjcsl_nx { get; set; }//十字交叉顺流-十字交叉数
        public string szjcnl_nx { get; set; }//十字交叉逆流-十字交叉数
        public ljxs eljxs { get; set; }//十字交叉联接型式
        public dlzjg edlzjg { get; set; }//十字交叉导流罩型式
    }

    //换热管几何参数
    public class ZQJRQJiHeCanShuBaseModel
    {
        public ZQJRQJiHeCanShuBaseModel(gzlx _egzlx)
        {
            egzlx = _egzlx;
            d = "";
            l = "";
            δd = "";
            s1 = "";
            s2 = "";
            z1 = "";
            z2 = "";
            n = "";
        }

        public ZQJRQJiHeCanShuBaseModel(gzlx _egzlx,string _d, string _l, string _δd, string _s1, string _s2, string _z1, string _z2, string _n)
        {
            egzlx = _egzlx;
            d = _d;
            l = _l;
            δd = _δd;
            s1 = _s1;
            s2 = _s2;
            z1 = _z1;
            z2 = _z2;
            n = _n;
        }
        public gzlx egzlx { get; set; }//换热管几何参数
        public string d { get; set; }//换热管外径
        public string l { get; set; }//换热管长度
        public string δd { get; set; }//换热管壁厚
        public string s1 { get; set; }//横向节距
        public string s2 { get; set; }//纵向节距
        public string z1 { get; set; }//横向排数
        public string z2 { get; set; }//纵向排数
        public string n { get; set; }//管子总数
    }

    //膜式
    public class ZQJRQJiHeCanShuModel_ms : ZQJRQJiHeCanShuBaseModel
    {
        public ZQJRQJiHeCanShuModel_ms(gzlx _egzlx) : base(_egzlx)
        {
            δp = "";
        }

        public ZQJRQJiHeCanShuModel_ms(gzlx _egzlx, string _d, string _l, string _δd, string _s1, string _s2, string _z1, string _z2, string _n, string _δp) : base(_egzlx, _d, _l, _δd, _s1,_s2,_z1, _z2, _n)
        {
            δp = _δp;
        }

        public string δp { get; set; }//膜片厚度
    }

    //方型横肋管
    public class ZQJRQJiHeCanShuModel_fxhlg : ZQJRQJiHeCanShuBaseModel
    {
        public ZQJRQJiHeCanShuModel_fxhlg(gzlx _egzlx) : base(_egzlx)
        {
            δl = "";
            wl = "";
            sl = "";
        }

        public ZQJRQJiHeCanShuModel_fxhlg(gzlx _egzlx, string _d, string _l, string _δd, string _s1, string _s2, string _z1, string _z2, string _n, string _δl, string _wl, string _sl) : base(_egzlx, _d, _l, _δd, _s1, _s2, _z1, _z2, _n)
        {
            δl = _δl;
            wl = _wl;
            sl = _sl;
        }

        public string δl { get; set; }//肋片厚度
        public string wl { get; set; }//肋片宽度
        public string sl { get; set; }//肋片节距
    }

    //圆型横肋管
    public class ZQJRQJiHeCanShuModel_yxhlg : ZQJRQJiHeCanShuBaseModel
    {
        public ZQJRQJiHeCanShuModel_yxhlg(gzlx _egzlx) : base(_egzlx)
        {
            δl = "";
            Dl = "";
            sl = "";
        }

        public ZQJRQJiHeCanShuModel_yxhlg(gzlx _egzlx, string _d, string _l, string _δd, string _s1, string _s2, string _z1, string _z2, string _n, string _δl, string _Dl, string _sl) : base(_egzlx, _d, _l, _δd, _s1, _s2, _z1, _z2, _n)
        {
            δl = _δl;
            Dl = _Dl;
            sl = _sl;
        }

        public string δl { get; set; }//肋片厚度
        public string Dl { get; set; }//肋片外径
        public string sl { get; set; }//肋片节距
    }

    //鳍片管
    public class ZQJRQJiHeCanShuModel_qpg : ZQJRQJiHeCanShuBaseModel
    {
        public ZQJRQJiHeCanShuModel_qpg(gzlx _egzlx) : base(_egzlx)
        {
            hq = "";
            δq = "";
        }

        public ZQJRQJiHeCanShuModel_qpg(gzlx _egzlx, string _d, string _l, string _δd, string _s1, string _s2, string _z1, string _z2, string _n, string _hq, string _δq) : base(_egzlx, _d, _l, _δd, _s1, _s2, _z1, _z2, _n)
        {
            hq = _hq;
            δq = _δq;
        }

        public string hq { get; set; }//鳍片高度
        public string δq { get; set; }//鳍片厚度
    }

    //花瓣管
    public class ZQJRQJiHeCanShuModel_hbg : ZQJRQJiHeCanShuBaseModel
    {
        public ZQJRQJiHeCanShuModel_hbg(gzlx _egzlx) : base(_egzlx)
        {
            δb = "";
            hb = "";
            lb = "";
            sb = "";
            ssp = "";
        }

        public ZQJRQJiHeCanShuModel_hbg(gzlx _egzlx, string _d, string _l, string _δd, string _s1, string _s2, string _z1, string _z2, string _n, string _δb, string _hb, string _lb, string _sb, string _ssp) : base(_egzlx, _d, _l, _δd, _s1, _s2, _z1, _z2, _n)
        {
            δb = _δb;
            hb = _hb;
            lb = _lb;
            sb = _sb;
            ssp = _ssp;
        }

        public string δb { get; set; }//瓣片厚度
        public string hb { get; set; }//瓣片高度
        public string lb { get; set; }//瓣片长度
        public string sb { get; set; }//瓣片间隙
        public string ssp { get; set; }//瓣片节距
    }

    //膜_瓣管
    public class ZQJRQJiHeCanShuModel_mbg : ZQJRQJiHeCanShuBaseModel
    {
        public ZQJRQJiHeCanShuModel_mbg(gzlx _egzlx) : base(_egzlx)
        {
            δp = "";
            hp = "";
            δb = "";
            hb = "";
            lb = "";
            sb = "";
            ssp = "";
        }

        public ZQJRQJiHeCanShuModel_mbg(gzlx _egzlx, string _d, string _l, string _δd, string _s1, string _s2, string _z1, string _z2, string _n, string _δp, string _hp, string _δb, string _hb, string _lb, string _sb, string _ssp) : base(_egzlx, _d, _l, _δd, _s1, _s2, _z1, _z2, _n)
        {
            δp = _δp;
            hp = _hp;
            δb = _δb;
            hb = _hb;
            lb = _lb;
            sb = _sb;
            ssp = _ssp;
        }

        public string δp { get; set; }//膜片厚度
        public string hp { get; set; }//膜片高度
        public string δb { get; set; }//瓣片厚度
        public string hb { get; set; }//瓣片高度
        public string lb { get; set; }//瓣片长度
        public string sb { get; set; }//瓣片间隙
        public string ssp { get; set; }//瓣片节距
    }

    //螺旋线肋片管
    public class ZQJRQJiHeCanShuModel_lxxlpg : ZQJRQJiHeCanShuBaseModel
    {
        public ZQJRQJiHeCanShuModel_lxxlpg(gzlx _egzlx) : base(_egzlx)
        {
            hq_hp = "";
            hq_z = "";
            lj_sp = "";
        }

        public ZQJRQJiHeCanShuModel_lxxlpg(gzlx _egzlx, string _d, string _l, string _δd, string _s1, string _s2, string _z1, string _z2, string _n, string _hq_hp, string _hq_z, string _lj_sp) : base(_egzlx, _d, _l, _δd, _s1, _s2, _z1, _z2, _n)
        {
            hq_hp = _hq_hp;
            hq_z = _hq_z;
            lj_sp = _lj_sp;
        }

        public string hq_hp { get; set; }//环圈高度
        public string hq_z { get; set; }//环圈数
        public string lj_sp { get; set; }//螺距
    }
}
