using UnityEngine;

public class EnemyEntity : Entity
{
    public Ability BasicAttack
    { get; set; }
    
    void Start()
    {
        BasicAttack = AbilityBank.Instance.NewAbility(FunctionTypes.LINEAR);
    }

    public override void TakeDamage(float damage)
    {
        Debug.Log($"Enemy hit for {damage} dmg");
        base.TakeDamage(damage);
    }
}
