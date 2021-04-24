using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO", order = 1)]
public class ItemSO : ScriptableObject
{
	public string itemID = "NA";

	public string itemName = "This Item needs a name!";

	public string description = "This item needs a description!";

	public Sprite itemImage;
}
