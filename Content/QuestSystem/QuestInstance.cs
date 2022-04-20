using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    /// <summary>
    /// Has reference to a QuestData and tracks specific information for quests
    /// </summary>
    public class QuestInstance
    {
        public QuestData CurrentData;
        public List<QuestRequirementInstanceBase> RequirmentInstanceCollection = new List<QuestRequirementInstanceBase>(); 
        // TODO - not needed?
        //public List<QuestRewardInstanceBase> RewardInstanceCollection = new List<QuestRewardInstanceBase>(); 

        public QuestPlayer OwningPlayer;

        public QuestState CurrentQuestState
        {
            get
            {
                foreach (QuestRequirementInstanceBase i in RequirmentInstanceCollection)
                {
                    if (i.CurrentQuestState == QuestState.inProgress)
                    {
                        return QuestState.inProgress;
                    }
                }
                return QuestState.pendingCompleted;
            }
        }
        public float CurrentPercentComplete
        { 
            get
            {
                if (CurrentData.RequirementCollection.Count <= 0)
                {
                    // If there are no requirements, then the quest is completed
                    return 1f;
                }


                float toReturn = 0f;
                foreach (QuestRequirementInstanceBase i in RequirmentInstanceCollection)
                {
                    toReturn += i.EvaluateCompletionPercentage(OwningPlayer);
                }

                toReturn /= CurrentData.RequirementCollection.Count;

                return toReturn;
            }
        }

        public QuestInstance(QuestData newData)
        {
            CurrentData = newData;
            foreach (QuestRequirementDataBase i in CurrentData.RequirementCollection)
            {
                QuestRequirementInstanceBase instance = (QuestRequirementInstanceBase)Activator.CreateInstance(i.RequirementInstanceType);
                RequirmentInstanceCollection.Add(instance);
                instance.CurrentData = i;
            }
        }


        public virtual void OnPlayerKilledNPC(NPC npcKilled) { }
    }
}
