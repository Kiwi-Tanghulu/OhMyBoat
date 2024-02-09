using UnityEngine;

public class Spear : Equipment
{
    private void Awake()
    {
        Debug.Log("임시 도구 내구도 초기화");
        Init();
    }

    protected override void OnEquipmentActived()
    {
        Debug.Log($"적들을 공격해라! [ 남은 내구도 : {durability} ]");
    }
}
