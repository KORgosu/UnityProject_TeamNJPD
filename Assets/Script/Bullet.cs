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
    public void Init(float damage, int per, Vector3 dir) // per는 관통임
    {
        this.damage = damage;
        this.per = per;

        if (per >= 0) // 만약 원거리무기라면
        {
            rigid.velocity = dir * 15f; // 총알 속도관련
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // 관통관련 컨트롤
    {
        // 충돌한게 몬스터가 아니거나, 근접무기의 경우 아무것도 하지않음
        if (!collision.CompareTag("Monster") || per == -100)
        {
            return;
        }
        per--;

        if (per < 0) // 몬스터에게 맞으면 Object 삭제
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area") || per == -100) // 원거리 무기인데, 플레이어 Area의 범위에서 벗어난 경우 그거 삭제함
        {
            return;
        }
        gameObject.SetActive(false);
    }
}
