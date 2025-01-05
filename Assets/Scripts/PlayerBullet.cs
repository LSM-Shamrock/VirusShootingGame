using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float shootSpeed = 20f;
    public float shootDistance = 16f;
    public int shootDamage = 20;

    private void Update()
    {
        if (shootDistance > 0)
        {
            transform.Translate(Vector3.up * shootSpeed * Time.deltaTime);
            shootDistance -= shootSpeed * Time.deltaTime;
        }
        else
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(shootDamage);
            gameObject.SetActive(false);
        }

        BloodCell bloodCell = collision.gameObject.GetComponent<BloodCell>();
        if (bloodCell != null)
        {
            bloodCell.TakeDamage(shootDamage);
            gameObject.SetActive(false);
        }
    }
}
