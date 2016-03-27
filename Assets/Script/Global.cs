using UnityEngine;
public static class Global
{
    private const string GLOBALNAME = "_Global";
    private const string PREFAB_PATH = "Prefab/";
    private const string GROUND_PATH = PREFAB_PATH + "Ground";
    private const string PAWN_PATH = PREFAB_PATH + "Pawn";
    private const string MATERIAL_PATH = "Materials/";
    public const float TILE_SCALE = 0.95f;
	public static LocalMap _map { get; private set; }
    
    // ID 관련 값
    public const int MIN_ID_LENGTH = 4;
    public const int MAX_ID_LENGTH = 16;
    public const int MIN_PASSWORD_LENGTH = 8;
    public const int MAX_PASSWORD_LENGTH = 16; 
    
    private static Transform _root;
	
	public static bool Create()
	{
        InitializeRoot();
		InitializeMap();
        InitializeActor();
        InitializeCamera();
		return true;
	}
	
	public static bool Cleanup()
	{
		return true;
	}
    
    public static bool InitializeRoot()
    {
        _root = (new GameObject(GLOBALNAME)).transform;
        return true;
    }
	
	 /// <summary>
    /// Initializes the map.
    /// </summary>
    public static bool InitializeMap()
    {
		_map = new LocalMap();
        for (int i = 0; i < Resource.Data.mapNum.Count; ++i)
        {
            string tileName = Resource.Data.groundName[Resource.Data.mapNum[i]];
            var obj = CreateTile(tileName);
            
            _map.AddGround(obj.AddComponent<Ground>());
        }
        
        return _map.GetSize() > 0;
    }

    public static GameObject CreateTile(string tileName)
    {
        var prefabTile = Resource.Data.Load<GameObject>(GROUND_PATH);
        var tileMat = Resource.Data.Load<Material>(MATERIAL_PATH + tileName);
        var obj = GameObject.Instantiate(prefabTile);
        obj.GetComponent<MeshRenderer>().material = tileMat;
        obj.transform.SetParent(_root);

        return obj;
    }

    /// <summary>
    /// Initializes the actor.
    /// </summary>
    public static bool InitializeActor()
    {
        var prefabPawn = Resource.Data.Load<GameObject>(PAWN_PATH);
        var obj = GameObject.Instantiate(prefabPawn);
        obj.transform.localScale = new Vector3(TILE_SCALE, TILE_SCALE, TILE_SCALE);
        obj.transform.SetParent(_root);
        obj.AddComponent<Actor.Movable>().Init(0);
        
        return true;
    }

    public static void InitializeCamera()
    {
        var trans = Camera.main.transform;

        var center = _map.GetSize() / 5.0f / 2.0f;
        trans.position = new Vector3(center - 0.5f, center, -5);
        trans.eulerAngles = new Vector3(0, 0, 90);
    }
}