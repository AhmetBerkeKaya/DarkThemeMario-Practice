using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10f; // Hasar miktar�n� buradan ayarlayabilirsiniz

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �arp��ma yap�lan nesne PlayerManager ise hasar ver
        if (collision.gameObject.CompareTag("Player"))
        {
            // PlayerManager'daki GetDamage fonksiyonunu �a��r
            collision.gameObject.GetComponent<PlayerManager>().GetDamage(damageAmount);
        }
    }
}
