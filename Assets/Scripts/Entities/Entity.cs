using UnityEngine;

public class Entity : MonoBehaviour
{
    public string Name;
    private float health;
    public float Health
    {
        get => health;
        set { health = value; }
    }
    private float maxHealth;
    public float MoveSpeed;
}
