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
    /// アイテムマスタ
    /// </summary>
    public class Master_Item
    {
        //プロパティ
        public int M_ITEMNO { get; set; }
        public string M_ITEMNAME_JPN { get; set; }
        public string M_ITEMNAME_ENG { get; set; }
        public int M_ITEM_CATE { get; set; } //カテゴリー
        public int M_ITEM_LOST { get; set; } //一度使うとなくなるフラグ
        public int M_KINOMIFLG { get; set; } //木のみであるフラグ　必須ではない
        public Master_Type M_TYPE_BUFF { get; set; } //タイプ強化アイテムフラグ　必須ではない
    }

    /// <summary>
    /// タイプデータ*******************************************************************************************************
    ///アイテムID、アイテム名(日本語)、アイテム名(英語)、アイテムカテゴリ、消耗品フラグ、木の実フラグ、強化タイプ
    ///
    ///アイテムカテゴリ： 0=なし、1=木の実、2=強化アイテム、3=それ以外、4=特殊効果、9=Z
    ///
    ///消耗品フラグ： 0=消耗しない 1以降～消耗品　消耗タイミングごとにID分け
    /// * 1=木の実系、2=状態異常木の実系、3=半減実系、4=タスキ、5=じゅうでんち系、6=脱出ボタン、9=Z
    /// * 
    /// * 木の実フラグ：
    /// * 0=なし、1=回復(オボン)、2=回復(1/2各種)、
    /// * 11～15：ピンチ実(A～Sアップ)、16サン､17スター
    /// * 21～38：半減実
    /// * 41～：ラム、カゴなど
    /// * 
    /// * 強化タイプ：0:なし 1～18:タイプマスタの値と同じ
    /// </summary>
}
