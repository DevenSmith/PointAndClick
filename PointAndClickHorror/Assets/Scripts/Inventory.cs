using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
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
