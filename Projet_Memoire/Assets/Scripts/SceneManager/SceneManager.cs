using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private InputAction Escape;
    public static SceneManager _SceneManager;

    private void Awake()
    {
        //Escape Input
        Escape = new InputAction(binding: "<Keyboard>/escape");
        Escape.performed += _ => GoToMainMenu();

        //Handling public static
        if (SceneManager._SceneManager == null)
        {
            SceneManager._SceneManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        Escape.Enable();
    }

    private void OnDisable()
    {
        Escape.Disable();
    }

    public void GoToMainMenu()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene() == UnityEngine.SceneManagement.SceneManager.GetSceneAt(0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    public void LoadScene(int sceneNum)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);
    }
}
