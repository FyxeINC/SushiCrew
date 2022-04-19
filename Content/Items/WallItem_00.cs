using Terraria;
using SushiCrew.Content.Walls;
using Terraria.ID;
using Terraria.ModLoader;

namespace SushiCrew.Content.Items
{
	public class WallItem_00 : ItemBase
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purple Flower Wall"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Purple Flower Wall");
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 10;//15;
			Item.useTime = 15;//7;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createWall = ModContent.WallType<Wall_00>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock,1);//PurplePaint
			//recipe.AddIngredient(ItemID.FancyGreyWallpaper, 1);//FancyGreyWallpaper
			recipe.ReplaceResult(this,4);
			recipe.Register();
		}
	}
}