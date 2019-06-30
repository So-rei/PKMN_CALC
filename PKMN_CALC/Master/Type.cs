using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Reflection;
using static PKMN_CALC.Master._Master_Common;
using static PKMN_CALC.Master._Master_Data;
using static PKMN_CALC.Utility.ErrorLog;
using PKMN_CALC.Utility;

namespace PKMN_CALC.Master
{
    //マスタランク
    public class Master_Type : _Master_Mom
    {
        //プロパティ
        public eTypeNo M_TYPENO { get; set; }
        public string M_TYPENAME_JPN { get; set; }
        public string M_TYPENAME_ENG { get; set; }
        public double M_NORMAL { get ; set; }
        public double M_HONOO { get; set; }
        public double M_MIZU { get; set; }
        public double M_DENKI { get; set; }
        public double M_KUSA { get; set; }
        public double M_KOORI { get; set; }
        public double M_KAKUTOU { get; set; }
        public double M_DOKU { get; set; }
        public double M_JIMEN { get; set; }
        public double M_HIKOU { get; set; }
        public double M_ESP { get; set; }
        public double M_MUSI { get; set; }
        public double M_IWA { get; set; }
        public double M_GHOST { get; set; }
        public double M_DRAGON { get; set; }
        public double M_AKU { get; set; }
        public double M_HAGANE { get; set; }
        public double M_FAIRY { get; set; }

    }
    public enum eTypeNo
    {
        M_NORMAL = 0,
        M_HONOO,
        M_MIZU,
        M_DENKI,
        M_KUSA,
        M_KOORI,
        M_KAKUTOU,
        M_DOKU,
        M_JIMEN,
        M_HIKOU,
        M_ESP,
        M_MUSI,
        M_IWA,
        M_GHOST,
        M_DRAGON,
        M_AKU,
        M_HAGANE,
        M_FAIRY
    }

    /// <summary>
    /// タイプデータ*******************************************************************************************************
    /// 無効0 いまひとつ0.5 通常1またはnull 抜群2
    /// </summary>
}

