using System;
using UnityEngine;

public class Loot : MonoBehaviour
{
	public enum LootItemType
	{
		Eat,
		Wood,
		Scrap,
		Electronics
	}

	[Serializable]
	public class LootItem
	{
		public LootItemType lootItemType;
		public int minQuantity;
		public int maxQuantity;
	}

	public LootItem[] itemsLoots;

	public void IssuindLoots()
	{
		foreach (LootItem lootItem in itemsLoots)
		{
			int quantity = UnityEngine.Random.Range(lootItem.minQuantity, lootItem.maxQuantity + 1);
			LootItemType itemType = lootItem.lootItemType;

			switch (itemType)
			{
				case LootItemType.Eat:
					Data.Eat += quantity;
					break;
				case LootItemType.Wood:
					Data.Wood += quantity;
					break;
				case LootItemType.Scrap:
					Data.Scrap += quantity;
					break;
				case LootItemType.Electronics:
					Data.Electronics += quantity;
					break;
			}
		}
	}
}
