using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 스캔용 코드 - 원거리 자동공격을 위한 코드

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    private void FixedUpdate()
    {
        // 몬스터가 둥글게 있으면 검색됨
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = GetNearest();
    }

    Transform GetNearest() // 가장 가까운 몬스터 스캔
    {
        Transform result = null;
        float diff = 100; // 스캔 최소거리 100

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position; // 현재 플레이어 위치
            Vector3 targetPos = target.transform.position; // 타겟의 위치

            float posDiff = Vector3.Distance(myPos, targetPos); // 

            if (posDiff < diff) // 
            {
                diff = posDiff;
                result = target.transform;
            }
        }
        return result;
    }
}
