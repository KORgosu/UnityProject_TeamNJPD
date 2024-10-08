using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) // Area 가 아니면 return
        {
            return;
        }
        // 플레이어 위치와 Area 위치 비교
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        

        switch (transform.tag)
        {
            case "Ground":
                float diffX = playerPos.x - myPos.x; // 플레이어위치 - 타일맵위치 -> 방향
                float diffY = playerPos.y - myPos.y; // 플레이어위치 - 타일맵위치 -> 방향
                float dirX = diffX < 0 ? -1 : 1; // 방향이 왼쪽이면 -1, 오른쪽이면 1 부여
                float dirY = diffY < 0 ? -1 : 1; // 방향이 아래쪽이면 -1, 위쪽이면 1 부여
                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);
                if (diffX > diffY) // x 축으로 이동하게되면 맵을 x축으로 넓혀야함
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY) // x 축으로 이동하게되면 맵을 y축 방향으로 넓혀야함
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;

            case "Enemy":
                if (coll.enabled)
                {
                    Vector3 distance = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3, 3), 0);
                    transform.Translate(ran + distance * 2);
                }
                break;
        }


    }
}
