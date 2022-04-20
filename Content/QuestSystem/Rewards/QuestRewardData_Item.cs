using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestRewardData_Item : QuestRewardDataBase
    {
        public int RewardItemID = ItemID.DirtBlock;
        public int RewardItemAmount = 1;

        public QuestRewardData_Item(int rewardItemID, int rewardItemAmount)
        {
            RewardItemID = rewardItemID;
            RewardItemAmount = rewardItemAmount;
        }

        public override string RewardDescriptionShort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string RewardDescriptionLong { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void GrantRewards(Player player)
        {            
            player.QuickSpawnItem(player.GetItemSource_Misc(ItemSourceID.None), RewardItemID, RewardItemAmount);
        }
    }
}
