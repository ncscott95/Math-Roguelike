using System.Collections.Generic;
using UnityEngine;

public enum Operations
{
    CONSTANT,
    VARIABLE,
    ADD,
    SUBTRACT,
    MULTIPLY,
    DIVIDE,
    EXPONENT,
    SINE
}

[CreateAssetMenu(menuName = "Math Function", fileName = "New Math Function")]
public class MathFunction : ScriptableObject
{
    [System.Serializable]
    public class Operation
    {
        [SerializeField] private Operations operation;
        [SerializeField] private float number;

        public float Evaluate(float var, float answer)
        {
            return operation switch
            {
                Operations.CONSTANT => number,
                Operations.VARIABLE => var,
                Operations.ADD => answer += number,
                Operations.SUBTRACT => answer -= number,
                Operations.MULTIPLY => answer *= number,
                Operations.DIVIDE => answer /= number,
                _ => number,
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
