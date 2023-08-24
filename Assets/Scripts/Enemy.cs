using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action OnCollidedWithEnemy;

    private void OnCollisionEnter(Collision collision)
    {
        OnCollidedWithEnemy?.Invoke();
    }
}
