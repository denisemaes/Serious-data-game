using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI questionText = null;
    [SerializeField]
    public TMP_InputField answerInputField = null;
    [SerializeField]
    public GameObject completePanel = null;
    [SerializeField]
    QuestionDatabase questionDatabase = null;

    public void UpdateQuestionText(int questionIndex)
    {
        questionText.text = questionDatabase.questions[questionIndex].question;
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void OnMoreInfoButton()
    {
        //SceneManager.LoadScene();
    }
}
