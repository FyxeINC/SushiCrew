using SushiCrew.Content.NPCs;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestSystem : ModSystem
    {
        public Dictionary<int, QuestData> QuestDataCollection = new Dictionary<int, QuestData>();

        /// <summary>
        /// After the world is loaded, setup the quest data.
        /// </summary>
        public override void OnWorldLoad()
        {
            base.OnWorldLoad();
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
                new List<QuestRequirementDataBase> { new QuestRequirementData_NPCKills(1, new List<int> { NPCID.BlueSlime, NPCID.GreenSlime }) },
                new List<QuestRewardDataBase> { new QuestRewardData_Item(ItemID.DirtBomb, 7) }
                );
            QuestDataCollection.TryAdd(QuestID, newQuest);            
            QuestID++;

            #endregion // Example Quests
        }

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
