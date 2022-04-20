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
        public Dictionary<QuestID, QuestData> QuestDataCollection = new Dictionary<QuestID, QuestData>();

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

            QuestData newQuest;


            #region Example Quests       

            // This is a blank quest, used for designers to understand how to create one
            newQuest = new QuestData(
                QuestID.Example_00_Blank,                      // QuestID, needs to be unique for every quest. Found in QuestID.cs
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
                );  // Quest data end
            QuestDataCollection.TryAdd(newQuest.QuestID, newQuest);  // Add the quest to the collection, allows it to be used by the system            

            // Kill 5 slimes
            newQuest = new QuestData(
                QuestID.Example_01_Kill, 
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
                    new QuestRequirementData_NotCompletedQuests(new List<QuestID> { QuestID.Example_01_Kill })  // Used to not let this quest be repeatable
                },
                new List<QuestTaskDataBase>
                {
                    new QuestTaskData_NPCKills("Kill5Slimes", 5, new List<int> { NPCID.BlueSlime, NPCID.GreenSlime }),
                    new QuestTaskData_NPCKills("Kill3Slimes", 3, new List<int> { NPCID.BlueSlime, NPCID.GreenSlime })
                },
                new List<QuestRewardDataBase> 
                { 
                    new QuestRewardData_GiveItem(ItemID.DirtBomb, 3, 8) 
                }
                );
            QuestDataCollection.TryAdd(newQuest.QuestID, newQuest);

            // Acquire 10 gel
            newQuest = new QuestData(
                QuestID.Example_02_Acquire,
                "Acquire 10 gel",
                "Acquire 10 blue gel.",
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
                    new QuestTaskData_AcquireItem("Acquire10Gel", 10, new List<int> { ItemID.Gel })
                },
                new List<QuestRewardDataBase>
                {
                    new QuestRewardData_RemoveItem(ItemID.Gel, 10, 10),
                    new QuestRewardData_GiveItem(ItemID.DirtBomb, 3, 8)
                }
                );
            QuestDataCollection.TryAdd(newQuest.QuestID, newQuest);

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

        public QuestInstance GetInstanceForQuestID(QuestID questID)
        {
            if (!QuestDataCollection.ContainsKey(questID))
            {
                return null;
            }

            QuestInstance newQuestInstance = new QuestInstance(QuestDataCollection[questID]);
            return newQuestInstance;
        }

        public bool DoesPlayerMeetRequirementsForQuest(QuestPlayer player, QuestID questID)
        {
            if (!QuestDataCollection.ContainsKey(questID))
            {
                return false;
            }

            QuestData questData = QuestDataCollection[questID];

            foreach (QuestRequirementDataBase i in questData.RequirementCollection)
            {
                if (!i.DoesPlayerMeetRequirements(player))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
