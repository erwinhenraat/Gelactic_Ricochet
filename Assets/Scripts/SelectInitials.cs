using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class SelectInitials : MonoBehaviour
{
    public static Action<string> onInitialsSubmitted; 

    [SerializeField] private Image up;
    [SerializeField] private Image down;
    [SerializeField] private TMP_Text instructionsField;
    [SerializeField] private TMP_Text fireWhenDone;
    [SerializeField] private float[] collumPositions = new float[3];
    [SerializeField] private float inputThreshold = 0.5f;
    [SerializeField] private float submissionDelay = 5f;
    private string _initials = "AAA";
    private int _initialIndex = 0;
    private int _maxInitials = 3;
    private bool _active;
    private TMP_Text _initialField;
    private float _submissionTimer = 0f;
    private Vector2 lastDirection = Vector2.zero;
    private float _countDown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _initialField = GetComponent<TMP_Text>();
        Score.onSaveNewHighscore += Activate;
        Deactivate();

    }
    private void OnDisable()
    {
        Score.onSaveNewHighscore -= Activate;
    }

    private void Activate(int highscore)
    {        
        foreach (Image im in gameObject.GetComponentsInChildren<Image>())
        {
            im.enabled = true;
        }
        _initialField.enabled = true;
        instructionsField.enabled = true;
        if(CrosshairInput.SelectedType == InputType.XBox) fireWhenDone.enabled = true;
        UpdateUI();
        Cursor.visible = true;
        _active = true;
        _submissionTimer = 0;
        _countDown = submissionDelay;
    }
    private void Deactivate()
    {        
        foreach (Image im in gameObject.GetComponentsInChildren<Image>()) { 
            im.enabled = false;
        }
        _initialField.enabled = false; 
        instructionsField.enabled = false;
        if(fireWhenDone.enabled)fireWhenDone.enabled = false;
        Cursor.visible = false;
        _active = false;
    }  
    // Update is called once per frame
    void Update()
    {

        if(CrosshairInput.SelectedType == InputType.XBox && _active)CheckJoystickInput();
    }
    
  
    public void CheckJoystickInput() {        

        Vector2 direction = Vector2.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        //right
        if (lastDirection.x > inputThreshold && direction.x < inputThreshold) OnPressNext();
        if (lastDirection.x < -inputThreshold && direction.x > -inputThreshold) OnPressPrev();
        if (lastDirection.y > inputThreshold && direction.y < inputThreshold) OnPressUp();
        if (lastDirection.y < -inputThreshold && direction.y > -inputThreshold) OnPressDown();

        if (Input.GetButtonUp("Fire1")&& _submissionTimer > submissionDelay) OnPressDone();
          

        
        _submissionTimer += Time.deltaTime;
        float cd = _countDown - _submissionTimer;

        if (cd > 0) { 
            fireWhenDone.text = $"{Mathf.Round(cd)}"; } 
        else {
            fireWhenDone.text = "press -FIRE- to submit!";
        }

        lastDirection.x = direction.x;
        lastDirection.y = direction.y;


    }
    private enum SwapDirection { UP, DOWN };
    public void OnPressUp() {
        InitialChange(SwapDirection.UP);
        UpdateUI();
    }
    public void OnPressDown() {
        InitialChange(SwapDirection.DOWN);
        UpdateUI();
    }
    public void OnPressNext()
    {
        NextInitial();
        RelocateArrows();
    }
    public void OnPressPrev()
    {
        PrevInitial();
        RelocateArrows();
    }
    public void OnPressDone() {
        HandleDone();
    }    

    private void RelocateArrows() {
        //up arrow
        Vector2 newPos = up.gameObject.transform.localPosition;
        newPos.x = collumPositions[_initialIndex];
        up.gameObject.transform.localPosition = newPos;
        //down arrow
        newPos = down.gameObject.transform.localPosition;
        newPos.x = collumPositions[_initialIndex];
        down.gameObject.transform.localPosition = newPos;
    }

    private void InitialChange(SwapDirection direction) {
        
        char character = _initials[_initialIndex];
       
        switch (direction) { 
            case SwapDirection.UP:
                character++;
                break;
            case SwapDirection.DOWN:
                character--;
                break;
            default:
                break;

        }       
        char[] chars = _initials.ToCharArray();
        chars[_initialIndex] = character;
        string result = string.Empty;
        foreach (char c in chars) {
            result += c;
        }
        _initials = result;
        

    }
    private void UpdateUI()
    {
       _initialField.text = _initials;
    } 
    private void NextInitial() {
        if (_initialIndex < _maxInitials - 1) _initialIndex++;
    }
    private void PrevInitial() {
        if (_initialIndex >  0) _initialIndex--;
    }
    private void HandleDone() {        
       
        Deactivate();
        onInitialsSubmitted?.Invoke(_initials);
    }

}
