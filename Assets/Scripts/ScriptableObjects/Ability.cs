using UnityEngine;

public class Ability : ScriptableObject
{
    public string AbilityName;
    public float CooldownTime;

    public bool CanUse
    { get; set; } = true;

    public virtual void Use(Entity source)
    {
        CanUse = false;
        _ = Cooldown();
    }

    protected async Awaitable Cooldown()
    {
        await Awaitable.WaitForSecondsAsync(CooldownTime);
        CanUse = true;
    }
}
