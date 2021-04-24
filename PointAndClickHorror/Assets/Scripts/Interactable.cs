using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[SerializeField]
	private Collider2D interactableCollider;

	public void Awake()
	{
		if (interactableCollider == null)
		{
			interactableCollider = GetComponent<Collider2D>();

			if (interactableCollider == null)
			{
				Debug.LogError(name + " doesn't have a collider for its interactable!");
			}
		}
		
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
		interactableCollider.enabled = false;
	}

	public void OnConfirmDenyClosed()
	{
		interactableCollider.enabled = true;
	}
}
