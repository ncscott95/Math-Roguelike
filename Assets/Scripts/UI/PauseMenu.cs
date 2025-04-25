using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public GameObject CanvasObject;
    
    private PlayerControls inputs;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogWarning("Tried to create more than one instance of the PauseMenu singleton!");
            Destroy(this);
        }

        if(CanvasObject == null) CanvasObject = GetComponentInChildren<Canvas>().gameObject;
        CanvasObject.SetActive(false);

        inputs = new PlayerControls();
        inputs.UI.PauseUI.performed += ctx => ButtonPauseGame();
        inputs.UI.Disable();
    }

    void OnDestroy()
    {
        inputs.UI.PauseUI.performed -= ctx => ButtonPauseGame();
        inputs.UI.Disable();
    }

    public void SetControlsActive(bool active)
    {
        if(active) inputs.UI.Enable();
        else inputs.UI.Disable();
    }

    public void ButtonPauseGame()
    {
        GameManager.Instance.PauseGame();
    }
}
