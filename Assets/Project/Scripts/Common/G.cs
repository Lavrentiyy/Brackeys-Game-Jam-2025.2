using UnityEngine;

public static class G
{
    public static ServiceLocator Services;

    public static T Get<T>()
    {
        return Services.Get<T>();
    }
}
