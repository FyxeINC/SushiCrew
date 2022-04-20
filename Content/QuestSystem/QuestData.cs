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

        public List<int> QuestGiverNPCIDCollection { get; private set; } = new List<int> ();
        public List<int> QuestRewardGiverNPCIDCollection { get; private set; } = new List<int>();

        public List<QuestRequirementDataBase> RequirementCollection { get; private set; } = new List<QuestRequirementDataBase>();
        public List<QuestTaskDataBase> TaskCollection { get; private set; } = new List<QuestTaskDataBase>();
        public List<QuestRewardDataBase> RewardCollection { get; private set; } = new List<QuestRewardDataBase>();

        public QuestData(int questID, string questName, string questDescription, List<int> questGiverNPCCollection, List<int> questRewardGiverNPCCollection, List<QuestRequirementDataBase> requirements, List<QuestTaskDataBase> tasks, List<QuestRewardDataBase> rewards)
        {
            QuestID = questID;
            QuestName = questName;
            QuestDescription = questDescription;
            QuestGiverNPCIDCollection = questGiverNPCCollection;
            QuestRewardGiverNPCIDCollection = questRewardGiverNPCCollection;
            RequirementCollection = requirements;
            TaskCollection = tasks;
            RewardCollection = rewards;
        }
    }
}
