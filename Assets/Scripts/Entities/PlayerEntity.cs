using UnityEngine;

public class PlayerEntity : Entity
{
    public Ability BasicAttack
    { get; set; }
    public Ability SpecialAttack
    { get; set; }
    public Ability LinearAttack
    { get; set; }
    public Ability SineAttack
    { get; set; }
    public Ability RoseAttack
    { get; set; }

    public AbilityEquationViewer temp;

    void Start()
    {
        LinearAttack = AbilityBank.Instance.NewAbility(FunctionTypes.LINEAR);
        LinearAttack.PosVars[1].Value = 25f;
        LinearAttack.DmgVars[3].Value = 1f;

        SineAttack = AbilityBank.Instance.NewAbility(FunctionTypes.SINE);

        RoseAttack = AbilityBank.Instance.NewAbility(FunctionTypes.ROSEX);
        RoseAttack.DmgVars[1].Value = 1f;
        RoseAttack.DmgVars[2].Value = 5f;
        RoseAttack.DmgVars[3].Value = 2f;

        BasicAttack = LinearAttack;
        SpecialAttack = RoseAttack;

        temp.Ability = SineAttack;
    }
    
    public override void TakeDamage(float damage)
    {
        Debug.Log($"Player hit for {damage} dmg");
        base.TakeDamage(damage);
    }
}
