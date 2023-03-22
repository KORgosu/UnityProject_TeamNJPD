using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour // 게임로직 구성에 필요한 클래스
{
    public Vector2 inputVec; // 변수타입 : Vector2, 변수명 inputVec
    public float speed;
    Rigidbody2D rigid;

    void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>(); // 리지드바디2D 컴포넌트 가져오기
    }

    void Update()
    {
        // X축, Y축 움직임
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() // 물리연산 프레임에 필요
    {
        //rigid.AddForce(inputVec); // 힘 ++
        //rigid.velocity = inputVec; // 속도제어

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; // 물리프레임 하나가 소비된 시간
        rigid.MovePosition(rigid.position + nextVec); // 위치이동


    }

}
