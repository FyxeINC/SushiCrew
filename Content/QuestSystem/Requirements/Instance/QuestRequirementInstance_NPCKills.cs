using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestRequirementInstance_NPCKills : QuestRequirementInstanceBase
    {
        public QuestRequirementData_NPCKills CurrentData_NPCKills => CurrentData as QuestRequirementData_NPCKills;

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

            if (CurrentData_NPCKills.NPCIDs.Count > 0 && !CurrentData_NPCKills.NPCIDs.Contains(npcKilled.type))
            {
                return;
            }

            CurrentKills++;

            if (CurrentKills >= CurrentData_NPCKills.KillsRequired)
            {
                CurrentQuestState = QuestState.pendingCompleted;
            }
        }
    }
}
