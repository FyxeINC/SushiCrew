using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SushiCrew.Content.QuestSystem
{
    // ModContent.GetInstance<QuestSystem>();
    
    public class QuestPlayer : ModPlayer
    {
        const string SaveData_Quests_Completed = "CompletedQuestCollection";
        const string SaveData_Quests_Active = "ActiveQuestIDCollection";

        public Dictionary<QuestID, QuestInstance> ActiveQuestCollection = new Dictionary<QuestID, QuestInstance>();
        public List<QuestID> CompletedQuestCollection = new List<QuestID>();

        internal static Item[] previousInventoryItems;

        public override void Initialize()
        {
            base.Initialize();
            ActiveQuestCollection = new Dictionary<QuestID, QuestInstance>();
            CompletedQuestCollection = new List<QuestID>();

            previousInventoryItems = new Item[this.Player.inventory.Length];
            SetPreviousInventory();
        }

        public override void PostUpdate()
        {
            if (ItemChanged())
            {
                foreach (KeyValuePair<QuestID, QuestInstance> i in ActiveQuestCollection)
                {
                    foreach (QuestTaskInstanceBase j in i.Value.TaskInstanceCollection)
                    {
                        j.OnPlayerInventoryChanged(this);
                    }
                }
                SetPreviousInventory();
            }
        }

        bool ItemChanged()
        {   
            if (this.Player == null)
            {
                return false;
            }
            else if (this.Player.inventory == null)
            {
                return false;
            }

            for (int i = 0; i < this.Player.inventory.Length - 1; i++)
            {
                if (this.Player.inventory[i] == null && previousInventoryItems[i] != null)
                {
                    return true;
                }
                if (this.Player.inventory[i] != null && previousInventoryItems[i] == null)
                {
                    return true;
                }
                if (this.Player.inventory[i] != null && previousInventoryItems[i] != null)
                {
                    if (this.Player.inventory[i].IsNotSameTypePrefixAndStack(previousInventoryItems[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        void SetPreviousInventory()
        {            
            for (int i = 0; i < this.Player.inventory.Length; i++)
            {
                if (this.Player.inventory[i] == null)
                {
                    previousInventoryItems[i] = null;
                }
                else
                {
                    previousInventoryItems[i] = this.Player.inventory[i].Clone();
                }
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(item, target, damage, knockback, crit);
            if (target.life - damage <= 0)
            {
                OnNPCKilled(target);
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPCWithProj(proj, target, damage, knockback, crit);
            if (target.life - damage <= 0)
            {
                OnNPCKilled(target);
            }
        }

        void OnNPCKilled(NPC npcKilled)
        {
            foreach (KeyValuePair<QuestID, QuestInstance> i in ActiveQuestCollection)
            {
                foreach (QuestTaskInstanceBase j in i.Value.TaskInstanceCollection)
                {
                    j.OnPlayerKilledNPC(npcKilled, this);
                }
            }
        }               

        //public void OnItemPickup(Item item)
        //{

        //}       

        public QuestState GetQuestState(QuestID questID)
        {
            if (CompletedQuestCollection.Contains(questID))
            {
                return QuestState.completed;
            }

            if (ActiveQuestCollection.ContainsKey(questID))
            {
                return ActiveQuestCollection[questID].CurrentQuestState;
            }

            return QuestState.notAcquired;
        }

        public bool AttemptRecieveQuest(QuestID questID)
        {
            if (!CanRecieveQuest(questID))
            {
                return false;
            }

            return DoRecieveQuest(questID);
        }

        public bool CanRecieveQuest(QuestID questID)
        {
            QuestSystem questSystem = ModContent.GetInstance<QuestSystem>();
            if (questSystem == null)
            {
                return false;
            }

            if (ActiveQuestCollection.ContainsKey(questID))
            {
                return false;
            }

            if (!questSystem.DoesPlayerMeetRequirementsForQuest(this, questID))
            {
                return false;
            }

            return true;
        }

        bool DoRecieveQuest(QuestID questID)
        {
            QuestSystem questSystem = ModContent.GetInstance<QuestSystem>();
            if (questSystem == null)
            {
                return false;
            }

            QuestInstance newQuestInstance = questSystem.GetInstanceForQuestID(questID);
            ActiveQuestCollection.Add(newQuestInstance.CurrentData.QuestID, newQuestInstance);

            Main.NewText("Quest Added. ID:" + questID);

            // Force an inventory update 
            foreach (KeyValuePair<QuestID, QuestInstance> i in ActiveQuestCollection)
            {
                foreach (QuestTaskInstanceBase j in i.Value.TaskInstanceCollection)
                {
                    j.OnPlayerInventoryChanged(this);
                }
            }

            return true;
        }
        
        public bool AttemptCompleteQuest(QuestID questID)
        {
            if (!CanCompleteQuest(questID))
            {
                return false;
            }

            return DoCompleteQuest(questID);
        }

        public bool CanCompleteQuest(QuestID questID)
        {
            QuestSystem questSystem = ModContent.GetInstance<QuestSystem>();
            if (questSystem == null)
            {
                return false;
            }

            if (!ActiveQuestCollection.ContainsKey(questID))
            {
                return false;
            }

            QuestInstance questInstance = ActiveQuestCollection[questID];
            if (questInstance.CurrentQuestState != QuestState.pendingCompleted)
            {
                return false;
            }


            return true;
        }

        public bool DoCompleteQuest(QuestID questID)
        {
            QuestSystem questSystem = ModContent.GetInstance<QuestSystem>();
            if (questSystem == null)
            {
                return false;
            }
            
            if (!ActiveQuestCollection.ContainsKey(questID))
            {
                return false;
            }

            QuestInstance questInstance = ActiveQuestCollection[questID];            

            foreach (var i in questInstance.CurrentData.RewardCollection)
            {
                i.GrantRewards(this.Player);
            }

            ActiveQuestCollection.Remove(questID);

            if (!CompletedQuestCollection.Contains(questID))
            {
                CompletedQuestCollection.Add(questID);
            }
            return true;
        }

        public override void OnEnterWorld(Player player)
        {
            base.OnEnterWorld(player);
            Main.NewText("Completed:" + CompletedQuestCollection.Count);
            Main.NewText("Active:" + ActiveQuestCollection.Count);
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add(SaveData_Quests_Completed, CompletedQuestCollection.ToInt());

            List<QuestID> activeQuests = ActiveQuestCollection.Keys.ToList();
            tag.Set(SaveData_Quests_Active, activeQuests.ToInt());
            foreach (KeyValuePair<QuestID, QuestInstance> i in ActiveQuestCollection)
            {
                foreach (var j in i.Value.TaskInstanceCollection)
                {
                    j.SaveData(i.Value, tag);
                }
            }
        }
        
        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey(SaveData_Quests_Completed))
            {
                CompletedQuestCollection = ((List<int>)tag.GetList<int>(SaveData_Quests_Completed)).ToQuestID();
            }

            if (tag.ContainsKey(SaveData_Quests_Active))
            {
                List<QuestID> activeQuests = ((List<int>)tag.GetList<int>(SaveData_Quests_Active)).ToQuestID();
                foreach (QuestID i in activeQuests)
                {
                    if (!DoRecieveQuest(i))
                    {
                        // TODO - #ERROR
                    }
                    else
                    {                        
                        foreach (KeyValuePair<QuestID, QuestInstance> j in ActiveQuestCollection)
                        {
                            foreach (QuestTaskInstanceBase k in j.Value.TaskInstanceCollection)
                            {
                                k.LoadData(j.Value, tag);
                            }
                        }
                    }
                }
            }
        }
    }
}
