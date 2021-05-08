using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MansionBuilder : MonoBehaviour
{
    public List<RoomSO> sideRooms = new List<RoomSO>();
    public List<RoomSO> hallFloors = new List<RoomSO>();

	public List<ItemSO> items = new List<ItemSO>();

	private GameStateSO gameState = null;

	[SerializeField]
	private bool forceRoomReset = false;

	public void Awake()
	{
		Signals.Get<GameStateSignals.SendGameState>().AddListener(GetGameState);
	}

	public void OnDestroy()
	{
		Signals.Get<GameStateSignals.SendGameState>().RemoveListener(GetGameState);
	}

	public void Start()
	{
		Signals.Get<GameStateSignals.RequestGameState>().Dispatch();
		if (forceRoomReset == false && gameState != null && gameState.mansionBuilt && gameState.playerRoom != null)
		{
			Signals.Get<RoomSignals.LoadRoom>().Dispatch(gameState.playerRoom);
			return;
		}

		ResetRooms();

		Utilities.ShuffleList(sideRooms);
		Utilities.ShuffleList(items);

		for(int i = 0; i < hallFloors.Count; i++)
		{
			for(int j = 0; j < hallFloors[i].roomsToConnect; j++)
			{
				RoomSO sideRoom = sideRooms[0];
				hallFloors[i].connectedRooms.Add(sideRoom);
				//sideRoom.roomItem = items[0];
				sideRoom.connectedRooms.Clear();
				sideRoom.connectedRooms.Add(hallFloors[i]);
				//items.RemoveAt(0);
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
		Signals.Get<GameStateSignals.SetMansionBuiltState>().Dispatch(true);
		Signals.Get<RoomSignals.LoadDefaultRoom>().Dispatch();
	}

	private void GetGameState(GameStateSO sentGameState)
	{
		gameState = sentGameState;
		Signals.Get<GameStateSignals.SendGameState>().RemoveListener(GetGameState);
	}

	public void ResetRooms()
	{
		foreach (RoomSO hall in hallFloors)
		{
			hall.connectedRooms.Clear();
		}

		foreach (RoomSO sideRoom in sideRooms)
		{
			sideRoom.connectedRooms.Clear();
		}
	}
}

