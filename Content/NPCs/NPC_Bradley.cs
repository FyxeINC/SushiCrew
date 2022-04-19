using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.ID;

namespace SushiCrew.Content.NPCs
{
	public class NPC_Bradley : NPC_TownBase
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            NPC.Happiness
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Love) // Example Person dislikes the snow.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Hate) // Example Person dislikes the snow.
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.

                .SetNPCAffection<NPC_Joe>(AffectionLevel.Love) // Loves living near the dryad.
                .SetNPCAffection<NPC_Willer>(AffectionLevel.Like) // Likes living near the guide.
                .SetNPCAffection<NPC_Ashlyn>(AffectionLevel.Like) // Likes living near the guide.
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Dislike) // Dislikes living near the merchant.
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate); // Hates living near the demolitionist.
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            AnimationType = NPCID.Guide;

            PossibleNames = new string[] { "Bradley","Brad the Dad","Brad","Bread" };

            #region Chats
            PossibleBasicChats.Add("I'm the BEST.");
            PossibleBasicChats.Add("Wanna do a Disney singalong??", 1.0);
            PossibleBasicChats.Add("Terraria is the BOMB. Yanno what I'm saying??", 1.5);
            PossibleBasicChats.Add("My girlfriend Emmy is fucking cool.", 1.2);
            #endregion

            //ChatButtonName_1 = "Shop";
            //ChatButtonName_2 = "";

            NPCGender = Gender.male;
        }
    }
}