using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Interactable
{
	[SerializeField]
	private string description = "This prop needs a description!";

	public new void Awake()
	{
		base.Awake();
		button.onClick.AddListener(OnPropClicked);
	}

	public new void OnDestroy()
	{
		RemoveConfirmDenyListeners();
		button.onClick.RemoveListener(OnPropClicked);
	}

	private void SetConfirmDenyListeners()
	{
		Signals.Get<GameSignals.confirmSelection>().AddListener(OnPropClicked);
		Signals.Get<GameSignals.closeConfirmDeny>().AddListener(RemoveConfirmDenyListeners);
	}

	private void RemoveConfirmDenyListeners()
	{
		Signals.Get<GameSignals.confirmSelection>().RemoveListener(OnPropClicked);
		Signals.Get<GameSignals.closeConfirmDeny>().RemoveListener(RemoveConfirmDenyListeners);
	}

	private void OnPropClicked()
	{
		Signals.Get<TextHandlerSignals.DisplayTextSignal>().Dispatch(description);
	}


}
