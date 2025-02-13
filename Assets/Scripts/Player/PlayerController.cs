using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    PlayerControls inputs;
    Vector2 move;

    void Awake()
    {
        inputs = new PlayerControls();
        inputs.Player.Attack.performed += ctx => Attack();
        inputs.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputs.Player.Move.canceled += ctx => move = Vector2.zero;
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
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector2(move.x, move.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
