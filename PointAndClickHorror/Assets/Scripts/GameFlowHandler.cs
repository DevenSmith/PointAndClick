using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The player will do an action then the ai will do an action
/// </summary>

public class GameFlowHandler : MonoBehaviour
{
	public enum ActiveTurns { Player, AI};
	public ActiveTurns activeTurn = ActiveTurns.Player;
    
}
