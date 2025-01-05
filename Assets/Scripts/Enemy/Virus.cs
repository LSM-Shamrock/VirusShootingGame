using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    private Enemy enemy;

    private float rushSpeed = 10f;
    private float rushDistance = 1.5f;
    private float rushDelay = 1.5f;
    private bool isRush = false;
    private Vector3 rushDirection;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        enemy.downSpeed = 3f;
        enemy.maxHP = 60;
        enemy.collisionDamage = 40;
        enemy.penaltyPain = 20;
        enemy.killScore = 2;
    }

    private void OnEnable()
    {
        isRush = false;
        StartCoroutine(StartRush());
    }

    private void Update()
    {
        if (enemy.remainHP > 0 && isRush)
        {
            transform.Translate(rushDirection * rushSpeed * Time.deltaTime);
        }
    }

    private IEnumerator StartRush()
    {
        while (true)
        {
            yield return new WaitForSeconds(rushDelay);

            rushDirection = Stage.player.transform.position - transform.position;
            rushDirection.Normalize();
            isRush = true;
            
            yield return new WaitForSeconds(rushDistance / rushSpeed);

            isRush = false;
        }
    }
}
