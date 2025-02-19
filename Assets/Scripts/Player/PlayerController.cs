using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private PlayerEntity player;

    PlayerControls inputs;
    Vector2 move;
    Vector2 look;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogWarning("Tried to create more than one instance of the PlayerController singleton!");
            Destroy(this);
        }

        player = GetComponent<PlayerEntity>();
        inputs = new PlayerControls();

        inputs.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputs.Player.Move.canceled += ctx => move = Vector2.zero;

        inputs.Player.Look.performed += ctx => look = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        
        inputs.Player.Attack.performed += ctx => Attack();
        inputs.Player.Special.performed += ctx => Special();
        inputs.Player.Pause.performed += ctx => Pause();

        inputs.Player.DebugSwap.performed += ctx => DebugSwapAttacks();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnEnable()
    {
        inputs.Player.Enable();
    }

    void OnDisable()
    {
        inputs.Player.Disable();
    }

    public void SetControlsActive(bool active)
    {
        if(active) inputs.Player.Enable();
        else inputs.Player.Disable();
    }
    
    void Attack()
    {
        player.BasicAttack.Use(player);
    }

    void Special()
    {
        player.SpecialAttack.Use(player);
    }

    void Pause()
    {
        GameManager.Instance.PauseGame();
    }

    void DebugSwapAttacks()
    {
        if(player.BasicAttack == player.LinearAttack) player.BasicAttack = player.SineAttack;
        else player.BasicAttack = player.LinearAttack;
    }

    void Update()
    {
        Vector2 movement = player.MoveSpeed * Time.deltaTime * new Vector2(move.x, move.y);
        transform.Translate(movement, Space.World);

        Vector2 facingDirection = look - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
