using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public delegate void ItemDelegate(Player player);
    public ItemDelegate itemDelegate;

    private int itemScore = 1;

    private float downSpeed = 5f;

    private float magnetDistance = 3f;
    private float magnetSpeed = 3f;

    private void Update()
    {
        transform.Translate(Vector3.down * downSpeed * Time.deltaTime, Space.World);
        if (transform.position.y < -9)
            gameObject.SetActive(false);

        float playerDistance = Vector3.Distance(Stage.player.transform.position, transform.position);
        if (playerDistance <= magnetDistance)
        {
            Vector3 magnetDirection = Stage.player.transform.position - transform.position;
            magnetDirection = magnetDirection.normalized;
            transform.Translate(magnetDirection * magnetSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            itemDelegate(player);
            Stage.score += itemScore;
            gameObject.SetActive(false);
        }
    }
}
