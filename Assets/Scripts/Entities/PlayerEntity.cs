using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public Ability BasicAttack
    { get; set; }
    public Ability SpecialAttack
    { get; set; }
    public List<GameObject> ProjectilePrefabs;

    void Start()
    {
        BasicAttack = ScriptableObject.CreateInstance<Ability>();
        BasicAttack.Variables = new(){ new("Duration", 4f), new("Speed", 10f), new("Width", 0.5f), new("Frequency", 10f) };
        BasicAttack.fX = FunctionBank.Instance.Linear;
        BasicAttack.fY = FunctionBank.Instance.Sine;
        BasicAttack.Projectile = ProjectilePrefabs[0];

        SpecialAttack = ScriptableObject.CreateInstance<Ability>();
        SpecialAttack.Variables = new(){ new("Duration", 4f), new("Speed", 20f), new("Radius", 2f), new("Petals", 5f/6f) };
        SpecialAttack.fX = FunctionBank.Instance.RoseX;
        SpecialAttack.fY = FunctionBank.Instance.RoseY;
        SpecialAttack.Projectile = ProjectilePrefabs[1];
    }
}
