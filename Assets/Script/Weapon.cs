using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;// 무기 ID
    public int prefabID; // prefab Id
    public float damage; // damage
    public int count; // weapon 개수 몇개배치?
    public float speed; // cycle speed

    private void Start()
    {
        Init(); // 변수초기화
    }

    // Update is called once per frame
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }

        if (Input.GetButtonDown("Jump"))
        {
            LevelUp(20, 5);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id == 0)
        {
            Batch();
        }
    }
    

    public void Init()
    {
        switch(id)
        {
            case 0:
                speed = 150; // - 부호로 해야 시계방향으로 돌거임
                Batch();
                break;
            default:
                break;
        }
    }

    void Batch()
    {
        for (int i = 0; i < count; i++)
        {
            // 부모를 PoolManager -> Weapon0 으로 바꾸기
            Transform bullet;

            if (i < transform.childCount)
            {
                bullet = transform.GetChild(i);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabID).transform;
                bullet.parent = transform; // 부모를 Weapon 0으로 설정
            }
                
            bullet.localPosition = Vector3.zero; // 플레이어의 위치로 소환위치 초기화
            bullet.localRotation = Quaternion.identity;

            Vector3 rotateVector = Vector3.forward * 360 * i / count;
            bullet.Rotate(rotateVector);
            bullet.Translate(bullet.up * 1.4f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1); // 무한으로 관통 : -1 is infinity per.
        }
    }
}
