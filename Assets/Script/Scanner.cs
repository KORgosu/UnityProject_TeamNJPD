using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ��ĵ�� �ڵ� - ���Ÿ� �ڵ������� ���� �ڵ�

public class Scanner : MonoBehaviour
{
    public float scanRange; // ��ĵ����
    public LayerMask targetLayer; // � ������Ʈ�� ��Ų�� ���ΰ�?
    public RaycastHit2D[] targets; // �ټ��� �˻��ϱ� ���� �迭
    public Transform nearestTarget; // ���� ������ 1������ ���� ����

    private void FixedUpdate() // ���� ��ĵ�� ���� �Լ�
    {
        // ���Ͱ� �ձ۰� ������ �˻���
        targets = Physics2D.CircleCastAll(transform.position/*ĳ���� ������ġ */, scanRange /*������*/, Vector2.zero /*ĳ���ù���*/, 0/*ĳ���ñ���*/, targetLayer/*����̾�*/);
        nearestTarget = GetNearest();
    }

    Transform GetNearest() // ���� ����� ���� ��ĵ, result�� �ش� ���� ����
    {
        Transform result = null;
        float diff = 100; // ��ĵ �ּҰŸ� 100

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position; // ���� �÷��̾� ��ġ
            Vector3 targetPos = target.transform.position; // Ÿ���� ��ġ

            float curDiff = Vector3.Distance(myPos, targetPos); // �� �����ǰ� Ÿ�� �������� ���� ���ϱ�

            if (curDiff < diff) //  ���� Ÿ�ٱ����� �Ÿ��� �ּҰŸ����� �� ������ �ּҰŸ� ������Ʈ
            {
                diff = curDiff;
                result = target.transform;
            }
        }
        return result;
    }
}
