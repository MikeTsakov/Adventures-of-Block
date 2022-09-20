//http://stackoverflow.com/questions/13708395/how-can-i-draw-a-circle-in-unity3d/30441346#30441346

using UnityEngine;
using System.Collections;

public class CircleDraw : MonoBehaviour
{
    float theta_scale = 0.01f; //Set lower to add more points
    float radius = 3f;
    int size; //Total number of points in circle
    LineRenderer lineDrawer;
    LineRenderer lineDrawerFill;
    float duration = 0.185f;
    float temp = 0f;
    float tempFill = 0f;
    float theta = 0f;

    [SerializeField]
    Color color;

    [SerializeField]
    float width = 0.02f;

    [SerializeField]
    Material material;

    GameObject circleFill;
    //GameObject particleFill;

    public void SetRadius(float value)
    {
        radius = value;
    }

    public void SetEnabled(bool value)
    {
        this.enabled = value;
        lineDrawer.enabled = value;
        lineDrawerFill.enabled = value;
    }

    void Start()
    {
        lineDrawer = GetComponent<LineRenderer>();
        lineDrawer.material = material;

        lineDrawerFill = GetComponent<LineRenderer>();
        lineDrawerFill.material = material;

        //lineDrawer.SetColors(color, color);
        //lineDrawer.SetWidth(width, width); //thickness of line

        lineDrawer.startColor = color;
        lineDrawer.endColor = color;
        lineDrawer.startWidth = width;
        lineDrawer.endWidth = width;

        lineDrawerFill.startColor = color;
        lineDrawerFill.endColor = color;
        lineDrawerFill.startWidth = width;
        lineDrawerFill.endWidth = width;

        circleFill = transform.Find("circleFill").gameObject;
        //particleFill = transform.Find("particleFill").gameObject;
    }


    void Update()
    {
        theta = 0f;
        size = (int)((1f / theta_scale) + 1f);
        float gOx = gameObject.transform.position.x;
        float gOy = gameObject.transform.position.y;
        //lineDrawer.SetVertexCount(size);
        lineDrawer.positionCount = size;
        lineDrawerFill.positionCount = size;


        temp += Time.deltaTime;
        for (int i = 0; i < size; i++)
        {
            theta += (2.0f * Mathf.PI * theta_scale);
            float x = radius * Mathf.Cos(theta) + gOx;
            float y = radius * Mathf.Sin(theta) + gOy;
            lineDrawer.SetPosition(i, new Vector3(x, y, 0));
        }


        /*if (temp > duration)
        {
            tempFill = tempFill + temp;
            StartCoroutine(drawIncrements(gOx, gOy));
            for (int j = 0; j < size; j++)
            {
                theta += (2.0f * Mathf.PI * theta_scale);
                float xFill = radius * tempFill / Level.getDelay() * Mathf.Cos(theta) + gOx;
                float yFill = radius * tempFill / Level.getDelay() * Mathf.Sin(theta) + gOy;
                lineDrawerFill.SetPosition(j, new Vector3(xFill, yFill, 0));
            }
            temp = temp - duration;
        }*/

        if (MenuScript.enabledVisuals == true)
        {
            if (temp > duration)
            {
                tempFill = tempFill + temp;
                circleFill.transform.localScale += new Vector3(radius, radius, 0) * tempFill / Level.getDelay();
                temp = temp - duration;
            }
        } 
    }
}