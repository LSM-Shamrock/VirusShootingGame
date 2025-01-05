using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    private Enemy enemy;

    private Vector3 moveDirection;
    private float moveRotationDelay = 0.5f;
    private float moveSpeed = 2f;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        enemy.downSpeed = 3f;
        enemy.maxHP = 40;
        enemy.collisionDamage = 0;
        enemy.penaltyPain = 10;
        enemy.killScore = 1;
    }

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 365f));
        StartCoroutine(StartMoveRotation());
    }

    private void Update()
    {
        if (enemy.remainHP > 0)
        {
            Vector3 movePosition = transform.position;
            movePosition += moveDirection * moveSpeed * Time.deltaTime;
            if (movePosition.x > 4f)
                movePosition.x = 4f;
            if (movePosition.x < -4f)
                movePosition.x = -4f;
            transform.position = movePosition;
        }
    }

    private IEnumerator StartMoveRotation()
    {
        while (true)
        {
            moveDirection = Random.insideUnitCircle;
            moveDirection.Normalize();

            yield return new WaitForSeconds(moveRotationDelay * Random.Range(0.75f, 1.25f));
        }
    }
}
