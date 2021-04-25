using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
	[SerializeField]
	private RoomSO roomToLoad;

	[SerializeField]
	private string doorDescription;

	public new void OnDestroy()
	{
		RemoveConfirmDenyListeners();
	}

	public void OnMouseDown()
	{
		Signals.Get<GameSignals.openConfirmDeny>().Dispatch();
		Signals.Get<TextHandlerSignals.DisplayTextSignal>().Dispatch(doorDescription);
		SetConfirmDenyListeners();
	}

	public void SetRoomToLoad(RoomSO room)
	{
		roomToLoad = room;
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
		Signals.Get<RoomSignals.LoadRoom>().Dispatch(roomToLoad);
	}

}
