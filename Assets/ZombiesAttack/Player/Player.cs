using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Transform playerTransform;
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        playerTransform = transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            uiManager.GameOver();
        }
    }
}
