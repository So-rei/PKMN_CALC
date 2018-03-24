using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PKMN_CALC.Master
{
    //マスタランク
    public class Master_Type
    {
        //プロパティ
        public int M_TYPENO { get; set; }
        public string M_TYPENAME_JPN { get; set; }
        public string M_TYPENAME_ENG { get; set; }
        public double M_NORMAL { get; set; }
        public double M_HONOO { get; set; }
        public double M_MIZU { get; set; }
        public double M_DENKI { get; set; }
        public double M_KUSA { get; set; }
        public double M_KOORI { get; set; }
        public double M_KAKUTOU { get; set; }
        public double M_DOKU { get; set; }
        public double M_JIMEN { get; set; }
        public double M_HIKOU { get; set; }
        public double M_ESP { get; set; }
        public double M_MUSI { get; set; }
        public double M_IWA { get; set; }
        public double M_GHOST { get; set; }
        public double M_DRAGON { get; set; }
        public double M_AKU { get; set; }
        public double M_HAGANE { get; set; }
        public double M_FAIRY { get; set; }

    }

    public class Master_Type_Set
    {
        //テーブル順
        private enum jyun
        {
            typeno,
            typename_jpn,
            typename_eng,
            normal,
            honoo,
            mizu,
            denki,
            kusa,
            koori,
            kakutou,
            doku,
            jimen,
            hikou,
            esp,
            musi,
            iwa,
            ghost,
            dragon,
            aku,
            hagane,
            fairy,
        }

        //データ量が少なければ、以下のように配列から直接データを作成する。
        
        /// <summary>
        /// データベースをList形式にセット
        /// </summary>
        /// <returns></returns>
        public List<Master_Type> Init()
        {
            try
            {
                Master_Type cMaster_Type;
                var L_Master_Type = new List<Master_Type>();

                foreach (var ovalue in type)
                {
                    cMaster_Type = SetData(ovalue);
                    L_Master_Type.Add(cMaster_Type);
                }
                return L_Master_Type;
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
        private Master_Type SetData(object[] values)
        {
            try
            {
                Master_Type cData = new Master_Type();

                cData.M_TYPENO = Convert.ToInt32(values[(int)jyun.typeno]);
                cData.M_TYPENAME_JPN = (string)values[(int)jyun.typename_jpn];
                cData.M_TYPENAME_ENG = (string)values[(int)jyun.typename_eng];
                cData.M_NORMAL = CDbl(values[(int)jyun.normal]);
                cData.M_HONOO = CDbl(values[(int)jyun.honoo]);
                cData.M_MIZU = CDbl(values[(int)jyun.mizu]);
                cData.M_DENKI = CDbl(values[(int)jyun.denki]);
                cData.M_KUSA = CDbl(values[(int)jyun.kusa]);
                cData.M_KOORI = CDbl(values[(int)jyun.koori]);
                cData.M_KAKUTOU = CDbl(values[(int)jyun.kakutou]);
                cData.M_DOKU = CDbl(values[(int)jyun.doku]);
                cData.M_JIMEN = CDbl(values[(int)jyun.jimen]);
                cData.M_HIKOU = CDbl(values[(int)jyun.hikou]);
                cData.M_ESP = CDbl(values[(int)jyun.esp]);
                cData.M_MUSI = CDbl(values[(int)jyun.musi]);
                cData.M_IWA = CDbl(values[(int)jyun.iwa]);
                cData.M_GHOST = CDbl(values[(int)jyun.ghost]);
                cData.M_DRAGON = CDbl(values[(int)jyun.dragon]);
                cData.M_AKU = CDbl(values[(int)jyun.aku]);
                cData.M_HAGANE = CDbl(values[(int)jyun.hagane]);
                cData.M_FAIRY = CDbl(values[(int)jyun.fairy]);

                return cData;
            }
            catch (Exception e)
            {
                //ログ出力
                return null;
            }
        }      

        /// <summary>
        /// 通常相性null->1に変換
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        private Double CDbl(object j)
        {
            if (j is double) return (double)j;
            return 1;
        }

        /// <summary>
        /// タイプデータ*******************************************************************************************************
        /// 無効0 いまひとつ0.5 通常1またはnull 抜群2
        /// </summary>
        private static string[][] type = new string[][] {
            //ノ 炎 水 電 草 氷 格 毒 地 飛 超 虫 岩 霊 竜 悪 鋼 妖
              new string[] {"1","ノーマル","Normal","","","","","","","","","","","","0.5","0","","","0.5","" ,""},
              new string[] {"2","ほのお","Fire","","0.5","0.5","","2","2","","","","","","2","0.5","","0.5","","2", ""},
              new string[] {"3","みず","Water","","2","0.5","","0.5","","","","2","","","","2","","0.5","","","", },
              new string[] {"4","でんき","Electic","","","2","0.5","","0.5","","","","0","2","","","","","0.5","","","" },
              new string[] {"5","くさ","Glass","","0.5","2","","0.5","","","0.5","2","0.5", "","0.5","2","","0.5","","0.5",""},
              new string[] {"6","こおり","Ice","","0.5","0.5","","2","0.5","","","2","2","","","","","2","","0.5","" },
              new string[] {"7","かくとう","Fight","2","","","","","","2","","0.5","","0.5","0.5","0.5","2","0","","2","2","0.5" },
              new string[] {"8","どく","Poison","","","","","2","","","0.5","0.5", "", "", "","0.5","0.5","","","0","2" },
              new string[] {"9","じめん","Ground","","","","2","0.5","","","2","","0","","0.5","2","","","","2","" },
              new string[] {"10","ひこう","Fly","","2","","0.5","2","","2","","","","","","2","0.5", "","","","0.5",""},
              new string[] {"11","エスパー","Physic","","","","","","","2","2","", "","0.5","","","","","0","0.5",""},
              new string[] {"12","むし","Beat","","0.5","","","2","","0.5","0.5","", "0.5","2","","","0.5","","2","0.5","0.5"},
              new string[] {"13","いわ","Lock","","2","","","","2","0.5","","0.5", "2","","2","","","","","0.5",""},
              new string[] {"14","ゴースト","Ghost","0","","","","","","","","", "","2","","","2","","0.5","",""},
              new string[] {"15","ドラゴン","Dragon","","","","","","","","","", "","","","","","2","","0.5",""},
              new string[] {"16","あく","Dark","","","","","","","0.5","","","","2","","","2","","0.5", "","0.5"},
              new string[] {"17","はがね","Steel","","0.5","0.5","0.5","","2","","","","","","","2","","","","0.5","2" },
              new string[] {"18","フェアリー","Fairy","","0.5","","","","","2","0.5","","","","","","","2","2","0.5","" },
        };

    }
}

