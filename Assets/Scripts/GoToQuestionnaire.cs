using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToQuestionnaire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenLink()
    {
        Application.OpenURL("https://forms.gle/iSgtiaNUoxmNaxdE8");
    }
}
