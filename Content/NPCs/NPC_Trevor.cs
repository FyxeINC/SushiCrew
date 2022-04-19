using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.ID;

namespace SushiCrew.Content.NPCs
{
	public abstract class NPC_Trevor : NPC_TownBase
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

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

            //ChatButtonName_1 = "Shop";
            //ChatButtonName_2 = "";

            NPCGender = Gender.male;
        }
    }
}