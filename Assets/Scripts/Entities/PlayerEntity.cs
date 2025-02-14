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

        // BasicAttack = ScriptableObject.CreateInstance<Ability>();

        // List<MathFunction.Variable> vars1 = new()
        // {
        //     new("Duration", 4),
        //     new("Speed", 10),
        //     new("Width", 0.5f),
        //     new("Frequency", 10)
        // };

        // BasicAttack.FunctionX = new MathFunction(vars1, new List<MathFunction.Operation>
        // {
        //     new(Operations.PARAMETER, 0)
        // });

        // BasicAttack.FunctionY = new MathFunction(vars1, new List<MathFunction.Operation>
        // {
        //     new(Operations.SINE, new MathFunction(vars1, new List<MathFunction.Operation>
        //     {
        //         new(Operations.VARIABLE, 3),
        //         new(Operations.MULTIPLY, new MathFunction(vars1, new List<MathFunction.Operation>
        //         {
        //             new(Operations.PARAMETER, 0)
        //         }))
        //     })),
        //     new(Operations.MULTIPLY, new MathFunction(vars1, new List<MathFunction.Operation>
        //     {
        //         new(Operations.VARIABLE, 2)
        //     }))
        // });

        // BasicAttack.Variables = vars1;
        // BasicAttack.Projectile = ProjectilePrefabs[0];

        // SpecialAttack = ScriptableObject.CreateInstance<Ability>();

        // List<MathFunction.Variable> vars2 = new()
        // {
        //     new("Duration", 4),
        //     new("Speed", 20),
        //     new("Radius", 2),
        //     new("Petals", 5f/6f)
        // };

        // SpecialAttack.FunctionX = new MathFunction(vars2, new List<MathFunction.Operation>
        // {
        //     new(Operations.VARIABLE, 2),
        //     new(Operations.MULTIPLY, new MathFunction(vars2, new List<MathFunction.Operation>
        //     {
        //         new(Operations.SINE, new MathFunction(vars2, new List<MathFunction.Operation>
        //         {
        //             new(Operations.VARIABLE, 3),
        //             new(Operations.MULTIPLY, new MathFunction(vars2, new List<MathFunction.Operation>
        //             {
        //                 new(Operations.PARAMETER, 0)
        //             }))
        //         }))
        //     })),
        //     new(Operations.MULTIPLY, new MathFunction(vars2, new List<MathFunction.Operation>
        //     {
        //         new(Operations.COSINE, new MathFunction(vars2, new List<MathFunction.Operation>
        //         {
        //             new(Operations.PARAMETER, 0)
        //         }))
        //     }))
        // });

        // SpecialAttack.FunctionY = new MathFunction(vars2, new List<MathFunction.Operation>
        // {
        //     new(Operations.VARIABLE, 2),
        //     new(Operations.MULTIPLY, new MathFunction(vars2, new List<MathFunction.Operation>
        //     {
        //         new(Operations.SINE, new MathFunction(vars2, new List<MathFunction.Operation>
        //         {
        //             new(Operations.VARIABLE, 3),
        //             new(Operations.MULTIPLY, new MathFunction(vars2, new List<MathFunction.Operation>
        //             {
        //                 new(Operations.PARAMETER, 0)
        //             }))
        //         }))
        //     })),
        //     new(Operations.MULTIPLY, new MathFunction(vars2, new List<MathFunction.Operation>
        //     {
        //         new(Operations.SINE, new MathFunction(vars2, new List<MathFunction.Operation>
        //         {
        //             new(Operations.PARAMETER, 0)
        //         }))
        //     }))
        // });

        // SpecialAttack.Variables = vars2;
        // SpecialAttack.Projectile = ProjectilePrefabs[1];
    }
}
