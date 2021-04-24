using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHandlerSignals 
{
	public class DisplayTextSignal : ASignal<string> { };

	public class DisplayTextImmediateSignal : ASignal<string> { };
}
