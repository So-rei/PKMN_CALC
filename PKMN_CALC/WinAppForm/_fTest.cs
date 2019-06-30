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
            var slist= Enum.GetValues(typeof(Master_ID)).OfType<Master_ID>().Select(x=>x.ToString()).AsEnumerable<string>().ToList();

            cboMaster.DataSource = slist;
            //string[] slist = { "特性マスタ", "覚えるわざマスタ", "アイテムマスタ", "ポケモンマスタ", "ランクマスタ", "性格マスタ", "タイプマスタ", "わざマスタ", "わざ特殊処理マスタ" };
            for (int i = 0; i < slist.Count() - 1; i++)
            {
                cboMaster.Items.Add(slist[i]);
            }
        }

        //EVENT*********************************************************************************************************************************************************

        //RELOAD
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    cPackage = new Package();
        //}




        //TEST BUTTON***************************************************************************************************************************************************

        //テスト　ランク=4以上をとってくる
        //List方式
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Master_Rank MASTER_RANK_LIST in _Master_Data.MASTER_RANK_LIST)
            {
                if (MASTER_RANK_LIST.M_RANK > 3)
                {
                    lbLog.Items.Add("\r\n" + "ランク:" + MASTER_RANK_LIST.M_BUNSHI.ToString() + "/" + MASTER_RANK_LIST.M_BUNBO.ToString() + "=" + MASTER_RANK_LIST.RANKTOPER.ToString());
                }
            }

        }

        //テスト　タイプ=ノーマルをとってくる Linq・クエリ方式
        private void button3_Click(object sender, EventArgs e)
        {
            var x = _Master_Data.MASTER_TYPE_LIST;
            var y = from p in x where p.M_TYPENAME_JPN == "ノーマル" select p.M_TYPENAME_ENG;
            foreach (var sRet in y)
            {
                lbLog.Items.Add("\r\n" + "タイプ:ノーマル=" + sRet);
            }

        }

        //テスト　jsonシリアライズ化・デシリアライズする
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Master_Pokemon mp = _Master_Data.MASTER_POKEMON_LIST.First();

                Sample_Serialize_Json sj = new Sample_Serialize_Json();

                sj.TestSerialize(mp);

            }
            catch (Exception ex)
            {
                OutputErrorLog(GetType().FullName + "," + MethodBase.GetCurrentMethod().Name, ex.Message.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //JSON形式でファイルを保存
            Sample_Serialize_Json sj = new Sample_Serialize_Json();
            sj.TestSaveSerialize_JSON();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //XML形式でファイルを保存
            Sample_Serialize_Json sj = new Sample_Serialize_Json();
            sj.TestSaveSerialize_XML();
        }

        //テスト わざ="じしん"をとってくる Linq・メソッド方式
        private void button7_Click(object sender, EventArgs e)
        {
            var x = _Master_Data.MASTER_WAZA_LIST;
            var z = x.Single(r => r.M_SKILLNAME_JPN == "じしん").M_SKILLNAME_ENG;

            lbLog.Items.Add("\r\n" + "じしん=" + z.ToString());
        }

        //タイプ倍率計算サンプル
        private void button8_Click(object sender, EventArgs e)
        {
            eTypeNo AttackType = eTypeNo.M_IWA;
            int EnemyPokemonNo = 999;

            double d = CalcDamage.TypeBairituCalc(AttackType, EnemyPokemonNo);

            lbLog.Items.Add("\r\n" + "いわ→じめん/ひこう" + d.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //技マスタバインド
            dgv1.DataSource = _Master_Data.MASTER_WAZA_LIST;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //技マスタ編集終了
            List<Master_Waza> cmw = this.dgv1.DataSource as List<Master_Waza>;

            _Master_Data.MASTER_WAZA_LIST = cmw;
        }

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

        private void button12_Click(object sender, EventArgs e)
        {
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
    }
}
