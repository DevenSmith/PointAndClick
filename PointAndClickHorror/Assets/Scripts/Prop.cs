using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Interactable, IContainer
{
	[SerializeField]
	private string description = "This prop needs a description!";

	[SerializeField]
	private string itemFoundDescription = "Inside you find ";

	private ItemSO containerItem = null;

	private RoomSO room;

	public RoomSO Room
	{
		set
		{
			room = value;
		}
	}

	public new void Awake()
	{
		base.Awake();
		button.onClick.AddListener(OnPropClicked);
	}

	public new void OnDestroy()
	{
		containerItem = null;
		room = null;
		RemoveConfirmDenyListeners();
		button.onClick.RemoveListener(OnPropClicked);
	}

	private void SetConfirmDenyListeners()
	{
		Signals.Get<GameSignals.confirmSelection>().AddListener(TakeContainedItem);
		Signals.Get<GameSignals.closeConfirmDeny>().AddListener(RemoveConfirmDenyListeners);
	}

	private void RemoveConfirmDenyListeners()
	{
		Signals.Get<GameSignals.confirmSelection>().RemoveListener(TakeContainedItem);
		Signals.Get<GameSignals.closeConfirmDeny>().RemoveListener(RemoveConfirmDenyListeners);
	}

	private void OnPropClicked()
	{
		Signals.Get<TextHandlerSignals.DisplayTextSignal>().Dispatch(description);
		if (containerItem != null)
		{
			Signals.Get<GameSignals.openConfirmDeny>().Dispatch();
			Signals.Get<TextHandlerSignals.DisplayTextSignal>().Dispatch(itemFoundDescription + containerItem.itemName);
			SetConfirmDenyListeners();
		}
	}

	#region IContainer Implementaion
	public bool ContainsItem()
	{
		return containerItem != null;
	}

	public ItemSO GetContainedItem()
	{
		return containerItem;
	}

	public void TakeContainedItem()
	{
		ItemSO item = containerItem;
		containerItem = null;
		//return item; change this to a signal when items management is implemented.
	}

	public void StoreItemInContainer(ItemSO item)
	{
		if(containerItem != null)
		{
			Debug.LogError(name + " just tried to overwrite its stored item!");
			return;
		}

		containerItem = item;
	}
	#endregion
}
