using UnityEngine;

[CreateAssetMenu(fileName = "InformationValues", menuName = "ScripableObjects/InformationStats")]
public class InformationValues : ScriptableObject
{
    // Global Health Variables
    public int _maxHealth = 1000;

    // Global Movement Speed Variables - GDW variable
    public int _EnemySpeed = 4;

    public int _PlayerMaxHealth = 1000;

    // Reference to another Scriptable Object to gain access
    public DamageValues damage;
}
