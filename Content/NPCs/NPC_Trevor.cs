using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.ID;

namespace SushiCrew.Content.NPCs
{
	public class NPC_Trevor : NPC_TownBase
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love) // Example Person dislikes the snow.
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Hate) // Example Person dislikes the snow.
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.

                .SetNPCAffection<NPC_Austin>(AffectionLevel.Like) // Loves living near the dryad.
                .SetNPCAffection<NPC_Ashlyn>(AffectionLevel.Love) // Likes living near the guide.
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Dislike) // Dislikes living near the merchant.
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Hate); // Hates living near the demolitionist.
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            AnimationType = NPCID.Guide;

            PossibleNames = new string[] { "Trevor", "Trev", "Fyxe", "Tdog" };

            #region Chats
            PossibleBasicChats.Add("Yanno, you're not wrong.");
            PossibleBasicChats.Add("Ash the Decorator is pretty neat.");
            PossibleBasicChats.Add("Do you need help finding a new game to play? I know of a few.");
            PossibleBasicChats.Add("Have you seen the new Tarkov updates?", 2.0);
            PossibleBasicChats.Add("You should come check out my mini men army. I tried this cool new technique that really makes the colors pop.", 2.0);
            PossibleBasicChats.Add("Dwarf Fortress is the coolest game EVER.", 1.5);
            PossibleBasicChats.Add("League of Legends isn't a good game. Period.");
            PossibleBasicChats.Add("Don't tell anyone else I told you this, but I've got a big crush on Ash the Decorator.", 0.8);
            #endregion

            ChatButtonName_1 = "Shop";
            ChatButtonName_2 = "Love";

            ChatButton1IsShop = true;

            NPCGender = Gender.male;

            //MOD SHOPS
            //BasicShopItems = new int[] {ModContent.ItemType<>};

            //BASIC SHOPS
            BasicShopItems = new int[] { ItemID.DrumSet,ItemID.DrumStick,ItemID.SparkleGuitar,ItemID.IvyGuitar,ItemID.CarbonGuitar,ItemID.Harp, ItemID.WhoopieCushion };
        }
    }
}