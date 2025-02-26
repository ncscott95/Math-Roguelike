using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Entity source;
    private int ignoreLayer;
    private float damage;
    private float time;
    private bool isActive = false;
    private FunctionBank.FValue positionFunctionX;
    private FunctionBank.FValue positionFunctionY;
    private FunctionBank.FValue damageFunctionD;
    private List<FunctionBank.Variable> posVars;
    private List<FunctionBank.Variable> dmgVars;
    private float duration;
    
    public void Fire(Entity source, FunctionBank.FValue fx, FunctionBank.FValue fy, 
            List<FunctionBank.Variable> posVars, FunctionBank.FValue fd, List<FunctionBank.Variable> dmgVars)
    {
        this.source = source;
        this.ignoreLayer = source.gameObject.layer;
        this.positionFunctionX = fx;
        this.positionFunctionY = fy;
        this.damageFunctionD = fd;
        this.posVars = posVars;
        this.dmgVars = dmgVars;
        this.duration = posVars[0].Value;
        
        time = 0;
        isActive = true;
        StartCoroutine(ProjectileLifecycle());
    }
    
    private IEnumerator ProjectileLifecycle()
    {
        // Get position variables
        float speed = posVars[1].Value;
        float a = posVars[2].Value;
        float n = posVars[3].Value;

        // Get damage variables
        float initial = dmgVars[0].Value;
        float dmgSpeed = dmgVars[1].Value;
        float multiplier = dmgVars[2].Value;
        float power = dmgVars[3].Value;

        while (time <= duration && isActive)
        {
            time += Time.deltaTime;
            
            // Update position
            transform.localPosition = new Vector2(
                positionFunctionX(time, speed, a, n), 
                positionFunctionY(time, speed, a, n)
            );
            
            // Update damage
            damage = initial + damageFunctionD(time, dmgSpeed, multiplier, power);
            
            yield return null;
        }
        
        // Return to pool instead of destroying
        isActive = false;
        ProjectilePool.Instance.ReturnToPool(transform.parent.gameObject);
    }
    
    public void OnDisable()
    {
        isActive = false;
        StopAllCoroutines();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != ignoreLayer)
        {
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();
            if (target != null)
            {
                target.TakeDamage(damage);
                // Optional: Deactivate projectile on hit
                // isActive = false;
                // ProjectilePool.Instance.ReturnToPool(transform.parent.gameObject);
            }
        }
    }
}
