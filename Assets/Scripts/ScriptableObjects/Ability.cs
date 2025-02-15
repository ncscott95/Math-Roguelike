using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public delegate float MathFunction(float t, float S, float a, float n);
    public MathFunction PosX;
    public MathFunction PosY;
    public List<FunctionBank.Variable> PosVars;
    public MathFunction Dmg;
    public List<FunctionBank.Variable> DmgVars;
    public GameObject Projectile;

    public void Use(Entity source)
    {
        Instantiate(Projectile, source.transform.position, source.transform.rotation)
                .GetComponentInChildren<Projectile>().Fire(source, PosX, PosY, PosVars, Dmg, DmgVars);
    }
}
