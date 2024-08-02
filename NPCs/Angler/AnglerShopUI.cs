using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Chat;
using yitangCalamity.Global.Config;

namespace yitangCalamity.NPCs.Angler
{
	internal class AnglerShopUI : UIState
	{
		private static readonly object TextDisplayCache = typeof(Main).GetField("_textDisplayCache", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(Main.instance)!;

		public override void Draw(SpriteBatch spriteBatch)
		{
			if (Main.npcChatText == string.Empty || !ytCalamityConfig.Instance.ytNPCAngler
				|| !yitangCalamity.ShouldEnableAnglerShop())
			{
				return;
			}
			base.Draw(spriteBatch);
			Vector2 scale = new Vector2(0.9f);
			Vector2 scale2 = new Vector2(0.9f);
			string text = Language.GetTextValue("LegacyInterface.28");
			string text2 = Language.GetTextValue("装饰");
			int numLines = (int)AnglerShopUI.TextDisplayCache.GetType().GetProperty("AmountOfLines", BindingFlags.Instance | BindingFlags.Public).GetValue(AnglerShopUI.TextDisplayCache);
			Vector2 stringSize = ChatManager.GetStringSize(FontAssets.MouseText.Value, text, scale, -1f);
			Vector2 stringSize2 = ChatManager.GetStringSize(FontAssets.MouseText.Value, text2, scale2, -1f);
			Vector2 value = new Vector2(1f);
			Vector2 value2 = new Vector2(1f);
			if (stringSize.X > 260f)
			{
				value.X *= 260f / stringSize.X;
			}
			if (stringSize2.X > 260f)
			{
				value2.X *= 260f / stringSize2.X;
			}
			float posButton4 = (float)(180 + (Main.screenWidth - 800) / 2) + ChatManager.GetStringSize(FontAssets.MouseText.Value, Language.GetTextValue("LegacyInterface.64"), scale, -1f).X + 30f + ChatManager.GetStringSize(FontAssets.MouseText.Value, Language.GetTextValue("LegacyInterface.52"), scale, -1f).X + 30f + ChatManager.GetStringSize(FontAssets.MouseText.Value, Language.GetTextValue("UI.NPCCheckHappiness"), scale, -1f).X + 30f;
			float posButton5 = posButton4 + ChatManager.GetStringSize(FontAssets.MouseText.Value, Language.GetTextValue("LegacyInterface.28"), scale2, -1f).X + 30f;
			Vector2 position = new Vector2(posButton4, (float)(130 + numLines * 30));
			Vector2 position2 = new Vector2(posButton5, (float)(130 + numLines * 30));
			if (Main.MouseScreen.Between(position, position + stringSize * scale * value.X) && !PlayerInput.IgnoreMouseInterface)
			{
				Main.LocalPlayer.mouseInterface = true;
				Main.LocalPlayer.releaseUseItem = false;
				scale *= 1.2f;
				if (!this.shopButton1Hovered)
				{
					SoundEngine.PlaySound(SoundID.MenuTick, null, null);
				}
				this.shopButton1Hovered = true;
			}
			else
			{
				if (this.shopButton1Hovered)
				{
					SoundEngine.PlaySound(SoundID.MenuTick, null, null);
				}
				this.shopButton1Hovered = false;
			}
			if (Main.MouseScreen.Between(position2, position2 + stringSize2 * scale2 * value2.X) && !PlayerInput.IgnoreMouseInterface)
			{
				Main.LocalPlayer.mouseInterface = true;
				Main.LocalPlayer.releaseUseItem = false;
				scale2 *= 1.2f;
				if (!this.shopButton2Hovered)
				{
					SoundEngine.PlaySound(SoundID.MenuTick, null, null);
				}
				this.shopButton2Hovered = true;
			}
			else
			{
				if (this.shopButton2Hovered)
				{
					SoundEngine.PlaySound(SoundID.MenuTick, null, null);
				}
				this.shopButton2Hovered = false;
			}
			ChatManager.DrawColorCodedStringShadow(spriteBatch, FontAssets.MouseText.Value, text, position + stringSize * value * 0.5f, (!this.shopButton1Hovered) ? Color.Black : Color.Brown, 0f, stringSize * 0.5f, scale * value, -1f, 2f);
			ChatManager.DrawColorCodedString(spriteBatch, FontAssets.MouseText.Value, text, position + stringSize * value * 0.5f, (!this.shopButton1Hovered) ? new Color(228, 206, 114, (int)(Main.mouseTextColor / 2)) : new Color(255, 231, 69), 0f, stringSize * 0.5f, scale, -1f, false);
			ChatManager.DrawColorCodedStringShadow(spriteBatch, FontAssets.MouseText.Value, text2, position2 + stringSize2 * value2 * 0.5f, (!this.shopButton2Hovered) ? Color.Black : Color.Brown, 0f, stringSize2 * 0.5f, scale2 * value2, -1f, 2f);
			ChatManager.DrawColorCodedString(spriteBatch, FontAssets.MouseText.Value, text2, position2 + stringSize2 * value2 * 0.5f, (!this.shopButton2Hovered) ? new Color(228, 206, 114, (int)(Main.mouseTextColor / 2)) : new Color(255, 231, 69), 0f, stringSize2 * 0.5f, scale2, -1f, false);
		}

		public override void Update(GameTime gameTime)
		{
			if (!ytCalamityConfig.Instance.ytNPCAngler || !yitangCalamity.ShouldEnableAnglerShop())
			{
				return;
			}
			base.Update(gameTime);
			if (shopButton1Hovered && Main.mouseLeft)
			{
				OpenShop(yitangCalamity.ShopName);
			}
			else if (shopButton2Hovered && Main.mouseLeft)
			{
				OpenShop(yitangCalamity.VanityShopName);
			}
		}

		internal static void OpenShop(string name)
		{
			Main.playerInventory = true;
			Main.stackSplit = 9999;
			Main.npcChatText = "";
			Main.SetNPCShopIndex(1);
			Main.instance.shop[Main.npcShop].SetupShop(name, Main.LocalPlayer.TalkNPC);
			SoundEngine.PlaySound(SoundID.MenuTick, null, null);
		}

		private bool shopButton1Hovered;

		private bool shopButton2Hovered;
	}
}