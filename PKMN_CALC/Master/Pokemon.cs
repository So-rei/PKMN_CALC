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
    /// ポケモンマスタ
    /// </summary>
    public class Master_Pokemon
    {
        //プロパティ
        public int M_POKENO { get; set; }
        public int M_FORM { get; set; }//必須でない
        public string M_POKENAME_JPN { get; set; }
        public string M_POKENAME_ENG { get; set; }
        public int M_ZUKANNO { get; set; }
        public int M_GENELATION { get; set; }
        public eTypeNo M_TYPE_1 { get; set; }
        public eTypeNo? M_TYPE_2 { get; set; }//タイプ2は無いことがある
        public int M_ABILITY_1 { get; set; }
        public int M_ABILITY_2 { get; set; }
        public int M_ABILITY_3 { get; set; }
        public int M_H { get; set; } = 0;
        public int M_A { get; set; } = 0;
        public int M_B { get; set; } = 0;
        public int M_C { get; set; } = 0;
        public int M_D { get; set; } = 0;
        public int M_S { get; set; } = 0;
        public int M_SEX_PER { get; set; }
        public int M_LO { get; set; }//未進化なら1
        public int M_MEGA_POKENO1 { get; set; }//必須でない
        public int M_MEGA_POKENO2 { get; set; }//必須でない
        public int M_RULE_CATE { get; set; }//必須でない

        //HABCDSはStatusクラスとして運用する
        [JsonIgnore]
        public Status M_ST_SYUZOKU
        {
            get
            {
                return new Status((M_H, M_A, M_B, M_C, M_D, M_S));//ステータスセット(HABCDS) シリアライズ処理関数で一旦objectを介しているので、タプル等では名前解決が出来なくなる
            }
        }

    }

    /// <summary>
    /// ランクデータ*******************************************************************************************************
    ///
    /// 性別：0性別なし　1♂のみ　2♂7:♀1　3♂1:♀1　4♂1：♀7　5♀のみ
    /// 最終進化前フラグ：未進化なら1
    /// ルールカテゴリ：　準伝１伝２幻３
    /// </summary>
}
