using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[CreateAssetMenu(fileName = "GameStateSO", menuName = "ScriptableObjects/GameStateSO", order = 1)]
public class GameStateSO : ScriptableObject
{
    public bool mansionBuilt = false;
	public List<ItemSO> playerInventory;
	public RoomSO playerRoom = null;
	public RoomSO butlerRoom = null;

	[SerializeField]
	private string filePath = "Assets/Resources/";
	[SerializeField]
	private string fileName = "gameState_Save.txt";

	private struct saveInfo
	{
		public bool mansionState;
		public List<string> playerInventory;
		public string playerRoomID;
		public string butlerRoomID;
	}

    public void ResetGameState()
	{
		mansionBuilt = false;
		playerInventory.Clear();
		playerRoom = null;
		butlerRoom = null;
	}

	public void SaveGameState()
	{
		saveInfo save = new saveInfo();
		save.mansionState = mansionBuilt;
		foreach(ItemSO item in playerInventory)
		{
			save.playerInventory.Add(item.itemID);
		}
		if (playerRoom != null)
		{
			save.playerRoomID = playerRoom.roomID;
		}
		if (butlerRoom != null)
		{
			save.butlerRoomID = butlerRoom.roomID;
		}

		string gameStateJson = JsonUtility.ToJson(save);

		StreamWriter sr = null;

		if (File.Exists(filePath + fileName))
		{
			sr = new StreamWriter(filePath + fileName, false);
		}
		else
		{
			sr = File.CreateText(filePath + fileName);
		}

		sr.WriteLine(gameStateJson);
		sr.Close();
	}

	public void LoadGameState()
	{
		if (File.Exists(fileName) == false)
		{
			return;
		}

		TextAsset asset = (TextAsset)Resources.Load(fileName);
		saveInfo save = JsonUtility.FromJson<saveInfo>(asset.text);
		mansionBuilt = save.mansionState;
		//get player inventory from save
		//get player and butler rooms from save

	}
}
