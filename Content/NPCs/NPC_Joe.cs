using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.ID;

namespace SushiCrew.Content.NPCs
{
	public class NPC_Joe : NPC_TownBase
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love) // Example Person dislikes the snow.
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Hate) // Example Person dislikes the snow.
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.

                .SetNPCAffection<NPC_Ashlyn>(AffectionLevel.Like) // Likes living near the guide.
                .SetNPCAffection<NPC_Willer>(AffectionLevel.Love) // Likes living near the guide.
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Dislike) // Dislikes living near the merchant.
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate) // Hates living near the demolitionist.
            ; // < Mind the semicolon!
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            AnimationType = NPCID.Guide;

            PossibleNames = new string[] { "Joe","Jojo","Obiloyd","Joseph" };

            #region Chats
            PossibleBasicChats.Add("If it happens once, it will never happen again; however, if it happens a second time, it will happen a third time.");
            PossibleBasicChats.Add("Sometimes I miss my dog Pancho.");
            PossibleBasicChats.Add("I'm going to put on Star Wars: Episode 1 and paint my mini men.");
            PossibleBasicChats.Add("I'd go rock climbing if I didn't have these stitches in my hand.");
            PossibleBasicChats.Add("ITADAKIMAAASSSSS!", 2.0);
            PossibleBasicChats.Add("If you've got drama, I don't want to hear about it.");
            PossibleBasicChats.Add("Sorry, can't chat long, I have DnD  to prep for.", 2.0);
            #endregion

            //ChatButtonName_1 = "Shop";
            //ChatButtonName_2 = "";

            NPCGender = Gender.male;
        }
    }
}