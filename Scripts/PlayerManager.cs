using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public float health;
    public float bulletSpeed;
    public bool amIDead = false;
    public float lowerBound = -6f;

    [SerializeField] public bool dead = false;
    bool mouseIsNotOverUI = false;

    Animator playerAnimation;
    Transform muzzle;
    public Transform bullet, floatingText;

    public Slider slider;

    public delegate void PlayerDeathAction();
    public static event PlayerDeathAction OnPlayerDeath;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
        if (transform.position.y <= lowerBound)
        {
            health = 0;
            AmIDead();
        }
    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
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
            playerAnimation.SetBool("AmIDead", amIDead);
            OnPlayerDeath?.Invoke(); // Notify subscribers (like CameraManager)
            Destroy(gameObject, 1f);
        }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
    }
}
