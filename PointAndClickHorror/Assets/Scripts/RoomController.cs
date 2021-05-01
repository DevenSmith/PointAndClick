using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public RoomSO roomSO;

    public List<Door> doors = new List<Door>();

	public List<Prop> props = new List<Prop>();
 
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

		while(roomSO.propItems.Count < props.Count)
		{
			roomSO.propItems.Add(null);
		}

		for(int i = 0; i < props.Count; i++)
		{
			props[i].Room = roomSO;

			if(roomSO.propItems[i] != null)
			{
				props[i].StoreItemInContainer(roomSO.propItems[i]);
			}
		}
	}

	public void CleanUpRoomForDestruction()
	{
		for (int i = 0; i < props.Count; i++)
		{
			if (props[i] != null)
			{
				roomSO.propItems[i] = props[i].GetContainedItem();
			}
		}
	}
}
