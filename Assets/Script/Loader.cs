using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{    
    // Use this for initialization
    void Start()
    {
        Manager.Resource.Create();        
        Global.Create();

        GameObject obj = new GameObject("InputMgr");
        obj.AddComponent<Control.Manager>();
    }
}
