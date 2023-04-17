using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Transform playerTransform;
    public UnityEvent OnDeath;

    private void Awake()
    {
        playerTransform = transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            OnDeath?.Invoke();
        }
    }
}
