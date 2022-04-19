using Terraria;
using Terraria.Utilities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace SushiCrew.Content.NPCs
{
    public enum Gender
    {
        male,
        female,
        other
    }

	public abstract class NPC_TownBase : NPCBase
	{
        protected string[] PossibleNames;
        protected WeightedRandom<string> PossibleBasicChats;

        protected string ChatButtonName_1;
        protected string ChatButtonName_2;

        protected Gender NPCGender;


        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            PossibleNames = new string[] { "SETNAMES" };
            PossibleBasicChats = new WeightedRandom<string>();

            ChatButtonName_1 = "Button 1";
            ChatButtonName_2 = "Button 2";

            NPCGender = Gender.male;
        }

        public override string TownNPCName()
        {
            int selectedIndex = Main.rand.Next(0, PossibleNames.Length);
            return PossibleNames[selectedIndex];
        }

        public override string GetChat()
        {
            if (PossibleBasicChats.elements.Count <= 0)
            {
                return "SETCHATS";
            }
            else
            {
                return PossibleBasicChats.Get();
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = ChatButtonName_1;
            button2 = ChatButtonName_2; 
        }

        public override bool CanGoToStatue(bool toKingStatue)
        {
            if (NPCGender == Gender.male && toKingStatue)
            {
                return true;
            }
            else if (NPCGender == Gender.female && !toKingStatue)
            {
                return true;
            }
            else if (NPCGender == Gender.other)
            {
                return true;
            }

            return false;
        }
    }
}