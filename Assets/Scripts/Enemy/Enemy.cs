using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public float downSpeed;
    [HideInInspector] public int maxHP;
    [HideInInspector] public int remainHP;
    [HideInInspector] public int collisionDamage;
    [HideInInspector] public int penaltyPain;
    [HideInInspector] public int killScore;

    [SerializeField] private Sprite flashSprite;

    private float flashTime;

    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    private void OnEnable()
    {
        remainHP = maxHP;
        flashTime = 0f;
        spriteRenderer.color = Color.white;
    }

    private void Update()
    {
        if (remainHP > 0)
        {
            if (flashTime > 0f)
            {
                flashTime -= Time.deltaTime;
                spriteRenderer.sprite = flashSprite;
            }
            else
            {
                flashTime = 0f;
                spriteRenderer.sprite = originalSprite;
            }

            transform.Translate(Vector3.down * downSpeed * Time.deltaTime, Space.World);
            if (transform.position.y < -9)
            {
                Stage.currentPain += penaltyPain;
                if (Stage.currentPain > Stage.maxPain)
                    Stage.currentPain = Stage.maxPain;
                gameObject.SetActive(false);
            }
        }
        else
        {
            spriteRenderer.sprite = flashSprite;
            Color color = spriteRenderer.color;
            color.a -= 4f * Time.deltaTime;
            spriteRenderer.color = color;
            if (color.a <= 0f)
                gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(collisionDamage);
            TakeDamage(player.collisionDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        if (remainHP > 0)
        {
            flashTime = 0.1f;
            if (remainHP > damage)
                remainHP -= damage;
            else
            {
                remainHP = 0;
                Stage.score += killScore;
            }
        }
    }
}
