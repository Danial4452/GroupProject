using UnityEngine;
using UnityEngine.InputSystem;

public class LevelTrigger : MonoBehaviour
{
    public GameObject levelPanel;

    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            OpenLevel();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            playerNearby = true;
            Debug.Log("Press E to Play");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            playerNearby = false;
        }
    }

    void OpenLevel()
    {
        Debug.Log("LEVEL 1 STARTED!");

        if (levelPanel != null)
            levelPanel.SetActive(true);
    }
}