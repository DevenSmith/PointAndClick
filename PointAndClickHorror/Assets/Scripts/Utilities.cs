using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities 
{
	public static void ShuffleList<T>(List<T> list)
	{
		for(int i = 0; i < list.Count; i++)
		{
			T temp = list[i];
			int randomIndex = Random.Range(i, list.Count);
			list[i] = list[randomIndex];
			list[randomIndex] = temp;
		}
	}
}
