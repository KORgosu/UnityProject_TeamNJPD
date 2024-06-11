using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) // Area �� �ƴϸ� return
        {
            return;
        }
        // �÷��̾� ��ġ�� Area ��ġ ��
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        

        switch (transform.tag)
        {
            case "Ground":
                float diffX = playerPos.x - myPos.x; // �÷��̾���ġ - Ÿ�ϸ���ġ -> ����
                float diffY = playerPos.y - myPos.y; // �÷��̾���ġ - Ÿ�ϸ���ġ -> ����
                float dirX = diffX < 0 ? -1 : 1; // ������ �����̸� -1, �������̸� 1 �ο�
                float dirY = diffY < 0 ? -1 : 1; // ������ �Ʒ����̸� -1, �����̸� 1 �ο�
                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);
                if (diffX > diffY) // x ������ �̵��ϰԵǸ� ���� x������ ��������
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY) // x ������ �̵��ϰԵǸ� ���� y�� �������� ��������
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;

            case "Enemy":
                if (coll.enabled)
                {
                    Vector3 distance = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3, 3), 0);
                    transform.Translate(ran + distance * 2);
                }
                break;
        }


    }
}
