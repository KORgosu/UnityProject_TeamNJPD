using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;// ���� ID
    public int prefabID; // prefab Id
    public float damage; // damage
    public int count; // weapon ���� ���ġ?
    public float speed; // cycle speed

    float timer;
    Player player;

    private void Awake()
    {
        player = GameManager.instance.player;
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;
            
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
                    FireBullet();
                }
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
        damage = data.baseDamage;
        count = data.baseCount;

        for (int index=0; index < GameManager.instance.pool.prefabs.Length; index++) {
            if (data.projectile == GameManager.instance.pool.prefabs[index]) {
                prefabID = index;
                break;
            }
        }




        switch(id)
        {
            case 0:
                speed = 150; // - ��ȣ�� �ؾ� �ð�������� ������
                Batch();
                break;
            default:// ���Ÿ�
                speed = 2.5f; // �߻�ӵ� 
                break;
        }

        player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver); // 무기가 새로 생성될 때 

    }

    void Batch()
    {
        for (int i = 0; i < count; i++)
        {
            // �θ� PoolManager -> Weapon0 ���� �ٲٱ�
            Transform bullet;

            if (i < transform.childCount)
            {
                bullet = transform.GetChild(i);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabID).transform;
                bullet.parent = transform; // �θ� Weapon 0���� ����
            }
                
            bullet.localPosition = Vector3.zero; // �÷��̾��� ��ġ�� ��ȯ��ġ �ʱ�ȭ
            bullet.localRotation = Quaternion.identity;

            Vector3 rotateVector = Vector3.forward * 360 * i / count;
            bullet.Rotate(rotateVector);
            bullet.Translate(bullet.up * 1.4f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); // �������� ���� : -1 is infinity per.
        }
    }

    void FireBullet()
    {
        if (!player.scanner.nearestTarget) // �����̿� ��������� ������ �ƹ��ϵ� ����
        {
            return;
        }

        Vector3 targetPos = player.scanner.nearestTarget.position; // Ÿ���� ��ġ�� �÷��̾ ���� ����� ����
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = GameManager.instance.pool.Get(prefabID).transform;
        bullet.position = transform.position;

        //ȸ������
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(damage, count, dir);
    }
}
