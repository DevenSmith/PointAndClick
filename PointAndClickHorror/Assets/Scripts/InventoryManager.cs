using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	[SerializeField]
	private InventorySO inventory;

	[SerializeField]
	private ItemSO itemToTestWith;

	[SerializeField]
	private bool testItemPickUp = false;

	[SerializeField]
	private bool testItemDrop = false;

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


}
