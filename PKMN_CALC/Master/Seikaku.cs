using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKMN_CALC.Master
{
    /// <summary>
    /// 性格マスタ
    /// </summary>
    class Master_Seikaku
    {
        //プロパティ
        public int M_SEIKAKUNO { get; set; }
        public string M_SEIKAKUNAME_JPN { get; set; }
        public string M_SEIKAKUNAME_ENG { get; set; }
        public int M_UP { get; set; }
        public int M_DOWN { get; set; }
    }

    class Master_Seikaku_Set
    {
        //テーブル順
        private enum jyun
        {
            seikakuno,
            seikakuname_jpn,
            seikakuname_eng,
            up,
            down,
        }

        /// <summary>
        /// データベースをList形式にセット
        /// </summary>
        /// <returns></returns>
        public List<Master_Seikaku> Init()
        {
            try
            {
                Master_Seikaku cMaster_Seikaku;
                var L_Master_Seikaku = new List<Master_Seikaku>();

                foreach (var ovalue in seikaku)
                {
                    cMaster_Seikaku = SetData(ovalue);
                    L_Master_Seikaku.Add(cMaster_Seikaku);
                }
                return L_Master_Seikaku;
            }
            catch (Exception e)
            {
                //ログ出力
                return null;
            }
        }

        /// <summary>
        /// 値をプロパティにセット
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private Master_Seikaku SetData(object[] values)
        {
            try
            {
                Master_Seikaku cData = new Master_Seikaku();

                cData.M_SEIKAKUNO = Convert.ToInt32(values[(int)jyun.seikakuno]);
                cData.M_SEIKAKUNAME_JPN = (string)values[(int)jyun.seikakuname_jpn];
                cData.M_SEIKAKUNAME_ENG = (string)values[(int)jyun.seikakuname_eng];
                cData.M_UP = Convert.ToInt32(values[(int)jyun.up]);
                cData.M_DOWN = Convert.ToInt32(values[(int)jyun.down]);

                return cData;
            }
            catch (Exception e)
            {
                //ログ出力
                return null;
            }
        }

        //タイプデータ*******************************************************************************************************
        /*
         * 性格ID、性格名（日本語）、性格名（英語）、上がるステ、下がるステ
         * ステについては、補正なし性格0 ABCDS=12345
         */
        private static object[][] seikaku = new object[][] {
              new object[] {"1","がんばりや","","0","0"},
              new object[] {"2","さみしがり","","1","2"},
              new object[] {"3","ゆうかん","","1","5"},
              new object[] {"4","いじっぱり","","1","3"},
              new object[] {"5","やんちゃ","","1","4"},
              new object[] {"6","ずぶとい","","2","1"},
              new object[] {"7","すなお","","0","0"},
              new object[] {"8","のんき","","2","5"},
              new object[] {"9","わんぱく","","2","3"},
              new object[] {"10","のうてんき","","2","4"},
              new object[] {"11","おくびょう","","3","1"},
              new object[] {"12","せっかち","","3","2"},
              new object[] {"13","まじめ","","3","5"},
              new object[] {"14","ようき","","0","0"},
              new object[] {"15","むじゃき","","3","4"},
              new object[] {"16","ひかえめ","","4","1"},
              new object[] {"17","おっとり","","4","2"},
              new object[] {"18","れいせい","","4","5"},
              new object[] {"19","てれや","","4","3"},
              new object[] {"20","うっかりや","","0","0"},
              new object[] {"21","おだやか","","5","1"},
              new object[] {"22","おとなしい","","5","2"},
              new object[] {"23","なまいき","","0","0"},
              new object[] {"24","しんちょう","","5","3"},
              new object[] {"25","きまぐれ","","5","4"},
        };


    }
}
