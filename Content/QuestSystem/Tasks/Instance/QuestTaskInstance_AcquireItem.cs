using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestTaskInstance_AcquireItem : QuestTaskInstanceBase
    {
        public QuestTaskData_AcquireItem CurrentData_AcquireItem => CurrentData as QuestTaskData_AcquireItem;

        public override string DisplayString
        {
            get
            {
                string toReturn = "";

                toReturn += $"({CurrentAcquiredItems}/{m_ItemsRequired}) Kill {CurrentData_AcquireItem.GeneralizedItemName}";
                if (m_ItemsRequired > 1)
                {
                    toReturn += "s";
                }

                return toReturn;
            }
        }

        public int CurrentAcquiredItems = 0;      
        protected int m_ItemsRequired { get => CurrentData_AcquireItem.ItemsRequired; }

        public override float EvaluateCompletionPercentage(QuestPlayer questPlayer)
        {
            return ((float)CurrentAcquiredItems) / ((float)m_ItemsRequired);            
        }

        public override void OnPlayerInventoryChanged(QuestPlayer player)
        {
            base.OnPlayerInventoryChanged(player);
            CurrentAcquiredItems = 0;
            for (int i = 0; i < player.Player.inventory.Length - 1; i++)
            {
                if (CurrentData_AcquireItem.ItemIDCollection.Contains(player.Player.inventory[i].type))
                {
                    CurrentAcquiredItems += player.Player.inventory[i].stack;
                }
            }

            if (CurrentAcquiredItems >= m_ItemsRequired)
            {
                CurrentQuestState = QuestState.pendingCompleted;
            }
        }


        public override void SaveData(QuestInstance questInstance, TagCompound tag)
        {
            string slug = questInstance.CurrentData.QuestID + "." + CurrentData.TaskSlug;
            tag.Add(slug, CurrentAcquiredItems);
        }

        public override void LoadData(QuestInstance questInstance, TagCompound tag)
        {
            string slug = questInstance.CurrentData.QuestID + "." + CurrentData.TaskSlug;
            if (tag.ContainsKey(slug))
            {
                CurrentAcquiredItems = tag.GetInt(slug);
            }

            if (CurrentAcquiredItems >= m_ItemsRequired)
            {
                CurrentQuestState = QuestState.pendingCompleted;
            }
        }
    }
}
