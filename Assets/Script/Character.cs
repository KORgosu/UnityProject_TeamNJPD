using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour // ���� ���۽� �÷��̾ ���� Ư���� ������.
{
    public static float AttackDamage
    {
        get { return GameManager.instance.playerId == 0 ? 1.1f  : 1f; }
    }

    public static float MovingSpeed
    {
        get { return GameManager.instance.playerId == 1 ? 1.1f : 1f; }
    }

    public static float LongShotWeaponSpeed
    {
        get { return GameManager.instance.playerId == 1 ? 0.5f : 1f; }
    }

}