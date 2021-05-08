using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHandler : MonoBehaviour
{
	[SerializeField]
	private float charactersPerSecond = 10;

	[SerializeField]
	private TMP_Text textField;

	[SerializeField]
	private string textToDisplay = "";

	private Queue<string> textsToDisplay = new Queue<string>();

	[SerializeField]
	private bool testDisplay = false;

	private Coroutine currentDisplayRoutine = null;

	public void Awake()
	{
		Signals.Get<TextHandlerSignals.DisplayTextSignal>().AddListener(DisplayText);
		Signals.Get<TextHandlerSignals.DisplayTextImmediateSignal>().AddListener(DisplayTextImmediate);
	}

	public void OnDestroy()
	{
		Signals.Get<TextHandlerSignals.DisplayTextSignal>().RemoveListener(DisplayText);
		Signals.Get<TextHandlerSignals.DisplayTextImmediateSignal>().RemoveListener(DisplayTextImmediate);
	}

	public void DisplayCurrentTextImmediately()
	{
		if(currentDisplayRoutine != null)
		{
			StopCoroutine(currentDisplayRoutine);
		}

		DisplayTextImmediate(textToDisplay);
	}

	public void DisplayTextImmediate(string text)
	{
		textToDisplay = text;
		textToDisplay = textToDisplay.Replace("\\n", "\n");
		textField.text = textToDisplay;
	}

	public void DisplayText(string text)
	{
		if (currentDisplayRoutine != null)
		{
			textsToDisplay.Enqueue(text);
		}
		else
		{
			textToDisplay = text;
			currentDisplayRoutine = StartCoroutine(DisplayTextRoutine(text));
		}
	}

	private IEnumerator DisplayTextRoutine(string text)
	{
		float stringIndex = 0.0f;

		string displayString = "";

		while(stringIndex < text.Length)
		{
			stringIndex += (charactersPerSecond * Time.deltaTime);
			displayString = text.Substring(0, (int)stringIndex);
			displayString = displayString.Replace("\\n", "\n");
			textField.text = displayString;
			yield return new WaitForEndOfFrame();
		}
		currentDisplayRoutine = null;
		yield return null;
		if(textsToDisplay.Count > 0)
		{
			yield return new WaitForSeconds(2.0f);
			DisplayText(textsToDisplay.Dequeue());
		}
	}

	private void Update()
	{
		if(testDisplay)
		{
			testDisplay = false;
			DisplayText(textToDisplay);
		}
	}

}
