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
        public List<QuestTaskInstanceBase> TaskInstanceCollection = new List<QuestTaskInstanceBase>(); 
        // TODO - not needed?
        //public List<QuestRewardInstanceBase> RewardInstanceCollection = new List<QuestRewardInstanceBase>(); 

        public QuestPlayer OwningPlayer;

        public QuestState CurrentQuestState
        {
            get
            {
                foreach (QuestTaskInstanceBase i in TaskInstanceCollection)
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
                if (CurrentData.TaskCollection.Count <= 0)
                {
                    // If there are no Tasks, then the quest is completed
                    return 1f;
                }


                float toReturn = 0f;
                foreach (QuestTaskInstanceBase i in TaskInstanceCollection)
                {
                    toReturn += i.EvaluateCompletionPercentage(OwningPlayer);
                }

                toReturn /= CurrentData.TaskCollection.Count;

                return toReturn;
            }
        }

        public QuestInstance(QuestData newData)
        {
            CurrentData = newData;
            foreach (QuestTaskDataBase i in CurrentData.TaskCollection)
            {
                QuestTaskInstanceBase instance = (QuestTaskInstanceBase)Activator.CreateInstance(i.TaskInstanceType);
                TaskInstanceCollection.Add(instance);
                instance.CurrentData = i;
            }
        }


        public virtual void OnPlayerKilledNPC(NPC npcKilled) { }
    }
}
