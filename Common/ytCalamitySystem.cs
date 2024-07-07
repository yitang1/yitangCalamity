using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;

namespace yitangCalamity.Common
{
	public class ytCalamitySystem : ModSystem
	{
		public override void Load()
		{
			On_ChatManager.ParseMessage += Translate;
		}
		public override void Unload()
		{
			On_ChatManager.ParseMessage -= Translate;
		}

		private static List<TextSnippet> Translate(On_ChatManager.orig_ParseMessage orig, string text, Color baseColor)
		{
			text = Regex.Replace(text, "Lunar Event", "月亮事件");
			text = Regex.Replace(text, "Recipe added by ", "配方来自 ");
			return orig.Invoke(text, baseColor);
		}
	}
}