using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed; // 속도
    public Rigidbody2D target; // 타겟 설정    

    bool isLive = true; // 살아있는지 

    Rigidbody2D rigid; // 물리 움직임 선언
    SpriteRenderer spriter; //스프라이트 선언

    void Awake() //변수 초기화
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();

    }


    void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        
        //���� �ʱ�ȭ
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }
    void LateUpdate() {
        if (!isLive)
            return;
    
        
        spriter.flipX = target.position.x < rigid.position.x;
        
    }
    




}
