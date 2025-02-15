using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    [Header("Abilities")]
    public Ability BasicAttack
    { get; set; }
    public Ability SpecialAttack
    { get; set; }
    public List<GameObject> ProjectilePrefabs;

    public Ability LinearAttack
    { get; set; }
    public Ability SineAttack
    { get; set; }
    public Ability RoseAttack
    { get; set; }

    void Start()
    {
        LinearAttack = ScriptableObject.CreateInstance<Ability>();
        LinearAttack.PosX = FunctionBank.Instance.Linear;
        LinearAttack.PosY = FunctionBank.Instance.Constant;
        LinearAttack.PosVars = new(){ new("Duration", 2f), new("Speed", 25f), new("---", 0f), new("---", 0f) };
        LinearAttack.Dmg = FunctionBank.Instance.Polynomial;
        LinearAttack.DmgVars = new(){ new("Initial", 0f), new("Speed", 10f), new("Multiplier", 1f), new("Power", 1f) };
        LinearAttack.Projectile = ProjectilePrefabs[0];

        SineAttack = ScriptableObject.CreateInstance<Ability>();
        SineAttack.PosX = FunctionBank.Instance.Linear;
        SineAttack.PosY = FunctionBank.Instance.Sine;
        SineAttack.PosVars = new(){ new("Duration", 4f), new("Speed", 10f), new("Width", 0.5f), new("Frequency", 10f) };
        SineAttack.Dmg = FunctionBank.Instance.Polynomial;
        SineAttack.DmgVars = new(){ new("Initial", 0f), new("Speed", 1f), new("Multiplier", 1f), new("Power", 0f) };
        SineAttack.Projectile = ProjectilePrefabs[0];

        RoseAttack = ScriptableObject.CreateInstance<Ability>();
        RoseAttack.PosX = FunctionBank.Instance.RoseX;
        RoseAttack.PosY = FunctionBank.Instance.RoseY;
        RoseAttack.PosVars = new(){ new("Duration", 4f), new("Speed", 20f), new("Radius", 2f), new("Petals", 5f/6f) };
        RoseAttack.Dmg = FunctionBank.Instance.Polynomial;
        RoseAttack.DmgVars = new(){ new("Initial", 0f), new("Speed", 1f), new("Multiplier", 5f), new("Power", 2f) };
        RoseAttack.Projectile = ProjectilePrefabs[1];

        BasicAttack = LinearAttack;
        SpecialAttack = RoseAttack;
    }
}
