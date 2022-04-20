using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestRequirementData_NPCKills : QuestRequirementDataBase
    {
        public override Type RequirementInstanceType => typeof(QuestRequirementInstance_NPCKills);
        
        public override string RequirementDescriptionShort { get => "Kill " + KillsRequired; }
        public override string RequirementDescriptionLong { get => "Kill " + KillsRequired + " NPCs"; }

        public int KillsRequired = 1;
        public string GeneralizedNPCName = "NPCs";
        public List<int> NPCIDs = new List<int>();

        public QuestRequirementData_NPCKills(string requirementSlug, int killsRequired, List<int> newNPCIDs)
        {
            RequirementSlug = requirementSlug;
            KillsRequired = killsRequired;
            NPCIDs = newNPCIDs;
        }
    }
}
