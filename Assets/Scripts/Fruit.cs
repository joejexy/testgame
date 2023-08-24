using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public static event Action OnCollidedWithFruit;

    private void OnCollisionEnter(Collision collision)
    {
        OnCollidedWithFruit?.Invoke();
    }
}
