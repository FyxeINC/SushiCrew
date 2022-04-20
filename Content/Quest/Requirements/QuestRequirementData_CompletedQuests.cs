using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.Quest
{
    public class QuestRequirementData_CompletedQuests : QuestRequirementDataBase
    {
        List<QuestID> QuestIDsToCheckCollection = new List<QuestID>();

        public QuestRequirementData_CompletedQuests(List<QuestID> questIDs)
        {
            QuestIDsToCheckCollection = questIDs;
        }

        public override bool DoesPlayerMeetRequirements(QuestPlayer player)
        {
            foreach (QuestID i in QuestIDsToCheckCollection)
            {
                if (!player.CompletedQuestCollection.Contains(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
