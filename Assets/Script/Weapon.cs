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

    private void Start()
    {
        Init(); // �����ʱ�ȭ
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
                speed = 150; // - ��ȣ�� �ؾ� �ð�������� ������
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
            bullet.GetComponent<Bullet>().Init(damage, -1); // �������� ���� : -1 is infinity per.
        }
    }
}
