using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerousCell : MonoBehaviour
{
    private Enemy enemy;

    [SerializeField] private Transform spin;
    [SerializeField] private List<Enemy> minis = new List<Enemy>();

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        enemy.downSpeed = 3f;
        enemy.maxHP = 30;
        enemy.collisionDamage = 40;
        enemy.penaltyPain = 20;
        enemy.killScore = 2;

        foreach (Enemy mini in minis)
        {
            mini.downSpeed = 0f;
            mini.maxHP = 20;
            mini.collisionDamage = 20;
            mini.penaltyPain = 0;
            mini.killScore = 0;
        }
    }

    private void OnEnable()
    {
        foreach (Enemy mini in minis)
            mini.gameObject.SetActive(true);
    }

    private void Update()
    {
        spin.Rotate(0f, 0f, 90f * Time.deltaTime);
    }
}
