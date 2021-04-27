using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public RoomSO roomSO;

    public List<Door> doors = new List<Door>();

    public void Awake()
	{
        if(roomSO.connectedRooms.Count != doors.Count)
		{
			Debug.LogError("The number of rooms and doors are not equal!!!");
		}

		foreach(Door door in doors)
		{
			door.CurrentRoom = roomSO;
		}
	}
}
