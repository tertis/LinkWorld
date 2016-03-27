using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
    public static class Manager {
        private const string UIPATH = "Prefab/UI/";
        
        enum FEATURE {
            Button,
        }
        public static void CreateStartUI()
        {
            GameObject prefab = global::Resource.Data.Load<GameObject>(UIPATH + FEATURE.Button);
            
            GameObject.Instantiate(prefab);
        }
        
        public static bool NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return true;
        }
    }
}