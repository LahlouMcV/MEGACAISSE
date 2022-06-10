using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScreen : MonoBehaviour
{
    [SerializeField] GameObject LevelButton;
    [SerializeField] Transform GridParent;
    private void Awake()
    {
        int scenes = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 1;
        for (int i = 0; i < scenes; i++)
        {
            LevelSelectButtons button = Instantiate(LevelButton, GridParent).GetComponent<LevelSelectButtons>();
            button.SceneToLoad = i + 1;
        }
    }
}
