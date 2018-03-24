using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PKMN_CALC.Master
{
    /// <summary>
    /// ランクマスタ
    /// </summary>
    public class Master_Rank
    {
        //プロパティ
        public int M_RANK { get; set; }
        public int M_BUNSHI { get; set; }
        public int M_BUNBO { get; set; }
        //カスタムプロパティ
        public double RANKTOPER
        {
            get
            {
                return (double)M_BUNSHI / (double)M_BUNBO;
            }
        }
    }

    public class Master_Rank_Set
    {
        //テーブル順
        private enum jyun
        {
            rank,
            bunshi,
            bunbo,
            ranktoper
        }

        //データベースをList形式にセット
        public List<Master_Rank> Init()
        {
            try
            {
                Master_Rank cMaster_Rank;
                var L_Master_Rank = new List<Master_Rank> { };

                foreach (var ovalue in rank)
                {
                    cMaster_Rank = SetData(ovalue);
                    L_Master_Rank.Add(cMaster_Rank);
                }

                return L_Master_Rank;
            }
            catch (Exception e)
            {
                //ログ出力
                return null;
            }
        }

        //値をプロパティにセット
        private Master_Rank SetData(int[] values)
        {
            try
            {
                Master_Rank cData = new Master_Rank();

                cData.M_RANK = (int)values[(int)jyun.rank];
                cData.M_BUNSHI = (int)values[(int)jyun.bunshi];
                cData.M_BUNBO = (int)values[(int)jyun.bunbo];

                return cData;
            }
            catch (Exception e)
            {
                //ログ出力
                return null;
            }
        }

        /// <summary>
        /// ランクデータ*******************************************************************************************************
        /// ランク、倍率（分子）、倍率（分母）
        /// </summary>
        private static int[][] rank = new int[][] {
              new int[] {6,8,2},
              new int[] {5,7,2},
              new int[] {4,6,2},
              new int[] {3,5,2},
              new int[] {2,4,2},
              new int[] {1,3,2},
              new int[] {0,2,2},
              new int[] {-1,2,3},
              new int[] {-2,2,4},
              new int[] {-3,2,5},
              new int[] {-4,2,6},
              new int[] {-5,2,7},
              new int[] {-6,2,8,},
        };


    }

}
    