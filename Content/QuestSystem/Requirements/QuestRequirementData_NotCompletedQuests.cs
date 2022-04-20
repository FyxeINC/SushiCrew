﻿using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestRequirementData_NotCompletedQuests : QuestRequirementDataBase
    {
        List<QuestID> QuestIDsToCheckCollection = new List<QuestID>();

        public QuestRequirementData_NotCompletedQuests(List<QuestID> questIDs)
        {
            QuestIDsToCheckCollection = questIDs;
        }

        public override bool DoesPlayerMeetRequirements(QuestPlayer player)
        {
            foreach (var i in QuestIDsToCheckCollection)
            {
                if (player.CompletedQuestCollection.Contains(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
