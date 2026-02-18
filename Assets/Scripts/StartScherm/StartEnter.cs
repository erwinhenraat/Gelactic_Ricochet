using UnityEngine;

public class StartEnter : MonoBehaviour
{
    private float timer = 0f;
    public bool visib;
    public CanvasGroup CanvasGroup;

    void Start()
    {
        CanvasGroup = GetComponent<CanvasGroup>();

    }

    // Update is called once per frame
    void Update()
    {
        ToggleVisibility();
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
}
