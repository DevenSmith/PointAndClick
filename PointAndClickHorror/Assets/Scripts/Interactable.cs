using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
	public Button button;

	public void Awake()
	{
		Signals.Get<GameSignals.openConfirmDeny>().AddListener(OnConfirmDenyOpened);
		Signals.Get<GameSignals.closeConfirmDeny>().AddListener(OnConfirmDenyClosed);
	}

	public void OnDestroy()
	{
		Signals.Get<GameSignals.openConfirmDeny>().RemoveListener(OnConfirmDenyOpened);
		Signals.Get<GameSignals.closeConfirmDeny>().RemoveListener(OnConfirmDenyClosed);
	}

	public void OnConfirmDenyOpened()
	{
		button.interactable = false;
	}

	public void OnConfirmDenyClosed()
	{
		button.interactable = true;
	}
}
