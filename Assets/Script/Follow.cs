using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
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
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
    }
}
