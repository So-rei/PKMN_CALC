using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PKMN_CALC.Master;
using static PKMN_CALC.Master._Master_Data;
using static PKMN_CALC.Master._Master_Common;
using static PKMN_CALC.Utility.ErrorLog;

namespace PKMN_CALC.Calc
{
    public static class CalcDamage
    {
        static readonly string sErrorPlace = typeof(CalcDamage).FullName + "," + MethodBase.GetCurrentMethod().Name;
        //計算クラス*********************************************************************************************************

        /// <summary>
        /// タイプ相性計算
        /// </summary>
        /// <param name="AttackType"></param>
        /// <param name="EnemyPokemonNo"></param>
        /// <returns></returns>
        public static double TypeBairituCalc(eTypeNo AttackType, int EnemyPokemonNo)
        {
            double dRet;
            try
            {
                //基本計算
                //タイプ1、タイプ2
                var xtypeNo = MASTER_TYPE_LIST.Single(r => r.M_TYPENO == AttackType).M_TYPENO;//攻撃側タイプ

                var y = MASTER_POKEMON_LIST.Single(r => r.M_POKENO == EnemyPokemonNo);//防御側ポケモンデータ            
                var ytype1No = MASTER_TYPE_LIST.Single(r => r.M_TYPENO == y.M_TYPE_1).M_TYPENO;//防御側タイプ1
                var ytype2No = MASTER_TYPE_LIST.Single(r => r.M_TYPENO == y.M_TYPE_2).M_TYPENO;//防御側タイプ2

                dRet = _Master_Common.GetTypeBairitu(xtypeNo, ytype1No) * _Master_Common.GetTypeBairitu(xtypeNo, ytype2No);

                //特殊な技(じゅうりょく、はねやすめ、みずびだし、もりののろい)
                //特殊な特性(よびみず、ひらいしん、ちょすい、かんそうはだ、そうしょく、もらいびetc)

                return dRet;
            }
            catch (Exception ex)
            {
                OutputErrorLog(sErrorPlace, ex.Message.ToString());
                return -1;
            }
        }

        /// <summary>
        /// ステータス計算
        /// </summary>
        /// <param name="PokeNo">ポケモンNo</param>
        /// <param name="SeikakuNo">性格No</param>
        /// <param name="StKotai">個体値 HABCDS</param>
        /// <param name="StDoryoku">努力値 HABCDS</param>
        /// <param name="StLv">Lv(省略可、通常50)</param>
        /// <returns></returns>
        public static Status StatusCalc(int PokeNo, int SeikakuNo, Status StKotai, Status StDoryoku, int StLv = 50)
        {
            try
            {
                //入力チェック
                if (St_Check() == false)
                {
                    OutputErrorLog(sErrorPlace, "努力値が異常です");
                    return null;
                }

                var x = MASTER_POKEMON_LIST.Single(r => r.M_POKENO == PokeNo);//対象ポケモンデータ
                var y = MASTER_SEIKAKU_LIST.Single(r => r.M_SEIKAKUNO == SeikakuNo);//対象性格  

                Status StRet = new Status();

                //ステータス計算式
                //Hだけ計算式が違う
                //努力値÷4の端数切り捨て、Lv乗算後にもう一度端数切り捨て

                for (int i = 0; i < 6; i++)
                {
                    switch ((Stjyun)(i))
                    {
                        case Stjyun.H:
                            StRet.H = Convert.ToInt32(Math.Floor((x.M_ST_SYUZOKU.H * 2 + StKotai.H + Math.Floor((double)(StDoryoku.H / 4))) * StLv / 100) + 10 + StLv);
                            break;
                        case Stjyun.A:
                        case Stjyun.B:
                        case Stjyun.C:
                        case Stjyun.D:
                        case Stjyun.S:
                            StRet.ST[i] = Convert.ToInt32(Math.Floor((x.M_ST_SYUZOKU.ST[i] * 2 + StKotai.ST[i] + Math.Floor((double)(StDoryoku.ST[i] / 4))) * StLv / 100) + 5);
                            //性格補正
                            if (y.M_UP == (Stjyun)(i))
                                StRet.ST[i] = (int)Math.Floor(StRet.ST[i] * 1.1);
                            if (y.M_DOWN == (Stjyun)(i))
                                StRet.ST[i] = (int)Math.Floor(StRet.ST[i] * 0.9);
                            break;
                        default:
                            OutputErrorLog(sErrorPlace, "種族値が異常です。");
                            return null;
                    }
                }


                //計算結果を返す
                return StRet;

                //入力チェック用ローカル関数------------------------------
                bool St_Check()
                {
                    if (StLv > 100 || StLv < 1) return false;//Lv1-100以内であること

                    if (StKotai is null) return false;
                    foreach (var kvalue in StKotai.ST)
                        if (kvalue > 31 || kvalue < 0) return false;//個体値0-31以内であること

                    if (StDoryoku is null) return false;
                    foreach (var dvalue in StDoryoku.ST)
                        if (dvalue > 255 || dvalue < 0) return false;//努力値0-255以内であること

                    if (StDoryoku.ST.Sum() > 510) return false;//努力値合計が510以内であること

                    return true;
                }
                //--------------------------------------------------------
            }
            catch (Exception ex)
            {
                OutputErrorLog(sErrorPlace, ex.Message.ToString());
                return null;
            }
        }

    }
}
