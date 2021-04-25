using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MansionBuilder : MonoBehaviour
{
    public List<RoomSO> sideRooms = new List<RoomSO>();
    public List<RoomSO> hallFloors = new List<RoomSO>();

	public List<ItemSO> items = new List<ItemSO>();


	public void Start()
	{
		sideRooms = Utilities.ShuffleList(sideRooms);
		items = Utilities.ShuffleList(items);

		for(int i = 0; i < hallFloors.Count; i++)
		{
			for(int j = 0; j < hallFloors[i].roomsToConnect; j++)
			{
				RoomSO sideRoom = sideRooms[0];
				hallFloors[i].connectedRooms.Add(sideRoom);
				sideRoom.roomItem = items[0];
				sideRoom.connectedRooms.Add(hallFloors[i]);
				items.RemoveAt(0);
				sideRooms.RemoveAt(0);

				if (sideRooms.Count == 0)
				{
					break;
				}
			}

			if (sideRooms.Count == 0)
			{
				break;
			}
		}
	}

}

