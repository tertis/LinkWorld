using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
	private const string GROUND_PATH = "Prefab/Ground/Ground";
	private const string MATERIAL_PATH = "Materials/";
	private const string ACTOR_PATH = "Prefab/Actor/";
	private const float TILE_SCALE = 0.95f;

	// Use this for initialization
	void Start ()
	{
		Manager.Resource.Create ();

		InitializeMap ();
		InitializeActor ();
		InitializeCamera ();
	}

	/// <summary>
	/// Initializes the map.
	/// </summary>
	private void InitializeMap()
	{
		for (int i = 0; i < Manager.Resource.Map.Count; ++i)
		{
			string tileName = Manager.Resource.GroundName[Manager.Resource.Map[i]];
			var obj = CreateTile(tileName);
			obj.transform.localPosition = new Vector3(i % 5, -i /5, 0);
			obj.transform.localScale = new Vector3(TILE_SCALE, TILE_SCALE, TILE_SCALE);
			obj.AddComponent<Ground>();
		}
	}

	private GameObject CreateTile(string tileName)
	{
		var prefabTile = Manager.Action.Load<GameObject>(GROUND_PATH);
		var tileMat = Manager.Action.Load<Material>(MATERIAL_PATH + tileName);
		var obj = GameObject.Instantiate(prefabTile);
		obj.GetComponent<MeshRenderer>().material = tileMat;
		obj.transform.SetParent(this.transform);

		return obj;
	}

	/// <summary>
	/// Initializes the actor.
	/// </summary>
	private void InitializeActor()
	{

	}

	private void InitializeCamera()
	{
		var trans = Camera.main.transform;
		trans.position = new Vector3 (0, 0, -10);
		trans.eulerAngles = new Vector3 (0, 0, 90);
	}
}
