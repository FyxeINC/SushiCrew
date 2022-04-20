using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SushiCrew.Content.Quest
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

            foreach (KeyValuePair<QuestID, QuestInstance> i in questPlayer.ActiveQuestCollection)
            {
                displayString += "\n-" + i.Value.CurrentData.QuestName + ": ";
                if (i.Value.CurrentQuestState == QuestState.pendingCompleted)
                {
                    displayString += "Completed!";
                }
                else
                {
                    foreach (QuestTaskInstanceBase j in i.Value.TaskInstanceCollection)
                    {
                        displayString += j.GetDisplayString() + ", ";
                    }
                }
            }

            return displayString;
        }
    }
}
