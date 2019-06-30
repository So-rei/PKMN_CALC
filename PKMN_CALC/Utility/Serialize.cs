using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.IO;
using static System.Console;
using PKMN_CALC.Master;
using static PKMN_CALC.Master._Master_Data;
using static PKMN_CALC.Utility.ErrorLog;
using System.Reflection;

namespace PKMN_CALC.Utility
{
    /// <summary>
    /// シリアライズ基本クラス
    /// </summary>
    public static class Serialize
    {
        /// <summary>
        /// jsonファイル→マスタの方に対応した形でデシリアライズ→List<T>に返却
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="jMaster"></param>
        public static IEnumerable<T> FileLoadAndDeserialize<T>(IEnumerable<T> T1, string filename) where T:class
        {
            try
            {
                var text = File.ReadAllText(@filename, System.Text.Encoding.GetEncoding("shift_jis"));
                return JsonConvert.DeserializeObject<IEnumerable<T>>(text);
            }
            catch (Exception ex)
            {
                OutputErrorLog(typeof(Serialize).Name + "," + MethodBase.GetCurrentMethod().Name, ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// List<>をシリアライズ→ファイルに保存
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="savelist"></param>
        public static void SerializeAndFileSave<T>(string filepath,T cMT) where T: System.Collections.IEnumerable
        {
            try
            {
                //ストリームライターでファイルに保存
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filepath, false, System.Text.Encoding.GetEncoding("shift_jis"));
                sw.Write(JsonConvert.SerializeObject(cMT, Formatting.Indented));
                sw.Close();
            }
            catch (Exception ex)
            {
                OutputErrorLog(typeof(Serialize).Name + "," + MethodBase.GetCurrentMethod().Name, ex.Message.ToString());
            }
        }
    }





    //以下はテスト用クラス
    public class Sample_Serialize_Json
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public void TestSerialize(object z)
        {
            var p = new Person();
            p.Name = "Kato Jun";
            p.Age = 31;

            //保存先のファイル名
            string fileName = @System.Windows.Forms.Application.StartupPath + "\\test.json";

            using (var ms = new MemoryStream())
            using (var sr = new StreamReader(ms))
            {
                //DataContractJsonSerializer(System.Runtime.Serialization.Json名前空間)
                //を用いたJSONシリアライズ/デシリアライズ

                //シリアライズ
                var serializer = new DataContractJsonSerializer(typeof(Person));
                serializer.WriteObject(ms, p);
                ms.Position = 0;

                //XMLシリアライズ＋ファイルに保存
                using (System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(fileName))
                    //Write JSON
                    serializer.WriteObject(xw, p);

                //ストリームを画面に表示
                var json = sr.ReadToEnd();
                WriteLine($"{json}"); 

                //デシリアライズ
                var ser = new DataContractJsonSerializer(typeof(Person));
                ms.Position = 0;
                var deserialized = (Person)ser.ReadObject(ms);
                WriteLine($"Name: {deserialized.Name}"); // Kato Jun
                WriteLine($"Age : {deserialized.Age}");  // 31
            }
        }

        public void TestSaveSerialize_JSON()
        {
            var p = new Person();
            p.Name = "Amada Siro";
            p.Age = 33;

            //保存先のファイル名
            string fileName = @System.Windows.Forms.Application.StartupPath + "\\test2.json";


            //Json.NETを用いたJSONシリアライズ/デシリアライズ

            //シリアライズ
            var json = JsonConvert.SerializeObject(p);

            //ストリームライターでファイルに保存
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
            sw.Write(json);
            sw.Close();

            //ストリームを画面に表示
            WriteLine($"{json}");

            //デシリアライズ
            var deserialized = JsonConvert.DeserializeObject<Person>(json);
            WriteLine($"Name: {deserialized.Name}"); // Kato Jun
            WriteLine($"Age : {deserialized.Age}");  // 31

            Console.WriteLine("json success");
        }

        public void TestSaveSerialize_XML()
        {
            var p = new Person();
            p.Name = "Daigouji Gai";
            p.Age = 33;

            //保存先のファイル名
            string fileName = @System.Windows.Forms.Application.StartupPath + "\\test.xml";

            //シリアライズ、ストリーム、保存
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(Person));

            using (StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false)))
                //シリアル化と書込
                serializer.Serialize(sw, p);

            Console.WriteLine("xml success");
        }
    }
}
