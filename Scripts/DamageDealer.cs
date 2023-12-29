using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10f; // Hasar miktarýný buradan ayarlayabilirsiniz

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarpýþma yapýlan nesne PlayerManager ise hasar ver
        if (collision.gameObject.CompareTag("Player"))
        {
            // PlayerManager'daki GetDamage fonksiyonunu çaðýr
            collision.gameObject.GetComponent<PlayerManager>().GetDamage(damageAmount);
        }
    }
}
