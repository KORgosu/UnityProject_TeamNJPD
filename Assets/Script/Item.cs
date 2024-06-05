using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData data;
    public int level;
    public Weapon weapon; 
    public Gear gear;

    Image icon;
    Text textLevel;
    Text textName;
    Text textDesc;

    void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon;
  
        Text[] texts = GetComponentsInChildren<Text>();

        // 계층구조 순서 주의
        textLevel = texts[0];
        textName = texts[1];
        textName.text = data.itemName; // 초기화
        textDesc = texts[2];
    }
    
    void OnEnable() //활성화 되었을때 자동으로 발동. 아이템 텍스트 레벨, 퍼센트 나타나게 해주는 함수  
    {    
        textLevel.text = "Lv." + (level + 1); // LV 1부터 시작

        switch (data.itemType)
        {
            case ItemData.ItemType.Melee:
            case ItemData.ItemType.Range:
                textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100 , data.counts[level]);
                break;
            case ItemData.ItemType.Glove:
            case ItemData.ItemType.Shoe:
                textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100);
                break;
            default:
                textDesc.text = string.Format(data.itemDesc);
                break;
        }

        
    }
    
    public void OnClick() // 버튼을 누를 시 어떤 상황이 발생하는가
    {
        switch (data.itemType) {
            case ItemData.ItemType.Melee: // 근접
            case ItemData.ItemType.Range: // 원거리, 근접과 원거리는 붙여둠
               // 무기생성 
               if (level == 0) {
                   GameObject newWeapon = new GameObject();
                   weapon = newWeapon.AddComponent<Weapon>();
                   weapon.Init(data);
               }          
               else {
                // 레벨 올라가면 대미지 상승
                   float nextDamage = data.baseDamage;
                   int nextCount = 0;

                   nextDamage += data.baseDamage * data.damages[level];
                   nextCount += data.counts[level];

                    // weapon 에 다음 대미지, 카운트 적용
                   weapon.LevelUp(nextDamage, nextCount);
               }
                break;

            case ItemData.ItemType.Glove:
            case ItemData.ItemType.Shoe:
                if (level == 0){  
                    GameObject newGear = new GameObject();
                    gear = newGear.AddComponent<Gear>();
                    gear.Init(data);
                } 
                else {
                    float nextRate = data.damages[level];
                    gear.LevelUp(nextRate);
                }

                break;
            case ItemData.ItemType.Heal:
                /*
                GameManager.instance.health = GameManager.instance.maxHealth;
                */
                break;          
       
        }

        level++;

        if (level == data.damages.Length){ // 최대레벨에 도달시, 아이템의 버튼의 Interactive 끄기
            GetComponent<Button>().interactable = false;
        }
    }
}
