using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private MathFunction functionX;
    [SerializeField] private MathFunction functionY;
    [SerializeField] private float sineDuration;
    [SerializeField] private float sineSpeed;

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
        StartCoroutine(TestSineTransform(sineDuration));
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(move.x, move.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private IEnumerator TestSineTransform(float duration)
    {
        Vector2 origin = transform.position;
        float t = 0;
        while(t <= duration)
        {
            transform.position = origin + new Vector2(functionX.Calculate(t * sineSpeed), functionY.Calculate(t * sineSpeed));
            t += Time.deltaTime;
            yield return null;
        }
    }
}
