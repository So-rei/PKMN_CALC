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
    /// わざマスタ
    /// </summary>
    public class Master_Waza
    {
        //プロパティ
        public int M_SKILLNO { get; set; }
        public string M_SKILLNAME_JPN { get; set; }
        public string M_SKILLNAME_ENG { get; set; }
        public int M_MOVE_SPEED { get; set; }
        public int M_OFFENSEFLG { get; set; }
        public eTypeNo M_TYPE { get; set; }
        public int M_ATK_SATK { get; set; }
        public int M_DMG { get; set; }
        public int M_HIT { get; set; }
        public int M_RANGE { get; set; }//必須でない
        public int M_GUARD { get; set; }//必須でない
        public int M_SKILL_LINK { get; set; }//必須でない
        public int M_SKILL_LINK_MIN { get; set; }//必須でない
        public int M_SKILL_LINK_MAX { get; set; }//必須でない
        public int M_DIRECT { get; set; }//必須でない
        public int M_ADD_PER { get; set; }//必須でない
        public int M_ADD_E { get; set; }//必須でない
        public int M_ADDST_ENE_A { get; set; }//必須でない
        public int M_ADDST_ENE_B { get; set; }//必須でない
        public int M_ADDST_ENE_C { get; set; }//必須でない
        public int M_ADDST_ENE_D { get; set; }//必須でない
        public int M_ADDST_ENE_S { get; set; }//必須でない
        public int M_ADDST_ME_A { get; set; }//必須でない
        public int M_ADDST_ME_B { get; set; }//必須でない
        public int M_ADDST_ME_C { get; set; }//必須でない
        public int M_ADDST_ME_D { get; set; }//必須でない
        public int M_ADDST_ME_S { get; set; }//必須でない
        public int M_SPFLG { get; set; }//必須でない
        public int M_Z_UP { get; set; }//必須でない
        public int M_Z_ID { get; set; }//必須でない
        public int M_Z_FLG { get; set; }//必須でない
    }

    /// <summary>
    /// わざデータ*******************************************************************************************************
    /// 
    /// MOVESPEED : +5（てだすけ)～-7(トリックルーム)
    /// OFFENSEFLG : 攻撃技である=1
    /// TYPE : タイプマスタと対応
    /// ATK_SATK : 物理=0,特殊=1
    /// HIT : 0～100%、-1=必中
    /// RANGE : 1=敵単体、2=敵２体、3=全体、4=味方1体、5=味方2体、6=敵2体ランダム
    /// GUARD : まもるで防がれる=1,まもる1/4=2,まもる貫通=3,まもる無視=4
    /// SKILL_LINK : 連続技である=1
    /// DIRECT : 直接攻撃である=1
    /// Z_FLG : Zわざである=1
    /// </summary>
}
