using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairStuffIconUI : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image icon;

    public void SetBackground(Color color)
    {
        background.color = color;
    }

    public void SetIcon(Sprite image)
    {
        icon.sprite = image;
    }
}
