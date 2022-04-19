using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.ID;

namespace SushiCrew.Content.NPCs
{
    [Autoload]
	public class NPC_Willer : NPC_TownBase
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Pest");
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love) // Example Person dislikes the snow.
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Hate) // Example Person dislikes the snow.
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.
                .SetNPCAffection<NPC_Joe>(AffectionLevel.Love) // Loves living near the dryad.
                .SetNPCAffection<NPC_Bradley>(AffectionLevel.Love) // Loves living near the dryad.
                .SetNPCAffection<NPC_Trevor>(AffectionLevel.Like) // Likes living near the guide.
                .SetNPCAffection<NPC_Ashlyn>(AffectionLevel.Like) // Likes living near the guide.
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Dislike) // Dislikes living near the merchant.
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate); // Hates living near the demolitionist.
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            AnimationType = NPCID.Guide;

            PossibleNames = new string[] { "Willer","Weewer","Spiller" };

            #region Chats
            //PossibleBasicChats.Add("");
            PossibleBasicChats.Add("I just want to find a mine shaft that hasn't been completely stripped.");
            PossibleBasicChats.Add("It is my sworn goal to be an absolute pest of this Terraria server.");
            PossibleBasicChats.Add("Don't tell Ash the Decorator, but I've stolen like, 10 stacks of doors from the town buildings. I didn't need them, I just find joy in being a pest.");
            PossibleBasicChats.Add("Wanna boof?");
            PossibleBasicChats.Add("Wanna play some Guilty Gear?");
            PossibleBasicChats.Add("I'll play any game that has a good combat system. Terraria is alright too, I guess.");
            PossibleBasicChats.Add("Bradley is one of my favorite people.");
            PossibleBasicChats.Add("My girlfriend Elise is fucking rad.", 1.2);
            #endregion

            //ChatButtonName_1 = "Shop";
            //ChatButtonName_2 = "";

            NPCGender = Gender.male;

        }        
    }
}