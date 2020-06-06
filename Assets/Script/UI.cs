using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditorInternal;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText = null;
    [SerializeField] GameObject answerPanel = null;
    [SerializeField] TextMeshProUGUI headlineText = null;
    [SerializeField] TextMeshProUGUI answerText = null;
    [SerializeField] TextMeshProUGUI explanationText = null;
    [SerializeField] public GameObject completePanel = null;
    [SerializeField] QuestionDatabase QD = null;
    [SerializeField] UnityEngine.UI.Toggle[] toggles;
    [SerializeField] TextMeshProUGUI[] answers;

    //public TMP_InputField answerInputField = null;


    public void UpdateQuestionText(int index) 
    {
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].text = QD.questions[QD.index].answers[i];
        }
        questionText.text = QD.questions[index].articleText;
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("IntroScene");
    }

    int GetActiveToggleNumber()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
                return i;
        }
        return 999;
    }

    public void OnSubmitButton()
    {
        
        answerPanel.SetActive(true);
        if (QD.questions[QD.index].correctToggle == GetActiveToggleNumber())
        {
            answerText.text = "Correct!";
            answerText.color = Color.green;
        }
        else
        {
            answerText.text = "Fout";
            answerText.color = Color.red;
        }

        explanationText.text = QD.questions[QD.index].answerExplanation;
        if (QD.index < QD.questions.Count + 1)
            QD.index++;

        if (QD.index >= QD.questions.Count)
        {
            completePanel.SetActive(true);
        }
        else
        {
            UpdateQuestionText(QD.index);
        }
    }

    public void OnTerugButton()
    {
        answerPanel.SetActive(false);
    }

    public void OnMeerInfoButton()
    {
        answerPanel.SetActive(true);
    }
}
