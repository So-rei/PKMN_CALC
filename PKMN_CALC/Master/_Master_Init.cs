using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKMN_CALC.Master
{
    class _Master_Init
    {
        //public List<Master_Ability> cMaster_Ability;
        //public List<Master_EachPokeCanUseWaza> cMaster_EachPokeCanUseWaza;
        public List<Master_Item> cMaster_Item;
        public List<Master_Pokemon> cMaster_Pokemon;
        public List<Master_Rank> cMaster_Rank;
        public List<Master_Seikaku> cMaster_Seikaku;
        public List<Master_Type> cMaster_Type;
        public List<Master_Waza> cMaster_Waza;
        //public List<Master_Waza_Sp> cMaster_Waza_Sp;

        //各種マスタデータを読み込む
        public void Load()
        {
            //Master_Ability_Set tMaster_Ability = new Master_Ability_Set();
            //cMaster_Ability = tMaster_Ability.Init();
            //Master_EachPokeCanUseWaza_Set tMaster_EachPokeCanUseWaza = new Master_EachPokeCanUseWaza_Set();
            //cMaster_EachPokeCanUseWaza = tMaster_EachPokeCanUseWaza.Init();
            Master_Item_Set tMaster_Item = new Master_Item_Set();
            cMaster_Item = tMaster_Item.Init();
            Master_Pokemon_Set tMaster_Pokemon = new Master_Pokemon_Set();
            cMaster_Pokemon = tMaster_Pokemon.Init();
            Master_Rank_Set tMaster_Rank = new Master_Rank_Set();
           cMaster_Rank = tMaster_Rank.Init();
            Master_Seikaku_Set tMaster_Seikaku = new Master_Seikaku_Set();
            cMaster_Seikaku = tMaster_Seikaku.Init();
            Master_Type_Set tMaster_Type = new Master_Type_Set();
            cMaster_Type = tMaster_Type.Init();
            Master_Waza_Set tMaster_Waza = new Master_Waza_Set();
            cMaster_Waza = tMaster_Waza.Init();
            //Master_Waza_Sp_Set tMaster_Waza_Sp = new Master_Waza_Sp_Set();
            //cMaster_Waza_Sp = tMaster_Waza_Sp.Init();

        }
    }
}
