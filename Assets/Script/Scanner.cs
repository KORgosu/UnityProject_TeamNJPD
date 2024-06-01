using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 스캔용 코드 - 원거리 자동공격을 위한 코드

public class Scanner : MonoBehaviour
{
    public float scanRange; // 스캔범위
    public LayerMask targetLayer; // 어떤 오브젝트를 스킨할 것인가?
    public RaycastHit2D[] targets; // 다수를 검색하기 위한 배열
    public Transform nearestTarget; // 가장 근접한 1마리의 몬스터 지정

    private void FixedUpdate() // 몬스터 스캔을 위한 함수
    {
        // 몬스터가 둥글게 있으면 검색됨
        targets = Physics2D.CircleCastAll(transform.position/*캐스팅 시작위치 */, scanRange /*반지름*/, Vector2.zero /*캐스팅방향*/, 0/*캐스팅길이*/, targetLayer/*대상레이어*/);
        nearestTarget = GetNearest();
    }

    Transform GetNearest() // 가장 가까운 몬스터 스캔, result에 해당 몬스터 저장
    {
        Transform result = null;
        float diff = 100; // 스캔 최소거리 100

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position; // 현재 플레이어 위치
            Vector3 targetPos = target.transform.position; // 타겟의 위치

            float curDiff = Vector3.Distance(myPos, targetPos); // 내 포지션과 타겟 포지션의 차이 구하기

            if (curDiff < diff) //  만약 타겟까지의 거리와 최소거리보다 더 작으면 최소거리 업데이트
            {
                diff = curDiff;
                result = target.transform;
            }
        }
        return result;
    }
}
