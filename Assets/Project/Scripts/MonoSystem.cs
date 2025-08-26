using System;
using UnityEngine;

public class MonoSystem : MonoBehaviour
{
    protected virtual void Awake()
    {
        G.Services.Add(this);
    }
}
