using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed;

    bool isFollowingPlayer = true;

    void OnEnable()
    {
        PlayerManager.OnPlayerDeath += StopFollowingPlayer;
    }

    void OnDisable()
    {
        PlayerManager.OnPlayerDeath -= StopFollowingPlayer;
    }

    void Update()
    {
        if (isFollowingPlayer)
        {
            // Follow the player
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, desiredPosition, cameraSpeed * Time.deltaTime);
        }
    }

    void StopFollowingPlayer()
    {
        isFollowingPlayer = false; // Stop following the player
        Invoke("LoadMenuScene", 2f); // Delay scene transition
    }

    void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene"); // Replace "MenuScene" with the name of your menu scene
    }
}
