using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 20;

    public void ShootWithGun(GunStats gunStats)
    {
        Health -= gunStats.Damage;
        Debug.Log($"Shot with {gunStats.Name} current health {Health}");
    }
}
