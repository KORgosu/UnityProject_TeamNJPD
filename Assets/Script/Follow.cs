using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour // ü�°������� ĳ���͸� ���󰡴� Follow ��ũ��Ʈ
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

        // ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
        
    }
}
