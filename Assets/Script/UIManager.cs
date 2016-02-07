using UnityEngine;

namespace UI {
    public static class UIManager {
        private const string UIPATH = "Prefab/UI/";
        
        enum FEATURE {
            Button,
        }
        public static void CreateStartUI()
        {
            GameObject prefab = Manager.Action.Load<GameObject>(UIPATH + FEATURE.Button);
            
            GameObject.Instantiate(prefab);
        }
    }
}