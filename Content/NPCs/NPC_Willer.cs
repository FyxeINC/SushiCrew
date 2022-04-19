using Terraria.ModLoader;

namespace SushiCrew.Content.NPCs
{
	public abstract class NPC_Willer : NPC_TownBase
	{
        public override void SetDefaults()
        {
            base.SetDefaults();

            PossibleNames = new string[] { "Willer" };

            #region Chats
            //PossibleBasicChats.Add("");
            #endregion

            //ChatButtonName_1 = "Shop";
            //ChatButtonName_2 = "";

            NPCGender = Gender.male;
        }
    }
}