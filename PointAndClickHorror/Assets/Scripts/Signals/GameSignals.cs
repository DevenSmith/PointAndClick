using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSignals 
{
	public class confirmSelection : ASignal{ };
	public class denySelection : ASignal { };
	public class openConfirmDeny : ASignal { };
	public class closeConfirmDeny : ASignal { };
}
