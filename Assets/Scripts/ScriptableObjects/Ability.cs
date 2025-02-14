using UnityEngine;

[CreateAssetMenu(menuName = "Ability")]
public class Ability : ScriptableObject
{
    public GameObject Prefab;
    public MathFunction FunctionX;
    public MathFunction FunctionY;
    public float Duration;
    public float Speed;
    // private Projectile projectile;

    public void Use(Entity source)
    {
        // GameObject obj = Instantiate(Prefab, source.transform.position, source.transform.rotation);
        // projectile = obj.GetComponentInChildren<Projectile>();
        // projectile.Fire(FunctionX, FunctionY, Duration, Speed);

        Instantiate(Prefab, source.transform.position, source.transform.rotation)
                .GetComponentInChildren<Projectile>()
                .Fire(FunctionX, FunctionY, Duration, Speed);
    }
}
