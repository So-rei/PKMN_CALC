using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int M_TYPE_1 { get; set; }
        public int M_TYPE_2 { get; set; }
        public int M_ABILITY_1 { get; set; }
        public int M_ABILITY_2 { get; set; }
        public int M_ABILITY_3 { get; set; }
        public int M_H { get; set; }
        public int M_A { get; set; }
        public int M_B { get; set; }
        public int M_C { get; set; }
        public int M_D { get; set; }
        public int M_S { get; set; }
        public int M_SEX_PER { get; set; }
        public int M_LO { get; set; }
        public int M_MEGA_POKENO1 { get; set; }//必須でない
        public int M_MEGA_POKENO2 { get; set; }//必須でない
        public int M_RULE_CATE { get; set; }//必須でない
    }

    public class Master_Pokemon_Set
    { 
        //テーブル順
        private enum jyun
        {
            pokeno,
            form,
            pokename_jpn,
            pokename_eng,
            zukanno,
            genelation,
            type_1,
            type_2,
            ability_1,
            ability_2,
            ability_3,
            h,
            a,
            b,
            c,
            d,
            s,
            sex_per,
            lo,
            mega_pokeno1,
            mega_pokeno2,
            rule_cate,
        }
        
        /// <summary>
        /// 値をプロパティにセット
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private Master_Pokemon SetData(object[] values)
        {
            try
            {
                Master_Pokemon cData = new Master_Pokemon();

                cData.M_POKENO = Convert.ToInt32(values[(int)jyun.pokeno]);
                cData.M_FORM = Convert.ToInt32(values[(int)jyun.form]);
                cData.M_POKENAME_JPN = Convert.ToString(values[(int)jyun.pokename_jpn]);
                cData.M_POKENAME_ENG = Convert.ToString(values[(int)jyun.pokename_eng]);
                cData.M_ZUKANNO = Convert.ToInt32(values[(int)jyun.zukanno]);
                cData.M_GENELATION = Convert.ToInt32(values[(int)jyun.genelation]);
                cData.M_TYPE_1 = Convert.ToInt32(values[(int)jyun.type_1]);
                cData.M_TYPE_2 = Convert.ToInt32(values[(int)jyun.type_2]);
                cData.M_ABILITY_1 = Convert.ToInt32(values[(int)jyun.ability_1]);
                cData.M_ABILITY_2 = Convert.ToInt32(values[(int)jyun.ability_2]);
                cData.M_ABILITY_3 = Convert.ToInt32(values[(int)jyun.ability_3]);
                cData.M_H = Convert.ToInt32(values[(int)jyun.h]);
                cData.M_A = Convert.ToInt32(values[(int)jyun.a]);
                cData.M_B = Convert.ToInt32(values[(int)jyun.b]);
                cData.M_C = Convert.ToInt32(values[(int)jyun.c]);
                cData.M_D = Convert.ToInt32(values[(int)jyun.d]);
                cData.M_S = Convert.ToInt32(values[(int)jyun.s]);
                cData.M_SEX_PER = Convert.ToInt32(values[(int)jyun.sex_per]);
                cData.M_LO = Convert.ToInt32(values[(int)jyun.lo]);
                cData.M_MEGA_POKENO1 = (string)values[(int)jyun.mega_pokeno1] == "" ? 0 : (int)values[(int)jyun.mega_pokeno1];
                cData.M_MEGA_POKENO2 = (string)values[(int)jyun.mega_pokeno2] == "" ? 0 : (int)values[(int)jyun.mega_pokeno2];
                cData.M_RULE_CATE = Convert.ToInt32(values[(int)jyun.rule_cate]);

                return cData;
            }
            catch (Exception e)
            {
                //ログ出力
                return null;
            }
        }
        
        /// <summary>
        /// データベースをList形式にセット
        /// </summary>
        /// <returns></returns>
        public List<Master_Pokemon> Init()
        {
            try
            {
                Master_Pokemon cMaster_Pokemon;
                var L_Master_Pokemon = new List<Master_Pokemon> { };

                foreach (var strvalue in poke)
                {
                    cMaster_Pokemon = SetData(strvalue);
                    L_Master_Pokemon.Add(cMaster_Pokemon);
                }

                return L_Master_Pokemon;
            }

            catch (Exception e)
            {
                //ログ出力
                return null;
            }
        }

        /// <summary>
        /// ランクデータ*******************************************************************************************************
        ///
        /// 性別：0性別なし　1♂のみ　2♂7:♀1　3♂1:♀1　4♂1：♀7　5♀のみ
        /// 最終進化前フラグ：未進化なら1
        /// ルールカテゴリ：　準伝１伝２幻３
        /// </summary>
        public static object[][] poke = new object[][] {
              new object[] {"999","2","ランドロス(れいじゅう)","Landoros(Ghost)","646","6","9","10","1","0","0", "89","145","90","105","80","91","1","0","","","1"},
        };

    }
}
