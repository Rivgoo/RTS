using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct SaveIslandData
{
	public bool IsNewIsland;
	
	[HideInInspector]
	public Transform IslandBaseTransform;
	[HideInInspector]
	public List<Transform> PrefabBoxesTransform;
	[HideInInspector]
	public List<Transform> PrefabTreesTransform;
	[HideInInspector]
	public List<Transform> PrefabRocksTransform;
	[HideInInspector]
	public List<Transform> PrefabGressesTransform;
	[HideInInspector]
	public List<Transform> PrefabDetalilsTransform;
	
	[HideInInspector]
	public int IslandBaseID;
	[HideInInspector]
	public List<int> PrefabBoxesID;
	[HideInInspector]
	public List<int> PrefabTreesID;
	[HideInInspector]
	public List<int> PrefabRocksID;
	[HideInInspector]
	public List<int> PrefabGressesID;
	[HideInInspector]
	public List<int> PrefabDetalilsID;
}