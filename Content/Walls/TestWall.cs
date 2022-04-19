using SushiCrew.Content.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Diagnostics;

namespace SushiCrew.Content.Walls
{
    public class TestWall : WallBase
	{
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = true;
			
			//dustType = ModContent.DustType<Sparkle>();
			ItemDrop = ModContent.ItemType<TestWallItem>();
			AddMapEntry(new Color(70, 29, 123));
		}
	}
}