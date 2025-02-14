using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerEntity player;

    PlayerControls inputs;
    Vector2 move;
    Vector2 look;

    void Awake()
    {
        inputs = new PlayerControls();

        inputs.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputs.Player.Move.canceled += ctx => move = Vector2.zero;

        inputs.Player.MousePos.performed += ctx => look = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        
        inputs.Player.Attack.performed += ctx => Attack();

        player = GetComponent<PlayerEntity>();
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
        Debug.Log("Attack Pressed");
        player.basicAttack.Use(player);
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
