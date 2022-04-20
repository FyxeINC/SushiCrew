using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestTaskData_NPCChat : QuestTaskDataBase
    {
        public override Type TaskInstanceType => typeof(QuestTaskInstance_NPCChat);
        
        public override string TaskDescriptionShort { get => "Talk to " + Lang.GetNPCNameValue(NPCID); }
        public override string TaskDescriptionLong { get => "Talk to " + Lang.GetNPCNameValue(NPCID); }

        public int NPCID;

        public QuestTaskData_NPCChat(string taskSlug, int npcID)
        {
            TaskSlug = taskSlug;
            NPCID = npcID;
        }
    }
}
