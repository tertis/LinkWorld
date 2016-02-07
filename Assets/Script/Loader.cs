using UnityEngine;

public class Loader : MonoBehaviour
{    
    // Use this for initialization
    void Start()
    {
        Manager.Resource.Create();        
        Global.Create();
        UI.UIManager.CreateStartUI();

        GameObject obj = new GameObject("InputMgr");
        obj.AddComponent<Control.Manager>();
    }
}
