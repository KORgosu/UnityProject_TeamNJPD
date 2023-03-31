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
    }

    public GameObject Get(int i) // 
    {
        GameObject select = null;

        foreach (GameObject item in pools[i])
        {
            if(!item.activeSelf)//아이템이 비활성화 상태면
            {
                select = item;
                select.SetActive(true); // 활성화로 전환
                break;
            }
        }

        if (select == null) // 만약 select 변수에 아무것도 없으면
        {
            // 원본 오브젝트 복제해서 ------------------>
            select = Instantiate(prefabs[i], transform/*자기자신에 넣음*/);
            pools[i].Add(select); // pool에도 등록하기
        }

        return select;
    }
}
