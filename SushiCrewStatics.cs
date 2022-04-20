using SushiCrew.Content.QuestSystem;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace SushiCrew
{
	public static class SushiCrewStatic 
	{
		public static List<int> ToInt(this List<QuestID> questIDList)
        {
			List<int> toReturn = new List<int>();
            foreach (var i in questIDList)
            {
				toReturn.Add((int)i);
            }
			return toReturn;
        }
		public static List<QuestID> ToQuestID(this List<int> intList)
		{
			List<QuestID> toReturn = new List<QuestID>();
			foreach (var i in intList)
			{
				toReturn.Add((QuestID)i);
			}
			return toReturn;
		}
	}
}