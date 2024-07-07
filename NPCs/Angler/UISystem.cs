using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using yitangCalamity.Global.Config;

namespace yitangCalamity.NPCs.Angler
{
	internal class UISystem : ModSystem
	{
		public override void Load()
		{
			if (!ytCalamityConfig.Instance.ytNPCAngler || !yitangCalamity.ShouldEnableAnglerShop())
			{
				return;
			}
			if (!Main.dedServ)
			{
				UIState anglerShopUI = new AnglerShopUI();
				anglerShopUI.Activate();
				userInterface = new UserInterface();
				userInterface.SetState(anglerShopUI);
			}
		}

		public override void PostSetupContent()
		{
			if (!ytCalamityConfig.Instance.ytNPCAngler || !yitangCalamity.ShouldEnableAnglerShop())
			{
				return;
			}
			if (ModLoader.TryGetMod("DialogueTweak", out Mod dialogueTweak))
			{
				dialogueTweakLoaded = true;
				dialogueTweak.Call("AddButton",
					NPCID.Angler,
					() => Language.GetTextValue("LegacyInterface.28"),
					"DialogueTweak/Interfaces/Assets/Icon_Default",
					() =>
					{
						if (Main.mouseLeft && Main.mouseLeftRelease)
							AnglerShopUI.OpenShop(yitangCalamity.ShopName);
					}
				);
				dialogueTweak.Call("AddButton",
					NPCID.Angler,
					() => Language.GetTextValue("GameUI.PainterDecor"),
					"DialogueTweak/Interfaces/Assets/Icon_Default",
					() =>
					{
						if (Main.mouseLeft && Main.mouseLeftRelease)
							AnglerShopUI.OpenShop(yitangCalamity.VanityShopName);
					}
				);
			}
		}

		private GameTime lastUpdateUiGameTime;
		public override void UpdateUI(GameTime gameTime)
		{
			if (!ytCalamityConfig.Instance.ytNPCAngler || !yitangCalamity.ShouldEnableAnglerShop())
			{
				return;
			}

			lastUpdateUiGameTime = gameTime;

			if (Main.LocalPlayer.talkNPC != -1 && Main.npc[Main.LocalPlayer.talkNPC].type == NPCID.Angler && Main.npcShop != 99)
			{
				userInterface?.Update(gameTime);
			}
		}

		private bool DrawUI()
		{
			if (Main.LocalPlayer.talkNPC != -1 && Main.npc[Main.LocalPlayer.talkNPC].type == NPCID.Angler && Main.npcShop != 99 && !dialogueTweakLoaded)
			{
				userInterface?.Draw(Main.spriteBatch, lastUpdateUiGameTime);
			}
			return true;
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			if (!ytCalamityConfig.Instance.ytNPCAngler || !yitangCalamity.ShouldEnableAnglerShop())
			{
				return;
			}

			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex == -1)
			{
				return;
			}
			layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer("AnglerShop: UI", DrawUI, InterfaceScaleType.UI));
		}

		private UserInterface userInterface;

		private static bool dialogueTweakLoaded;
	}
}