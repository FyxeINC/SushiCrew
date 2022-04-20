using SushiCrew.Content.NPCs;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SushiCrew.Content.QuestSystem
{
    public class QuestGlobalNPC : GlobalNPC
    {
        public override void GetChat(NPC npc, ref string chat)
        {
            base.GetChat(npc, ref chat);

            Main.LocalPlayer.GetModPlayer<QuestPlayer>().OnChatNPC(npc);
        }
    }
}
