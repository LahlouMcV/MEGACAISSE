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
    [SerializeField] FMODUnity.StudioEventEmitter VictorySound;
    [SerializeField] FMODUnity.StudioEventEmitter LoseSound;

    bool once = false;
    bool twonce = false;

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
        UnityEngine.UI.Image image = VictoryFeedback.GetComponent<UnityEngine.UI.Image>();
        image.color = new Color(0, 0, 0, 0);
        UnityEngine.UI.Image img = LoseFeedback.GetComponent<UnityEngine.UI.Image>();
        img.color = new Color(0, 0, 0, 0);
        once = false;
        twonce = false;
    }

    public void LoadScene(int sceneNum)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);
    }

    public void TriggerWinCondition()
    {
        if(once == false)
        {
            once = true;
            Debug.Log("Triggered Win");
            StartCoroutine(VictoryAnimation());
            VictorySound.Play();
            Invoke("GoToMainMenu", 5f);
        }
        
    }

    public void TriggerLoseCondition()
    {
        if (twonce == false)
        {
            twonce = true;
            Debug.Log("Triggered Loss");
            StartCoroutine(LossAnimation());
            LoseSound.Play();
            Invoke("GoToMainMenu", 5f);
        }
        
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
        UnityEngine.UI.Image image = LoseFeedback.GetComponent<UnityEngine.UI.Image>();
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
