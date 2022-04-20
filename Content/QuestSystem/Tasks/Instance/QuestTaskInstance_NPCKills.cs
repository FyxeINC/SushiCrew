using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestTaskInstance_NPCKills : QuestTaskInstanceBase
    {
        public QuestTaskData_NPCKills CurrentData_NPCKills => CurrentData as QuestTaskData_NPCKills;

        public override string DisplayString
        {
            get
            {
                string toReturn = "";

                toReturn += $"({CurrentKills}/{CurrentData_NPCKills.KillsRequired}) Kill {CurrentData_NPCKills.GeneralizedNPCName}";
                if (CurrentData_NPCKills.KillsRequired > 1)
                {
                    toReturn += "s";
                }

                return toReturn;
            }
        }

        public int CurrentKills = 0;        

        public override float EvaluateCompletionPercentage(QuestPlayer questPlayer)
        {
            return ((float)CurrentKills) / ((float)CurrentData_NPCKills.KillsRequired);
        }

        public override void OnPlayerKilledNPC(NPC npcKilled, QuestPlayer questPlayer)
        {
            base.OnPlayerKilledNPC(npcKilled, questPlayer);

            if (CurrentQuestState != QuestState.inProgress)
            {
                return;
            }

            if (CurrentData_NPCKills.NPCIDCollection.Count > 0 && !CurrentData_NPCKills.NPCIDCollection.Contains(npcKilled.type))
            {
                return;
            }

            CurrentKills++;

            if (CurrentKills >= CurrentData_NPCKills.KillsRequired)
            {
                CurrentQuestState = QuestState.pendingCompleted;
            }
        }

        public override void SaveData(QuestInstance questInstance, TagCompound tag)
        {
            string slug = questInstance.CurrentData.QuestID + "." + CurrentData_NPCKills.TaskSlug;
            tag.Add(slug, CurrentKills);
        }

        public override void LoadData(QuestInstance questInstance, TagCompound tag)
        {
            string slug = questInstance.CurrentData.QuestID + "." + CurrentData_NPCKills.TaskSlug;
            if (tag.ContainsKey(slug))
            {
                CurrentKills = tag.GetInt(slug);
            }

            if (CurrentKills >= CurrentData_NPCKills.KillsRequired)
            {
                CurrentQuestState = QuestState.pendingCompleted;
            }
        }
    }
}
