using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    [Header("Abilities")]
    public List<GameObject> ProjectilePrefabs;

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

    void Start()
    {
        LinearAttack = AbilityBank.Instance.NewAbility(FunctionTypes.LINEAR);
        LinearAttack.PosVars = new(){ new("Duration", 2f), new("Speed", 25f), new("---", 0f), new("---", 0f) };
        LinearAttack.DmgVars = new(){ new("Initial", 0f), new("Speed", 10f), new("Multiplier", 1f), new("Power", 1f) };

        SineAttack = AbilityBank.Instance.NewAbility(FunctionTypes.SINE);
        SineAttack.PosVars = new(){ new("Duration", 4f), new("Speed", 10f), new("Width", 0.5f), new("Frequency", 10f) };
        SineAttack.DmgVars = new(){ new("Initial", 0f), new("Speed", 1f), new("Multiplier", 1f), new("Power", 0f) };

        RoseAttack = AbilityBank.Instance.NewAbility(FunctionTypes.ROSEX);
        RoseAttack.PosVars = new(){ new("Duration", 4f), new("Speed", 20f), new("Radius", 2f), new("Angular Frequency", 5f/6f) };
        RoseAttack.DmgVars = new(){ new("Initial", 0f), new("Speed", 1f), new("Multiplier", 5f), new("Power", 2f) };

        BasicAttack = LinearAttack;
        SpecialAttack = RoseAttack;
    }
}
