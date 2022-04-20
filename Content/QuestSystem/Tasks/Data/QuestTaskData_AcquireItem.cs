using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestTaskData_AcquireItem : QuestTaskDataBase
    {
        public override Type TaskInstanceType => typeof(QuestTaskInstance_AcquireItem);
        
        public override string TaskDescriptionShort { get => "Acquire " + ItemsRequired; }
        public override string TaskDescriptionLong { get => "Acquire " + ItemsRequired + " Item"; }

        public int ItemsRequired = 1;
        public string GeneralizedItemName = "Item";
        public List<int> ItemIDCollection = new List<int>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskSlug">Used for saving. Must be unique per quest.</param>
        /// <param name="killsRequired"></param>
        /// <param name="newNPCIDs">List of NPCIDs that can be killed to advance this Task.</param>
        public QuestTaskData_AcquireItem(string taskSlug, int itemsRequired, List<int> itemIDs)
        {
            TaskSlug = taskSlug;
            ItemsRequired = itemsRequired;
            ItemIDCollection = itemIDs;
        }
    }
}
