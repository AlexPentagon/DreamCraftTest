using System.Collections.Generic;
using UnityEngine;

public class WeaponUser : MonoBehaviour
{
    public List<WeaponInventory> weaponInventory = new List<WeaponInventory>();

    [SerializeField] private Transform playerWeaponsHolder;
    [SerializeField] private Transform projectilesHolder;

    private List<GameObject> playersWeapons = new List<GameObject>();
    private InputController inputController;
    private int currentWeaponNumber;

    private void Awake()
    {
        inputController = GetComponent<InputController>();
        inputController.OnNumberPressed += ChangeWeapon;

        for(int i =0;i< weaponInventory.Count;i++)
        {
            var weapon = Instantiate(weaponInventory[i].weaponPrefab, playerWeaponsHolder);
            weapon.GetComponent<Weapon>().projectilesHolder = projectilesHolder;
            playersWeapons.Add(weapon);
            weapon.SetActive(false);
        }

        SetWeapon(currentWeaponNumber);
    }

    private void ChangeWeapon(int key)
    {
        key = key - 1;
        if (currentWeaponNumber == key || key >= weaponInventory.Count)
            return;

        SetWeapon(key);
        inputController.OnShoot -= playersWeapons[currentWeaponNumber].GetComponent<Weapon>().Shoot;
        playersWeapons[currentWeaponNumber].SetActive(false);
        currentWeaponNumber = key;
    }

    private void SetWeapon(int weaponNumber)
    {
        if (playersWeapons.Count > weaponNumber)
        {
            GameObject weapon = playersWeapons[weaponNumber];
            weapon.SetActive(true);
            inputController.OnShoot += weapon.GetComponent<Weapon>().Shoot;
        }
    }

    public GameObject GetWeapon(int index)
    {
        return playersWeapons[index];
    }
}
