using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.Quest
{
    public abstract class QuestRequirementDataBase
    {
        public abstract bool DoesPlayerMeetRequirements(QuestPlayer player);
    }
}
