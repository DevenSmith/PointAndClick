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

		Signals.Get<RoomSignals.LoadRoom>().AddListener(LoadRoom);
		Signals.Get<RoomSignals.LoadDefaultRoom>().AddListener(LoadDefaultRoom);
	}

	private void OnDestroy()
	{
		Signals.Get<RoomSignals.LoadRoom>().RemoveListener(LoadRoom);
		Signals.Get<RoomSignals.LoadDefaultRoom>().RemoveListener(LoadDefaultRoom);
	}

	// Start is called before the first frame update
	private void LoadDefaultRoom()
    {
		Signals.Get<RoomSignals.LoadDefaultRoom>().RemoveListener(LoadDefaultRoom);
		LoadRoom(defaultRoom);
    }

	public void LoadRoom(RoomSO newRoom)
	{
		RoomSO previousRoom = null;
		if(currentRoomObject != null)
		{
			previousRoom = currentRoomObject.GetComponent<RoomController>().roomSO;
			Destroy(currentRoomObject);
		}

		GameObject roomObj = Instantiate(newRoom.roomPrefab, roomHolderTransform);

		//RoomController roomController = roomObj.GetComponent<RoomController>();
		

		Signals.Get<TextHandlerSignals.DisplayTextSignal>().Dispatch(newRoom.roomDescription);
	}
}
