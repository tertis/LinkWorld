using UnityEngine;
public static class Global
{
    private const string GLOBALNAME = "_Global";
    private const string PREFAB_PATH = "Prefab/";
    private const string GROUND_PATH = PREFAB_PATH + "Ground";
    private const string PAWN_PATH = PREFAB_PATH + "Pawn";
    private const string MATERIAL_PATH = "Materials/";
    private const float TILE_SCALE = 0.95f;
    public const int MAP_WIDTH = 5;
	public static LocalMap _map { get; private set; }
    
    private static Transform _root;
	
	public static bool Create()
	{
        _root = (new GameObject(GLOBALNAME)).transform;
		InitializeMap();
        InitializeActor();
        InitializeCamera();
		return true;
	}
	
	public static bool Cleanup()
	{
		return true;
	}
	
	 /// <summary>
    /// Initializes the map.
    /// </summary>
    private static void InitializeMap()
    {
		_map = new LocalMap();
        for (int i = 0; i < Manager.Resource.Map.Count; ++i)
        {
            string tileName = Manager.Resource.GroundName[Manager.Resource.Map[i]];
            var obj = CreateTile(tileName);
            obj.transform.localPosition = new Vector3(i % MAP_WIDTH, i / MAP_WIDTH, 0);
            obj.transform.localScale = new Vector3(TILE_SCALE, TILE_SCALE, TILE_SCALE);
            
            _map.AddGround(obj.AddComponent<Ground>());
        }
    }

    private static GameObject CreateTile(string tileName)
    {
        var prefabTile = Manager.Action.Load<GameObject>(GROUND_PATH);
        var tileMat = Manager.Action.Load<Material>(MATERIAL_PATH + tileName);
        var obj = GameObject.Instantiate(prefabTile);
        obj.GetComponent<MeshRenderer>().material = tileMat;
        obj.transform.SetParent(_root);

        return obj;
    }

    /// <summary>
    /// Initializes the actor.
    /// </summary>
    private static void InitializeActor()
    {
        var prefabPawn = Manager.Action.Load<GameObject>(PAWN_PATH);
        var obj = GameObject.Instantiate(prefabPawn);
        obj.transform.localScale = new Vector3(TILE_SCALE, TILE_SCALE, TILE_SCALE);
        obj.transform.SetParent(_root);
        obj.AddComponent<Actor.Movable>().Init(0);
    }

    private static void InitializeCamera()
    {
        var trans = Camera.main.transform;

        var center = _map.GetSize() / 5.0f / 2.0f;
        trans.position = new Vector3(center - 0.5f, center, -5);
        trans.eulerAngles = new Vector3(0, 0, 90);
    }
}