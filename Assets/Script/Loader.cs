using UnityEngine;

public class Loader : MonoBehaviour
{    
    // Use this for initialization
    void Start()
    {
        Resource.Data.Create();        
        Global.Create();
        UI.Manager.CreateStartUI();

        GameObject obj = new GameObject("InputMgr");
        obj.AddComponent<Control.Manager>();
    }
}
