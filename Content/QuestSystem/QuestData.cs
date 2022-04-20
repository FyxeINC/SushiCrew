using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    /// <summary>
    /// Holds immutable information about quests
    /// </summary>
    public class QuestData
    {
        public int QuestID { get; private set; } = -1;
        public string QuestName { get; private set; } = "UNNAMED QUEST";
        public string QuestDescription { get; private set; } = "QUEST DESCRIPTION";

        public int QuestGiverNPCID { get; private set; } = -1;
        public int QuestRewardGiverNPCID { get; private set; } = -1;

        public List<QuestRequirementDataBase> RequirementCollection { get; private set; } = new List<QuestRequirementDataBase>();
        public List<QuestRewardDataBase> RewardCollection { get; private set; } = new List<QuestRewardDataBase>();

        public QuestData(int questID, string questName, string questDescription, int questGiverNPC, int questRewardGiverNPC, List<QuestRequirementDataBase> requirements, List<QuestRewardDataBase> rewards)
        {
            QuestID = questID;
            QuestName = questName;
            QuestDescription = questDescription;
            QuestGiverNPCID = questGiverNPC;
            QuestRewardGiverNPCID = questRewardGiverNPC;
            RequirementCollection = requirements;
            RewardCollection = rewards;
        }
    }
}
