using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerThermalCalculation.model
{

    //炉膛热力参数
    public class LTRLCSModel
    {
        public LTRLCSModel()
        {
            Ta = "";
            Ti = "";
            α = "";
            q4 = "";
            hzwd = "";
            hzbrr = "";
            hzhtl = "";
            fhfe = "";
            fhhtl = "";
            q3 = "";
            q5 = "";
        }

        public LTRLCSModel(string _Ta, string _Ti, string _α, string _q4, string _hzwd, string _hzbrr, string _hzhtl, string _fhfe, string _fhhtl, string _q3, string _q5)
        {
            Ta = _Ta;
            Ti = _Ti;
            α = _α;
            q4 = _q4;
            hzwd = _hzwd;
            hzbrr = _hzbrr;
            hzhtl = _hzhtl;
            fhfe = _fhfe;
            fhhtl = _fhhtl;
            q3 = _q3;
            q5 = _q5;
        }

        public string Ta { get; set; }//基准温度
        public string Ti { get; set; }//炉膛出口温度
        public string α { get; set; }//过量空气系数
        public string q4 { get; set; }//机械不完全燃烧损失
        public string hzwd { get; set; }//灰渣温度
        public string hzbrr { get; set; }//灰渣比热容
        public string hzhtl { get; set; }//灰渣含碳量
        public string fhfe { get; set; }//飞灰份额
        public string fhhtl { get; set; }//飞灰含碳量
        public string q3 { get; set; }//化学不完全燃烧损失
        public string q5 { get; set; }//锅炉散热损失
    }

    //锅炉结构型式
    public class GLJGXSModel
    {
        public GLJGXSModel()
        {
            eglxs = glxs.mfl;
            ersqbz = rsqbz.dmqqbz;
            epzfs = pzfs.gtpz;
            eycjg = ycjg.ycckmysrm;
            egzyh = gzyh.wyh;
            echzz = chzz.with;
        }

        public GLJGXSModel(glxs _eglxs, rsqbz _ersqbz, pzfs _epzfs, ycjg _eycjgs, gzyh _egzyh, chzz _echzz)
        {
            eglxs = _eglxs;
            ersqbz = _ersqbz;
            epzfs = _epzfs;
            eycjg = _eycjgs;
            egzyh = _egzyh;
            echzz = _echzz;
        }

        public glxs eglxs { get; set; }//锅炉型式
        public rsqbz ersqbz { get; set; }//燃烧器布置方式
        public pzfs epzfs { get; set; }//排渣方式
        public ycjg eycjg { get; set; }//烟窗结构
        public gzyh egzyh { get; set; }//管子氧化程度
        public chzz echzz { get; set; }//吹灰装置
    }

    //炉膛几何参数
    public class LTJHCSModel
    {
        public LTJHCSModel()
        {
            W = "";
            D = "";
            H = "";
            hyc = "";
            rscmj = "";
            rsqbz = new DataTable();
            rsqbz.Columns.Add("层序", Type.GetType("System.Int32")); //层序
            rsqbz.Columns.Add("燃烧器数量", Type.GetType("System.String")); //燃烧器数量
            rsqbz.Columns.Add("标高", Type.GetType("System.String")); //标高
            rsqbz.Columns.Add("燃烧量", Type.GetType("System.String")); //燃烧量
        }

        public LTJHCSModel(string _W, string _D, string _H, string _hyc, string _rscmj, DataTable _rsqbz)
        {
            W = _W;
            D = _D;
            H = _H;
            hyc = _hyc;
            rscmj = _rscmj;
            rsqbz = _rsqbz;
        }

        public string W { get; set; }//当量容积宽度
        public string D { get; set; }//当量容积深度
        public string H { get; set; }//当量容积高度
        public string hyc { get; set; }//出口烟窗高度
        public string rscmj { get; set; }//燃烧层面积
        public DataTable rsqbz { get; set; }//燃烧层布局
    }

    //专家参数
    public class ZJModel
    {
        public ZJModel()
        {
            qamax = "";
            qamin = "";
            qvmax = "";
            qvmin = "";
            cycmax = "";
            cycmin = "";
            qrmax = "";
            qrmin = "";
            ypy = "";
        }

        public ZJModel(string _qamax, string _qamin, string _qvmax, string _qvmin, string _cycmax, string _cycmin, string _qrmax, string _qrmin, string _ypy)
        {
            qamax = _qamax;
            qamin = _qamin;
            qvmax = _qvmax;
            qvmin = _qvmin;
            cycmax = _cycmax;
            cycmin = _cycmin;
            qrmax = _qrmax;
            qrmin = _qrmin;
            ypy = _ypy;
        }

        public string qamax { get; set; }//截面热负荷上限
        public string qamin { get; set; }//截面热负荷下限
        public string qvmax { get; set; }//容积热负荷上限
        public string qvmin { get; set; }//容积热负荷下限
        public string cycmax { get; set; }//烟窗流速上限
        public string cycmin { get; set; }//烟窗流速下限
        public string qrmax { get; set; }//燃烧器区壁面热负荷上限
        public string qrmin { get; set; }//燃烧器区壁面热负荷下限
        public string ypy { get; set; }//屏区及烟窗吸热分配系数
    }
}
