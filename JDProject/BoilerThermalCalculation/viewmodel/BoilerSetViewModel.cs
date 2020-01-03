using BoilerThermalCalculation.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace BoilerThermalCalculation.viewmodel
{
    public class LTRLCSViewModel
    {
        LTRLCSModel lTRLCSModel = null;
        public LTRLCSViewModel()
        {
            lTRLCSModel = new LTRLCSModel();
        }

        #region Public Properties
        public string Ta
        {
            get { return lTRLCSModel.Ta; }
            set { lTRLCSModel.Ta = value; }
        }
        public string Ti
        {
            get { return lTRLCSModel.Ti; }
            set { lTRLCSModel.Ti = value; }
        }
        public string α
        {
            get { return lTRLCSModel.α; }
            set { lTRLCSModel.α = value; }
        }
        public string q4
        {
            get { return lTRLCSModel.q4; }
            set { lTRLCSModel.q4 = value; }
        }
        public string hzwd
        {
            get { return lTRLCSModel.hzwd; }
            set { lTRLCSModel.hzwd = value; }
        }
        public string hzbrr
        {
            get { return lTRLCSModel.hzbrr; }
            set { lTRLCSModel.hzbrr = value; }
        }
        public string hzhtl
        {
            get { return lTRLCSModel.hzhtl; }
            set { lTRLCSModel.hzhtl = value; }
        }
        public string fhfe
        {
            get { return lTRLCSModel.fhfe; }
            set { lTRLCSModel.fhfe = value; }
        }
        public string fhhtl
        {
            get { return lTRLCSModel.fhhtl; }
            set { lTRLCSModel.fhhtl = value; }
        }
        public string q3
        {
            get { return lTRLCSModel.q3; }
            set { lTRLCSModel.q3 = value; }
        }
        public string q5
        {
            get { return lTRLCSModel.q5; }
            set { lTRLCSModel.q5 = value; }
        }
        #endregion

    }

    public class GLJGXSViewModel
    {
        GLJGXSModel gLJGXSModel = null;
        public GLJGXSViewModel()
        {
            gLJGXSModel = new GLJGXSModel();
        }

        #region Public Properties
        public glxs eglxs
        {
            get { return gLJGXSModel.eglxs; }
            set { gLJGXSModel.eglxs = value; }
        }
        public rsqbz ersqbz
        {
            get { return gLJGXSModel.ersqbz; }
            set { gLJGXSModel.ersqbz = value; }
        }
        public pzfs epzfs
        {
            get { return gLJGXSModel.epzfs; }
            set { gLJGXSModel.epzfs = value; }
        }
        public ycjg eycjg
        {
            get { return gLJGXSModel.eycjg; }
            set { gLJGXSModel.eycjg = value; }
        }
        public gzyh egzyh
        {
            get { return gLJGXSModel.egzyh; }
            set { gLJGXSModel.egzyh = value; }
        }
        public chzz echzz
        {
            get { return gLJGXSModel.echzz; }
            set { gLJGXSModel.echzz = value; }
        }
        #endregion

    }

    public class LTJHCSViewModel
    {
        LTJHCSModel lTJHCSModel = null;
        public LTJHCSViewModel()
        {
            lTJHCSModel = new LTJHCSModel();
        }

        #region Public Properties
        public string W
        {
            get { return lTJHCSModel.W; }
            set { lTJHCSModel.W = value; }
        }
        public string D
        {
            get { return lTJHCSModel.D; }
            set { lTJHCSModel.D = value; }
        }
        public string H
        {
            get { return lTJHCSModel.H; }
            set { lTJHCSModel.H = value; }
        }
        public string hyc
        {
            get { return lTJHCSModel.hyc; }
            set { lTJHCSModel.hyc = value; }
        }
        public string rscmj
        {
            get { return lTJHCSModel.rscmj; }
            set { lTJHCSModel.rscmj = value; }
        }
        public DataTable rsqbz
        {
            get { return lTJHCSModel.rsqbz; }
            set { lTJHCSModel.rsqbz = value; }
        }
        #endregion

    }

    public class ZJViewModel
    {
        ZJModel zJModel = null;
        public ZJViewModel()
        {
            zJModel = new ZJModel();
        }

        #region Public Properties
        public string qamax
        {
            get { return zJModel.qamax; }
            set { zJModel.qamax = value; }
        }
        public string qamin
        {
            get { return zJModel.qamin; }
            set { zJModel.qamin = value; }
        }
        public string qvmax
        {
            get { return zJModel.qvmax; }
            set { zJModel.qvmax = value; }
        }
        public string qvmin
        {
            get { return zJModel.qvmin; }
            set { zJModel.qvmin = value; }
        }
        public string cycmax
        {
            get { return zJModel.cycmax; }
            set { zJModel.cycmax = value; }
        }
        public string cycmin
        {
            get { return zJModel.cycmin; }
            set { zJModel.cycmin = value; }
        }
        public string qrmax
        {
            get { return zJModel.qrmax; }
            set { zJModel.qrmax = value; }
        }
        public string qrmin
        {
            get { return zJModel.qrmin; }
            set { zJModel.qrmin = value; }
        }
        public string ypy
        {
            get { return zJModel.ypy; }
            set { zJModel.ypy = value; }
        }
        #endregion

    }
}
