using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerThermalCalculation.model
{


    public class ReLiCanShuBaseModel
    {
        public ReLiCanShuBaseModel()
        {
            gzysxs = "";
            gzys = "";
            gzls = "";
            yqysxs = "";
            yqys = "";
        }

        public ReLiCanShuBaseModel(string _gzysxs, string _gzys, string _gzls, string _yqysxs, string _yqys)
        {
            gzysxs = _gzysxs;
            gzys = _gzys;
            gzls = _gzls;
            yqysxs = _yqysxs;
            yqys = _yqys;
        }

        public string gzysxs { get; set; }//工质压损系数
        public string gzys { get; set; }//工质压损
        public string gzls { get; set; }//工质流速
        public string yqysxs { get; set; }//烟气压损系数
        public string yqys { get; set; }//烟气压损
    }

    public class BiMianGuoReQi:ReLiCanShuBaseModel
    {
        public BiMianGuoReQi():base()
        {
            gzckwd = "";
        }

        public BiMianGuoReQi(string _gzysxs, string _gzys, string _gzls, string _yqysxs, string _yqys, string _gzckwd) :base(_gzysxs, _gzys, _gzls, _yqysxs, _yqys)
        {
            gzckwd = _gzckwd;
        }

        public string gzckwd { get; set; }//工质压损系数
    }

    public class JiHeCanShuModel
    {
        public JiHeCanShuModel(int id,string na)
        {
            ID = id;
            name = na;
            d = "";
            l = "";
            s = "";
            e = "";
            n = "";
            egzlx = gzlx.gg;
            esrfs = srfs.dm;
        }

        public JiHeCanShuModel(int id, string na,string _d, string _l, string _s, string _e, string _n, gzlx _egzlx, srfs _esrfs)
        {
            ID = id;
            name = na;
            d = _d;
            l = _l;
            s = _s;
            e = _e;
            n = _n;
            egzlx = _egzlx;
            esrfs = _esrfs;
        }

        public int ID { get; set; }//ID
        public string name { get; set; }//显示名称
        public string d { get; set; }//换热管外径
        public string l { get; set; }//换热管有效长度
        public string s { get; set; }//换热管节距
        public string e { get; set; }//换热管至墙中心距
        public string n { get; set; }//换热管数量
        public gzlx egzlx { get; set; }//换热管类型
        public srfs esrfs { get; set; }//受热方式
    }
}
