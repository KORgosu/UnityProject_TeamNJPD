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
        //prefab ������ �Ȱ��� �ʱ�ȭ
        pools = new List<GameObject>[prefabs.Length];
        
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>(); 
        }
    }

    public GameObject Get(int i)
    {
        GameObject select = null;

        foreach (GameObject item in pools[i])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(prefabs[i], transform);
            pools[i].Add(select);
        }

        return select;
    }
}
