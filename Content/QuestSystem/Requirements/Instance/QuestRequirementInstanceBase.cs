﻿using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public abstract class QuestRequirementInstanceBase
    {
        public QuestRequirementDataBase CurrentData;
        public QuestState CurrentQuestState = QuestState.inProgress;

        public abstract string RequirementDescriptionShort { get; }
        public abstract string RequirementDescriptionLong { get; }

        public abstract float EvaluateCompletionPercentage(QuestPlayer questPlayer);

        public virtual void OnPlayerKilledNPC(NPC npcKilled, QuestPlayer questPlayer) { }

    }
}