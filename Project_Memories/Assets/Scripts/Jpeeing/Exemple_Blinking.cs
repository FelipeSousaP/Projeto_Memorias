using UnityEngine;
using UnityEngine.VFX;

public class Exemple_Blinking : MonoBehaviour{
    public int timer;
    [SerializeField] private VisualEffect _blinkParticles;


    void Update() {
        timer++;
        if (timer == 1000) {
            _blinkParticles.SendEvent("OnStopBlink");
            GetComponent<Renderer>().enabled = false;
        }
        if (timer == 1500) {
            GetComponent<Renderer>().enabled = true;
            timer = 0;
            _blinkParticles.SendEvent("OnBlink");
        }
    }

}
