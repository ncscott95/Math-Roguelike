using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public GameObject Projectile;

    public MathFunction FunctionX;
    public MathFunction FunctionY;
    public List<MathFunction.Variable> Variables;

    public void Use(Entity source)
    {
        Instantiate(Projectile, source.transform.position, source.transform.rotation)
                .GetComponentInChildren<Projectile>()
                .Fire(FunctionX, FunctionY, Variables[0].Value, Variables[1].Value);
    }
}
