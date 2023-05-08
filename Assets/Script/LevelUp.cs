using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Item[] items;
    

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
    }

    
    public void Show()
    {
        Next();
        rect.localScale = Vector3.one;
        GameManager.instance.Stop();
        
    }

    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
    }
    
    public void Select(int index) //버튼 대신 눌러주는 함수
    {
        items[index].OnClick();
    }

    void Next()
    {
        //1 모든 아이템 비활성화
        foreach (Item item in items) {
            item.gameObject.SetActive(false);
        }

        //2. 그 중 랜덤 아이템 3개 활성화
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

            //3. 맥스레벨 도달시 소비아이템으로 교체
            if (ranItem.level == ranItem.data.damages.Length) {
                items[index + 3].gameObject.SetActive(true);
            }
            else {
                ranItem.gameObject.SetActive(true); 
            }  
        }
    }
}
