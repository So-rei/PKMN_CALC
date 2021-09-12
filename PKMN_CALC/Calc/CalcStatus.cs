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
    /// <summary>
    /// ステータス計算クラス
    /// </summary>
    public static class CalcStatus
    { 
        //共通クラス****************************************************************************************************************************************************

        /// <summary>
        /// 努力値などからステータス計算
        /// </summary>
        /// <param name="PokeNo">ポケモンNo</param>
        /// <param name="SeikakuNo">性格No</param>
        /// <param name="StKotai">個体値 HABCDS</param>
        /// <param name="StDoryoku">努力値 HABCDS</param>
        /// <param name="StLv">Lv(省略可、通常50)</param>
        /// <returns></returns>
        public static Status CalcParam(int PokeNo, int SeikakuNo, Status StKotai, Status StDoryoku, int StLv = 50)
        {
            try
            {
                //入力チェック
                if (St_Check() == false)
                {
                    OutputErrorLog(_Calc_Common.sErrorPlace, "努力値が異常です");
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
                            OutputErrorLog(_Calc_Common.sErrorPlace, "種族値が異常です。");
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

                    if (StDoryoku.ST.Sum() > 510) return false;//努力値合計が510以内であること.

                    return true;
                }
                //--------------------------------------------------------
            }
            catch (Exception ex)
            {
                OutputErrorLog(_Calc_Common.sErrorPlace, ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// [8世代] 通常->ダイマックスHP計算
        /// </summary>
        /// <param name="s">元ステータス</param>
        /// <param name="hp">現HP</param>
        /// <returns></returns>
        public static Status CalcToDaiMax(Status s, int iDaimax = 10)
        {
            double retH = s.H * (1 + iDaimax * 0.1);
            s.H = (int)Math.Floor(retH);
            return s;
        }
    }
}
