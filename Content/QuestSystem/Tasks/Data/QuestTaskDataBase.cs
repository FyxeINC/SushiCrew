using Terraria;
using Terraria.ModLoader;

namespace SushiCrew.Content.QuestSystem
{
    public abstract class QuestTaskDataBase
    {
        public abstract System.Type TaskInstanceType { get; }

        public string TaskSlug { get; set; }
        public abstract string TaskDescriptionShort { get; }
        public abstract string TaskDescriptionLong { get; }

    }
}
