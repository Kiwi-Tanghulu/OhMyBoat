using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LeakMiniGame : RepairMiniGame
{
    [Space]
    [SerializeField] private RectTransform paenl;
    [SerializeField] private RectTransform hammer;
    [SerializeField] private List<RectTransform> ponds;
    [SerializeField] private float hammerMoveSpeed;

    private float hammerRadius;
    private float halfPaenlXSize;

    private Vector3 moveDir;

    private List<bool> isClaer;
    private int claerCount;

    private void Awake()
    {
        hammerRadius = hammer.rect.width * 0.5f;
        halfPaenlXSize = paenl.rect.width * 0.5f;
        isClaer = new List<bool>();
        for (int i = 0; i < ponds.Count; i++)
            isClaer.Add(false);
    }

    public override void StartGame(RepairMissonObject missonObject)
    {
        base.StartGame(missonObject);

        moveDir = Vector3.right;
        hammer.localPosition = Vector3.zero;

        claerCount = 0;
        for (int i = 0; i < ponds.Count; i++)
            isClaer[i] = false;
    }

    protected override void Input_SpaceEvent()
    {
        for(int i = 0; i < ponds.Count; i++)
        {
            if (Vector2.Distance(ponds[i].position, hammer.position) <= hammerRadius && !isClaer[i])
            {
                claerCount++;
                isClaer[i] = true;
            }
        }

        if(claerCount == ponds.Count)
        {
            isSuccesses = true;
            EndGame();
        }
    }

    protected override void Update()
    {
        base.Update();

        hammer.localPosition += moveDir * hammerMoveSpeed * Time.deltaTime;
        
        if (Mathf.Abs(hammer.localPosition.x) >= halfPaenlXSize - hammerRadius)
        {
            moveDir *= -1;
        }
    }
}
