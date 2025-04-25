using UnityEngine;

public class EnemyEntity : Entity
{
    public Transform Target;
    public float RotationSpeed = 5f;
    public float StoppingDistance = 2f;
    public Ability BasicAttack
    { get; set; }
    
    void Start()
    {
        BasicAttack = AbilityBank.Instance.NewAbility(FunctionTypes.LINEAR);
    }
    
    private void Update()
    {
        if (Target != null)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 direction = Target.position - transform.position;
        float distance = direction.magnitude;

        if (distance > StoppingDistance)
        {
            transform.position += MoveSpeed * Time.deltaTime * transform.right;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }

    public override void TakeDamage(float damage)
    {
        Debug.Log($"Enemy hit for {damage} dmg");
        base.TakeDamage(damage);
    }
}
