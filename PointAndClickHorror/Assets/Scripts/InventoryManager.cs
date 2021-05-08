using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public static InventoryManager instance;

	[SerializeField]
	private InventorySO inventory;

	[SerializeField]
	private ItemSO itemToTestWith;

	[SerializeField]
	private bool testItemPickUp = false;

	[SerializeField]
	private bool testItemDrop = false;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	private void Update()
	{
		if(testItemDrop)
		{
			testItemDrop = false;
			inventory.RemoveItem(itemToTestWith);
		}

		if(testItemPickUp)
		{
			testItemPickUp = false;
			inventory.PickUpItem(itemToTestWith);
		}
	}

	public bool DoesInventoryContainItem(ItemSO itemToCheck)
	{
		return inventory.ContainsItem(itemToCheck);
	}


}
