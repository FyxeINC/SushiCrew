﻿using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestRequirementData_NPCKills : QuestRequirementDataBase
    {
        public override Type RequirementInstanceType => typeof(QuestRequirementInstance_NPCKills);
        public override string RequirementDescriptionShort { get => ""; }
        public override string RequirementDescriptionLong { get => ""; }

        public int KillsRequired = 1;
        public List<int> NPCIDs = new List<int>();

        public QuestRequirementData_NPCKills(int killsRequired, List<int> newNPCIDs)
        {
            KillsRequired = killsRequired;
            NPCIDs = newNPCIDs;
        }
    }
}