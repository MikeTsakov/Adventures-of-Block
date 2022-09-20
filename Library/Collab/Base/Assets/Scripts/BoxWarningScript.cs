using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWarningScript : MonoBehaviour
{
    public float warningDuration = 2;
    //public SpriteRenderer spriteRenderer;
    public GameObject lbox, lbox1, lbox2;
    public GameObject rbox, rbox1, rbox2;
    float spawn_time;
    bool left = false;

    public void SetProperties(float warningDuration, bool enabled, string s)
    {
        this.enabled = enabled;
        this.warningDuration = warningDuration;
        spawn_time = Time.time;
        if (s == "left") {
            left = true;
        } else {
            left = false;
        }
    }

    private void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (left == true) {
            lbox.GetComponent<GameObject>();
            lbox1.name = "leftBWarn1";
            lbox2.name = "leftBWarn2";
            lbox.SetActive(false);
            lbox1.GetComponent<SpriteRenderer>().enabled = false;
            lbox2.GetComponent<SpriteRenderer>().enabled = false;
            //spriteRenderer.enabled = false;
        } else {
            rbox1.name = "rightBWarn1";
            rbox2.name = "rightBWarn2";
            rbox1.GetComponent<SpriteRenderer>().enabled = false;
            rbox2.GetComponent<SpriteRenderer>().enabled = false;
            //spriteRenderer.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (enabled && MenuScript.enabledVisuals == true)
        {
            if (Time.fixedTime >= spawn_time + warningDuration)
            {
                lbox.SetActive(false);
                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (Time.fixedTime >= spawn_time + 6 * warningDuration / 7)
            {
                lbox.SetActive(true);
                //gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (Time.fixedTime >= spawn_time + 5 * warningDuration / 7)
            {
                lbox.SetActive(false);
                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (Time.fixedTime >= spawn_time + 4 * warningDuration / 7)
            {
                lbox.SetActive(true);
                //gameObject.GetComponent<SpriteRenderer>().enabled = true;
                //box1.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (Time.fixedTime >= spawn_time + 3 * warningDuration / 7)
            {
                lbox.SetActive(false);
                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                //box1.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (Time.fixedTime >= spawn_time + 2 * warningDuration / 7)
            {
                lbox.SetActive(true);
                //gameObject.GetComponent<SpriteRenderer>().enabled = true;
                //box1.GetComponent<SpriteRenderer>().enabled = true;
                //box2.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (Time.fixedTime >= spawn_time + warningDuration / 7)
            {
                lbox.SetActive(false);
                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                //box1.GetComponent<SpriteRenderer>().enabled = false;
                //box2.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                lbox.SetActive(true);
                //gameObject.GetComponent<SpriteRenderer>().enabled = true;
                //box1.GetComponent<SpriteRenderer>().enabled = true;
                //box2.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
