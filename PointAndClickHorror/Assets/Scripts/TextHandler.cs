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

	private List<string> textsToDisplay = new List<string>();

	private bool displayingText = false;

	[SerializeField]
	private bool testDisplay = false;

	public void DisplayTextImmediate(string text)
	{
		textToDisplay = text;
		textField.text = text;
	}

	public void DisplayText(string text)
	{
		textToDisplay = text;
		StartCoroutine(DisplayTextRoutine(text));
	}

	private IEnumerator DisplayTextRoutine(string text)
	{
		displayingText = true;
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
		displayingText = false;
		yield return null;
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
