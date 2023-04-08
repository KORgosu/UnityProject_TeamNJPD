using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ��ĵ�� �ڵ� - ���Ÿ� �ڵ������� ���� �ڵ�

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    private void FixedUpdate()
    {
        // ���Ͱ� �ձ۰� ������ �˻���
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = GetNearest();
    }

    Transform GetNearest() // ���� ����� ���� ��ĵ
    {
        Transform result = null;
        float diff = 100; // ��ĵ �ּҰŸ� 100

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position; // ���� �÷��̾� ��ġ
            Vector3 targetPos = target.transform.position; // Ÿ���� ��ġ

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
