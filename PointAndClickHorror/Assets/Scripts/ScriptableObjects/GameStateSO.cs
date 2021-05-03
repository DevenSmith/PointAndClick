using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameStateSO", menuName = "ScriptableObjects/GameStateSO", order = 1)]
public class GameStateSO : ScriptableObject
{
    public bool mansionBuilt = false;
	public List<ItemSO> playerInventory;
	public RoomSO playerRoom = null;
	public RoomSO butlerRoom = null;

    public void ResetGameState()
	{
		mansionBuilt = false;
		playerInventory.Clear();
		playerRoom = null;
		butlerRoom = null;
	}
}
