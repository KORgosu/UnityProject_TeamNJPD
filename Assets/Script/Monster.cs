using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed; // 속도
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target; // 타겟 설정    

    bool isLive = true; // 살아있는지 

    Rigidbody2D rigid; // 물리 움직임 선언
    Collider2D coll; // 몬스터 충돌관련(사망 시 비활성화)
    Animator anim;
    SpriteRenderer spriter; //스프라이트 선언
    WaitForFixedUpdate wait;

    void Awake() //변수 초기화
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        wait = new WaitForFixedUpdate();
    }


    void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) // 넉백발생 효과
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }
    void LateUpdate() {
        if (!GameManager.instance.isLive)
            return;
            
        if (!isLive)
            return;      
        spriter.flipX = target.position.x < rigid.position.x;     
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        coll.enabled = true; // 물리적 활성화
        rigid.simulated = true; // 물리적 활성화
        spriter.sortingOrder = 2; // Order in Layer 값 증가
        anim.SetBool("Dead", false); // 생존상태로 전환
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 몬스터가 무기랑 충돌할때만
        if (!collision.CompareTag("Bullet") || !isLive) // Bullet이랑 충돌한게 아니면, !isLive -> 사망로직이 연달아 실행되는 것 방지
        {
            return;
        }

         //무기에 맞으면 몬스터 체력이 깎이는 함수임
         //몬스터 체력부분 구현되면 주석제거 예정
        health -= collision.GetComponent<Bullet>().damage; // 피격 계산하기
        StartCoroutine(KnockBack()); // 코루틴 실행

        if (health > 0)
        {
            // 몬스터가 생존했는데 타격할 시, Hit 애니메이션(흰색효과)
            anim.SetTrigger("Hit");
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit); // 몬스터 타격시 SFX 재생
        }
        else
        {
            // 몬스터 사망
            isLive = false;
            coll.enabled = false; // 물리적 비활성화
            rigid.simulated = false; // 물리적 비활성화 리지드바디의 경우 simulated로
            spriter.sortingOrder = 1; // Inspector -> Sprite Layer의 OrderLayer 감소
            anim.SetBool("Dead", true); // 사망상태로 전환
            GameManager.instance.kill++;
            GameManager.instance.GetExp();

            if (GameManager.instance.isLive == true) // EnemyCleaner 사용시 sfx 재생 X
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Dead); // 몬스터 처치시 SFX 재생
        }

        //코루틴 (넉백함수), OnTriggerEnter2D 에 사용
        IEnumerator KnockBack()
        {
            yield return wait; // 1 프레임 딜레이
            Vector3 playerPos = GameManager.instance.player.transform.position;
            Vector3 dirVec = transform.position - playerPos;
            rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse); // 즉발적으로 (Impulse) 넉백
            
        }

        
        void Dead()
        {
            gameObject.SetActive(false); // 비활성화
        }

    }



}
