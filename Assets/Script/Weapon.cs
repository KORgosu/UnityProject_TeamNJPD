using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapon : MonoBehaviour
{
    public int id;// 
    public int prefabID; //
    public float damage; // 
    public int count; // 
    public float speed; //

    float timer;
    Player player;

    void Awake()
    {
        player = GameManager.instance.player;
    }

    void Update()
    {
        /*
        if (!GameManager.instance.isLive)
            return;
        */
            
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                timer += Time.deltaTime;

                if (timer > speed)
                {
                    timer = 0f;
                    Fire();
                }
                break;
        }

        if (Input.GetButtonDown("Jump"))
        {
            LevelUp(10, 1);
        }
    }

    public void LevelUp(float damage, int count) // 레벨업할때마다 공격력과 무기개수 증가
    {
        this.damage = damage;
        this.count += count;

        if (id == 0)  
            Batch();


        player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver); // 무기가 업그레이드 될 때
        
    }
    

    public void Init(ItemData data)
    {
        
        // Basic Set
        name = "Weapon " + data.itemId;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;


        // Property Set <-- 무기 속성 변수를 스크립터블 오브젝트 데이터로 초기화
        id = data.itemId;
        damage = data.baseDamage; // 초반 대미지
        count = data.baseCount; // 초반 총탄개수

        // 프리팹에 넣기
        for (int index=0; index < GameManager.instance.pool.prefabs.Length; index++) {
            if (data.projectile == GameManager.instance.pool.prefabs[index]) {
                prefabID = index;
                break;
            }
        }

        switch(id)
        {
            case 0:
                speed = -150; 
                Batch();
                break;
            default:
                speed = 1.0f; // 원거리무기 연사속도
                break;
        }

        player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver); // 무기가 새로 생성될 때 

    }

    void Batch() // 무기배치함수
    {
        for (int i = 0; i < count; i++)
        {
            Transform bullet;

            if (i < transform.childCount) // 가지고있는 자식의 개수(무기의 개수)
            {
                bullet = transform.GetChild(i); // GetChild 함수로 bullet 가져오기
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabID).transform; // Weapon 0으로
                bullet.parent = transform; // 자식 오브젝트 들어감
            }
                
            bullet.localPosition = Vector3.zero; // bullet 위치를 플레이어 초기화
            bullet.localRotation = Quaternion.identity; // 회전값도 초기화

            Vector3 rotateVector = Vector3.forward * 360 * i / count; // 근접무기 뺑뺑이 각도 설정
            bullet.Rotate(rotateVector); // 근접무기 회전
            bullet.Translate(bullet.up * 1.4f, Space.World); // 무기가 배치될 곳은 캐릭터로부터 1.4 공간
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); //  : -1 is infinity per.
        }
    }

    void Fire()
    {
        if (!player.scanner.nearestTarget)
        {
            return;
        }

        // 적을 향해 총알의 탄두가 바라보기
        Vector3 targetPos = player.scanner.nearestTarget.position; // 위치
        Vector3 dir = targetPos - transform.position;                           // 방향
        dir = dir.normalized;                                                                       // 벡터크기 유지

        Transform bullet = GameManager.instance.pool.Get(prefabID).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);   // 축을 중심으로 목표를 향해 총알을 회전

        bullet.GetComponent<Bullet>().Init(damage, count, dir); // 초기화함수
    }
}
