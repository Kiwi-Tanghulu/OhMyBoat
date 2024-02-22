using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeBtn : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Fader.Instance.FadeOut(() => SceneManager.LoadScene(sceneName));
    }
}
