using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
[System.Serializable] public struct TagColor {
    public string tag;
    public Color32 color;
}
public class ComboMood : MonoBehaviour
{

    [SerializeField] private List<TagColor> tagColors = new List<TagColor>();
    [SerializeField] private TMP_Text multiplierField;
    [SerializeField] private TMP_Text restartField;
    [SerializeField] private TMP_Text titleField;

    [SerializeField] private float fadeIntensity = 0.25f;
    [SerializeField] private float fadeToColorTime = 0.3f;
    [SerializeField] private float fadeToBlackTime = 0.4f;
    [SerializeField] private float loopInterval = 0.8f;

    private VolumeProfile _volumeProfile;
    private int _tagColorIterator = 0;
    private bool _loops = false;


    private void Start() {         

        Combo.onComboAchieved += ChangeMood;
        Combo.onComboLost += ChangeMood;
        Lives.onGameOver += LoopMoods;
        Restart.onRestart += StopMoodLoop;

        _volumeProfile = GetComponent<Volume>().profile;
        
    }
    private void OnDisable()
    {
        Combo.onComboAchieved -= ChangeMood; 
        Combo.onComboLost -= ChangeMood;
        Lives.onGameOver -= LoopMoods;
        Restart.onRestart -= StopMoodLoop;

    }
    private void ChangeMood(int _, string tag) {
        Vignette vignette;
        if (!_volumeProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
       
        
        bool tagColorExists = false;
        foreach (TagColor tc in tagColors) {          
            if (tag == tc.tag) {
               
                StartCoroutine(FadeIn(vignette, tc.color, fadeIntensity, fadeToColorTime));
                tagColorExists = true;
                if (multiplierField != null) multiplierField.color = new Color32(tc.color.r, tc.color.g, tc.color.b, 255);
                //if (restartField != null) restartField.color = new Color32(tc.color.r, tc.color.g, tc.color.b, 255);
                if (titleField != null) titleField.color = new Color32(tc.color.r, tc.color.g, tc.color.b, 255);
            }
        }        
        if (!tagColorExists && vignette.color.value != Color.black) {
          
            StartCoroutine(FadeIn(vignette, Color.black, fadeIntensity, fadeToBlackTime));
            if (multiplierField != null) multiplierField.color = new Color32(255, 255, 255, 255);
            //if (restartField != null) multiplierField.color = new Color32(255, 255, 255, 255);
            if (titleField != null) titleField.color = new Color32(255, 255, 255, 255);
        } 
       
        
    }


    
    private void LoopMoods(string _) {
        _loops = true;
        StartCoroutine(Loop());
    }
    private void StopMoodLoop(string _) {
        _loops = false;
    }
    
    private IEnumerator Loop() {
        while (true) {
            if (!_loops) break;
            ChangeMood(0, tagColors[_tagColorIterator].tag);
            if (_tagColorIterator < tagColors.Count - 1) { _tagColorIterator++; } else { _tagColorIterator = 0; }
                yield return new WaitForSeconds(loopInterval);


        }

    }

    private IEnumerator FadeIn(Vignette v, Color color, float intensity, float seconds) 
    {
        
        float timer = 0f;
        
        while (true) {
            if (v == null) break;
            timer += Time.deltaTime;
            float interpolationValue = timer / seconds;            
            if (interpolationValue < .5f) { 
                v.intensity.Override(Mathf.Lerp(intensity, 0f, interpolationValue));
               

            }
            else {
                if (v.color.value != color) v.color.Override(color);
                v.intensity.Override(Mathf.Lerp(0f, intensity, interpolationValue));
                if (timer >= seconds) break;
            }           
            yield return new WaitForEndOfFrame();                     

        }
        
    }


}
