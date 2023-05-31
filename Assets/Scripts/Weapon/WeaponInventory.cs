using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "WeaponInventory", menuName = "ScriptableObjects/WeaponInventory")]
public class WeaponInventory : ScriptableObject
{
    public GameObject weaponPrefab;
    public Sprite weaponSprite;
    public string weaponName;
}
