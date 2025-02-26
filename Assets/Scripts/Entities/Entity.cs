using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    [Header("General Entity")]
    [Header("Basic Info")]
    public string Name;

    [Header("Stats")]
    [SerializeField] private float maxHealth;
    public float MoveSpeed;

    // Delegate and event declarations
    public delegate void HealthChangedHandler(float currentHealth, float maxHealth);
    public event HealthChangedHandler OnHealthChanged;
    
    public delegate void EntityDeathHandler(Entity entity);
    public event EntityDeathHandler OnEntityDeath;
    
    // Health property with event trigger
    private float _health;
    public float Health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, 0, maxHealth);
            OnHealthChanged?.Invoke(_health, maxHealth);
            
            if (_health <= 0)
            {
                OnDeath();
            }
        }
    }

    void OnEnable()
    {
        Health = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            OnDeath();
        }
    }
    
    protected virtual void OnDeath()
    {
        Debug.Log($"{Name} is dead");
        OnEntityDeath?.Invoke(this);
    }
}
