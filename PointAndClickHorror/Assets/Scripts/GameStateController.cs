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
		Signals.Get<GameStateSignals.RequestMansionBuiltState>().AddListener(MansionStateRequested);
		Signals.Get<GameStateSignals.RequestDoesPlayerHaveItem>().AddListener(DoesPlayerHaveItem);
		Signals.Get<GameStateSignals.RequestGameState>().AddListener(GameStateRequested);
	}

	public void OnDestroy()
	{
		Signals.Get<GameStateSignals.PlayerAquiredItem>().RemoveListener(PlayerAquiredItem);
		Signals.Get<GameStateSignals.SetMansionBuiltState>().RemoveListener(SetMansionBuiltState);
		Signals.Get<GameStateSignals.RequestMansionBuiltState>().RemoveListener(MansionStateRequested);
		Signals.Get<GameStateSignals.RequestDoesPlayerHaveItem>().RemoveListener(DoesPlayerHaveItem);
		Signals.Get<GameStateSignals.RequestGameState>().RemoveListener(GameStateRequested);
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

	private void GameStateRequested()
	{
		Signals.Get<GameStateSignals.SendGameState>().Dispatch(gameState);
	}

	private void DoesPlayerHaveItem(ItemSO item)
	{
		Signals.Get<GameStateSignals.SendDoesPlayerHaveItemState>().Dispatch(gameState.playerInventory.Contains(item));
	}

	private void MansionStateRequested()
	{
		Signals.Get<GameStateSignals.SendMansionBuiltState>().Dispatch(gameState.mansionBuilt);
	}
}
