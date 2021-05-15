using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
	public static GameStateController instance;

    [SerializeField]
    private GameStateSO gameState = null;

	[SerializeField]
	private string playerAquiredItemString = "You aquired ";

	public void Awake()
	{
		if(instance != null)
		{
			Destroy(this);
		}
		else
		{
			instance = this;
		}

		Signals.Get<GameStateSignals.PlayerAquiredItem>().AddListener(PlayerAquiredItem);
		Signals.Get<GameStateSignals.SetMansionBuiltState>().AddListener(SetMansionBuiltState);
		Signals.Get<GameStateSignals.RequestMansionBuiltState>().AddListener(MansionStateRequested);
		Signals.Get<GameStateSignals.RequestDoesPlayerHaveItem>().AddListener(DoesPlayerHaveItem);
		Signals.Get<GameStateSignals.RequestGameState>().AddListener(GameStateRequested);
		Signals.Get<GameStateSignals.SetPlayerRoom>().AddListener(SetPlayerRoom);
		Signals.Get<GameStateSignals.SetButlerRoom>().AddListener(SetButlerRoom);
		Signals.Get<GameStateSignals.SetGameState>().AddListener(SetGameStateReference);
	}

	public void OnDestroy()
	{
		Signals.Get<GameStateSignals.PlayerAquiredItem>().RemoveListener(PlayerAquiredItem);
		Signals.Get<GameStateSignals.SetMansionBuiltState>().RemoveListener(SetMansionBuiltState);
		Signals.Get<GameStateSignals.RequestMansionBuiltState>().RemoveListener(MansionStateRequested);
		Signals.Get<GameStateSignals.RequestDoesPlayerHaveItem>().RemoveListener(DoesPlayerHaveItem);
		Signals.Get<GameStateSignals.RequestGameState>().RemoveListener(GameStateRequested);
		Signals.Get<GameStateSignals.SetPlayerRoom>().RemoveListener(SetPlayerRoom);
		Signals.Get<GameStateSignals.SetButlerRoom>().RemoveListener(SetButlerRoom);
		Signals.Get<GameStateSignals.SetGameState>().RemoveListener(SetGameStateReference);
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
			Signals.Get<TextHandlerSignals.DisplayTextSignal>().Dispatch(playerAquiredItemString + aquiredItem.itemName);
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

	private void SetPlayerRoom(RoomSO newPlayerRoom)
	{
		gameState.playerRoom = newPlayerRoom;
	}

	private void SetButlerRoom(RoomSO newButlerRoom)
	{
		gameState.butlerRoom = newButlerRoom;
	}

	private void SetGameStateReference(System.Action<GameStateSO> action)
	{
		action(gameState);
	}
}
