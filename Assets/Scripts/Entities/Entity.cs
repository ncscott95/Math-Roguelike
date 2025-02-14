using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("General Entity")]
    [Header("Basic Info")]
    public string Name;

    [Header("Stats")]
    [SerializeField] private float maxHealth;
    public float MoveSpeed;

    private float health;
    public float Health
    {
        get => health;
        set { health = value; }
    }

    void OnEnable()
    {
        Health = maxHealth;
    }
}
