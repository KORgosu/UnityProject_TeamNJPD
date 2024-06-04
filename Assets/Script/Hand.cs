using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour // ���⸦ ��� �ִ� �� ���� �ٲٱ�
{
    public bool isLeft; // Inspector ���� üũ�Ұ�
    public SpriteRenderer spriter;

    SpriteRenderer player;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0); // �ȹٲ�����(�����ʺ���)
    Vector3 rightPosReverse = new Vector3(-0.15f, -0.15f, 0); // �ٲ����� (���ʺ���) �ѱ� ����
    Quaternion leftRot = Quaternion.Euler(0, 0, -35);
    Quaternion leftRotReverse = Quaternion.Euler(0, 0, -135);

    private void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];
    }

    private void LateUpdate()
    {
        bool isReverse = player.flipX; // spriterenderer player -> filp��

        if (isLeft) // �������� ȸ��
        {
            transform.localRotation = isReverse ? leftRotReverse : leftRot;
            spriter.flipY = isReverse;
            spriter.sortingOrder = isReverse ? 4 : 6; // sorting layer �ٲ��ֱ�
        }
        else // ���Ÿ����� ����
        {
            transform.localPosition= isReverse ? rightPosReverse : rightPos;
            spriter.flipX = isReverse;
            spriter.sortingOrder = isReverse ? 6 : 4; // sorting layer �ٲ��ֱ�
        }
    }
}
