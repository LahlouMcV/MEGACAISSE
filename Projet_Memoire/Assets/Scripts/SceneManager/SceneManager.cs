using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private InputAction Escape;
    public static SceneManager _SceneManager;

    [SerializeField] GameObject VictoryFeedback;
    [SerializeField] GameObject LoseFeedback;

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

    public void TriggerWinCondition()
    {
        Debug.Log("Triggered Win");
        StartCoroutine(VictoryAnimation());
        Invoke("GoToMainMenu", 2.5f);
    }

    public void TriggerLoseCondition()
    {
        Debug.Log("Triggered Loss");
        StartCoroutine(LossAnimation());
        Invoke("GoToMainMenu", 2.5f);
    }

    IEnumerator VictoryAnimation()
    {
        UnityEngine.UI.Image image = VictoryFeedback.GetComponent<UnityEngine.UI.Image>();
        float a = 0;
        while(true)
        {
            a += Time.deltaTime;
            image.color = new Color(0,0,0, a);
            if (a >= 1) StopAllCoroutines();
            yield return null;
        }
    }

    IEnumerator LossAnimation()
    {
        UnityEngine.UI.Image image = VictoryFeedback.GetComponent<UnityEngine.UI.Image>();
        float a = 0;
        while (true)
        {
            a += Time.deltaTime;
            image.color = new Color(0, 0, 0, a);
            if (a >= 1) StopAllCoroutines();
            yield return null;
        }
    }
}
