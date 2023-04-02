using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    public Vector2 inputVec; // ����Ÿ�� : Vector2, ������ inputVec
    public float speed; // 이동 속도

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // ������ٵ�2D ������Ʈ ��������
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
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
    void LateUpdate()
    { anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {   
            spriter.flipX = inputVec.x < 0;
        }
    }

}

