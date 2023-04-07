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
        float diffX = Mathf.Abs(playerPos.x - myPos.x); // 플레이어위치 - 타일맵위치
        float diffY = Mathf.Abs(playerPos.y - myPos.y); // 플레이어위치 - 타일맵위치

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1; // 방향이 왼쪽이면 -1, 오른쪽이면 1 부여
        float dirY = playerDir.y < 0 ? -1 : 1; // 방향이 아래쪽이면 -1, 위쪽이면 1 부여

        switch (transform.tag)
        {
            case "Ground":
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
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0));
                }
                break;
        }


    }
}
