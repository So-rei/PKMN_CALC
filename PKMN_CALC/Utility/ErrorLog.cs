using System;
using System.IO;
using System.Reflection;

namespace PKMN_CALC.Utility
{
    public static class ErrorLog
    {        
        static readonly string fileName = @System.Windows.Forms.Application.StartupPath + "\\ErrorLog.txt";//保存先のファイル名

        //public ErrorLog(string cAppName = "")
        //{
        //    DateTime dtNow = DateTime.Now;
        //    try
        //    {
        //        appName = cAppName;

        //        //ファイルがない場合作成
        //        if (!File.Exists(fileName))
        //        {
        //            //Shift JISで書き込む
        //            using (StreamWriter sw = new StreamWriter(
        //                fileName,
        //                false,
        //                System.Text.Encoding.GetEncoding("shift_jis")))

        //                sw.WriteLine(dtNow.ToString() + " Initialize");                    
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(dtNow.ToString() + GetType().FullName +","+ MethodBase.GetCurrentMethod().Name ,  ex.Message.ToString());
        //    }
        //}

        public static void OutputErrorLog(string cAppName, string cErrorLog, object cError = null)
        {
            DateTime dtNow = DateTime.Now;
            string cErrorMsg = "";
            try
            {
                cErrorMsg = dtNow.ToString() + ","+ cAppName + "," + cErrorLog + "," + (cError == null ? "" : cError.ToString());

                //Shift JISで書き込む
                //書き込むファイルが既に存在している場合は、ファイルの末尾に追加する
                using (StreamWriter sw = new StreamWriter(
                     fileName, true, System.Text.Encoding.GetEncoding("shift_jis")))

                    sw.WriteLine(cErrorMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(dtNow.ToString() + "," + "ErrorLog" +","+ MethodBase.GetCurrentMethod().Name +"," +  ex.Message.ToString());
            }
            finally
            {
                Console.WriteLine(cErrorMsg);
            }
        }

    }
}
