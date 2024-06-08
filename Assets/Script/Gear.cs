using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemType type;
    public float rate;

    public void Init(ItemData data)
    {
        // Basic Set
        name = "Gear " + data.itemId;
        transform.parent = GameManager.instance.player.transform;
        transform.localPosition = Vector3.zero;


        // Property Set
        type = data.itemType;
        rate = data.damages[0];
        ApplyGear(); 

    }

    public void LevelUp(float rate) //장비 레벨업 관련 함수
    {
        this.rate = rate; //현재 들어온 rate를 새롭게 들어온 rate로 갱신
        ApplyGear();
    }



    void ApplyGear() // 타입에 따라 적절한 로직을 적용시켜주는 함수
    {
        switch (type) {
            case ItemData.ItemType.Glove:
                RateUp();
                break;
            case ItemData.ItemType.Shoe:
                SpeedUp();
                break;
        }
    }

    void RateUp() //연사력 올리는 함수
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach(Weapon weapon in weapons) {
            switch(weapon.id) {
                case 0: //근접무기
                    weapon.speed = 150 + (150 * rate);
                    break;
                default: //원거리 무기
                    float speed = 0.5f * Character.LongShotWeaponSpeed;
                    weapon.speed = 0.5f * (1f - rate);
                    break;
            }
        }
    }

    void SpeedUp() //장화 이동속도 올리기
    {
        float speed = 3 * Character.MovingSpeed;
        GameManager.instance.player.speed = speed + speed * rate;

    }


}
