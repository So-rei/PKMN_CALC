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
using Newtonsoft.Json;

namespace PKMN_CALC.Master
{
    /// <summary>
    /// ランクマスタ
    /// </summary>
    public class Master_Rank : _Master_Mom
    {
        //プロパティ
        public int M_RANK { get; set; }
        public int M_BUNSHI { get; set; }
        public int M_BUNBO { get; set; }

        //カスタムプロパティ
        [JsonIgnore]
        public double RANKTOPER
        {
            get
            {
                return (double)M_BUNSHI / (double)M_BUNBO;
            }
        }
    }
    /// <summary>
    /// ランクデータ*******************************************************************************************************
    /// ランク、倍率（分子）、倍率（分母）
    /// </summary>

}
    