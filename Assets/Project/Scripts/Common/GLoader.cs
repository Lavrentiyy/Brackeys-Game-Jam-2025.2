using UnityEngine;

[DefaultExecutionOrder(-99999)]
public class GLoader : MonoBehaviour
{
    private void Awake()
    {
        G.Services = new ServiceLocator();
    }
}
