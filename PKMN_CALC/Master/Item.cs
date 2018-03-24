using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int M_ITEM_CATE { get; set; }
        public int M_ITEM_LOST { get; set; }
        public int M_KINOMIFLG { get; set; } //必須ではない
        public int M_TYPE_BUFF { get; set; } //必須ではない
    }

    public class Master_Item_Set
    {
        //テーブル順
        private enum jyun
        {
            itemno,
            itemname_jpn,
            itemname_eng,
            item_cate,
            item_lost,
            kinomiflg,
            type_buff,
        }

        //データベースをList形式にセット
        public List<Master_Item> Init()
        {
            try
            {
                Master_Item cMaster_Item;
                var L_Master_Item = new List<Master_Item>();

                foreach (var ovalue in item)
                {
                    cMaster_Item = SetData(ovalue);
                    L_Master_Item.Add(cMaster_Item);
                }
                return L_Master_Item;
            }
            catch (Exception e)
            {
                //ログ出力
                return null;
            }
        }

        //値をプロパティにセット
        private Master_Item SetData(object[] values)
        {
            try
            {
                Master_Item cData = new Master_Item();

                cData.M_ITEMNO = Convert.ToInt32(values[(int)jyun.itemno]);
                cData.M_ITEMNAME_JPN = (string)values[(int)jyun.itemname_jpn];
                cData.M_ITEMNAME_ENG = (string)values[(int)jyun.itemname_eng];
                cData.M_ITEM_CATE = (int)values[(int)jyun.item_cate];
                cData.M_ITEM_LOST = (int)values[(int)jyun.item_lost];
                cData.M_KINOMIFLG = (string)(values[(int)jyun.kinomiflg]) == "" ? 0 : (int)(values[(int)jyun.kinomiflg]);
                cData.M_TYPE_BUFF = (string)(values[(int)jyun.type_buff]) == "" ? 0 : (int)(values[(int)jyun.type_buff]);

                return cData;
            }
            catch (Exception e)
            {
                //ログ出力
                return null;
            }
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
        private static object[][] item = new object[][] {
            new object[] {"0","(なし)","None","0", "0", "0","0"},
            new object[] {"11","いのちのたま","","2", "0", "0","0"},
            new object[] {"47","こだわりスカーフ","","2", "0", "0","0"},
            new object[] {"48","こだわりハチマキ","","2", "0", "0","0"},
            new object[] {"49","こだわりメガネ","","2", "0", "0","0"},
            new object[] {"901","ノーマルZ","","9","9","0","0"},
            new object[] {"902","ほのおZ","","9", "9", "0","1"},
            new object[] {"903","みずZ","","9", "9", "0","2"},
            new object[] {"904","でんきZ","","9", "9", "0","3"},
            new object[] {"905","くさZ","","9", "9", "0","4"},
            new object[] {"906","こおりZ","","9", "9", "0","5"},
            new object[] {"907","かくとうZ","","9", "9", "0","6"},
            new object[] {"908","どくZ","","9", "9", "0","7"},
            new object[] {"909","じめんZ","","9", "9", "0","8"},
            new object[] {"910","ひこうZ","","9", "9", "0","9"},
            new object[] {"911","エスパーZ","","9", "9", "0","10"},
            new object[] {"912","むしZ","","9", "9", "0","11"},
            new object[] {"913","いわZ","","9", "9", "0","12"},
            new object[] {"914","ゴーストZ","","9", "9", "0","13"},
            new object[] {"915","ドラゴンZ","","9", "9", "0","14"},
            new object[] {"916","あくZ","","9", "9", "0","15"},
            new object[] {"917","はがねZ","","9", "9", "0","16"},
            new object[] {"918","フェアリーZ","","9", "9", "0","17"},
        };

        //消耗品系の発動タイミング判定用****************************************************************************************
        //
    }
}
