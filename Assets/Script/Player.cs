using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
    public Vector2 inputVec; // ����Ÿ�� : Vector2, ������ inputVec
    public float speed; // 이동 속도
    public Scanner scanner;
    public Hand[] hands; // 양손이니깐 배열로
    public RuntimeAnimatorController[] animCon;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;
    

    void Awake() // 초기화
    {
        rigid = GetComponent<Rigidbody2D>(); 
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }


    void OnEnable() // 캐릭터 애니메이터 변경로직
    {
        anim.runtimeAnimatorController = animCon[GameManager.instance.playerId];
    }
    

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() 
    {
        if (!GameManager.instance.isLive)
            return;

        //rigid.AddForce(inputVec); 
        //rigid.velocity = inputVec; 

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec); 


    }
    void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return; 
            
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {   
            spriter.flipX = inputVec.x < 0;
        }
    }

    void OnCollisionStay2D(Collision2D collision) // 몬스터와 부딪힐 시 상호작용(체력감소)
    {
        if (!GameManager.instance.isLive)
            return;

        GameManager.instance.health -= Time.deltaTime * 10; //플레이어 체력 줄어드는 주기기

        if (GameManager.instance.health < 0) // 플레이어 체력이 0보다 낮으면
        {
            for (int index=2; index < transform.childCount; index++) { // 캐릭터 자식 오브젝트들 비활성화
                transform.GetChild(index).gameObject.SetActive(false);
            }
            anim.SetTrigger("Dead"); //사망 애니메이션 활성화
            GameManager.instance.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ExpItem"))//TestItem 태그를 가진 아이템과 충돌할시 작동
        {
            Transform itemAreaTransform = transform.Find("ItemArea");//ItemaArea 이름을 가진 자식객체의 콜라이더를 사용

            if (itemAreaTransform != null && collision.IsTouching(itemAreaTransform.GetComponent<Collider2D>()))
            {
                GameManager.instance.GetExp();
                Destroy(collision.gameObject);
            }
        }
    }
}

