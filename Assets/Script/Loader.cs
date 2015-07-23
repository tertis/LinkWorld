using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
	private const string GROUND_PATH = "Prefab/Ground/";
	private const string ACTOR_PATH = "Prefab/Actor/";

	// Use this for initialization
	void Start ()
	{
		Manager.Resource.Create ();

		InitializeMap ();
		InitializeActor ();
	}

	/// <summary>
	/// Initializes the map.
	/// </summary>
	private void InitializeMap()
	{
		for (int i = 0; i < Manager.Resource.Map.Count; ++i)
		{
			string tileName = Manager.Resource.GroundName[Manager.Resource.Map[i]];
			GameObject prefabTile = Manager.Action.Load<GameObject>("Prefab/Ground/" + tileName);
			GameObject obj = GameObject.Instantiate(prefabTile);
			obj.transform.SetParent(this.transform);
			obj.transform.localPosition = new Vector3(i % 5, 0f, -i / 5);
			obj.transform.Rotate(new Vector3(90.0f, 0f, 0f));
			obj.AddComponent<Ground>();
		}
	}

	/// <summary>
	/// Initializes the actor.
	/// </summary>
	private void InitializeActor()
	{

	}
}
