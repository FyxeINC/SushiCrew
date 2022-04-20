using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SushiCrew.Content.Quest
{
    public class QuestRewardData_RemoveItem : QuestRewardDataBase
    {
        public int RemoveItemID = ItemID.DirtBlock;

        public int RemoveItemAmountMin = 1;
        public int RemoveItemAmountMax = 1;

        public QuestRewardData_RemoveItem(int removeItemID, int removeItemAmountMin, int removeItemAmountMax)
        {
            RemoveItemID = removeItemID;

            RemoveItemAmountMin = removeItemAmountMin;
            RemoveItemAmountMax = removeItemAmountMax;
        }

        public override string RewardDescriptionShort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string RewardDescriptionLong { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void GrantRewards(Player player)
        {
            int amountToRemove = Main.rand.Next(RemoveItemAmountMin, RemoveItemAmountMax);

            for (int i = 0; i < player.inventory.Length - 1; i++)   // Can subtract 9 from length to prevent ammo and coins
            {
                if (player.inventory[i].type == RemoveItemID)
                {
                    int amountRemoved = 0;
                    if (player.inventory[i].stack - amountToRemove <= 0)
                    {
                        amountRemoved = player.inventory[i].stack;
                        player.inventory[i].TurnToAir();
                    }
                    else
                    {
                        amountRemoved = amountToRemove;
                        player.inventory[i].stack -= amountToRemove;
                    }
                    amountToRemove -= amountRemoved;

                    if (amountToRemove <= 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
