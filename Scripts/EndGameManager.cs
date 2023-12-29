using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{

    public GameObject kutlamaParticle; // Kutlama i�in bir Particle System
    public TextMesh kutlamaYazi; // Kutlama yaz�s� i�in bir UI Text
    public float beklemeSuresi = 5f; // Men�ye ge�i� i�in beklenecek s�re
    public float endBound = 237f;

    private void Update()
    {
        if(transform.position.x >= endBound)
        {
            OyunuBitir();
        }
    }
    public void OyunuBitir()
    {
        // Kutlama efektini ba�lat
        kutlamaParticle.gameObject.SetActive(true);

        // Kutlama yaz�s�n� g�ster
        kutlamaYazi.gameObject.SetActive(true);

        // Belirtilen s�re kadar bekleyip sonra men� sahnesine ge�i� yap
        Invoke("MenuyeGecis", beklemeSuresi);
    }
    public void MenuyeGecis()
    {
        // Men� sahnesine ge�i� yap
        SceneManager.LoadScene(0);
    }
}
