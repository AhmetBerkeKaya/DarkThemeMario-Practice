using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        // Oyuna ba�lama i�lemi
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        // Oyunu kapatma i�lemi
        Application.Quit();
    }
}
