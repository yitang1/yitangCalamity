using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Events;

namespace yitangCalamity.Content.Items.SummonItems
{
	public class WorldControlUnit : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.rare = ItemRarityID.Pink;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item4;
			Item.consumable = false;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override bool ConsumeItem(Player player)
		{
			return false;
		}

		public override void RightClick(Player player)
		{
			if (player.ZoneDesert)
			{
				if (Sandstorm.Happening)
				{
					Main.NewText(Language.GetTextValue("沙尘暴已停止。"), 255, 255, 255);
					Sandstorm.Happening = false;
					Sandstorm.TimeLeft = 0;
					Sandstorm.IntendedSeverity = !Sandstorm.Happening ? Main.rand.Next(3) != 0 ? Main.rand.NextFloat() * 0.3f : 0.0f : 0.4f + Main.rand.NextFloat();
					return;
				}
				if (!Sandstorm.Happening)
				{
					Main.NewText(Language.GetTextValue("沙尘暴已开始。"), 255, 255, 255);
					Sandstorm.Happening = true;
					Sandstorm.TimeLeft = 36000;
					Sandstorm.IntendedSeverity = !Sandstorm.Happening ? Main.rand.Next(3) != 0 ? Main.rand.NextFloat() * 0.3f : 0.0f : 0.4f + Main.rand.NextFloat();
					return;
				}
			}
			if (Main.raining)
			{
				Main.NewText(Language.GetTextValue("停止下雨。"), 255, 255, 255);
				Main.rainTime = 0;
				Main.maxRaining = 0f;
				Main.raining = false;
				return;
			}
			if (!Main.raining)
			{
				Main.NewText(Language.GetTextValue("开始下雨。"), 255, 255, 255);
				Main.rainTime = 24000;
				Main.maxRaining = 1f;
				Main.raining = true;
				return;
			}
		}

		public override bool? UseItem(Player player)
		{
			if (Main.dayTime)
			{
				Main.NewText(Language.GetTextValue("时间已调整为夜晚。"), 255, 255, 255);
				Main.dayTime = false;
				Main.time = 0.0;
				return true;
			}
			if (!Main.dayTime)
			{
				Main.NewText(Language.GetTextValue("时间已调整为早上。"), 255, 255, 255);
				Main.dayTime = true;
				Main.time = 0.0;
				return true;
			}
			return true;
		}
	}
}