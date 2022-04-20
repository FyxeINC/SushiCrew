using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SushiCrew.Content.QuestSystem
{
    public abstract class QuestTaskInstanceBase
    {
        public QuestTaskDataBase CurrentData;
        public QuestState CurrentQuestState = QuestState.inProgress;

        public abstract string DisplayString { get; }

        public abstract float EvaluateCompletionPercentage(QuestPlayer questPlayer);

        public virtual void OnPlayerKilledNPC(NPC npcKilled, QuestPlayer questPlayer) { }

        public virtual string GetDisplayString()
        { 
            if (CurrentQuestState == QuestState.pendingCompleted)
            {
                return "Completed!";
            }
            else
            {
                return DisplayString;
            }
        }

        public virtual void OnPlayerInventoryChanged(QuestPlayer player) { }

        public abstract void SaveData(QuestInstance questInstance, TagCompound tag);

        public abstract void LoadData(QuestInstance questInstance, TagCompound tag);
    }
}
