using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI questionText;
    [SerializeField]
    public TMP_InputField answerInputField;
    [SerializeField]
    public GameObject wrongPanel;
    [SerializeField]
    public GameObject correctPanel;
    [SerializeField]
    public GameObject completePanel;
    [SerializeField]
    QuestionDatabase questionDatabase;

    public void UpdateQuestionText(int questionIndex)
    {
        questionText.text = questionDatabase.questions[questionIndex].question;
    }
}
