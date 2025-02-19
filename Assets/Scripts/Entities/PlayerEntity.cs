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
        LinearAttack.FunctionPosX = new(FunctionTypes.LINEAR);
        LinearAttack.FunctionPosY = new(FunctionTypes.CONSTANT);
        LinearAttack.PosVars = new(){ new("Duration", 2f), new("Speed", 25f), new("---", 0f), new("---", 0f) };
        LinearAttack.FunctionDmg = new(FunctionTypes.POLYNOMIAL);
        LinearAttack.DmgVars = new(){ new("Initial", 0f), new("Speed", 10f), new("Multiplier", 1f), new("Power", 1f) };
        LinearAttack.Projectile = ProjectilePrefabs[0];

        SineAttack = ScriptableObject.CreateInstance<Ability>();
        SineAttack.FunctionPosX = new(FunctionTypes.LINEAR);
        SineAttack.FunctionPosY = new(FunctionTypes.SINE);
        SineAttack.PosVars = new(){ new("Duration", 4f), new("Speed", 10f), new("Width", 0.5f), new("Frequency", 10f) };
        SineAttack.FunctionDmg = new(FunctionTypes.POLYNOMIAL);
        SineAttack.DmgVars = new(){ new("Initial", 0f), new("Speed", 1f), new("Multiplier", 1f), new("Power", 0f) };
        SineAttack.Projectile = ProjectilePrefabs[0];

        RoseAttack = ScriptableObject.CreateInstance<Ability>();
        RoseAttack.FunctionPosX = new(FunctionTypes.ROSEX);
        RoseAttack.FunctionPosY = new(FunctionTypes.ROSEY);
        RoseAttack.PosVars = new(){ new("Duration", 4f), new("Speed", 20f), new("Radius", 2f), new("Angular Frequency", 5f/6f) };
        RoseAttack.FunctionDmg = new(FunctionTypes.POLYNOMIAL);
        RoseAttack.DmgVars = new(){ new("Initial", 0f), new("Speed", 1f), new("Multiplier", 5f), new("Power", 2f) };
        RoseAttack.Projectile = ProjectilePrefabs[1];

        BasicAttack = LinearAttack;
        SpecialAttack = RoseAttack;
    }
}
