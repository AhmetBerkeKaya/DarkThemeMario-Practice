using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;
    public float moveSpeed = 1f;
    public float flipCooldown = 2f; // Flip aras�ndaki s�re

    public Slider slider;
    public bool amIDead = false;
    Animator enemyAnimation;

    bool colliderBusy = false;
    bool isMovingRight = true; // D��man�n hareket y�n�
    float timeSinceLastFlip = 0f; // Son flip zaman�

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;

        // Animator bile�enini al
        enemyAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!amIDead)
        {
            MoveHorizontal();
        }
    }

    void MoveHorizontal()
    {
        float horizontalMovement = isMovingRight ? moveSpeed : -moveSpeed;
        transform.Translate(new Vector2(horizontalMovement * Time.deltaTime, 0));

        // E�er d��man bir s�n�ra ula�t�ysa y�n� de�i�tir
        if (transform.position.x >= 3.0f || transform.position.x <= -3.0f)
        {
            if (Time.time - timeSinceLastFlip > flipCooldown)
            {
                isMovingRight = !isMovingRight;
                Flip();
                timeSinceLastFlip = Time.time;
            }
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            collision.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (collision.tag == "Bullet")
        {
            GetDamage(collision.GetComponent<BulletManager>().bulletDamage);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // OnTriggerStay2D i�eri�i
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            colliderBusy = false;
        }
    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health = health - damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;

        AmIDead();
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            amIDead = true;
            enemyAnimation.SetBool("AmIDead", amIDead);
            Destroy(gameObject, 1f);
        }
    }
}
