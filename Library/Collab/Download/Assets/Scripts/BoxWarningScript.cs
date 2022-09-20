using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWarningScript : MonoBehaviour
{
    public float warningDuration = 2;
    float spawn_time;
    bool enabled = false;

    public void SetProperties(float warningDuration, bool enabled)
    {
        this.enabled = enabled;
        this.warningDuration = warningDuration;
        spawn_time = Time.time;
    }

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
    }

    void FixedUpdate()
    {
        if (enabled && MenuScript.enabledVisuals == true)
        {
            if (Time.fixedTime >= spawn_time + warningDuration)
            {
                this.enabled = false;
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (Time.fixedTime >= spawn_time + 4 * warningDuration / 5)
            {
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (Time.fixedTime >= spawn_time + 3 * warningDuration / 5)
            {
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (Time.fixedTime >= spawn_time + 2 * warningDuration / 5)
            {
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (Time.fixedTime >= spawn_time + warningDuration / 5)
            {
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
