using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionDatabase : MonoBehaviour
{
    public List<Question> questions;
    [SerializeField]
    UI UI;
    int index;

    private void Start()
    {
        FirstQuestion();
    }

    public void FirstQuestion()
    {
        UI.UpdateQuestionText(0);
    }

    public void NextQuestion()
    {
        UI.answerInputField.text = "";
        index++;
        UI.UpdateQuestionText(index);
    }

    public void OnSubmitButton()
    {
        SceneManager.LoadScene("AverageScene");
    }
}
