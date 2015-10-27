using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
	private const string PREFAB_PATH = "Prefab/";
	private const string GROUND_PATH = PREFAB_PATH + "Ground";
	private const string PAWN_PATH = PREFAB_PATH + "Pawn";
	private const string MATERIAL_PATH = "Materials/";
	private const float TILE_SCALE = 0.95f;

	// Use this for initialization
	void Start ()
	{
		Manager.Resource.Create ();

		InitializeMap ();
		InitializeActor ();
		InitializeCamera ();

		GameObject obj = new GameObject ("InputMgr");
		obj.AddComponent<Control.Manager> ();
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
			obj.transform.localPosition = new Vector3(i % 5, i /5, 0);
			obj.transform.localScale = new Vector3(TILE_SCALE, TILE_SCALE, TILE_SCALE);
			Ground.Map.Add(obj.AddComponent<Ground>());
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
		var prefabPawn = Manager.Action.Load<GameObject> (PAWN_PATH);
		var obj = GameObject.Instantiate (prefabPawn);
		obj.transform.localScale = new Vector3(TILE_SCALE, TILE_SCALE, TILE_SCALE);
		obj.transform.SetParent (this.transform);
		obj.AddComponent<Actor.Movable> ();
	}

	private void InitializeCamera()
	{
		var trans = Camera.main.transform;

		var center = Ground.Map.Count / 5.0f / 2.0f;
		trans.position = new Vector3 (center - 0.5f, center, -5);
		trans.eulerAngles = new Vector3 (0, 0, 90);
	}
}
