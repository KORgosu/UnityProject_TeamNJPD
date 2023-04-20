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

    public GameObject Get(int i) // 
    {
        GameObject select = null;

        foreach (GameObject item in pools[i])
        {
            if(!item.activeSelf)//�������� ��Ȱ��ȭ ���¸�
            {
                select = item;
                select.SetActive(true); // Ȱ��ȭ�� ��ȯ
                break;
            }
        }

        if (select == null) // ���� select ������ �ƹ��͵� ������
        {
            // ���� ������Ʈ �����ؼ� ------------------>
            select = Instantiate(prefabs[i], transform/*�ڱ��ڽſ� ����*/);
            pools[i].Add(select); // pool���� ����ϱ�
        }

        return select;
    }
}
