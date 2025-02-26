using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("General Entity")]
    [Header("Basic Info")]
    public string Name;

    [Header("Stats")]
    public float Health
    { get; set; }
    [SerializeField] private float maxHealth;
    public float MoveSpeed;

    void OnEnable()
    {
        Health = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
