using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.ID;

namespace SushiCrew.Content.NPCs
{
	public abstract class NPC_Kyle : NPC_TownBase
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            //DisplayName.SetDefault();
            NPC.Happiness
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Like)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Hate)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
                .SetNPCAffection<NPC_Trevor>(AffectionLevel.Love)
                .SetNPCAffection<NPC_Tyler>(AffectionLevel.Like)
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate);
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            AnimationType = NPCID.Guide;

            PossibleNames = new string[] { "Kyle","Kyleg" };

            #region Chats
            PossibleBasicChats.Add("BEAT. THE. HELL. OUTTA. SKELETRON!!!!");
            PossibleBasicChats.Add("I'm practicing my moves for the Boot Dance");
            PossibleBasicChats.Add("BTHO my love life...");
            PossibleBasicChats.Add("Have you seen the latest of Love Sky Island??");
            PossibleBasicChats.Add("Between you and me, I think the Painter has a big crush on the Dryad.");
            #endregion

            //ChatButtonName_1 = "Shop";
            //ChatButtonName_2 = "";

            NPCGender = Gender.male;

            AttackProjectileID = ProjectileID.Bullet;
        }
    }
}