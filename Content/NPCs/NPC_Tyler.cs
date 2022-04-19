using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.ID;

namespace SushiCrew.Content.NPCs
{
	public class NPC_Tyler : NPC_TownBase
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Bee Keeper");
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // NPC prefers the forest.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love) // NPC dislikes the snow.
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Hate) // NPC dislikes the snow.
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike) // NPC dislikes the snow.

                .SetNPCAffection(NPCID.Truffle, AffectionLevel.Like) // Likes living near
                .SetNPCAffection<NPC_Willer>(AffectionLevel.Love) // Loves living near
                .SetNPCAffection<NPC_Ashlyn>(AffectionLevel.Love) // Loves living near
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Dislike) // Dislikes living near
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate); // Hates living near
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            AnimationType = NPCID.Guide;

            PossibleNames = new string[] { "Tyler","Tyty","Ty","Zanzooky" };

            #region Chats
            PossibleBasicChats.Add("I brought PORCH SWING!");
            PossibleBasicChats.Add("You shouldn't have been standing there.");
            PossibleBasicChats.Add("Guess you better get good.");
            PossibleBasicChats.Add("Do you want to play 7Wonders??");
            PossibleBasicChats.Add("Have you seen Ash the Decorator around? I need her input on my room layout.");
            PossibleBasicChats.Add("Be right back, Kelly is calling me.");
            //PossibleBasicChats.Add("");
            #endregion

            ChatButtonName_1 = "Shop";
            ChatButtonName_2 = "Taunt";

            ChatButton1IsShop = true;

            NPCGender = Gender.male;

            //MOD SHOPS
            //BasicShopItems = new int[] {ModContent.ItemType<>};

            //BASIC SHOPS
            BasicShopItems = new int[] { ItemID.Beenade,ItemID.BeeMask,ItemID.BeeHat, ItemID.BeeShirt,ItemID.BeePants,ItemID.BeeHive,ItemID.BeeKeeper,ItemID.BeesKnees };

            AttackProjectileID = ProjectileID.Beenade;
        }
    }
}