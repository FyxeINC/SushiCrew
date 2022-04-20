using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestRequirementInstance_NPCKills : QuestRequirementInstanceBase
    {
        public QuestRequirementData_NPCKills CurrentKillData => CurrentData as QuestRequirementData_NPCKills;

        public override string RequirementDescriptionShort { get => ""; }
        public override string RequirementDescriptionLong { get => ""; }

        public int CurrentKills = 0;        

        public override float EvaluateCompletionPercentage(QuestPlayer questPlayer)
        {
            return ((float)CurrentKills) / ((float)CurrentKillData.KillsRequired);
        }

        public override void OnPlayerKilledNPC(NPC npcKilled, QuestPlayer questPlayer)
        {
            base.OnPlayerKilledNPC(npcKilled, questPlayer);

            if (CurrentQuestState != QuestState.inProgress)
            {
                return;
            }

            if (CurrentKillData.NPCIDs.Count > 0 && !CurrentKillData.NPCIDs.Contains(npcKilled.type))
            {
                return;
            }

            CurrentKills++;

            if (CurrentKills >= CurrentKillData.KillsRequired)
            {
                CurrentQuestState = QuestState.pendingCompleted;
            }
        }
    }
}
