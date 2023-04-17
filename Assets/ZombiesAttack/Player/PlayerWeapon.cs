using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private float projectileVelocity;
    [SerializeField] private int damage;

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), 0, 1 / shootingSpeed);
    }

    public void Shoot()
    {
        ObjectPooler.instance.Spawn("Bullet", firePoint.position, firePoint.rotation).GetComponent<Projectile>().Set(projectileVelocity, damage, "Enemy");
    }

    private void RotateWeapon()
    {
        Vector2 lookDir = Camera.main.ScreenToWorldPoint(Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1;
        }
        else
        {
            localScale.y = 1;
        }
        transform.localScale = localScale;
    }

    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
            RotateWeapon();
    }
}
