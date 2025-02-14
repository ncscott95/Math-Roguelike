using System.Collections.Generic;
using UnityEngine;

public enum Operations
{
    CONSTANT,
    VARIABLE,
    ADD_CONST,
    ADD_FUNCT,
    SUBTRACT_CONST,
    SUBTRACT_FUNCT,
    MULTIPLY_CONST,
    MULTIPLY_FUNCT,
    DIVIDE_CONST,
    DIVIDE_FUNCT,
    EXPONENT_CONST,
    EXPONENT_FUNCT,
    SINE_CONST,
    SINE_FUNCT,
}

[CreateAssetMenu(menuName = "Math Function")]
public class MathFunction : ScriptableObject
{
    [System.Serializable]
    public class Operation
    {
        [SerializeField] private Operations operation;
        [SerializeField] private float constant;
        [SerializeField] private MathFunction expression;

        public float Evaluate(float var, float answer)
        {
            return operation switch
            {
                Operations.CONSTANT => constant,
                Operations.VARIABLE => var,
                Operations.ADD_CONST => answer += constant,
                Operations.ADD_FUNCT => answer += expression.Calculate(var),
                Operations.SUBTRACT_CONST => answer -= constant,
                Operations.SUBTRACT_FUNCT => answer -= expression.Calculate(var),
                Operations.MULTIPLY_CONST => answer *= constant,
                Operations.MULTIPLY_FUNCT => answer *= expression.Calculate(var),
                Operations.DIVIDE_CONST => answer /= constant,
                Operations.DIVIDE_FUNCT => answer *= expression.Calculate(var),
                Operations.EXPONENT_CONST => Mathf.Pow(answer, constant),
                Operations.EXPONENT_FUNCT => Mathf.Pow(answer, expression.Calculate(var)),
                Operations.SINE_CONST => Mathf.Sin(constant),
                Operations.SINE_FUNCT => Mathf.Sin(expression.Calculate(var)),
                _ => constant,
            };
        }
    }

    public List<Operation> Function = new();

    public float Calculate(float var)
    {
        float answer = 0;
        foreach(Operation op in Function) answer = op.Evaluate(var, answer);
        return answer;
    }
}
