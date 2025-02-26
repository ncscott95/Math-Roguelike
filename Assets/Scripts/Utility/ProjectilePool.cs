using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    private static ProjectilePool _instance;
    public static ProjectilePool Instance => _instance;
    
    public int initialPoolSize = 20;
    private Dictionary<GameObject, List<GameObject>> projectilePools = new Dictionary<GameObject, List<GameObject>>();
    
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }
    
    public void InitializePool(GameObject prefab)
    {
        if (!projectilePools.ContainsKey(prefab))
        {
            projectilePools[prefab] = new List<GameObject>();
            for (int i = 0; i < initialPoolSize; i++)
            {
                CreateProjectile(prefab);
            }
        }
    }
    
    private GameObject CreateProjectile(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        projectilePools[prefab].Add(obj);
        return obj;
    }
    
    public GameObject GetProjectile(GameObject prefab)
    {
        if (!projectilePools.TryGetValue(prefab, out List<GameObject> pool))
        {
            InitializePool(prefab);
            pool = projectilePools[prefab];
        }
            
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                ResetProjectile(obj);
                obj.SetActive(true);
                return obj;
            }
        }
        
        return CreateProjectile(prefab);
    }

    private void ResetProjectile(GameObject projectile)
    {
        projectile.transform.position = Vector3.zero;
        TrailRenderer trail = projectile.GetComponentInChildren<TrailRenderer>();
        if (trail != null) trail.Clear();
    }
    
    public void ReturnToPool(GameObject projectile)
    {
        projectile.SetActive(false);
    }
}
