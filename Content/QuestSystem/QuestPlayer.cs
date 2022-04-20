using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SushiCrew.Content.QuestSystem
{
    // ModContent.GetInstance<QuestSystem>();
    
    public class QuestPlayer : ModPlayer
    {        
        public Dictionary<int, QuestInstance> ActiveQuestCollection = new Dictionary<int, QuestInstance>();
        public List<int> CompletedQuestCollection = new List<int>();

        public int[] GetActiveQuestIDs()
        {
            int[] toReturn = new int[ActiveQuestCollection.Count];
            int index = 0;
            foreach (var i in ActiveQuestCollection)
            {
                toReturn[index] = i.Key;
                index++;
            }
            return toReturn;
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
            foreach (KeyValuePair<int, QuestInstance> i in ActiveQuestCollection)
            {
                foreach (QuestRequirementInstanceBase j in i.Value.RequirmentInstanceCollection)
                {
                    j.OnPlayerKilledNPC(npcKilled, this);
                }
            }
        }               

        //public void OnItemPickup(Item item)
        //{

        //}       

        public QuestState GetQuestState(int questID)
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

        public bool AttemptRecieveQuest(int questID)
        {
            if (!CanRecieveQuest(questID))
            {
                return false;
            }

            return DoRecieveQuest(questID);
        }

        public bool CanRecieveQuest(int questID)
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

            if (CompletedQuestCollection.Contains(questID))
            {
                return false;
            }
            return true;
        }

        bool DoRecieveQuest(int questID)
        {
            QuestSystem questSystem = ModContent.GetInstance<QuestSystem>();
            if (questSystem == null)
            {
                return false;
            }

            QuestInstance newQuestInstance = questSystem.GetInstanceForQuestID(questID);
            ActiveQuestCollection.Add(newQuestInstance.CurrentData.QuestID, newQuestInstance);

            Main.NewText("Quest Added. ID:" + questID);

            return true;
        }
        
        public bool AttemptCompleteQuest(int questID)
        {
            if (!CanCompleteQuest(questID))
            {
                return false;
            }

            return DoCompleteQuest(questID);
        }

        public bool CanCompleteQuest(int questID)
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

        public bool DoCompleteQuest(int questID)
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

        public override void SaveData(TagCompound tag)
        {
            tag.Add("CompletedQuestCollection", CompletedQuestCollection);
        }
        
        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("CompletedQuestCollection"))
            {
                CompletedQuestCollection = (List<int>)tag.GetList<int>("CompletedQuestCollection");
            }
        }
    }
}
