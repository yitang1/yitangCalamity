using System;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Global.Config;

namespace yitangCalamity.NPCs.Angler;

internal class AnglerShopSystem : ModSystem
{
	private static readonly NPCShop anglerShop = new(NPCID.Angler);
	private static readonly NPCShop anglerVanityShop = new(NPCID.Angler, "Vanity");

	public override void PostSetupContent()
	{
		if (!ytCalamityConfig.Instance.ytNPCAngler || !yitangCalamity.ShouldEnableAnglerShop())
		{
			return;
		}

		AddItemToShop(anglerShop, ItemID.ReinforcedFishingPole, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerShop, ItemID.AnglerHat, Item.buyPrice(0, 5, 0, 0));
		AddItemToShop(anglerShop, ItemID.AnglerVest, Item.buyPrice(0, 5, 0, 0));
		AddItemToShop(anglerShop, ItemID.AnglerPants, Item.buyPrice(0, 5, 0, 0));
		AddItemToShop(anglerShop, ItemID.ApprenticeBait, Item.buyPrice(0, 3, 0, 0));
		AddItemToShop(anglerShop, ItemID.JourneymanBait, Item.buyPrice(0, 10, 0, 0));
		AddItemToShop(anglerShop, ItemID.MasterBait, Item.buyPrice(0, 15, 0, 0));
		AddItemToShop(anglerShop, ItemID.SonarPotion, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerShop, ItemID.FishingPotion, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerShop, ItemID.CratePotion, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerShop, ItemID.FishingBobber, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerShop, ItemID.HighTestFishingLine, Item.buyPrice(0, 3, 0, 0));
		AddItemToShop(anglerShop, ItemID.TackleBox, Item.buyPrice(0, 3, 0, 0));
		AddItemToShop(anglerShop, ItemID.AnglerEarring, Item.buyPrice(0, 3, 0, 0));
		AddItemToShop(anglerShop, ItemID.FishermansGuide, Item.buyPrice(0, 3, 0, 0));
		AddItemToShop(anglerShop, ItemID.WeatherRadio, Item.buyPrice(0, 3, 0, 0));
		AddItemToShop(anglerShop, ItemID.Sextant, Item.buyPrice(0, 3, 0, 0));
		AddItemToShop(anglerShop, ItemID.FuzzyCarrot, Item.buyPrice(0, 5, 0, 0));
		AddItemToShop(anglerShop, ItemID.FishMinecart, Item.buyPrice(0, 5, 0, 0));
		AddItemToShop(anglerShop, ItemID.FishHook, Item.buyPrice(0, 5, 0, 0));
		AddItemToShop(anglerShop, ItemID.CanOfWorms, Item.buyPrice(0, 1, 50, 0));
		AddItemToShop(anglerShop, ItemID.ChumBucket, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerShop, ItemID.GoldenBugNet, Item.buyPrice(0, 10, 0, 0));
		AddItemToShop(anglerShop, ItemID.GoldenFishingRod, Item.buyPrice(0, 15, 0, 0));
		AddItemToShop(anglerShop, ItemID.BottomlessBucket, Item.buyPrice(0, 10, 0, 0));
		AddItemToShop(anglerShop, ItemID.SuperAbsorbantSponge, Item.buyPrice(0, 10, 0, 0));
		AddItemToShop(anglerShop, ItemID.BottomlessHoneyBucket, Item.buyPrice(0, 10, 0, 0));
		AddItemToShop(anglerShop, ItemID.HoneyAbsorbantSponge, Item.buyPrice(0, 10, 0, 0));
		AddItemToShop(anglerShop, ItemID.BottomlessLavaBucket, Item.buyPrice(0, 10, 0, 0));
		AddItemToShop(anglerShop, ItemID.LavaAbsorbantSponge, Item.buyPrice(0, 10, 0, 0));
		AddItemToShop(anglerShop, ItemID.HotlineFishingHook, Item.buyPrice(0, 6, 50, 0), Condition.Hardmode);
		AddItemToShop(anglerShop, ItemID.FinWings, Item.buyPrice(0, 6, 50, 0), Condition.Hardmode);
		AddItemToShop(anglerShop, ItemID.TeleportationPylonOcean, Item.buyPrice(0, 10, 0, 0), Condition.HappyEnoughToSellPylons);

		AddItemToShop(anglerVanityShop, ItemID.SeashellHairpin, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.MermaidAdornment, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.MermaidTail, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.FishCostumeMask, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.FishCostumeShirt, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.FishCostumeFinskirt, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.BunnyfishTrophy, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.GoldfishTrophy, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.SwordfishTrophy, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.SharkteethTrophy, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.TreasureMap, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.SeaweedPlanter, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.CompassRose, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.ShipsWheel, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.ShipInABottle, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.LifePreserver, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.WallAnchor, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.Coral, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.Seashell, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.Starfish, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.PillaginMePixels, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.NotSoLostInParadise, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.Crustography, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.WhatLurksBelow, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.Fangs, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.CouchGag, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.SilentFish, Item.buyPrice(0, 1, 0, 0));
		AddItemToShop(anglerVanityShop, ItemID.TheDuke, Item.buyPrice(0, 1, 0, 0));
	}

	private static void AddItemToShop(NPCShop shop, short id, int price, params Condition[] conditions)
	{
		var item = new Item(id) { value = price };

		item.shopCustomPrice = price;

		shop.Add(item, conditions);
	}

	public static NPCShop GetAnglerShop() => anglerShop;
	public static NPCShop GetAnglerVanityShop() => anglerVanityShop;
}