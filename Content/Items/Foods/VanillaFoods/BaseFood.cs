using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.CN.CalamityCN.Utils;

namespace yitangCalamity.Content.Items.Foods.VanillaFoods
{
	public abstract class BaseFood : ModItem
	{
		public abstract Color NameColor { get; }

		public override void SetDefaults()
		{
			Item.maxStack = 1;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.consumable = false;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine nameLine = tooltips.FirstOrDefault(x => x.Name == "ItemName" && x.Mod == "Terraria");
			if (nameLine != null)
			{
				nameLine.OverrideColor = NameColor;
			}

			tooltips.ReplaceText("[Consumed]", "[c/5ea45e:使用次数：0/1]");

		}
	}
}