using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerThermalCalculation.model
{


    public class FuelSetModel
    {
        public FuelSetModel()
        {
            erlxs = rlxs.wym;
            DT = "";
            ST = "";
            FT = "";
            egttjj = gttjj.with;
            Qnetar = "";
        }

        public FuelSetModel(rlxs _erlxs, string _DT, string _ST, string _FT, gttjj _egttjj, string _Qnetar)
        {
            erlxs = _erlxs;
            DT = _DT;
            ST = _ST;
            FT = _FT;
            egttjj = _egttjj;
            Qnetar = _Qnetar;
        }

        public rlxs erlxs { get; set; }//燃煤种类
        public string DT { get; set; }//煤灰变形温度
        public string ST { get; set; }//煤灰软化温度
        public string FT { get; set; }//煤灰熔化温度
        public gttjj egttjj { get; set; }//固体添加剂
        public string Qnetar { get; set; }//低位发热量
    }
}
