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
            var slist = @"
722	モクロー	くさ	ひこう	しんりょく		えんかく	68	55	55	50	50	42
723	フクスロー	くさ	ひこう	しんりょく		えんかく	78	75	75	70	70	52
724	ジュナイパー	くさ	ゴースト	しんりょく		えんかく	78	107	75	100	100	70
725	ニャビー	ほのお		もうか		いかく	45	65	40	60	40	70
726	ニャヒート	ほのお		もうか		いかく	65	85	50	80	50	90
727	ガオガエン	ほのお	あく	もうか		いかく	95	115	90	80	90	60
728	アシマリ	みず		げきりゅう		うるおいボイス	50	54	54	66	56	40
729	オシャマリ	みず		げきりゅう		うるおいボイス	60	69	69	91	81	50
730	アシレーヌ	みず	フェアリー	げきりゅう		うるおいボイス	80	74	74	126	116	60
731	ツツケラ	ノーマル	ひこう	するどいめ	 スキルリンク	ものひろい	35	75	30	30	30	65
732	ケララッパ	ノーマル	ひこう	するどいめ	 スキルリンク	ものひろい	55	85	50	40	50	75
733	ドデカバシ	ノーマル	ひこう	するどいめ	 スキルリンク	ちからずく	80	120	75	75	75	60
734	ヤングース	ノーマル		はりこみ	 がんじょうあご	てきおうりょく	48	70	30	30	30	45
735	デカグース	ノーマル		はりこみ	 がんじょうあご	てきおうりょく	88	110	60	55	60	45
736	アゴジムシ	むし		むしのしらせ			47	62	45	55	45	46
737	デンヂムシ	むし	でんき	バッテリー			57	82	95	55	75	36
738	クワガノン	むし	でんき	ふゆう			77	70	90	145	75	43
739	マケンカニ	かくとう		かいりきバサミ	 てつのこぶし	いかりのつぼ	47	82	57	42	47	63
740	ケケンカニ	かくとう	こおり	かいりきバサミ	 てつのこぶし	いかりのつぼ	97	132	77	62	67	43
741	オドリドリ(めらめら)	ほのお	ひこう	おどりこ			75	70	70	98	70	93
741	オドリドリ(ぱちぱち)	でんき	ひこう	おどりこ			75	70	70	98	70	93
741	オドリドリ(ふらふら)	エスパー	ひこう	おどりこ			75	70	70	98	70	93
741	オドリドリ(まいまい)	ゴースト	ひこう	おどりこ			75	70	70	98	70	93
742	アブリー	むし	フェアリー	みつあつめ	 りんぷん	スイートベール	40	45	40	55	40	84
743	アブリボン	むし	フェアリー	みつあつめ	 りんぷん	スイートベール	60	55	60	95	70	124
744	イワンコ	いわ		するどいめ	 やるき	ふくつのこころ	45	65	40	30	40	60
745	ルガルガン(昼)	いわ		するどいめ	 すなかき	ふくつのこころ	75	115	65	55	65	112
745	ルガルガン(夜)	いわ		するどいめ	 やるき	ノーガード	85	115	75	55	75	82
745	ルガルガン(黄昏)	いわ		かたいツメ	 		75	117	65	55	65	110
746	ヨワシ	みず		ぎょぐん		ぎょぐん	45	20	20	25	25	40
746	ヨワシ(群れ)	みず		ぎょぐん		ぎょぐん	45	140	130	140	135	30
747	ヒドイデ	どく	みず	ひとでなし	 じゅうなん	さいせいりょく	50	53	62	43	52	45
748	ドヒドイデ	どく	みず	ひとでなし	 じゅうなん	さいせいりょく	50	63	152	53	142	35
749	ドロバンコ	じめん		マイペース	 じきゅうりょく	せいしんりょく	70	100	70	45	55	45
750	バンバドロ	じめん		マイペース	 じきゅうりょく	せいしんりょく	100	125	100	55	85	35
751	シズクモ	みず	むし	すいほう		ちょすい	38	40	52	40	72	27
752	オニシズクモ	みず	むし	すいほう		ちょすい	68	70	92	50	132	42
753	カリキリ	くさ		リーフガード		あまのじゃく	40	55	35	50	35	35
754	ラランテス	くさ		リーフガード		あまのじゃく	70	105	90	80	90	45
755	ネマシュ	くさ	フェアリー	はっこう	 ほうし	あめうけざら	40	35	55	65	75	15
756	マシェード	くさ	フェアリー	はっこう	 ほうし	あめうけざら	60	45	80	90	100	30
757	ヤトウモリ	どく	ほのお	ふしょく		どんかん	48	44	40	71	40	77
758	エンニュート	どく	ほのお	ふしょく		どんかん	68	64	60	111	60	117
759	ヌイコグマ	ノーマル	かくとう	もふもふ	 ぶきよう	メロメロボディ	70	75	50	45	50	50
760	キテルグマ	ノーマル	かくとう	もふもふ	 ぶきよう	きんちょうかん	120	125	80	55	60	60
761	アマカジ	くさ		リーフガード	 どんかん	スイートベール	42	30	38	30	38	32
762	アママイコ	くさ		リーフガード	 どんかん	スイートベール	52	40	48	40	48	62
763	アマージョ	くさ		リーフガード	 じょうおうのいげん	スイートベール	72	120	98	50	98	72
764	キュワワー	フェアリー		フラワーベール	 ヒーリングシフト	しぜんかいふく	51	52	90	82	110	100
765	ヤレユータン	ノーマル	エスパー	せいしんりょく	 テレパシー	きょうせい	90	60	80	90	110	60
766	ナゲツケサル	かくとう		レシーバー		まけんき	100	120	90	40	60	80
767	コソクムシ	むし	みず	にげごし			25	35	40	20	30	80
768	グソクムシャ	むし	みず	ききかいひ			75	125	140	60	90	40
769	スナバァ	ゴースト	じめん	みずがため		すながくれ	55	55	80	70	45	15
770	シロデスナ	ゴースト	じめん	みずがため		すながくれ	85	75	110	100	75	35
771	ナマコブシ	みず		とびだすなかみ		てんねん	55	60	130	30	130	5
772	タイプ：ヌル	ノーマル		カブトアーマー			95	95	95	95	95	59
773	シルヴァディ	ノーマル		ARシステム			95	95	95	95	95	95
774	メテノ(流星)	いわ	ひこう	リミットシールド			60	60	100	60	100	60
774	メテノ(コア)	いわ	ひこう	リミットシールド			60	100	60	100	60	120
775	ネッコアラ	ノーマル		ぜったいねむり			65	115	65	75	95	65
776	バクガメス	ほのお	ドラゴン	シェルアーマー			60	78	135	91	85	36
777	トゲデマル	でんき	はがね	てつのトゲ	 ひらいしん	がんじょう	65	98	63	40	73	96
778	ミミッキュ	ゴースト	フェアリー	ばけのかわ			55	90	80	50	105	96
779	ハギギシリ	みず	エスパー	ビビッドボディ	 がんじょうあご	ミラクルスキン	68	105	70	70	70	92
780	ジジーロン	ノーマル	ドラゴン	ぎゃくじょう	 そうしょく	ノーてんき	78	60	85	135	91	36
781	ダダリン	ゴースト	くさ	はがねつかい			70	131	100	86	90	40
782	ジャラコ	ドラゴン		ぼうだん	 ぼうおん	ぼうじん	45	55	65	45	45	45
783	ジャランゴ	ドラゴン	かくとう	ぼうだん	 ぼうおん	ぼうじん	55	75	90	65	70	65
784	ジャラランガ	ドラゴン	かくとう	ぼうだん	 ぼうおん	ぼうじん	75	110	125	100	105	85
785	カプ・コケコ	でんき	フェアリー	エレキメイカー		テレパシー	70	115	85	95	75	130
786	カプ・テテフ	エスパー	フェアリー	サイコメイカー		テレパシー	70	85	75	130	115	95
787	カプ・ブルル	くさ	フェアリー	グラスメイカー		テレパシー	70	130	115	85	95	75
788	カプ・レヒレ	みず	フェアリー	ミストメイカー			70	75	115	95	130	85
789	コスモッグ	エスパー		てんねん			43	29	31	29	31	37
790	コスモウム	エスパー		がんじょう			43	29	131	29	131	37
791	ソルガレオ	エスパー	はがね	メタルプロテクト			137	137	107	113	89	97
792	ルナアーラ	エスパー	ゴースト	ファントムガード			137	113	89	137	107	97
793	ウツロイド	いわ	どく	ビーストブースト			109	53	47	127	131	103
794	マッシブーン	むし	かくとう	ビーストブースト			107	139	139	53	53	79
795	フェローチェ	むし	かくとう	ビーストブースト			71	137	37	137	37	151
796	デンジュモク	でんき		ビーストブースト			83	89	71	173	71	83
797	テッカグヤ	はがね	ひこう	ビーストブースト			97	101	103	107	101	61
798	カミツルギ	くさ	はがね	ビーストブースト			59	181	131	59	31	109
799	アクジキング	あく	ドラゴン	ビーストブースト			223	101	53	97	53	43
800	ネクロズマ	エスパー		プリズムアーマー			97	107	101	127	89	79
801	マギアナ	はがね	フェアリー	ソウルハート			80	95	115	130	115	65
802	マーシャドー	かくとう	ゴースト	テクニシャン			90	125	80	90	90	125	
";
            var plist_detail = new List<(string index, string name, string k1, string k2, string k3)>();
            var type = new List<string[]>();
            var st = new List<int[]>();
            foreach (var p in slist.Split('\r'))
            {
                var isl = p.Trim('\n').Split('\t');
                if (isl.Count() < 5) continue;
                plist_detail.Add((isl[0], isl[1].Trim(' '), isl[4].Trim(' '), isl[5].Trim(' '), isl[6].Trim(' ')));
                type.Add(new string[]{isl[2].Trim(' '), isl[3].Trim(' ')});
                st.Add(new int[] { Convert.ToInt32(isl[7].Trim(' ')), Convert.ToInt32(isl[8].Trim(' ')), Convert.ToInt32(isl[9].Trim(' ')), Convert.ToInt32(isl[10].Trim(' ')), Convert.ToInt32(isl[11].Trim(' ')), Convert.ToInt32(isl[12].Trim(' ')) });
                //if (int.TryParse(isl[0].Trim('\n'), out int index))
                //    plist_detail.Add((index, isl[1]));
            }

            for (int i = 821; i < 821 + plist_detail.Count; i++)
            {
                dgv1.Rows[i].Cells["PokeDex_Index"].Value = Convert.ToInt32(plist_detail[i-821].index);
                dgv1.Rows[i].Cells["M_POKENAME_JPN"].Value = plist_detail[i - 821].name;
                dgv1.Rows[i].Cells["Ability_1_JPN"].Value = plist_detail[i - 821].k1;
                dgv1.Rows[i].Cells["Ability_2_JPN"].Value = plist_detail[i - 821].k2;
                dgv1.Rows[i].Cells["Ability_3_JPN"].Value = plist_detail[i - 821].k3;
                dgv1.Rows[i].Cells["M_TYPE_1"].Value = Master_Type.GetCode(type[i - 821][0]);
                dgv1.Rows[i].Cells["M_TYPE_2"].Value = Master_Type.GetCode(type[i - 821][1]);
                dgv1.Rows[i].Cells["HP"].Value = st[i - 821][0];
                dgv1.Rows[i].Cells["Attack"].Value = st[i - 821][1];
                dgv1.Rows[i].Cells["Defense"].Value = st[i - 821][2];
                dgv1.Rows[i].Cells["Sp_Atk"].Value = st[i - 821][3];
                dgv1.Rows[i].Cells["Sp_Def"].Value = st[i - 821][4];
                dgv1.Rows[i].Cells["Speed"].Value = st[i - 821][5];
            }
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
