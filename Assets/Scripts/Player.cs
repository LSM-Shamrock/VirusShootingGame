using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public int maxHP = 100;
    [HideInInspector] public int remainHP;
    [HideInInspector] public int collisionDamage = 50;

    private bool isControllable = true;

    private Vector3 movePosition;
    private Vector3 moveDirection;
    private float moveSpeed = 12f;

    [SerializeField] private GameObject bulletOriginal;
    [HideInInspector] public int launcherUpgrade = 0;
    private float shootDelay = 0.2f;
    private float shootSpeed = 20f;
    private float shootDistance = 15f;
    private int shootDamage = 10;

    private SpriteRenderer spriteRenderer;
    private float invincibilityTime = 0f;

    [SerializeField] private SpriteRenderer shieldSpriteRenderer;
    [HideInInspector] public float shieldTime = 0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Stage.player = this;

        remainHP = maxHP;

        if (Stage.stage == 1)
            StartCoroutine(DepartureProduction());

        InvokeRepeating("Launch", 3f, shootDelay);
    }

    private void Update()
    {
        Color color = spriteRenderer.color;
        if (invincibilityTime > 0f)
        {
            invincibilityTime -= Time.deltaTime;
            color.a = 0.5f - Mathf.Clamp(invincibilityTime, 0f, 1f) * 0.4f;
        }
        else
        {
            invincibilityTime = 0f;
            color.a = 1f;
        }
        spriteRenderer.color = color;

        Color shieldColor = shieldSpriteRenderer.color;
        if (shieldTime > 0f)
        {
            shieldTime -= Time.deltaTime;
            shieldColor.a = Mathf.Clamp(shieldTime, 0f, 1f) * 0.9f;
        }
        else
        {
            shieldTime = 0f;
            shieldColor.a = 0f;
        }
        shieldSpriteRenderer.color = shieldColor;

        if (isControllable )
        {
            moveDirection = Vector3.zero;
            if (Input.GetKey(KeyCode.D) ||
                Input.GetKey(KeyCode.RightArrow))
                moveDirection.x++;
            if (Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.LeftArrow))
                moveDirection.x--;
            if (Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.UpArrow))
                moveDirection.y++;
            if (Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.DownArrow))
                moveDirection.y--;
            moveDirection.Normalize();

            movePosition = transform.position;
            movePosition += moveDirection * moveSpeed * Time.deltaTime;
            if (movePosition.x > 4f)
                movePosition.x = 4f;
            if (movePosition.x < -4f)
                movePosition.x = -4f;
            if (movePosition.y > 7.5f)
                movePosition.y = 7.5f;
            if (movePosition.y < -7.5f)
                movePosition.y = -7.5f;
            transform.position = movePosition;
        }
    }

    public IEnumerator DepartureProduction()
    {
        isControllable = false;
        transform.position = new Vector3 (0f, -9f, 0f);
        while (transform.position.y < -4f)
        {
            yield return null;

            transform.Translate(Vector3.up * 4f * Time.deltaTime);
        }
        isControllable = true;
    }

    private void Shoot(Vector3 direction)
    {
        GameObject bulletObject = Stage.poolManager.SpawnObject(bulletOriginal, transform.position, Quaternion.Euler(direction));
        PlayerBullet bullet = bulletObject.GetComponent<PlayerBullet>();
        bullet.shootSpeed = shootSpeed;
        bullet.shootDistance = shootDistance;
        bullet.shootDamage = shootDamage;
    }

    private void Launch()
    {
        Shoot(new Vector3(0, 0, 0));
        if (launcherUpgrade >= 1)
            Shoot(new Vector3(0, 0, -15));
        if (launcherUpgrade >= 2)
            Shoot(new Vector3(0, 0, 15));
        if (launcherUpgrade >= 3)
            Shoot(new Vector3(0, 0, -30));
        if (launcherUpgrade >= 4)
            Shoot(new Vector3(0, 0, 30));
    }

    public void LauncherUpgrade()
    {
        launcherUpgrade++;
        Invoke("LauncherDowngrade", 10f);
    }

    private void LauncherDowngrade()
    {
        launcherUpgrade--;
    }

    public void TakeDamage(int damage)
    {
        if (invincibilityTime <= 0f &&
            shieldTime <= 0f)
        {
            invincibilityTime = 1f;
            if (remainHP > damage)
                remainHP -= damage;
            else
                remainHP = 0;
        }
    }
}
