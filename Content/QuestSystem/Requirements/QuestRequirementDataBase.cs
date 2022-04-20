using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public abstract class QuestRequirementDataBase
    {
        public abstract bool DoesMeetRequirements(QuestPlayer player);
    }
}
