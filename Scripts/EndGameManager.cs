using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{

    public GameObject kutlamaParticle; // Kutlama için bir Particle System
    public TextMesh kutlamaYazi; // Kutlama yazýsý için bir UI Text
    public float beklemeSuresi = 5f; // Menüye geçiþ için beklenecek süre
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
        // Kutlama efektini baþlat
        kutlamaParticle.gameObject.SetActive(true);

        // Kutlama yazýsýný göster
        kutlamaYazi.gameObject.SetActive(true);

        // Belirtilen süre kadar bekleyip sonra menü sahnesine geçiþ yap
        Invoke("MenuyeGecis", beklemeSuresi);
    }
    public void MenuyeGecis()
    {
        // Menü sahnesine geçiþ yap
        SceneManager.LoadScene(0);
    }
}
