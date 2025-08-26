using UnityEngine;

public class Camp : MonoSystem
{
    private void Start()
    {
        G.Get<Camp>().Check();
    }

    public void Check()
    {
        Debug.Log("Check camp");
    }
}
