using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public Ability BasicAttack
    { get; set; }
    public GameObject ProjectilePrefab;

    void Start()
    {
        BasicAttack = ScriptableObject.CreateInstance<Ability>();

        List<MathFunction.Variable> vars = new()
        {
            new("Duration", 4),
            new("Speed", 4),
            new("Width", 4),
            new("Frequency", 2)
        };

        BasicAttack.FunctionX = new MathFunction(vars, new List<MathFunction.Operation>
        {
            new(Operations.PARAMETER, 0)
        });

        BasicAttack.FunctionY = new MathFunction(vars, new List<MathFunction.Operation>
        {
            new(Operations.SINE, new MathFunction(vars, new List<MathFunction.Operation>
            {
                new(Operations.VARIABLE, 3),
                new(Operations.MULTIPLY, new MathFunction(vars, new List<MathFunction.Operation>
                {
                    new(Operations.PARAMETER, 0)
                }))
            })),
            new(Operations.MULTIPLY, new MathFunction(vars, new List<MathFunction.Operation>
            {
                new(Operations.VARIABLE, 2)
            }))
        });

        BasicAttack.Variables = vars;
        BasicAttack.Projectile = ProjectilePrefab;
    }
}
