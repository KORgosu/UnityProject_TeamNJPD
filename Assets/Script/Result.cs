using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject[] titles;

    public void Lose() //지면 타이틀 0(Dead...) 을 활성화 시키는 함수
    {
        titles[0].SetActive(true);
    }

    public void Win()// 이기면 타이틀 1(Survived!)를 활성화 시키는 함수
    {
        titles[1].SetActive(true);
    }


}
