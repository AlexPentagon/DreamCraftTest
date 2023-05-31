using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textNumBt;
    [SerializeField] private Image weaponImage;
    [SerializeField] private TextMeshProUGUI textWeaponName;
    [SerializeField] private Image cooldownImage;

    public void SetFields(string numBt,Sprite image,string weaponName)
    {
        textNumBt.text = numBt;
        weaponImage.sprite = image;
        weaponImage.SetNativeSize();
        textWeaponName.text = weaponName;
    }

    public void SetCooldown(float amount)
    {
        cooldownImage.fillAmount = amount;
    }

}
