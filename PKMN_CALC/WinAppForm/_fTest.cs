﻿using System;
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
            Status StRet = CalcStatus.CalcParam(998, 23, StKotai, StDoryoku);
            lbLog.Items.Add("\r\n" + "H=" + StRet.H.ToString());
            lbLog.Items.Add("\r\n" + "A=" + StRet.A.ToString());
            lbLog.Items.Add("\r\n" + "B=" + StRet.B.ToString());
            lbLog.Items.Add("\r\n" + "C=" + StRet.C.ToString());
            lbLog.Items.Add("\r\n" + "D=" + StRet.D.ToString());
            lbLog.Items.Add("\r\n" + "S=" + StRet.S.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            var poke = LoadMaster((Master_ID)cboMaster.SelectedIndex, ref bRet);
            var _poke = ((IEnumerable<Master_Pokemon>)poke);
            //var siri_nn = _poke.Where(p => p.M_POKENAME_JPN.Last() == 'ン').Select(p => p.M_POKENAME_JPN).Distinct().ToList(); //おしりの文字が"ン"
            var poke_setend = _poke.Where(p => p.Juvenile == p.Juvenile_Max && p.Legendary == "" && p.Appearance_ShSw > 0)//最終進化系かつ使用可能のみに限定し
                                   .Select(p => (p, GetEnd(p.M_POKENAME_JPN))).ToList(); //おしりの文字を変換・取得

            var siritori_list = new List<List<Master_Pokemon>>();
            //しりとり開始
            foreach (var kana in "アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワ")
            {
                siritori_list.AddRange(CalcSiritori(new List<Master_Pokemon>(),kana, 0).ToList());
            }

            //結果出力 //合計Sでソート
            long i = 1;
            var pokeSearchAndSortedList = siritori_list.Where(p => p.Sum(q => Math.Max(q.Attack, q.Sp_Atk)) > 550).OrderByDescending(p => p.Sum(q => q.HP * (q.Defense + q.Sp_Def))).ToList(); //合計a/c550以上　耐久指数でソート
            foreach (var pokelist in pokeSearchAndSortedList) 
            {
                var s = new StringBuilder();
                foreach (var pl in pokelist)
                    s.Append(pl.M_POKENAME_JPN + "→");

                Console.WriteLine(i.ToString() + "," + 
                                    "合計s=" + pokelist.Sum(p => p.Speed).ToString() + "," +
                                    "合計aまたはc=" + pokelist.Sum(p => Math.Max(p.Attack,p.Sp_Atk)).ToString() + "," +
                                    "合計耐久指数=" + pokelist.Sum(p => p.HP * (p.Defense + p.Sp_Def)).ToString() + "," +
                                    s.ToString().TrimEnd('→'));

                i++;

                if (i > 1000)
                    return;
            }
            return;

            //処理用関数-------------------------------------------------------------------------

            char GetEnd(string name)
            {
                switch (name.Last())
                {
                    case 'ァ': return 'ア';
                    case 'ィ': return 'イ';
                    case 'ゥ': return 'ウ';
                    case 'ェ': return 'エ';
                    case 'ォ': return 'オ';
                    case 'ッ': return 'ツ';
                    case 'ャ': return 'ヤ';
                    case 'ュ': return 'ユ';
                    case 'ョ': return 'ヨ';
                    case 'ー': return name[name.Count() - 2];
                }
                return name.Last();
            }

            //メインしりとりループ
            IEnumerable<List<Master_Pokemon>> CalcSiritori(List<Master_Pokemon> bfList, char name, int cnt)
            {
                if (cnt == 5)
                {
                    var r6 = poke_setend.Where(p => p.Item1.M_POKENAME_JPN[0] == name).ToList();
                    foreach (var r in r6.Where(q => !bfList.Contains(q.p)))
                    {
                        var tbf = new List<Master_Pokemon>();
                        foreach (var bf in bfList) tbf.Add(bf);
                        tbf.Add(r.p);

                        yield return tbf;
                    }
                    yield break;
                }
                else
                {
                    var rx = poke_setend.Where(p => p.Item1.M_POKENAME_JPN[0] == name).ToList();
                    foreach (var r in rx.Where(q => !bfList.Contains(q.p)))
                    {
                        var tbf = new List<Master_Pokemon>();
                        foreach (var bf in bfList) tbf.Add(bf);
                        tbf.Add(r.p);

                        var rnext = CalcSiritori(tbf,r.Item2, cnt + 1);
                        foreach (var rr in rnext)
                            yield return (rr);
                    }
                }
            }

        }

        private void btnGoro_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            var poke = LoadMaster((Master_ID)cboMaster.SelectedIndex, ref bRet);
            var _poke = ((IEnumerable<Master_Pokemon>)poke);
            var poke_setend = _poke.Where(p => p.Juvenile == p.Juvenile_Max && p.Appearance_ShSw > 0).ToList();//最終進化系かつ使用可能のみに限定

            string value = txtgoro.Text;//語呂合わせの対象
            var udic = new Dictionary<(int index, int cnt), List<string>>();//コレクション　<開始文字index,何文字か>,マッチする名前たち

            for (int i = 0; i < value.Length; i++)
                for (int c = 1; c < 4; c++)
                    if (!SetMatchParams(i, c)) break;

            //出力
            int count = Math.Min(value.Count(), 6);//何匹でその語呂合わせを実現するか
            for (int c = 2; c<= count; c++)
            {
                if (txtGoroCnt.Text != "" && decimal.TryParse(txtGoroCnt.Text, out decimal inputcnt) && c != inputcnt) continue;

                var ret = getPtn(c, 0).ToList();

                foreach (var r in ret)
                {
                    if (c == 2)
                    {
                        if (udic.TryGetValue((r[0], r[1] - r[0]), out List<string> v1) &&
                            udic.TryGetValue((r[1], value.Length - r[1]), out List<string> v2))
                        {
                            foreach (var s1 in v1)
                                foreach (var s2 in v2)
                                    Console.WriteLine(s1 + "," + s2);
                        }
                    }
                    if (c == 3)
                    {
                        if (udic.TryGetValue((r[0], r[1] - r[0]), out List<string> v1) &&
                            udic.TryGetValue((r[1], r[2] - r[1]), out List<string> v2) &&
                            udic.TryGetValue((r[2], value.Length - r[2]), out List<string> v3))
                        {
                            foreach (var s1 in v1)
                                foreach (var s2 in v2)
                                    foreach (var s3 in v3)
                                        Console.WriteLine(s1 + "," + s2 + "," + s3);
                        }
                    }
                    if (c == 4)
                    {
                        if (udic.TryGetValue((r[0], r[1] - r[0]), out List<string> v1) &&
                            udic.TryGetValue((r[1], r[2] - r[1]), out List<string> v2) &&
                            udic.TryGetValue((r[2], r[3] - r[2]), out List<string> v3) &&
                            udic.TryGetValue((r[3], value.Length - r[3]), out List<string> v4))
                        {
                            try
                            {
                                if (v1.Count() * v2.Count() * v3.Count() * v4.Count() > 1_000_000)
                                {
                                    Console.WriteLine("1M件を超えてしまいます");
                                    continue;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("1M件を超えてしまいます");
                                continue;
                            }

                            foreach (var s1 in v1)
                                foreach (var s2 in v2)
                                    foreach (var s3 in v3)
                                        foreach (var s4 in v4)
                                        {
                                            if (s1 == s2 || s1 == s3 || s1 == s4 || s2 == s3 || s2 == s4 || s3 == s4) continue;
                                            Console.WriteLine(s1 + "," + s2 + "," + s3 + "," + s4);
                                        }
                        }
                    }
                    if (c == 5)
                    {
                        if (udic.TryGetValue((r[0], r[1] - r[0]), out List<string> v1) &&
                            udic.TryGetValue((r[1], r[2] - r[1]), out List<string> v2) &&
                            udic.TryGetValue((r[2], r[3] - r[2]), out List<string> v3) &&
                            udic.TryGetValue((r[3], r[4] - r[3]), out List<string> v4) &&
                            udic.TryGetValue((r[4], value.Length - r[4]), out List<string> v5))
                        {
                            try
                            {
                                if (v1.Count() * v2.Count() * v3.Count() * v4.Count() * v5.Count() > 1_000_000)
                                {
                                    Console.WriteLine("1M件を超えてしまいます");
                                    continue;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("1M件を超えてしまいます");
                                continue;
                            }

                            foreach (var s1 in v1)
                                foreach (var s2 in v2)
                                    foreach (var s3 in v3)
                                        foreach (var s4 in v4)
                                            foreach (var s5 in v5)
                                            {
                                                if (s1 == s2 || s1 == s3 || s1 == s4 || s1 == s5 || s2 == s3 || s2 == s4 || s2 == s5 || s3 == s4 || s3 == s5 || s4 == s5) continue;
                                                Console.WriteLine(s1 + "," + s2 + "," + s3 + "," + s4 + "," + s5);
                                            }
                        }
                    }
                    if (c == 6)
                    {
                        if (udic.TryGetValue((r[0], r[1] - r[0]), out List<string> v1) &&
                            udic.TryGetValue((r[1], r[2] - r[1]), out List<string> v2) &&
                            udic.TryGetValue((r[2], r[3] - r[2]), out List<string> v3) &&
                            udic.TryGetValue((r[3], r[4] - r[3]), out List<string> v4) &&
                            udic.TryGetValue((r[4], r[5] - r[4]), out List<string> v5) &&
                            udic.TryGetValue((r[5], value.Length - r[5]), out List<string> v6))
                        {
                            try
                            {
                                if (v1.Count() * v2.Count() * v3.Count() * v4.Count() * v5.Count() * v6.Count() > 1_000_000)
                                {
                                    Console.WriteLine("1M件を超えてしまいます");
                                    continue;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("1M件を超えてしまいます");
                                continue;
                            }

                            foreach (var s1 in v1)
                                foreach (var s2 in v2)
                                    foreach (var s3 in v3)
                                        foreach (var s4 in v4)
                                            foreach (var s5 in v5)
                                                foreach (var s6 in v6)
                                                {
                                                    if (s1 == s2 || s1 == s3 || s1 == s4 || s1 == s5 || s2 == s3 || s2 == s4 || s2 == s5 || s3 == s4 || s3 == s5 || s4 == s5 ||
                                                        s1 == s6 || s2 == s6 || s3 == s6 || s4 == s6 || s5 == s6) continue;
                                                    Console.WriteLine(s1 + "," + s2 + "," + s3 + "," + s4 + "," + s5 + "," + s6);
                                                }
                        }
                    }
                }
            }
            return;

            //------
            bool SetMatchParams(int index, int cnt)
            {
                if (index + cnt > value.Length) return false;

                var ret = poke_setend.Where(p => p.M_POKENAME_JPN.Contains(value.Substring(index, cnt))).Select(p => p.M_POKENAME_JPN + (p.Form == 2 ? ("(" + p.Form_JPN + ")") : "")).ToList();
                udic.Add((index, cnt), ret);

                return true;
            }
            IEnumerable<int[]> getPtn(int cc, int strcnt)
            {
                if (strcnt >= value.Length) yield break;
                if (cc == 1)
                {
                    for (int i = 0; i < 3; i++)
                        if (strcnt + i <= value.Length)
                            yield return new int[1] { strcnt + i };
                    yield break;
                }

                for (int i = 1; i < 4; i++)
                {
                    foreach (var next in getPtn(cc - 1, strcnt + i))
                    {
                        var ptn = new int[cc];
                        ptn[0] = strcnt;
                        int j = 1;
                        foreach (var n in next)
                        {
                            ptn[j] = n;
                            j++;
                        }
                        yield return ptn;
                    }
                }
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    bool bRet = false;
        //    var poke = LoadMaster((Master_ID)cboMaster.SelectedIndex, ref bRet);
        //    var _poke = ((IEnumerable<Master_Pokemon>)poke);
        //    var siri_nn = _poke.Where(p => p.M_POKENAME_JPN.Last() == 'ン').Select(p => p.M_POKENAME_JPN).Distinct().ToList(); //おしりの文字が"ン"
        //    var siri_each = _poke.Select(p => (p.M_POKENAME_JPN, GetEnd(p.M_POKENAME_JPN))).ToList(); //おしりの文字を変換・取得
        //    var siri_each_uniq = new List<(string,char)>(); //そのうち、このおしりの文字になるポケモンはたった1匹しか居ない
        //    siri_each.Distinct().ToList().ForEach(p =>
        //    {
        //        if (siri_each.Count(q => q.Item2 == p.Item2) == 1) siri_each_uniq.Add(p);
        //    });

        //    var ngword = new List<string>();
        //    siri_each_uniq.ForEach(p => {
        //        var d = _poke.Where(q => q.M_POKENAME_JPN.First() == p.Item2);
        //        if (d.Count() == 1)
        //            ngword.Add("*" + p.Item1 + " -> " + d.First().M_POKENAME_JPN);
        //    });

        //    //結果、ngwordの数=0なので、「...○」のあと、○から始まるポケモンが「○...ン」しかいないような組み合わせが存在しない事が確定。

        //    char GetEnd(string name)
        //    {
        //        switch (name.Last()) {
        //            case 'ァ': return 'ア';
        //            case 'ィ': return 'イ';
        //            case 'ゥ': return 'ウ';
        //            case 'ェ': return 'エ';
        //            case 'ォ': return 'オ';
        //            case 'ッ': return 'ツ';
        //            case 'ャ': return 'ヤ';
        //            case 'ュ': return 'ユ';
        //            case 'ョ': return 'ヨ';
        //            case 'ー': return name[name.Count() - 2];
        //        }
        //        return name.Last();
        //    }

        //}


        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //index振り直し
        //    //for (int row = 0; row < dgv1.Rows.Count; row++)
        //    //    dgv1.Rows[row].Cells["Index"].Value =row + 1;
        //}



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

        //    double d = CalcBattle.TypeBairituCalc(AttackType, EnemyPokemonNo);

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
        //    Status StRet = CalcBattle.StatusCalc(998, 23, StKotai, StDoryoku);
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
