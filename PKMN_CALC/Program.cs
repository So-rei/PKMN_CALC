using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PKMN_CALC.Master._Master_Data;

namespace PKMN_CALC
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PKMN_CALC.Master._Master_Data.Load_Data();

            Application.Run(new WinAppForm._fTest());
        }
    }
}
