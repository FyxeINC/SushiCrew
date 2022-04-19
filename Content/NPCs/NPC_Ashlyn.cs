using Terraria.ModLoader;

namespace SushiCrew.Content.NPCs
{
	public abstract class NPC_Ashlyn : NPC_TownBase
	{
        public override void SetDefaults()
        {
            base.SetDefaults();

            PossibleNames = new string[] { "Ash", "Ashlyn", "Smashlyn", "Ashbumbash", "Smash", "Ashy", "Splashlyn", "Smashiyn" };
            
            #region Chats
            PossibleBasicChats.Add("Are there any sodas left?");
            PossibleBasicChats.Add("We should make pizza for dinner!");
            PossibleBasicChats.Add("I'm tired. Maybe I need caffeine. Or sleep. No, nevermind, not sleep, just caffeine.");
            PossibleBasicChats.Add("This message has a weight of 5, meaning it appears 5 times more often. Bitches.", 5.0);
            PossibleBasicChats.Add("This message has a weight of 0.1, meaning it appears 10 times as rare. Cunts.", 0.1);
            #endregion

            ChatButtonName_1 = "Shop";
            ChatButtonName_2 = "Bitch";

            NPCGender = Gender.female;
        }
    }
}