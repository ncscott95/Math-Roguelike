using UnityEngine;

[CreateAssetMenu(menuName = "Ability")]
public class Ability : ScriptableObject
{
    public GameObject Projectile;

    [Header("Functions")]
    public MathFunction FunctionX;
    public MathFunction FunctionY;

    [Header("Parameters")]
    public float Duration;
    public float Speed;

    public void Use(Entity source)
    {
        Instantiate(Projectile, source.transform.position, source.transform.rotation)
                .GetComponentInChildren<Projectile>()
                .Fire(FunctionX, FunctionY, Duration, Speed);
    }
}
