using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestInfoDisplay_Debug : InfoDisplay
    {
        public override void SetStaticDefaults()
        {
            InfoName.SetDefault("Quest Info");
        }

        public override bool Active()
        {
            return true;
        }

        public override string DisplayValue()
        {
            QuestPlayer questPlayer = Main.LocalPlayer.GetModPlayer<QuestPlayer>();
            string displayString = "Quest Info: ";

            foreach (KeyValuePair<int, QuestInstance> i in questPlayer.ActiveQuestCollection)
            {
                displayString += "\n-" + i.Value.CurrentData.QuestName + ": ";
                foreach (QuestRequirementInstanceBase j in i.Value.RequirmentInstanceCollection)
                {
                    displayString += j.DisplayString;
                }
            }

            return displayString;
        }
    }
}
