using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmDenyButton : MonoBehaviour
{
	[SerializeField]
	private GameObject confirmDenyOBJ;

	private void Awake()
	{
		Signals.Get<GameSignals.openConfirmDeny>().AddListener(ShowConfirmDeny);
	}

	private void OnDestroy()
	{
		Signals.Get<GameSignals.openConfirmDeny>().RemoveListener(ShowConfirmDeny);
	}

	private void ShowConfirmDeny()
	{
		confirmDenyOBJ.SetActive(true);
	}

	private void HideConfirmDeny()
	{
		confirmDenyOBJ.SetActive(false);
		Signals.Get<GameSignals.closeConfirmDeny>().Dispatch();
	}

	public void ConfirmClicked()
	{
		Signals.Get<GameSignals.confirmSelection>();
		HideConfirmDeny();
	}

	public void DenyClicked()
	{
		Signals.Get<GameSignals.denySelection>();
		HideConfirmDeny();
	}
}
