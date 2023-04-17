using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int points;
    [SerializeField] protected ParticleSystem damageParticles;

    private Transform target;

    private void Start()
    {
        target = Player.playerTransform;
    }

    protected void Move()
    {
        transform.Translate(speed * Time.deltaTime * (target.position - transform.position).normalized);
    }

    private void Update()
    {
        Move();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Score.instance.ChangeScore(points);
    }

    public void TakeDamageEffects()
    {
        damageParticles.Play();
    }
}
