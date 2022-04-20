using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Personalities;

namespace SushiCrew.Content.NPCs
{
	public class NPC_Kelsey : NPC_TownBase
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.npcFrameCount[NPC.type] = 23;

            NPC.Happiness
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Like)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Hate)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
                .SetNPCAffection<NPC_Ashlyn>(AffectionLevel.Love)
                .SetNPCAffection<NPC_Joe>(AffectionLevel.Like)
                .SetNPCAffection<NPC_Tyler>(AffectionLevel.Like)
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate);
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            AnimationType = NPCID.Stylist;
            NPC.width = 25;//18
            NPC.height = 40;//40

            PossibleNames = new string[] { "Kelsey","Kels","Sophie's Owner" };

            #region Chats
            PossibleBasicChats.Add("Wanna go for a walk on the trail?");
            PossibleBasicChats.Add("Wanna go to this new bar I found?");
            PossibleBasicChats.Add("Wanna go to Starbucks?");
            PossibleBasicChats.Add("Wanna host a game night?");
            PossibleBasicChats.Add("Wanna go see a movie?");
            PossibleBasicChats.Add("Wanna go rock climbing?");
            PossibleBasicChats.Add("Wanna go?");
            #endregion

            //ChatButtonName_1 = "Shop";
            //ChatButtonName_2 = "";

            NPCGender = Gender.female;
            //AttackProjectileID = ProjectileID.Glowstick;
        }
    }
}