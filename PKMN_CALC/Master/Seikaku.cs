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
    /// 性格マスタ
    /// </summary>
    public class Master_Seikaku : _Master_Mom
    {
        //プロパティ
        public int M_SEIKAKUNO { get; set; }
        public string M_SEIKAKUNAME_JPN { get; set; }
        public string M_SEIKAKUNAME_ENG { get; set; }
        public Stjyun M_UP { get; set; }
        public Stjyun M_DOWN { get; set; }
    }

    /// <summary>
    /// タイプデータ*******************************************************************************************************
    /// 性格ID、性格名（日本語）、性格名（英語）、上がるステ、下がるステ
    /// ステについては、補正なし性格0 ABCDS=12345
    /// </summary>
}
