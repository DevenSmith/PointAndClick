using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSignals 
{
	public class LoadDefaultRoom : ASignal { };
	public class LoadRoom : ASignal<RoomSO> { };
}
