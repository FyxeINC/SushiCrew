using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestRewardData_GiveItem : QuestRewardDataBase
    {
        public int RewardItemID = ItemID.DirtBlock;

        public int RewardItemAmountMin = 1;
        public int RewardItemAmountMax = 1;

        public QuestRewardData_GiveItem(int rewardItemID, int rewardItemAmountMin, int rewardItemAmountMax)
        {
            RewardItemID = rewardItemID;

            RewardItemAmountMin = rewardItemAmountMin;
            RewardItemAmountMax = rewardItemAmountMax;
        }

        public override string RewardDescriptionShort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string RewardDescriptionLong { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void GrantRewards(Player player)
        {
            int amountToGive = Main.rand.Next(RewardItemAmountMin, RewardItemAmountMax);
            player.QuickSpawnItem(player.GetItemSource_Misc(ItemSourceID.None), RewardItemID, amountToGive);
        }
    }
}
