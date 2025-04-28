using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private PlayerControls inputs;
    private Vector2 move;
    private Vector2 look;
    float colliderRadius;
    private const float maxWorldPos = 5f;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogWarning("Tried to create more than one instance of the PlayerController singleton!");
            Destroy(this);
        }

        inputs = new PlayerControls();

        inputs.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputs.Player.Move.canceled += ctx => move = Vector2.zero;

        inputs.Player.Look.performed += ctx => look = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        
        inputs.Player.Attack.performed += ctx => Attack();
        inputs.Player.Special.performed += ctx => Special();
        inputs.Player.Pause.performed += ctx => Pause();

        // TODO: debug, remove later
        inputs.Player.DebugSwap.performed += ctx => DebugSwapAttacks();

        colliderRadius = GetComponent<CircleCollider2D>().radius;
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
    
    private void Attack()
    {
        PlayerEntity.Instance.Abilities[0].Use(PlayerEntity.Instance);
    }

    private void Special()
    {
        PlayerEntity.Instance.Abilities[1].Use(PlayerEntity.Instance);
    }

    private void Pause()
    {
        GameManager.Instance.PauseGame();
    }

    // TODO: debug, remove later
    private void DebugSwapAttacks()
    {
        if(PlayerEntity.Instance.Abilities[0] == PlayerEntity.Instance.LinearAttack) PlayerEntity.Instance.Abilities[0] = PlayerEntity.Instance.SineAttack;
        else PlayerEntity.Instance.Abilities[0] = PlayerEntity.Instance.LinearAttack;
    }

    void Update()
    {
        Vector2 movement = PlayerEntity.Instance.MoveSpeed * Time.deltaTime * new Vector2(move.x, move.y);
        transform.Translate(movement, Space.World);
        float x = Mathf.Clamp(transform.position.x, -maxWorldPos + colliderRadius, maxWorldPos - colliderRadius);
        float y = Mathf.Clamp(transform.position.y, -maxWorldPos + colliderRadius, maxWorldPos - colliderRadius);
        transform.position = new Vector3(x, y, 0f);

        if(look != Vector2.zero)
        {
            Vector2 facingDirection = look - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
