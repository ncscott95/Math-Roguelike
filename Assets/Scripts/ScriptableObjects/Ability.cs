using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public delegate float PositionFunction(float t, float S, float a, float n);
    public PositionFunction fX;
    public PositionFunction fY;
    public List<FunctionBank.Variable> Variables;
    public GameObject Projectile;

    public float Damage = 1f; // TODO: replace with damage function

    public void Use(Entity source)
    {
        Instantiate(Projectile, source.transform.position, source.transform.rotation)
                .GetComponentInChildren<Projectile>().Fire(fX, fY, Variables, source, Damage);
    }
}
