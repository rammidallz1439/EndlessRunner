using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test",menuName ="Scripatbles/TestScriptable")]
public class TestScriptable : ScriptableObject
{
    public GameObject Enemy;
    public int Health;
    public int MaxHealth;
    public int AttackPower;
}
