using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKMN_CALC.Utility;
using System.Reflection;
using static PKMN_CALC.Utility.ErrorLog;

namespace PKMN_CALC.Master
{
    /// <summary>
    /// マスタの初期ロード・デバッグ画面からのセーブロードクラス
    /// </summary>
    public class _Master_Init
    {
        /// <summary>
        /// 全マスタを管理するID
        /// "特性マスタ", "覚えるわざマスタ", "アイテムマスタ", "ポケモンマスタ", "ランクマスタ", "性格マスタ", "タイプマスタ", "わざマスタ", "わざ特殊処理マスタ"
        /// </summary>
        public enum Master_ID
        {
            tokusei, eachpokecanusewaza, item, pokemon, rank, seikaku, type, waza,wazasp,
        }
        // 各種マスタデータ(JSONファイルから)を読み込む
        private static readonly string MASTER_ITEM_JSON = "Master_Item.json";
        private static readonly string MASTER_POKEMON_JSON = "Master_Pokemon.json";
        private static readonly string MASTER_RANK_JSON = "Master_Rank.json";
        private static readonly string MASTER_SEIKAKU_JSON = "Master_Seikaku.json";
        private static readonly string MASTER_TYPE_JSON = "Master_Type.json";
        private static readonly string MASTER_WAZA_JSON = "Master_Waza.json";
        private static readonly string MASTER_EACHWAZA_JSON = "Master_EachPokeCanUseWaza.json";

        //公開する各種マスタプロパティ
        //public List<Master_Ability> cMaster_Ability;
        public static IEnumerable<Master_Item> MASTER_ITEM_LIST { get; set; }
        public static IEnumerable<Master_Pokemon> MASTER_POKEMON_LIST { get; set; }
        public static IEnumerable<Master_Rank> MASTER_RANK_LIST { get; set; }
        public static IEnumerable<Master_Seikaku> MASTER_SEIKAKU_LIST { get; set; }
        public static IEnumerable<Master_Type> MASTER_TYPE_LIST { get; set; }
        public static IEnumerable<Master_Waza> MASTER_WAZA_LIST { get; set; }
        //覚える技マスタはポケモンマスタ、わざマスタを参照するのでその２つの後にロードすること
        public static IEnumerable<Master_EachPokeCanUseWaza> MASTER_EACHWAZA_LIST { get; set; }
        //public IEnumerable<Master_Waza_Sp> MASTER_WAZA_LIST_Sp { get; set; }

        /// <summary>
        /// 静的コンストラクタ(ファイルデータをロード)
        /// </summary>
        static _Master_Init()
        {
            FileInit();
        }

        /// <summary>
        /// 一括　ファイルデータ→マスタ
        /// </summary>
        public static void FileInit()
        {
            MASTER_ITEM_LIST = Serialize.FileLoadAndDeserialize(Master_ID.item, MASTER_ITEM_JSON) as IEnumerable<Master_Item>;
            MASTER_POKEMON_LIST = Serialize.FileLoadAndDeserialize(Master_ID.pokemon, MASTER_POKEMON_JSON) as IEnumerable<Master_Pokemon>;
            MASTER_RANK_LIST = Serialize.FileLoadAndDeserialize(Master_ID.rank, MASTER_RANK_JSON) as IEnumerable<Master_Rank>;
            MASTER_SEIKAKU_LIST = Serialize.FileLoadAndDeserialize(Master_ID.seikaku, MASTER_SEIKAKU_JSON) as IEnumerable<Master_Seikaku>;
            MASTER_TYPE_LIST = Serialize.FileLoadAndDeserialize(Master_ID.type, MASTER_TYPE_JSON) as IEnumerable<Master_Type>;
            MASTER_WAZA_LIST = Serialize.FileLoadAndDeserialize(Master_ID.waza, MASTER_WAZA_JSON) as IEnumerable<Master_Waza>;
            MASTER_EACHWAZA_LIST = Serialize.FileLoadAndDeserialize(Master_ID.eachpokecanusewaza, MASTER_EACHWAZA_JSON) as IEnumerable<Master_EachPokeCanUseWaza>;
        }

