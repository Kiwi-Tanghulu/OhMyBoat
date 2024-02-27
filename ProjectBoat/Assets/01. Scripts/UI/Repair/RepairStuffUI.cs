using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RepairStuffUI : MonoBehaviour
{
    [SerializeField] private int initIconCount = 5;
    [SerializeField] private RepairStuffIconUI stuffIconPrefab;

    private List<RepairStuffIconUI> stuffIcons;

    private void Awake()
    {
        stuffIcons = new List<RepairStuffIconUI>();
    }

    private void Start()
    {
        for (int i = 0; i < initIconCount; i++)
        {
            CreateIcon();
        }
    }

    public void Draw(List<StuffSO> repairStuffs, List<StuffSO> currentNeededStuffs)
    {
        List<StuffSO> currentNeededStuffsCopy = new List<StuffSO>(currentNeededStuffs);

        if (stuffIcons.Count < repairStuffs.Count)
        {
            for(int i = 0; i < repairStuffs.Count - stuffIcons.Count; i++)
            {
                CreateIcon();
            }
        }

        for(int i = repairStuffs.Count - 1; i >= 0; i--)
        {
            stuffIcons[i].SetIcon(repairStuffs[i].StuffIcon);
            stuffIcons[i].gameObject.SetActive(true);

            if (currentNeededStuffsCopy.Remove(repairStuffs[i]))
                stuffIcons[i].SetBackground(Color.red);
            else
                stuffIcons[i].SetBackground(Color.green);
        }
    }

    public void Hide()
    {
        for (int i = 0; i < stuffIcons.Count; i++)
            stuffIcons[i].gameObject.SetActive(false);
    }

    private void CreateIcon()
    {
        RepairStuffIconUI icon = Instantiate(stuffIconPrefab, transform);
        stuffIcons.Add(icon);
        icon.gameObject.SetActive(false);
    }
}
