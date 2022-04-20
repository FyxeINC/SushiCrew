﻿using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public abstract class QuestRewardDataBase
    {
        public abstract string RewardDescriptionShort { get; set; }
        public abstract string RewardDescriptionLong { get; set; }

        public abstract void GrantRewards(Player player);
    }
}