        /// <summary>
        /// 一括　サンプルデータ→マスタ
        /// </summary>
        public static void SampleInit()
        {
            MASTER_ITEM_LIST = new Master_Item_Set().SampleInit();
            MASTER_POKEMON_LIST = new Master_Pokemon_Set().SampleInit();
            MASTER_RANK_LIST = new Master_Rank_Set().SampleInit();
            MASTER_SEIKAKU_LIST = new Master_Seikaku_Set().SampleInit();
            MASTER_TYPE_LIST = new Master_Type_Set().SampleInit();
            MASTER_WAZA_LIST = new Master_Waza_Set().SampleInit();
            //覚える技マスタはポケモンマスタ、わざマスタを参照するのでその２つの後にロードすること
            MASTER_EACHWAZA_LIST = new Master_EachPokeCanUseWaza_Set().SampleInit();
        }

        /// <summary>
        /// 指定したマスタID→マスタ
        /// </summary>
        /// <param name="m_id"></param>
        /// <returns></returns>
        public static object LoadMaster(Master_ID m_id, ref bool bRet)
        {
            bRet = true;

            switch (m_id)
            {
                case Master_ID.item:
                    return MASTER_ITEM_LIST;
                case Master_ID.pokemon:
                    return MASTER_POKEMON_LIST;
                case Master_ID.rank:
                    return MASTER_RANK_LIST;
                case Master_ID.seikaku:
                    return MASTER_SEIKAKU_LIST;
                case Master_ID.type:
                    return MASTER_TYPE_LIST;
                case Master_ID.waza:
                    return MASTER_WAZA_LIST;
                case Master_ID.eachpokecanusewaza:
                    return MASTER_EACHWAZA_LIST;
                default:
                    //エラー
                    bRet = false;
                    return null;
            }
        }

        /// <summary>
        /// 指定したID・データ→マスタ→ファイル
        /// </summary>
        /// <param name="m_id"></param>
        /// <param name="cMaster"></param>
        /// <param name="bRet"></param>
        public static void SaveMaster(Master_ID m_id, object cMaster, ref bool bRet)
        {
            bRet = true;

            switch (m_id)
            {
                case Master_ID.item:
                    MASTER_ITEM_LIST = cMaster as IEnumerable<Master_Item>;
                    Serialize.SerializeAndFileSave(MASTER_ITEM_JSON, MASTER_ITEM_LIST);
                    break;
                case Master_ID.pokemon:
                    MASTER_POKEMON_LIST = cMaster as IEnumerable<Master_Pokemon>;
                    Serialize.SerializeAndFileSave(MASTER_POKEMON_JSON,MASTER_POKEMON_LIST);
                    break;
                case Master_ID.rank:
                    MASTER_RANK_LIST = cMaster as IEnumerable<Master_Rank>;
                    Serialize.SerializeAndFileSave(MASTER_RANK_JSON,MASTER_RANK_LIST);
                    break;
                case Master_ID.seikaku:
                    MASTER_SEIKAKU_LIST = cMaster as IEnumerable<Master_Seikaku>;
                    Serialize.SerializeAndFileSave(MASTER_SEIKAKU_JSON,MASTER_SEIKAKU_LIST);
                    break;
                case Master_ID.type:
                    MASTER_TYPE_LIST = cMaster as IEnumerable<Master_Type>;
                    Serialize.SerializeAndFileSave(MASTER_TYPE_JSON,MASTER_TYPE_LIST);
                    break;
                case Master_ID.waza:
                    MASTER_WAZA_LIST = cMaster as IEnumerable<Master_Waza>;
                    Serialize.SerializeAndFileSave(MASTER_WAZA_JSON,MASTER_WAZA_LIST);
                    break;
                case Master_ID.eachpokecanusewaza:
                    MASTER_EACHWAZA_LIST = cMaster as IEnumerable<Master_EachPokeCanUseWaza>;
                    Serialize.SerializeAndFileSave(MASTER_EACHWAZA_JSON,MASTER_EACHWAZA_LIST);
                    break;
                default:
                    bRet = false;
                    return;
            }            
        }
    }

}
