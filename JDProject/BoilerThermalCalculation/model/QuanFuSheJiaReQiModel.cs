using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerThermalCalculation.model
{
    public class PSJiHeCanShuModel
    {
        public PSJiHeCanShuModel(int id,string na)
        {
            ID = id;
            name = na;
            d = "";
            A = "";
            Adx = "";
            S2 = "";
            S1 = "";
            n = "";
            N = "";
            ysl = "";
            egzlx = gzlx.gg;
            epwz = pwz.qp;
        }

        public PSJiHeCanShuModel(int id, string na,string _d, string _A, string _Adx, string _S2, string _S1, string _n, string _N, string _ysl, string _egzlx, string _epwz)
        {
            ID = id;
            name = na;
            d = _d;
            A = _A;
            Adx = _Adx;
            S2 = _S2;
            S1 = _S1;
            n = _n;
            N = _N;
            ysl = _ysl;
            egzlx = gzlx.gg;
            epwz = pwz.qp;
        }

        public int ID { get; set; }//ID
        public string name { get; set; }//显示名称
        public string d { get; set; }//换热管外径
        public string A { get; set; }//换热管外径
        public string Adx { get; set; }//换热管外径
        public string S2 { get; set; }//换热管外径
        public string S1{ get; set; }//换热管外径
        public string n { get; set; }//换热管外径
        public string N { get; set; }//换热管外径
        public string ysl { get; set; }//换热管外径
        public gzlx egzlx { get; set; }//换热管外径
        public pwz epwz { get; set; }//换热管外径
    }
}
