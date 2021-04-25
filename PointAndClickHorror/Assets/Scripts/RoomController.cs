using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public RoomSO roomSO;

    public List<Door> doors = new List<Door>();

    public void OnAwake()
	{
        if(roomSO.connectedRooms.Count != doors.Count)
		{
			Debug.LogError("The number of rooms and doors are not equal!!!");
		}

		for(int i = 0; i < doors.Count; i++)
		{
			doors[i].SetRoomToLoad(roomSO.connectedRooms[i]);
		}

	}
}
