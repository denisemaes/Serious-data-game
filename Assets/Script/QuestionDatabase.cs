using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            UI.correctPanel.SetActive(false);
            UI.answerInputField.text = "";
            index++;
            UI.UpdateQuestionText(index);
    }

    public void CheckAnswer()
    {
        if (UI.answerInputField.text == questions[index].answer)
            UI.correctPanel.SetActive(true);
        else
            StartCoroutine(WrongPanelRoutine());
    }

    IEnumerator WrongPanelRoutine()
    {
        UI.wrongPanel.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        UI.wrongPanel.SetActive(false);
    }
}
