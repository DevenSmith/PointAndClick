using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoader : MonoBehaviour
{
	[SerializeField, Tooltip("The first room the game will load")]
	private RoomSO defaultRoom;

	[SerializeField, Tooltip("The object room prefabs will be childed to")]
	private Transform roomHolderTransform;

	private GameObject currentRoomObject;

	private void Awake()
	{
		if(defaultRoom == null)
		{
			Debug.LogError("DefaultRoom needs to be set!!!");
		}

		if(roomHolderTransform == null)
		{
			Debug.LogError("RoomHolderTransform needs to be set!!!");
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		LoadRoom(defaultRoom);
    }

	public void LoadRoom(RoomSO newRoom)
	{
		if(currentRoomObject != null)
		{
			Destroy(currentRoomObject);
		}

		Instantiate(newRoom.roomPrefab, roomHolderTransform);
		Signals.Get<TextHandlerSignals.DisplayTextSignal>().Dispatch(newRoom.roomDescription);
	}
}
