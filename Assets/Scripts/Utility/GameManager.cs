using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isPaused;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogWarning("Tried to create more than one instance of the GameManager singleton!");
            Destroy(this);
        }

        isPaused = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        PauseMenu.Instance.CanvasObject.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        PlayerController.Instance.SetControlsActive(!isPaused);
        PauseMenu.Instance.SetControlsActive(isPaused);
    }
}
