using Unity.VisualScripting;
using UnityEngine;

public class StartEnter : MonoBehaviour
{
    [SerializeField] private GameObject thisObject;
    [SerializeField] private GameObject levelMenu;

    private float timer = 0f;
    public bool visib;
    public CanvasGroup CanvasGroup;

    void Start()
    {
        CanvasGroup = GetComponent<CanvasGroup>();

        levelMenu.SetActive(false);
        thisObject.SetActive(true);
    }

    // Update is called once per frame
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
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))

        {
            levelMenu.SetActive(true);
            thisObject.SetActive(false);
        }
    }
}
