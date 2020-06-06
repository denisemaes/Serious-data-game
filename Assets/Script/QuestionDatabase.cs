using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionDatabase : MonoBehaviour
{
    [SerializeField] UI UI;
    public List<Question> questions;
    public int index;

    private void Start()
    {
        DontDestroyOnLoad(this);
        FirstQuestion();
    }

    void FirstQuestion()
    {
        UI.UpdateQuestionText(0);
    }
}
