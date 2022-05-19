using System.Collections.Generic;
using UnityEngine;

public static class RandomExt
{
    public static float GetRandom(this float value)
    {
        return Random.Range(-value, value);
    }

    public static Vector2 GetRandom(this Vector2 value)
    {
        return new Vector2(value.x.GetRandom(), value.y.GetRandom());
    }

    public static Vector3 GetRandom(this Vector3 value)
    {
        return new Vector3(value.x.GetRandom(), value.y.GetRandom(), value.z.GetRandom());
    }

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static T GetRandom<T>(this T[] list)
    {
        return list[Random.Range(0, list.Length)];
    }

    public static int GetRandomIndex<T>(this List<T> list)
    {
        return Random.Range(0, list.Count);
    }

    public static int GetRandomIndex<T>(this T[] list)
    {
        return Random.Range(0, list.Length);
    }
}
