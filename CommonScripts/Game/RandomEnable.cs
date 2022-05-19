using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnable : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjects;

    private void Start()
    {
        SetRandomEnable();
    }

    public void SetRandomEnable()
    {
        var rand = gameObjects.GetRandomIndex();

        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(i == rand);
        }
    }
}
