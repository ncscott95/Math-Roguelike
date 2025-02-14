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
        LinearAttack.Variables = new(){ new("Duration", 2f), new("Speed", 25f), new("---", 0f), new("---", 0f) };
        LinearAttack.fX = FunctionBank.Instance.Linear;
        LinearAttack.fY = FunctionBank.Instance.Constant;
        LinearAttack.Projectile = ProjectilePrefabs[0];

        SineAttack = ScriptableObject.CreateInstance<Ability>();
        SineAttack.Variables = new(){ new("Duration", 4f), new("Speed", 10f), new("Width", 0.5f), new("Frequency", 10f) };
        SineAttack.fX = FunctionBank.Instance.Linear;
        SineAttack.fY = FunctionBank.Instance.Sine;
        SineAttack.Projectile = ProjectilePrefabs[0];

        RoseAttack = ScriptableObject.CreateInstance<Ability>();
        RoseAttack.Variables = new(){ new("Duration", 4f), new("Speed", 20f), new("Radius", 2f), new("Petals", 5f/6f) };
        RoseAttack.fX = FunctionBank.Instance.RoseX;
        RoseAttack.fY = FunctionBank.Instance.RoseY;
        RoseAttack.Projectile = ProjectilePrefabs[1];

        BasicAttack = LinearAttack;
        SpecialAttack = RoseAttack;
    }
}
