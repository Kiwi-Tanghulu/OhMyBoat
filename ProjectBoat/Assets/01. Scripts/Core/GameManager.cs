using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        InputManager.ChangeInputMap(InputMapType.Play);
    }
}
