using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : Interactable
{
	private RoomSO currentRoom;

	public RoomSO CurrentRoom
	{
		set
		{
			currentRoom = value;
		}
	}

	[SerializeField]
	private RoomSO roomToLoad;

	[SerializeField]
	private int doorIndex = 0;

	[SerializeField]
	private string doorDescription;

	public new void Awake()
	{
		base.Awake();
		button.onClick.AddListener(DoorClicked);
	}

	public new void OnDestroy()
	{
		RemoveConfirmDenyListeners();
		button.onClick.RemoveListener(DoorClicked);
	}

	public void DoorClicked()
	{
		Signals.Get<GameSignals.openConfirmDeny>().Dispatch();
		Signals.Get<TextHandlerSignals.DisplayTextSignal>().Dispatch(doorDescription);
		SetConfirmDenyListeners();
	}

	private void SetConfirmDenyListeners()
	{
		Signals.Get<GameSignals.confirmSelection>().AddListener(DoorOpened);
		Signals.Get<GameSignals.closeConfirmDeny>().AddListener(RemoveConfirmDenyListeners);
	}

	private void RemoveConfirmDenyListeners()
	{
		Signals.Get<GameSignals.confirmSelection>().RemoveListener(DoorOpened);
		Signals.Get<GameSignals.closeConfirmDeny>().RemoveListener(RemoveConfirmDenyListeners);
	}

	private void DoorOpened()
	{
		if (roomToLoad == null)
		{
			Signals.Get<RoomSignals.LoadRoom>().Dispatch(currentRoom.connectedRooms[doorIndex]);
		}
		else
		{
			Signals.Get<RoomSignals.LoadRoom>().Dispatch(roomToLoad);
		}
	}

}
