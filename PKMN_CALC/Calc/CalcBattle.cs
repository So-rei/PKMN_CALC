using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PKMN_CALC.Master;
using static PKMN_CALC.Master._Master_Data;
using static PKMN_CALC.Master._Master_Common;
using static PKMN_CALC.Calc._Calc_Common;
using static PKMN_CALC.Utility.ErrorLog;

namespace PKMN_CALC.Calc
{
    public class CalcBattle
    {
        public CalcBattle(Situation At, Situation De, Field Fi)
        {

            //攻撃側ポケモン---------------------------------------------------------------------------------------------------------------------------------------------
            //わざ(威力・特殊/物理・命中率・味方ポケモンのタイプ一致)
            //攻撃数値(ポケモンの性格・種族値・個体値・努力値)
            //ランク(A/C)
            //道具(火力系)
            //特性(火力系)
            //その他(てだすけ・さきどり・そうでん・ハロウィン・バッテリー・やけど・じゅうでん・フラワーギフト・もりののろい)
            //急所            

            //防御側ポケモン---------------------------------------------------------------------------------------------------------------------------------------------
            //防御数値(ポケモンの性格・種族値・個体値・努力値)
            //ランク(B/D)
            //道具(耐久系)
            //特性(耐久系)
            //その他(リフレクター・ひかりのかべ・まもる・みずあそび・みやぶる・でんじふゆう・ハロウィン・フレンドガード・どろあそび・ミラクルアイ・フラワーギフト・もりののろい)

            //攻守決定してから決まる事象----------------------------------------------------------------------------------------------------------------------------------
            //タイプ相性(わざ・敵ポケモンより自動決定)

            //cMI,cErrorLogを使える

        }

        /// <summary>
        /// タイプ相性計算
        /// </summary>
        /// <param name="AttackType"></param>
        /// <param name="EnemyPokemonNo"></param>
        /// <returns></returns>
        public double TypeBairituCalc(eTypeNo AttackType, int EnemyPokemonNo)
        {
            double dRet;
            try
            {
                //基本計算
                //タイプ1、タイプ2
                var xtypeNo = MASTER_TYPE_LIST.Single(r => r.M_TYPENO == AttackType).M_TYPENO;//攻撃側タイプ

                var y = MASTER_POKEMON_LIST.Single(r => r.Index == EnemyPokemonNo);//防御側ポケモンデータ            
                var ytype1No = MASTER_TYPE_LIST.Single(r => r.M_TYPENO == y.M_TYPE_1).M_TYPENO;//防御側タイプ1
                var ytype2No = MASTER_TYPE_LIST.Single(r => r.M_TYPENO == y.M_TYPE_2).M_TYPENO;//防御側タイプ2

                dRet = _Master_Common.GetTypeBairitu(xtypeNo, ytype1No) * _Master_Common.GetTypeBairitu(xtypeNo, ytype2No);

                //特殊な技(じゅうりょく、はねやすめ、みずびたし、もりののろい、でんじふゆう)
                //特殊な特性(よびみず、ひらいしん、ちょすい、かんそうはだ、そうしょく、もらいびetc)

                return dRet;
            }
            catch (Exception ex)
            {
                OutputErrorLog(_Calc_Common.sErrorPlace, ex.Message.ToString());
                return -1;
            }
        }


    }
}
