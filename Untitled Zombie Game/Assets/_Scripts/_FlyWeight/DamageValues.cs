using UnityEngine;

[CreateAssetMenu(fileName = "DamageValues", menuName = "ScripableObjects/DamageStats")]
public class DamageValues : ScriptableObject
{
    // Global Damage Number Variables Assignment variables used
    public int _SmallDamage = 25;
    public int _EagleDamage = 75;
    public int _EnemyDamage = 20;
    public int _SmallAK47Damage = 40;

    // below is GDW game numbers to be used
    public int _BigDamage = 50;
    public int _BigEagleDamage = 125;
    public int _BigAK47Damage = 75;
    public int _GrenadeDamage = 100;
    public int _MeleeDamage = 50;
    public int _SmallCornDamage = 100;
    public int _BigCornDamage = 200;
}
