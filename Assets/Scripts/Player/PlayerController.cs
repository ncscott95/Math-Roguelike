using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerEntity player;

    PlayerControls inputs;
    Vector2 move;
    Vector2 look;

    void Awake()
    {
        player = GetComponent<PlayerEntity>();
        inputs = new PlayerControls();

        inputs.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputs.Player.Move.canceled += ctx => move = Vector2.zero;

        inputs.Player.Look.performed += ctx => look = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        
        inputs.Player.Attack.performed += ctx => Attack();
        inputs.Player.Special.performed += ctx => Special();
        inputs.Player.DebugSwap.performed += ctx => DebugSwapAttacks();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        inputs.Player.Enable();
    }

    private void OnDisable()
    {
        inputs.Player.Disable();
    }
    
    void Attack()
    {
        player.BasicAttack.Use(player);
    }

    void Special()
    {
        player.SpecialAttack.Use(player);
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
