using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SushiCrew.Content.Quest
{
    public class QuestTaskInstance_NPCChat : QuestTaskInstanceBase
    {
        public QuestTaskData_NPCChat CurrentData_NPCChat => CurrentData as QuestTaskData_NPCChat;

        public override string DisplayString
        {
            get
            {
                return "Talk to " + Lang.GetNPCNameValue(CurrentData_NPCChat.NPCID);
            }
        }

        public bool DidChat = false;

        public override float EvaluateCompletionPercentage(QuestPlayer questPlayer)
        {
            if (DidChat)
            {
                return 1f;
            }
            else
            {
                return 0f;
            }
        }

        public override void OnPlayerChatNPC(QuestPlayer player, NPC npcChatWith)
        {
            base.OnPlayerChatNPC(player, npcChatWith);
            if (npcChatWith.type == CurrentData_NPCChat.NPCID)
            {
                DidChat = true;
            }

            if (DidChat)
            {
                CurrentQuestState = QuestState.pendingCompleted;
            }
        }

        public override void SaveData(QuestInstance questInstance, TagCompound tag)
        {
            string slug = questInstance.CurrentData.QuestID + "." + CurrentData.TaskSlug;
            tag.Add(slug, DidChat);
        }

        public override void LoadData(QuestInstance questInstance, TagCompound tag)
        {
            string slug = questInstance.CurrentData.QuestID + "." + CurrentData.TaskSlug;
            if (tag.ContainsKey(slug))
            {
                DidChat = tag.GetBool(slug);
            }

            if (DidChat)
            {
                CurrentQuestState = QuestState.pendingCompleted;
            }
        }
    }
}
