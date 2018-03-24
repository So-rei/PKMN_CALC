using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int M_TYPE { get; set; }
        public int M_ATK_SATK { get; set; }
        public int M_DMG { get; set; }
        public int M_HIT { get; set; }
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
    /// わざマスタにデータをセットするクラス
    /// </summary>
    public class Master_Waza_Set
    {
        /// <summary>
        /// テーブル順
        /// </summary>
        private enum jyun
        {
            skillno,
            skillname_jpn,
            skillname_eng,
            move_speed,
            offenseflg,
            type,
            atk_satk,
            dmg,
            hit,
            guard,
            skill_link,
            skill_link_min,
            skill_link_max,
            direct,
            add_per,
            add_e,
            addst_ene_a,
            addst_ene_b,
            addst_ene_c,
            addst_ene_d,
            addst_ene_s,
            addst_me_a,
            addst_me_b,
            addst_me_c,
            addst_me_d,
            addst_me_s,
            spflg,
            z_up,
            z_id,
            z_flg,
        }
        
        /// <summary>
        /// データベースをList形式にセット
        /// </summary>
        /// <returns></returns>
        public List<Master_Waza> Init()
        {
            try
            {
                Master_Waza cMaster_Waza;
                var L_Master_Waza = new List<Master_Waza>();

                foreach (var ovalue in waza)
                {
                    cMaster_Waza = SetData(ovalue);
                    L_Master_Waza.Add(cMaster_Waza);
                }
                return L_Master_Waza;
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
        private Master_Waza SetData(object[] values)
        {
            Master_Waza cData = new Master_Waza();

            cData.M_SKILLNO = Convert.ToInt32(values[(int)jyun.skillno]);
            cData.M_SKILLNAME_JPN = (string)values[(int)jyun.skillname_jpn];
            cData.M_SKILLNAME_ENG = (string)values[(int)jyun.skillname_eng];
            cData.M_MOVE_SPEED = Convert.ToInt32(values[(int)jyun.move_speed]);
            cData.M_OFFENSEFLG = Convert.ToInt32(values[(int)jyun.offenseflg]);
            cData.M_TYPE = Convert.ToInt32(values[(int)jyun.type]);
            cData.M_ATK_SATK = Convert.ToInt32(values[(int)jyun.atk_satk]);
            cData.M_DMG = Convert.ToInt32(values[(int)jyun.dmg]);
            cData.M_HIT = Convert.ToInt32(values[(int)jyun.hit]);
            cData.M_GUARD = CIntZero(values[(int)jyun.guard]);
            cData.M_SKILL_LINK = CIntZero(values[(int)jyun.skill_link]);
            cData.M_SKILL_LINK_MIN = CIntZero(values[(int)jyun.skill_link_min]);
            cData.M_SKILL_LINK_MAX = CIntZero(values[(int)jyun.skill_link_max]);
            cData.M_DIRECT = CIntZero(values[(int)jyun.direct]);
            cData.M_ADD_PER = CIntZero(values[(int)jyun.add_per]);
            cData.M_ADD_E = CIntZero(values[(int)jyun.add_e]);
            cData.M_ADDST_ENE_A = CIntZero(values[(int)jyun.addst_ene_a]);
            cData.M_ADDST_ENE_B = CIntZero(values[(int)jyun.addst_ene_b]);
            cData.M_ADDST_ENE_C = CIntZero(values[(int)jyun.addst_ene_c]);
            cData.M_ADDST_ENE_D = CIntZero(values[(int)jyun.addst_ene_d]);
            cData.M_ADDST_ENE_S = CIntZero(values[(int)jyun.addst_ene_s]);
            cData.M_ADDST_ME_A = CIntZero(values[(int)jyun.addst_me_a]);
            cData.M_ADDST_ME_B = CIntZero(values[(int)jyun.addst_me_d]);
            cData.M_ADDST_ME_C = CIntZero(values[(int)jyun.addst_me_c]);
            cData.M_ADDST_ME_D = CIntZero(values[(int)jyun.addst_me_d]);
            cData.M_ADDST_ME_S = CIntZero(values[(int)jyun.addst_me_s]);
            cData.M_SPFLG = CIntZero(values[(int)jyun.spflg]);
            cData.M_Z_UP = CIntZero(values[(int)jyun.z_up]);
            cData.M_Z_ID = CIntZero(values[(int)jyun.z_id]);
            cData.M_Z_FLG = CIntZero(values[(int)jyun.z_flg]);

            return cData;
        }
        
        /// <summary>
        /// null->0に変換
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        private int CIntZero(object j)
        {
            if (j is int) return (int)j;
            return 0;
        }

        /// <summary>
        /// わざデータ*******************************************************************************************************
        /// </summary>
        private static object[][] waza = new object[][] {
            new object[]{ },
        };
    }
}
