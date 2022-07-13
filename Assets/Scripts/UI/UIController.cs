using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    public Joystick joystick { get { return _joystick; }}

    [SerializeField] private TMP_Text _inventoryText;
    [SerializeField] private TMP_Text _moneyText;

    public void InventoryTextUpdate(string text)
    {
        _inventoryText.text = text;

    }
}