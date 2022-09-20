/*
The MIT License (MIT)

Copyright (c) 2018 Victor van Andel, Chun He
Copyright (c) 2018 Twan Veldhuis, Ivar Troost

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using TMPro;

public class MenuScript : MonoBehaviour {

    public static bool enabledVisuals = true;

    [SerializeField]
    Button trialButton;

    [SerializeField]
    Button experimentButton;

    public static string state = "";
    public static int QuestionsAnswered = 0;
    public static int levelID = 0;
    public static string[] levelNames = new string[] { "Level1", "Level2", "Level3", "Level4", "Cloudtopia", "Bombmania" };
    public static Boolean trialPlayed = false;
    public static Variation[][] soundOrders = new Variation[][]
    {
        new Variation[] { Variation.None, Variation.None, Variation.None },
        new Variation[] { Variation.Video, Variation.Video, Variation.Video },
        new Variation[] { Variation.Slow, Variation.Slow, Variation.Slow },
        new Variation[] { Variation.Fast, Variation.Fast, Variation.Fast },
        new Variation[] { Variation.Both, Variation.Both, Variation.Both } // The 'Both' variant was created to test how well the animations and audio of the same tempo match, it is not actually used in the experiment though
    };

    public void Start()
    {
        
    }

    public void OnButtonTutorial()
    {
        Log.SetLevel(soundOrders[0][0], levelNames[0]);
        SceneManager.LoadScene("main");
        state = "tutorial";
    }

    public void OnButtonAudio()
    {
        InputField codeField = FindObjectOfType<InputField>();

        UserGroup group;
        try
        {
            int code = int.Parse(codeField.text);
            group = codeDict[code];
        }
        catch
        {
            //System.Random rnd = new System.Random();
            //group = codeDict[rnd.Next(1, 5)];
            group = Instructions.assignedGroup;
        }

        Log.SetLevel(soundOrders[0][0], levelNames[1]);
        SceneManager.LoadScene("main");
        state = "game";
        enabledVisuals = false;
    }

    public void OnButtonVisual()
    {
        InputField codeField = FindObjectOfType<InputField>();
        UserGroup group;
        try
        {
            int code = int.Parse(codeField.text);
            group = codeDict[code];
        }
        catch
        {
            //System.Random rnd = new System.Random();
            //group = codeDict[rnd.Next(1, 5)];
            group = Instructions.assignedGroup;
        }
        Log.SetLevel(soundOrders[0][0], levelNames[2]);

        GameObject.Find("Volume").gameObject.SetActive(false);
        PlayerPrefs.SetFloat("Volume", 0);
        SceneManager.LoadScene("main");
        state = "game";
        enabledVisuals = true;
    }

    public void OnButtonBoth()
    {
        InputField codeField = FindObjectOfType<InputField>();

        UserGroup group;
        try
        {
            int code = int.Parse(codeField.text);
            group = codeDict[code];
        }
        catch
        {
            group = Instructions.assignedGroup;
        }
        Log.SetLevel(soundOrders[0][0], levelNames[3]);
        SceneManager.LoadScene("main");
        state = "game";
    }

    public void OnNext()
    {
        if (state.Equals("tutorial"))
        {
            PlayerController.Score = 0;
            SceneManager.LoadScene("menu");
        }
        else
        {
            SceneManager.LoadScene("results");
        }
        
        if (!Log.IsSessionInProgress && !Log.isFreePlay)
            throw new Exception("only valid when session in progress");

        if(state == "game")
        {
            Log.EndAttempt();
            if (Log.Attempt < 1)
                SceneManager.LoadScene("main");
            else
            {
                if (levelID == 2)
                {
                    if (Log.isFreePlay)
                    {
                        SceneManager.LoadScene("freeplay");
                    }
                    else
                    {
                        state = "endQ";
                        SceneManager.LoadScene("question");
                    }
                }
                else
                {
                    state = "midQ";
                    OnNext();
                }
            }
            return;
        }
        else if (state == "midQ")
        {
            //go to the next level
            state = "game";
            levelID++;
            Log.SetLevel(soundOrders[(int)Log.UserGroup][levelID], levelNames[levelID]);
            SceneManager.LoadScene("main");
        }
       
        else if (state == "finished")
        {
            state = "";

            Log.EndSession();
            SceneManager.LoadScene("exit");
        }

        else if (state == "trial")
        {
            Log.EndAttempt();
            if (Log.Attempt < 1)
                SceneManager.LoadScene("main");
            else
            {
                trialPlayed = true;
                SceneManager.LoadScene("menu");
            }
            return;
        }
    }

    Dictionary<int, UserGroup> codeDict = new Dictionary<int, UserGroup>()
    {
        { 1, UserGroup.A },

        { 2, UserGroup.B },

        { 3, UserGroup.C },

        { 4, UserGroup.D },
        
        { 5, UserGroup.E }, // CHANGED FOR TESTING PURPOSES
    };
}
