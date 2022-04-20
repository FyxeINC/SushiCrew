using SushiCrew.Content.NPCs;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestSystem : ModSystem
    {
        public Dictionary<int, QuestData> QuestDataCollection = new Dictionary<int, QuestData>();

        //public override void OnModLoad()
        //{
        //    base.OnModLoad();
        //}

        //public override void Load()
        //{
        //    base.Load();
        //}

        //public override void LoadWorldData(TagCompound tag)
        //{
        //    base.LoadWorldData(tag);
        //}

        public override void PostSetupContent()
        {
            base.PostSetupContent();

            QuestDataCollection.Clear();

            int QuestID = 0;
            QuestData newQuest;


            #region 100 - Example Quests
            QuestID = 100;  // Specify starting point for all quests in this region            

            // Basic Go-To NPC quest
            newQuest = new QuestData(
                QuestID,
                "Quest 1",
                "Quest 1 Description",
                ModContent.NPCType<NPC_Ashlyn>(),
                ModContent.NPCType<NPC_Austin>(),
                new List<QuestRequirementDataBase> { },
                new List<QuestRewardDataBase> { }
                );
            QuestDataCollection.TryAdd(QuestID, newQuest);
            QuestID++;

            // Kill 5 slimes
            newQuest = new QuestData(
                QuestID,
                "Kill 5 Slimes",
                "Kill 5 Slimes from the overworld.",
                ModContent.NPCType<NPC_Ashlyn>(),
                ModContent.NPCType<NPC_Ashlyn>(),
                new List<QuestRequirementDataBase>
                {
                    new QuestRequirementData_NPCKills("Kill5Slimes", 5, new List<int> { NPCID.BlueSlime, NPCID.GreenSlime }),
                    new QuestRequirementData_NPCKills("Kill3Slimes", 3, new List<int> { NPCID.BlueSlime, NPCID.GreenSlime })
                },
                new List<QuestRewardDataBase> { new QuestRewardData_Item(ItemID.DirtBomb, 7) }
                );
            QuestDataCollection.TryAdd(QuestID, newQuest);
            QuestID++;

            #endregion // Example Quests
        }
       
        //public override void OnWorldLoad()
        //{
        //    base.OnWorldLoad();
        // Was perviously used to setup quest data, however player load was called after, causing issues 
        //}

        public List<int> GetQuestIDsForNPC(int npcIDToGetFor)
        {
            List<int> toReturn = new List<int>();

            foreach (KeyValuePair<int, QuestData> i in QuestDataCollection)
            {
                if (i.Value.QuestGiverNPCID == npcIDToGetFor)
                {
                    toReturn.Add(i.Key);
                }
            }

            return toReturn;
        }

        public QuestInstance GetInstanceForQuestID(int questID)
        {
            if (!QuestDataCollection.ContainsKey(questID))
            {
                return null;
            }

            QuestInstance newQuestInstance = new QuestInstance(QuestDataCollection[questID]);
            return newQuestInstance;
        }
    }
}
