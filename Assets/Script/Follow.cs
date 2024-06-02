using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour // 체력게이지가 캐릭터를 따라가는 Follow 스크립트
{
    RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    
    void FixedUpdate()
    {
        if (rect == null)
        {
            Debug.LogError("RectTransform not found in Follow script");
            return;
        }

        // 월드 좌표를 스크린 좌표로 변환
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
        
    }
}
