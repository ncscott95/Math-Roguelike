using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public enum Operations
{
    CONSTANT,
    PARAMETER,
    VARIABLE,
    ADD,
    SUBTRACT,
    MULTIPLY,
    DIVIDE,
    EXPONENT,
    SINE,
}

public class MathFunction
{
    public class Operation
    {
        private Operations operation;
        private float constant;
        private MathFunction expression;

        public Operation(Operations operation, float constant)
        {
            this.operation = operation;
            this.constant = constant;
            expression = null;
        }

        public Operation(Operations operation, MathFunction expression)
        {
            this.operation = operation;
            this.expression = expression;
            constant = 0;
        }

        public float Evaluate(float param, List<Variable> vars, float answer)
        {
            float rValue = constant;
            if(expression != null) rValue = expression.Calculate(param);

            return operation switch
            {
                Operations.CONSTANT => rValue,
                Operations.PARAMETER => param,
                Operations.VARIABLE => vars[(int)constant].Value,
                Operations.ADD => answer += rValue,
                Operations.SUBTRACT => answer -= rValue,
                Operations.MULTIPLY => answer *= rValue,
                Operations.DIVIDE => answer /= rValue,
                Operations.EXPONENT => Mathf.Pow(answer, rValue),
                Operations.SINE => Mathf.Sin(rValue),
                _ => rValue,
            };
        }
    }
    
    public class Variable
    {
        public string Name;
        public float Value;

        public Variable(string name, float value)
        {
            Name = name;
            Value = value;
        }
    }

    public List<Operation> Function;
    public List<Variable> Variables;

    public MathFunction(List<Variable> variables, List<Operation> function)
    {
        Variables = variables;
        Function = function;
    }

    public float Calculate(float param)
    {
        float answer = 0;
        foreach(Operation op in Function) answer = op.Evaluate(param, Variables, answer);
        return answer;
    }
}
