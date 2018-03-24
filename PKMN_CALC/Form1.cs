using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PKMN_CALC.Master;

namespace PKMN_CALC
{
    public partial class Form1 : Form
    {
        //共通クラス
        _Master_Init cMI = new _Master_Init();

        //初期化        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            cMI.Load();
        }

        //EVENT*********************************************************************************************************************************************************
 
        //RELOAD
        private void button1_Click(object sender, EventArgs e)
        {
            cMI.Load();
        }


        //テスト　ランク=2をとってくる
        //List方式
        private void button2_Click(object sender, EventArgs e)
        {           
            foreach (Master_Rank cMaster_Rank in cMI.cMaster_Rank)
            {
                if (cMaster_Rank.M_RANK > 0)
                {
                    Console.WriteLine("{0},{1},{2}", cMaster_Rank.M_BUNBO.ToString(), cMaster_Rank.M_BUNSHI.ToString(), cMaster_Rank.RANKTOPER.ToString());
                }
            }

        }

        //テスト　タイプ=ノーマルをとってくる
        //Linq方式
        private void button3_Click(object sender, EventArgs e)
        {
            var x = cMI.cMaster_Type;
            var y = from p in x where p.M_TYPENAME_JPN == "ノーマル" select p.M_TYPENAME_ENG;
            foreach (var M_TYPENAME_ENG in y)
            {
                Console.WriteLine("{0}", M_TYPENAME_ENG);
            }
        }

    }
}
