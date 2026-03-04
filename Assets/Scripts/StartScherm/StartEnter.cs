using Unity.VisualScripting;
using UnityEngine;

public class StartEnter : MonoBehaviour
{
    [SerializeField] private GameObject thisObject;
    [SerializeField] private GameObject levelMenu;

    private float timer = 0f;
    private bool visib;
    private CanvasGroup CanvasGroup;

    void Start()
    {
        CanvasGroup = GetComponent<CanvasGroup>();

        levelMenu.SetActive(false);
        thisObject.SetActive(true);
    }

    void Update()
    {
        ToggleVisibility();
        ToggleMenu();
    }

    private void ToggleVisibility()
    {
        timer += Time.deltaTime;

        if (timer > 1 && !visib)
        {
            timer = 0;
            visib = true;
            CanvasGroup.alpha = 0f;
        }

        if (timer > 1 && visib)
        {
            CanvasGroup.alpha = 1f;
            visib = false;
            timer = 0;
        }
    }

    private void ToggleMenu()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton7))
        { 
            levelMenu.SetActive(true);
            thisObject.SetActive(false);
        }
 
    }
}
