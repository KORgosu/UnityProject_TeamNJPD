using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Init(float damage, int per, Vector3 dir) // per�� ������
    {
        this.damage = damage;
        this.per = per;

        if (per >= 0) // ���� ���Ÿ�������
        {
            rigid.velocity = dir * 15f; // �Ѿ� �ӵ�����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // ������� ��Ʈ��
    {
        // �浹�Ѱ� ���Ͱ� �ƴϰų�, ���������� ��� �ƹ��͵� ��������
        if (!collision.CompareTag("Monster") || per == -100)
        {
            return;
        }
        per--;

        if (per < 0) // ���Ϳ��� ������ Object ����
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area") || per == -100) // ���Ÿ� �����ε�, �÷��̾� Area�� �������� ��� ��� �װ� ������
        {
            return;
        }
        gameObject.SetActive(false);
    }
}
