using UnityEngine;

[CreateAssetMenu(fileName = "InformationValues", menuName = "ScripableObjects/InformationStats")]
public class InformationValues : ScriptableObject
{
    // Global Health Variables
    public int _maxHealth = 100;

    // Global Movement Speed Variables - GDW variable
    public int _EnemySpeed = 5;

    // Reference to another Scriptable Object to gain access
    public DamageValues damage;
}
