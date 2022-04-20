using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Personalities;

namespace SushiCrew.Content.NPCs
{
	public class NPC_Emily : NPC_TownBase
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Fisher");

            Main.npcFrameCount[NPC.type] = 23;

            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Love)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Hate)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)

                .SetNPCAffection<NPC_Bradley>(AffectionLevel.Love)
                .SetNPCAffection<NPC_Joe>(AffectionLevel.Like)
                .SetNPCAffection(NPCID.Stylist, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Love)
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate);
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            AnimationType = NPCID.Stylist;
            NPC.width = 25;//18
            NPC.height = 40;//40

            PossibleNames = new string[] { "Emily","Emmy","Stinkyface" };

            #region Chats
            PossibleBasicChats.Add("I'm moving in with Bradley soon.");
            PossibleBasicChats.Add("I love my two voids.");
            PossibleBasicChats.Add("MICKEY, get back here!!");
            PossibleBasicChats.Add("I'm looking for the Princess vanity set, let me know if you see it!");
            PossibleBasicChats.Add("Bradley is my favorite person EVER.");
            #endregion

            //ChatButtonName_1 = "Shop";
            //ChatButtonName_2 = "";

            NPCGender = Gender.female;
            AttackProjectileID = ProjectileID.FishHook;
        }
    }
}