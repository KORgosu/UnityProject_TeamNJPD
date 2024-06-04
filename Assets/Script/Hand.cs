using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour // 무기를 쥐고 있는 손 방향 바꾸기
{
    public bool isLeft; // Inspector 에서 체크할것
    public SpriteRenderer spriter;

    SpriteRenderer player;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0); // 안바꿨을때(오른쪽볼때)
    Vector3 rightPosReverse = new Vector3(-0.15f, -0.15f, 0); // 바꿨을때 (왼쪽볼때) 총구 돌림
    Quaternion leftRot = Quaternion.Euler(0, 0, -35);
    Quaternion leftRotReverse = Quaternion.Euler(0, 0, -135);

    private void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];
    }

    private void LateUpdate()
    {
        bool isReverse = player.flipX; // spriterenderer player -> filp함

        if (isLeft) // 근접무기 회전
        {
            transform.localRotation = isReverse ? leftRotReverse : leftRot;
            spriter.flipY = isReverse;
            spriter.sortingOrder = isReverse ? 4 : 6; // sorting layer 바꿔주기
        }
        else // 원거리무기 반전
        {
            transform.localPosition= isReverse ? rightPosReverse : rightPos;
            spriter.flipX = isReverse;
            spriter.sortingOrder = isReverse ? 6 : 4; // sorting layer 바꿔주기
        }
    }
}
