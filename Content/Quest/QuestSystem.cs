using SushiCrew.Content.NPCs;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SushiCrew.Content.Quest
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

            // This is a blank quest, used to showcase everything possible with the current quest system.
            newQuest = new QuestData(
                QuestID.Example_00_Blank,                      // QuestID, needs to be unique for every quest. Found in QuestID.cs
                "Quest 1",                                  // QuestName, does not need to be unique
                "Quest 1 Description",                      // Quest description
                new List<int>                               // (Unimplemented) Quest giver, determines who can give it out (Must be sushi NPC). An empty list means any sushi NPC
                {
                    ModContent.NPCType<NPC_Ashlyn>()
                },
                new List<int>                               // (Unimplemented) Quest reciever, determines who can complete it (Must be sushi NPC). An empty list means any sushi NPC
                {
                    ModContent.NPCType<NPC_Ashlyn>()
                },
                new List<QuestRequirementDataBase>          // Requirements for this quest to be available
                {
                    //new QuestRequirementData_CompletedQuests(new List<QuestID> { QuestID.Example_01_Kill })               // Given quests must be completed before this one can start
                    //new QuestRequirementData_NotCompletedQuests(new List<QuestID> { QuestID.Example_01_Kill })            // Given quests cannot be completed or active before this one can start
                },
                new List<QuestTaskDataBase>                 // List of Tasks. Kill X NPCs, talk to X, etc.
                {
                    //new QuestTaskData_NPCKills("Kill1Slime", 1, new List<int> { NPCID.BlueSlime, NPCID.GreenSlime })      // Kill X amount of NPCs
                    //new QuestTaskData_AcquireItem("Acquire10Gel", 10, new List<int> { ItemID.Gel })                       // Acquire X amount of items
                    //new QuestTaskData_NPCChat("TalkToNPC", NPCID.Merchant / ModContent.NPCType<NPC_Ashlyn>())             // Right click on an NPC and talk with them
                },
                new List<QuestRewardDataBase>               // List of rewards. Give X items, etc.
                {
                    //new QuestRewardData_RemoveItem(ItemID.Gel, 10, 10)                                                    // Removes x item from players inventory (useful for AcquireItem tasks)
                    //new QuestRewardData_GiveItem(ItemID.DirtBomb, 3, 8)                                                   // Gives the player min-max of said item
                }
                );  // Quest data end
            QuestDataCollection.TryAdd(newQuest.QuestID, newQuest);  // Add the quest to the collection, allows it to be used by the system            

            // Kill 5 slimes
            newQuest = new QuestData(
                QuestID.Example_01_Kill, 
                "Kill 20 Slimes",
                "Kill 20 Slimes from the overworld.",
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
                    //new QuestRequirementData_NotCompletedQuests(new List<QuestID> { QuestID.Example_01_Kill })  // Used to not let this quest be repeatable
                },
                new List<QuestTaskDataBase>
                {
                    new QuestTaskData_NPCKills("Kill20Slimes", 20, new List<int> { NPCID.BlueSlime, NPCID.GreenSlime }),
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
                    new QuestTaskData_AcquireItem("Acquire10Gel", 10, new List<int> { ItemID.Gel }),
                    new QuestTaskData_NPCChat("TalkToMerchant", NPCID.Merchant), 
                    new QuestTaskData_NPCChat("TalkToAsh", ModContent.NPCType<NPC_Ashlyn>())
                },
                new List<QuestRewardDataBase>
                {
                    new QuestRewardData_RemoveItem(ItemID.Gel, 10, 10),
                    new QuestRewardData_GiveItem(ItemID.DirtBomb, 3, 8)
                }
                );
            QuestDataCollection.TryAdd(newQuest.QuestID, newQuest);

            // Chat
            newQuest = new QuestData(
                QuestID.Example_03_Chat,
                "Chat with NPCs",
                "Chat with the Merchant and Ashlyn",
                new List<int>
                {
                    ModContent.NPCType<NPC_Austin>()
                },
                new List<int>
                {
                    ModContent.NPCType<NPC_Austin>()
                },
                new List<QuestRequirementDataBase>
                {

                },
                new List<QuestTaskDataBase>
                {
                    new QuestTaskData_NPCChat("TalkToMerchant", NPCID.Merchant),
                    new QuestTaskData_NPCChat("TalkToAsh", ModContent.NPCType<NPC_Ashlyn>())
                },
                new List<QuestRewardDataBase>
                {
                    new QuestRewardData_GiveItem(ItemID.DirtBomb, 3, 8)
                }
                );
            QuestDataCollection.TryAdd(newQuest.QuestID, newQuest);

            #endregion // Example Quests
        }

        //public override void OnWorldLoad()
        //{
        //    base.OnWorldLoad();
        // Was perviously used to setup quest data, however Player.Load was called after, causing issues 
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

        public List<QuestID> GetQuestIDsGiveForNPC(NPC npc)
        {
            List<QuestID> toReturn = new List<QuestID> ();
            foreach (KeyValuePair<QuestID, QuestData> i in QuestDataCollection)
            {
                if (i.Value.QuestGiverNPCIDCollection.Contains(npc.type) || i.Value.QuestGiverNPCIDCollection.Count <= 0)
                {
                    toReturn.Add(i.Key);
                }
            }
            return toReturn;
        }

        public List<QuestID> GetQuestIDsRecieveForNPC(NPC npc)
        {
            List<QuestID> toReturn = new List<QuestID>();
            foreach (KeyValuePair<QuestID, QuestData> i in QuestDataCollection)
            {
                if (i.Value.QuestRewardGiverNPCIDCollection.Contains(npc.type) || i.Value.QuestGiverNPCIDCollection.Count <= 0)
                {
                    toReturn.Add(i.Key);
                }
            }
            return toReturn;
        }
    }
}
