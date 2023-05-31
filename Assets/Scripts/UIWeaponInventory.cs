using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWeaponInventory : MonoBehaviour
{
    [SerializeField] WeaponUser weaponUser;
    [SerializeField] GameObject itemSlotPrefab;

    private List<Weapon> weapons = new List<Weapon>();
    private List<UIItemSlot> slots = new List<UIItemSlot>();

    private void Start()
    {
        int index = 1;

        foreach(var item in weaponUser.weaponInventory)
        {
            var itemSlot = Instantiate(itemSlotPrefab, transform);
            slots.Add(itemSlot.GetComponent<UIItemSlot>());
            itemSlot.GetComponent<UIItemSlot>().SetFields(index.ToString(),item.weaponSprite,item.weaponName);
            weapons.Add(weaponUser.GetWeapon(index-1).GetComponent<Weapon>());
            index++;
        }
    }

    private void Update()
    {
        for(int i =0;i<weapons.Count;i++)
        {
            var time = Time.time - weapons[i].LastShotTime;
            if(time > weapons[i].SecondsCooldown)
            {
                slots[i].SetCooldown(0);
                continue;
            }
            var progress = time / weapons[i].SecondsCooldown; 
            slots[i].SetCooldown(1f-progress);
        }
    }

    public void ClickItem()
    {

    }
}
