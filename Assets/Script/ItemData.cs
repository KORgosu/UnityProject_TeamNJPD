using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject //다양한 데이터를 저장하는 에셋 SciptableObject 상속
{
    public enum ItemType { Melee, Range, Glove, Shoe, Heal }

    [Header("# Main Info")]
    public ItemType itemType;
    public int itemId;
    public string itemName;
    [TextArea] // <-- 인스펙터에 텍스트를 여러 줄 넣을 수 있는 명령어(Data-> Item -> Item Desc)
    public string itemDesc; // 아이템에 대한 설명
    public Sprite itemIcon; // 아이템의 아이콘 sprite 담기

    [Header("# Level Data")]
    public float baseDamage;
    public int baseCount;
    public float[] damages;
    public int[] counts;

    [Header("# Weapon")] //투사체 프리팹
    public GameObject projectile;
    public Sprite hand;

}
