using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour // ���ӷ��� ������ �ʿ��� Ŭ����
{
    public Vector2 inputVec; // ����Ÿ�� : Vector2, ������ inputVec
    public float speed;
    Rigidbody2D rigid;

    void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>(); // ������ٵ�2D ������Ʈ ��������
    }

    void Update()
    {
        // X��, Y�� ������
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() // �������� �����ӿ� �ʿ�
    {
        //rigid.AddForce(inputVec); // �� ++
        //rigid.velocity = inputVec; // �ӵ�����

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; // ���������� �ϳ��� �Һ�� �ð�
        rigid.MovePosition(rigid.position + nextVec); // ��ġ�̵�


    }

}
