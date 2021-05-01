using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContainer 
{
	public bool ContainsItem();

	public ItemSO GetContainedItem();

	public void TakeContainedItem();

	public void StoreItemInContainer(ItemSO item);


}
