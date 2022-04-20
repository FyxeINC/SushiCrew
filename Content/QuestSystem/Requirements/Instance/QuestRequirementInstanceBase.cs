using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public abstract class QuestRequirementInstanceBase
    {
        public QuestRequirementDataBase CurrentData;

        public abstract string RequirementDescriptionShort { get; }
        public abstract string RequirementDescriptionLong { get; }

        public abstract float EvaluateCompletionPercentage(QuestPlayer questPlayer);

        public abstract QuestState EvaluateQuestState(QuestPlayer questPlayer);

        public virtual void OnPlayerKilledNPC(NPC npcKilled, QuestPlayer questPlayer) { }

    }
}
