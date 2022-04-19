using SushiCrew.Content.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Diagnostics;

namespace SushiCrew.Content.Walls
{
    public class Window_Test : WallBase
	{
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = true;
			
			//dustType = ModContent.DustType<Sparkle>();
			ItemDrop = ModContent.ItemType<WindowItem_Test>();
			AddMapEntry(new Color(70, 29, 123));
		}
	}
}