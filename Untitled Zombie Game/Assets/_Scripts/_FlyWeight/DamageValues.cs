using UnityEngine;

[CreateAssetMenu(fileName = "DamageValues", menuName = "ScripableObjects/DamageStats")]
public class DamageValues : ScriptableObject
{
    // Global Damage Number Variables Assignment variables used
    public int _SmallDamage = 25;
    public int _EnemyDamage = 20;

    // below is GDW game numbers to be used
    public int _BigDamage = 50;
    public int _GrenadeDamage = 100;
}
