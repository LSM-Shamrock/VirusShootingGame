using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coronavirus : MonoBehaviour
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        enemy.downSpeed = 1f;
        enemy.maxHP = 2000;
        enemy.collisionDamage = 100;
        enemy.penaltyPain = 100;
        enemy.killScore = 100;
    }

    private void OnEnable()
    {
        StartCoroutine(AppearanceProduction());
    }

    public IEnumerator AppearanceProduction()
    {
        yield return new WaitWhile(() => transform.position.y > 5);
        enemy.downSpeed = 0f;
        Stage.boss = enemy;
    }
}
