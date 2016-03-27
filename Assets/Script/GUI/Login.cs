using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
    public bool OnClickLogin()
    {
        return UI.Manager.NextLevel();
    }
}
