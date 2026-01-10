using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName = "Scriptable Objects/GunStats")]
public class GunStats : ScriptableObject
{
    public float FireRate;
    public float ReloadTime;
    public float Damage;
    public string Name;
    public Sprite Icon;
}
