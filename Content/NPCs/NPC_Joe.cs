using Terraria.ModLoader;

namespace SushiCrew.Content.NPCs
{
	public abstract class NPC_Joe : NPC_TownBase
	{
        public override void SetDefaults()
        {
            base.SetDefaults();

            PossibleNames = new string[] { "Joe" };

            #region Chats
            //PossibleBasicChats.Add("");
            #endregion

            //ChatButtonName_1 = "Shop";
            //ChatButtonName_2 = "";

            NPCGender = Gender.male;
        }
    }
}