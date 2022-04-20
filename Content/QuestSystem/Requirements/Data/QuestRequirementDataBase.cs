﻿using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public abstract class QuestRequirementDataBase
    {
        public abstract System.Type RequirementInstanceType { get; }

        public abstract string RequirementDescriptionShort { get; }
        public abstract string RequirementDescriptionLong { get; }

    }
}