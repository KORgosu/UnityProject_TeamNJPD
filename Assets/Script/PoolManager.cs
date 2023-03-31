using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Prefabs storage val
    public GameObject[] prefabs;


    // Pool storage List
    List<GameObject>[] pools;

    private void Awake() // Just 1 Time 
    {
        //prefab 개수랑 똑같이 초기화
        pools = new List<GameObject>[prefabs.Length];
        
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>(); 
        }

        Debug.Log(pools.Length);
    }
}
