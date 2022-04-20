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


            #region 100-200 : Example Quests
            QuestID = 100;  // Specify starting point for all quests in this region            

            // This is a blank quest, used for designers to understand how to create one
            newQuest = new QuestData(
                QuestID,                                    // QuestID, needs to be unique for every quest
                "Quest 1",                                  // QuestName, does not need to be unique
                "Quest 1 Description",                      // Quest description
                new List<int>                               // (Unimplemented) Quest giver, determines who can give it out. "-1" is any sushi NPC
                {
                    ModContent.NPCType<NPC_Ashlyn>()
                },
                new List<int>                               // (Unimplemented) Quest reciever, determines who can complete it. "-1" is any sushi NPC
                {
                    ModContent.NPCType<NPC_Ashlyn>()
                },
                new List<QuestRequirementDataBase>          // Requirements for this quest to be available
                {

                },
                new List<QuestTaskDataBase>                 // List of Tasks. Kill X NPCs, talk to X, etc.
                {
                
                },
                new List<QuestRewardDataBase>               // List of rewards. Give X items, etc.
                {
                
                }
                );
            QuestDataCollection.TryAdd(QuestID, newQuest);  // Add the quest to the collection, allows it to be used by the system
            QuestID++;                                      // Increments the questID for the next quest

            // Kill 5 slimes
            newQuest = new QuestData(
                QuestID, 
                "Kill 5 Slimes",
                "Kill 5 Slimes from the overworld.",
                new List<int> 
                {
                    ModContent.NPCType<NPC_Ashlyn>()
                }, 
                new List<int>
                {
                    ModContent.NPCType<NPC_Ashlyn>()
                },
                new List<QuestRequirementDataBase>
                {

                },
                new List<QuestTaskDataBase>
                {
                    new QuestTaskData_NPCKills("Kill5Slimes", 5, new List<int> { NPCID.BlueSlime, NPCID.GreenSlime }),
                    new QuestTaskData_NPCKills("Kill3Slimes", 3, new List<int> { NPCID.BlueSlime, NPCID.GreenSlime })
                },
                new List<QuestRewardDataBase> 
                { 
                    new QuestRewardData_Item(ItemID.DirtBomb, 3, 8) 
                }
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

        //public List<int> GetQuestIDsForNPC(int npcIDToGetFor)
        //{
        //    List<int> toReturn = new List<int>();

        //    foreach (KeyValuePair<int, QuestData> i in QuestDataCollection)
        //    {
        //        if (i.Value.QuestGiverNPCIDCollection == npcIDToGetFor)
        //        {
        //            toReturn.Add(i.Key);
        //        }
        //    }

        //    return toReturn;
        //}

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
