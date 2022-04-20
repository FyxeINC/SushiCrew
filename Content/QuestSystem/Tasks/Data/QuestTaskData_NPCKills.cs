using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestTaskData_NPCKills : QuestTaskDataBase
    {
        public override Type TaskInstanceType => typeof(QuestTaskInstance_NPCKills);
        
        public override string TaskDescriptionShort { get => "Kill " + KillsRequired; }
        public override string TaskDescriptionLong { get => "Kill " + KillsRequired + " NPCs"; }

        public int KillsRequired = 1;
        public string GeneralizedNPCName = "NPCs";
        public List<int> NPCIDs = new List<int>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskSlug">Used for saving. Must be unique per quest.</param>
        /// <param name="killsRequired"></param>
        /// <param name="newNPCIDs">List of NPCIDs that can be killed to advance this Task.</param>
        public QuestTaskData_NPCKills(string taskSlug, int killsRequired, List<int> newNPCIDs)
        {
            TaskSlug = taskSlug;
            KillsRequired = killsRequired;
            NPCIDs = newNPCIDs;
        }
    }
}
