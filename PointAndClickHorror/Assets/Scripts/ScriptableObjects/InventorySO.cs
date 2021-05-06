using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/InventorySO", order = 1)]
public class InventorySO: ScriptableObject
{
	[SerializeField]
	private List<ItemSO> items = new List<ItemSO>();

	public void PickUpItem(ItemSO item)
	{
		items.Add(item);
	}

	public void RemoveItem(ItemSO item)
	{
		items.Remove(item);
	}
}
