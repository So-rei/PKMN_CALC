using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static PKMN_CALC.Master._Master_Common;
using static PKMN_CALC.Master._Master_Data;
using static PKMN_CALC.Utility.ErrorLog;
using PKMN_CALC.Utility;

namespace PKMN_CALC.Master
{
    /// <summary>
    /// 各ポケモンが覚えるわざリスト
    /// </summary>
    public class Master_EachPokeCanUseWaza
    {
        //プロパティ
        public int M_ID { get; set; }
        public int M_POKENO { get; set; }
        public string M_POKENAME_JPN { get; set; }//必須ではない
        public int M_SKILLNO { get; set; }
        public string M_SKILLNAME_JPN { get; set; }//必須ではない
        public int M_WAZA_CATE { get; set; }//必須ではない
        public int M_WAZA_GEN1 { get; set; }//必須ではない
        public int M_WAZA_GEN2 { get; set; }//必須ではない
        public int M_WAZA_GEN3 { get; set; }//必須ではない
        public int M_WAZA_GEN4 { get; set; }//必須ではない
        public int M_WAZA_GEN5 { get; set; }//必須ではない
        public int M_WAZA_GEN6 { get; set; }//必須ではない
        public int M_WAZA_GEN7 { get; set; }//必須ではない
    }
}
