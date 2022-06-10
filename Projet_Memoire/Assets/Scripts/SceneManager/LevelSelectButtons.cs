using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelectButtons : MonoBehaviour
{
    public int SceneToLoad = 0;
    [SerializeField] TMP_Text text;

    public void LoadScene()
    {
        SceneManager._SceneManager.LoadScene(SceneToLoad);
    }

    private void Start()
    {
        text.text = (SceneToLoad-1).ToString();
    }
}
