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

        public override QuestState EvaluateQuestState(QuestPlayer questPlayer)
        {
            throw new System.NotImplementedException();
        }
    }
}
