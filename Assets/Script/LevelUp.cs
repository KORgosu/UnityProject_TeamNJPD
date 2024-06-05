using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour // 레벨업 시 등장하는 화면 스케일을 조절해서 끄고, 키는 방식
{
    RectTransform rect;
    Item[] items; // 0. 시작시 기본 무기를 지급한다.
    

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true); // 0
    }

    
    public void Show() // 레벨업 보상 화면등장
    {
        Next();
        rect.localScale = Vector3.one;
        GameManager.instance.Stop(); // 시간 정지
        
    }

    public void Hide() // 레벨업 보상 화면없앰
    {
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume(); // 시간 재개
    }
    
    //0
    public void Select(int index) //버튼 대신 눌러주는 함수
    {
        items[index].OnClick();
    }

    void Next() // 1 아이템 선택시 랜덤선택하도록
    {
        //일단 모든 아이템을 비활성화하고
        foreach (Item item in items) {
            item.gameObject.SetActive(false);
        }

        //0번부터 4번중 아이템 3개를 랜덤 선택할 수 있도록 활성화
        int[] ran = new int[3];
        while (true) {
            ran[0] = Random.Range(0, items.Length);
            ran[1] = Random.Range(0, items.Length);
            ran[2] = Random.Range(0, items.Length);
            
            if (ran[0] != ran[1] && ran[1]!=ran[2] && ran[0] != ran[2])
                break;
        }

        for (int index=0; index < ran.Length; index++) {
            Item ranItem = items[ran[index]];

            // 맥스레벨 도달시 소비아이템으로 교체
            if (ranItem.level == ranItem.data.damages.Length) {
                items[index + 3].gameObject.SetActive(true);
            }
            else {
                ranItem.gameObject.SetActive(true); 
            }  
        }
    }
}
