using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))//점프버튼을 누르면
        {
            GameManager.instance.pool.Get(0);
        }
    }
}
