using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Tiles.Furniture;
using yitangCalamity.Content.Buffs.Others;
using yitangCalamity.Global.Config;

namespace yitangCalamity.Global.GlobalItems
{
	public class ytCalamityGlobalTiles : GlobalTile
	{
		public override void RightClick(int i, int j, int type)
		{
			Player player = Main.LocalPlayer;
			Tile tile = Main.tile[i, j];

			if (ytCalamityConfig.Instance.FuckCalamityAll1)
			{
				//醉仙女的恢复蜡烛
				if (tile.TileType == ModContent.TileType<PurpleCandle>())
				{
					player.AddBuff(ModContent.BuffType<PurpleCandleBuffNew>(), 108000);
				}
			}
		}
	}
}