using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Personalities;

namespace SushiCrew.Content.NPCs
{
	public class NPC_Ashlyn : NPC_TownBase
	{
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Decorator");
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love) // Example Person dislikes the snow.
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Hate) // Example Person dislikes the snow.
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.

                .SetNPCAffection<NPC_Trevor>(AffectionLevel.Love) // Loves living near the dryad.
                .SetNPCAffection<NPC_Joe>(AffectionLevel.Like) // Likes living near the guide.
                .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Dislike) // Dislikes living near the merchant.
                .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Hate); // Hates living near the demolitionist.
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Main.npcFrameCount[NPC.type] = 23;

            AnimationType = NPCID.Stylist;

            PossibleNames = new string[] { "Ash", "Ashlyn", "Smashlyn", "Ashbumbash", "Smash", "Ashy", "Splashlyn", "Smashiyn" };
            
            #region Chats
            PossibleBasicChats.Add("Are there any sodas left?");
            PossibleBasicChats.Add("We should make pizza for dinner!");
            PossibleBasicChats.Add("I'm tired. Maybe I need caffeine. Or sleep. No, nevermind, not sleep, just caffeine.");
            PossibleBasicChats.Add("Trying to think of how I can remake this space. Got any ideas?", 2.0);
            PossibleBasicChats.Add("Wanna know a secret? I think the Troubador is a hottie with a body.", 0.5);
            #endregion

            ChatButtonName_1 = Language.GetTextValue("LegacyInterface.28"); // Shop
            ChatButtonName_2 = "Bitch";

            ChatButton1IsShop = true;

            NPCGender = Gender.female;

            //MOD SHOPS
            BasicShopItems = new int[] { ModContent.ItemType<Content.Items.WallItem_00>(), ModContent.ItemType<Content.Items.WallItem_01>(), ModContent.ItemType<Content.Items.WallItem_02>(), ModContent.ItemType<Content.Items.WallItem_03>(), ModContent.ItemType<Content.Items.WindowItem_Test>(), ModContent.ItemType<Content.Items.TestWallItem>() };
            /*
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Walls.Wallpaper_00.WallpaperItem_00>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Walls.Wallpaper_01.WallpaperItem_01>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Walls.Wallpaper_02.WallpaperItem_02>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Walls.Wallpaper_03.WallpaperItem_03>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Walls.Window_00.WindowItem_Test>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Walls.TestWallItem>());
			nextSlot++;
             */

            //BASIC SHOPS
            //BasicShopItems = new int[] { ItemID.Beenade };

            AttackProjectileID = ProjectileID.WoodYoyo;
        }

        public override string GetChat()
        {
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.NextBool(4))
            {
                return "Can you please tell " + Main.npc[partyGirl].GivenName + " to shut the fuck up?";
            }
            else
            {
                return base.GetChat();
            }
        }

    }
}