using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateSignals 
{
	public class RequestMansionBuiltState : ASignal { };
	public class SendMansionBuiltState : ASignal<bool> { };
	public class SetMansionBuiltState : ASignal<bool> { };

	public class SetPlayerRoom : ASignal<RoomSO> { };
	public class SetButlerRoom : ASignal<RoomSO> { };

	public class PlayerAquiredItem : ASignal<ItemSO> { };

	public class RequestDoesPlayerHaveItem : ASignal<ItemSO> { };
	public class SendDoesPlayerHaveItemState : ASignal<bool> { };

	public class RequestGameState : ASignal { };
	public class SendGameState : ASignal<GameStateSO> { };

	public class SetGameState : ASignal<Action<GameStateSO>> { };
}
