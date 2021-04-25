using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomSO", menuName = "ScriptableObjects/RoomSO", order = 1)]
public class RoomSO : ScriptableObject
{
	public bool isAHall = false;
	public int roomsToConnect = 0;
	public List<RoomSO> connectedRooms = new List<RoomSO>();
	public GameObject roomPrefab;
	public ItemSO roomItem;

	//todo: consider switching this to reading from a file if the project expands
	public string roomDescription = "This room needs a description!";
}
