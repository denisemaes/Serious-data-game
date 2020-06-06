using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{   
    public string headline;
    public string articleText;
    public string[] answers;
    public int correctToggle;
    public string answerExplanation;
}
