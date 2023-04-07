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
        float diffX = Mathf.Abs(playerPos.x - myPos.x); // �÷��̾���ġ - Ÿ�ϸ���ġ
        float diffY = Mathf.Abs(playerPos.y - myPos.y); // �÷��̾���ġ - Ÿ�ϸ���ġ

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1; // ������ �����̸� -1, �������̸� 1 �ο�
        float dirY = playerDir.y < 0 ? -1 : 1; // ������ �Ʒ����̸� -1, �����̸� 1 �ο�

        switch (transform.tag)
        {
            case "Ground":
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
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0));
                }
                break;
        }


    }
}
