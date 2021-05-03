using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField]
    private GameStateSO gameState = null;

	public void Awake()
	{
		Signals.Get<GameStateSignals.PlayerAquiredItem>().AddListener(PlayerAquiredItem);
		Signals.Get<GameStateSignals.SetMansionBuiltState>().AddListener(SetMansionBuiltState);
	}

	public void OnDestroy()
	{
		Signals.Get<GameStateSignals.PlayerAquiredItem>().RemoveListener(PlayerAquiredItem);
		Signals.Get<GameStateSignals.SetMansionBuiltState>().RemoveListener(SetMansionBuiltState);
	}

	private void PlayerAquiredItem(ItemSO aquiredItem)
	{
		if(gameState.playerInventory.Contains(aquiredItem))
		{
			Debug.LogError("Player tried to aquired an item they already had");
		}
		else
		{
			gameState.playerInventory.Add(aquiredItem);
		}
	}

	private void SetMansionBuiltState(bool state)
	{
		gameState.mansionBuilt = state;
	}
}
