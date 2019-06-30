using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using PKMN_CALC.Calc;
using PKMN_CALC.Master;
using PKMN_CALC.Utility;
using PKMN_CALC.WinAppForm;
using static PKMN_CALC.Utility.ErrorLog;
using static PKMN_CALC.Master._Master_Data;
using static PKMN_CALC.Master._Master_Common;


namespace PKMN_CALC.WinAppForm
{

    public partial class _fTest : Form
    {
        //共通クラス****************************************************************************************************************************************************
        //public Package cPackage;

        //初期化********************************************************************************************************************************************************    
        public _fTest()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            cboMaster.DataSource = Enum.GetValues(typeof(Master_ID)).OfType<Master_ID>().Select(x => x.ToString()).AsEnumerable<string>().ToList();
        }

        //EVENT*********************************************************************************************************************************************************

        /// <summary>
        /// Reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            cboMaster.DataSource = Enum.GetValues(typeof(Master_ID)).OfType<Master_ID>().Select(x => x.ToString()).AsEnumerable<string>().ToList();

        }


        //CONFIG DATA*******************************************************************************************************************************************************

        private void cboMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //ロード(マスタ単位)
                bool bRet = false;
                dgv1.DataSource = null;
                dgv1.DataSource = LoadMaster((Master_ID)cboMaster.SelectedIndex, ref bRet);
                if (bRet == false)
                    lbLog.Items.Add("\r\n" + "ロード失敗");
            }
            catch (Exception ex)
            {
                OutputErrorLog(GetType().FullName + "," + MethodBase.GetCurrentMethod().Name, ex.Message.ToString());
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //ファイルセーブ(マスタ単位)
                bool bRet = false;
                SaveMaster((Master_ID)cboMaster.SelectedIndex, this.dgv1.DataSource, ref bRet);
                if (bRet == false)
                    lbLog.Items.Add("\r\n" + "セーブ失敗");
            }
            catch (Exception ex)
            {
                OutputErrorLog(GetType().FullName + "," + MethodBase.GetCurrentMethod().Name, ex.Message.ToString());
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            //ファイルロード(全マスタ一括)
            try
            {
                FileInit();
            }
            catch (Exception ex)
            {
                OutputErrorLog(GetType().FullName + "," + MethodBase.GetCurrentMethod().Name, ex.Message.ToString());
            }
        }

        ////TEST BUTTON***************************************************************************************************************************************************

        private void button11_Click(object sender, EventArgs e)
        {
            //個体値
            Status StKotai = new Status((31, 31, 31, 31, 31, 31));
            //努力値
            Status StDoryoku = new Status((252, 252, 0, 0, 0, 0));
            //ポケモン名＋性格名＋個体値＋努力値　があれば、実数値が計算可能。
            Status StRet = CalcDamage.StatusCalc(998, 23, StKotai, StDoryoku);
            lbLog.Items.Add("\r\n" + "H=" + StRet.H.ToString());
            lbLog.Items.Add("\r\n" + "A=" + StRet.A.ToString());
            lbLog.Items.Add("\r\n" + "B=" + StRet.B.ToString());
            lbLog.Items.Add("\r\n" + "C=" + StRet.C.ToString());
            lbLog.Items.Add("\r\n" + "D=" + StRet.D.ToString());
            lbLog.Items.Add("\r\n" + "S=" + StRet.S.ToString());
        }





        ////テスト　ランク=4以上をとってくる
        ////List方式
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    foreach (Master_Rank MASTER_RANK_LIST in _Master_Data.MASTER_RANK_LIST)
        //    {
        //        if (MASTER_RANK_LIST.M_RANK > 3)
        //        {
        //            lbLog.Items.Add("\r\n" + "ランク:" + MASTER_RANK_LIST.M_BUNSHI.ToString() + "/" + MASTER_RANK_LIST.M_BUNBO.ToString() + "=" + MASTER_RANK_LIST.RANKTOPER.ToString());
        //        }
        //    }

        //}

        ////テスト　タイプ=ノーマルをとってくる Linq・クエリ方式
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    var x = _Master_Data.MASTER_TYPE_LIST;
        //    var y = from p in x where p.M_TYPENAME_JPN == "ノーマル" select p.M_TYPENAME_ENG;
        //    foreach (var sRet in y)
        //    {
        //        lbLog.Items.Add("\r\n" + "タイプ:ノーマル=" + sRet);
        //    }

        //}

        ////テスト　jsonシリアライズ化・デシリアライズする
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Master_Pokemon mp = _Master_Data.MASTER_POKEMON_LIST.First();

        //        Sample_Serialize_Json sj = new Sample_Serialize_Json();

        //        sj.TestSerialize(mp);

        //    }
        //    catch (Exception ex)
        //    {
        //        OutputErrorLog(GetType().FullName + "," + MethodBase.GetCurrentMethod().Name, ex.Message.ToString());
        //    }
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    //JSON形式でファイルを保存
        //    Sample_Serialize_Json sj = new Sample_Serialize_Json();
        //    sj.TestSaveSerialize_JSON();
        //}

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    //XML形式でファイルを保存
        //    Sample_Serialize_Json sj = new Sample_Serialize_Json();
        //    sj.TestSaveSerialize_XML();
        //}

        ////テスト わざ="じしん"をとってくる Linq・メソッド方式
        //private void button7_Click(object sender, EventArgs e)
        //{
        //    var x = _Master_Data.MASTER_WAZA_LIST;
        //    var z = x.Single(r => r.M_SKILLNAME_JPN == "じしん").M_SKILLNAME_ENG;

        //    lbLog.Items.Add("\r\n" + "じしん=" + z.ToString());
        //}

        ////タイプ倍率計算サンプル
        //private void button8_Click(object sender, EventArgs e)
        //{
        //    eTypeNo AttackType = eTypeNo.M_IWA;
        //    int EnemyPokemonNo = 999;

        //    double d = CalcDamage.TypeBairituCalc(AttackType, EnemyPokemonNo);

        //    lbLog.Items.Add("\r\n" + "いわ→じめん/ひこう" + d.ToString());
        //}

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    //技マスタバインド
        //    dgv1.DataSource = _Master_Data.MASTER_WAZA_LIST;
        //}

        //private void button10_Click(object sender, EventArgs e)
        //{
        //}

        //private void button11_Click(object sender, EventArgs e)
        //{
        //    //個体値
        //    Status StKotai = new Status((31, 31, 31, 31, 31, 31));
        //    //努力値
        //    Status StDoryoku = new Status((252, 252, 0, 0, 0, 0));
        //    //ポケモン名＋性格名＋個体値＋努力値　があれば、実数値が計算可能。
        //    Status StRet = CalcDamage.StatusCalc(998, 23, StKotai, StDoryoku);
        //    lbLog.Items.Add("\r\n" + "H=" + StRet.H.ToString());
        //    lbLog.Items.Add("\r\n" + "A=" + StRet.A.ToString());
        //    lbLog.Items.Add("\r\n" + "B=" + StRet.B.ToString());
        //    lbLog.Items.Add("\r\n" + "C=" + StRet.C.ToString());
        //    lbLog.Items.Add("\r\n" + "D=" + StRet.D.ToString());
        //    lbLog.Items.Add("\r\n" + "S=" + StRet.S.ToString());
        //}

        //private void button12_Click(object sender, EventArgs e)
        //{
        //    //var p = System.Collections.Generic.List<Master_Pokemon>();
        //    //pokemon.csvからMaster_Pokemonを作成するクラス
        //    // 読み込みたいCSVファイルのパスを指定して開く
        //    System.IO.StreamReader sr = new System.IO.StreamReader(@"Pokemon.csv");
        //    {
        //        int i = 0;
        //        // 配列からリストに格納する
        //        //var lists = new List<string[]>();
        //        // 末尾まで繰り返す
        //        while (!sr.EndOfStream)
        //        {
        //            // CSVファイルの一行を読み込む
        //            string line = sr.ReadLine();
        //            // 読み込んだ一行をカンマ毎に分けて配列に格納する
        //            string[] values = line.Split(',');

        //            // lists.Add(values);
        //            // dgv1.Rows.Add();
        //            if (i != 0)
        //            {
        //                dgv1.Rows[i - 1].Cells[0].Value = i.ToString();//連番
        //                if (i >= 2)
        //                {
        //                    if ((dgv1.Rows[i - 2].Cells[4].Value.ToString() == values[0]) && (values[1].Contains("Mega") || values[1].Contains(" ")))
        //                        dgv1.Rows[i - 1].Cells[1].Value = "2";//フォルム違い
        //                    else
        //                        dgv1.Rows[i - 1].Cells[1].Value = "1";//フォルム違い
        //                }
        //                dgv1.Rows[i - 1].Cells[2].Value = "";//日本語名
        //                dgv1.Rows[i - 1].Cells[3].Value = values[1];//英語名
        //                dgv1.Rows[i - 1].Cells[4].Value = values[0];//図鑑No
        //                dgv1.Rows[i - 1].Cells[5].Value = values[11];//世代
        //                dgv1.Rows[i - 1].Cells[6].Value = SET_TYPE(values[2]).ToString();//type1
        //                if (values[3] != "")
        //                    dgv1.Rows[i - 1].Cells[7].Value = SET_TYPE(values[3]).ToString();//type2
        //                else
        //                    dgv1.Rows[i - 1].Cells[7].Value = null;
        //                dgv1.Rows[i - 1].Cells[8].Value = 0;//Ability1
        //                dgv1.Rows[i - 1].Cells[9].Value = 0;//Ability2
        //                dgv1.Rows[i - 1].Cells[10].Value = 0;//Ability3
        //                dgv1.Rows[i - 1].Cells[11].Value = values[5];//H
        //                dgv1.Rows[i - 1].Cells[12].Value = values[6];//A
        //                dgv1.Rows[i - 1].Cells[13].Value = values[7];//B
        //                dgv1.Rows[i - 1].Cells[14].Value = values[8];//C
        //                dgv1.Rows[i - 1].Cells[15].Value = values[9];//D
        //                dgv1.Rows[i - 1].Cells[16].Value = values[10];//S
        //                dgv1.Rows[i - 1].Cells[17].Value = 0;//Sexper
        //                dgv1.Rows[i - 1].Cells[18].Value = 0;//未進化
        //                dgv1.Rows[i - 1].Cells[19].Value = values[1].Contains("Mega") ? 1 : 0;//メガ1
        //                dgv1.Rows[i - 1].Cells[20].Value = values[1].Contains("Mega") ? 1 : 0;//メガ2
        //                dgv1.Rows[i - 1].Cells[21].Value = Convert.ToInt32(Convert.ToBoolean(values[12]));//伝説幻である
        //            }
        //            i++;
        //        }

        //    }

        //    eTypeNo SET_TYPE(string s)
        //    {
        //        switch (s)
        //        {
        //            case "Normal":
        //                return eTypeNo.M_NORMAL;
        //            case "Fire":
        //                return eTypeNo.M_HONOO;
        //            case "Water":
        //                return eTypeNo.M_MIZU;
        //            case "Electric":
        //                return eTypeNo.M_DENKI;
        //            case "Grass":
        //                return eTypeNo.M_KUSA;
        //            case "Ice":
        //                return eTypeNo.M_KOORI;
        //            case "Fighting":
        //                return eTypeNo.M_KAKUTOU;
        //            case "Poison":
        //                return eTypeNo.M_DOKU;
        //            case "Ground":
        //                return eTypeNo.M_JIMEN;
        //            case "Flying":
        //                return eTypeNo.M_HIKOU;
        //            case "Psychic":
        //                return eTypeNo.M_ESP;
        //            case "Bug":
        //                return eTypeNo.M_MUSI;
        //            case "Rock":
        //                return eTypeNo.M_IWA;
        //            case "Ghost":
        //                return eTypeNo.M_GHOST;
        //            case "Dragon":
        //                return eTypeNo.M_DRAGON;
        //            case "Dark":
        //                return eTypeNo.M_AKU;
        //            case "Steel":
        //                return eTypeNo.M_HAGANE;
        //            case "Fairy":
        //                return eTypeNo.M_FAIRY;
        //            default:
        //                return 0;
        //        }
        //    }

        //}

    }
}
