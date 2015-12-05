using UnityEngine;

public class Ground : MonoBehaviour, Control.IClickable
{
    private int _pos;
    public int type { set; get; }
    public Material mat { set; get; }

    public void Init(int pos)
    {
        _pos = pos;
    }

    public void OnSelected()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void OnReleased(int pos)
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
    
    public int GetPos()
    {
        return _pos;
    }
}

