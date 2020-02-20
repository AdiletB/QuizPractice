using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    [SerializeField]
    private string sourceFileName;
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Button falseButton;
    [SerializeField]
    private Button trueButton;
    [SerializeField]
    private Canvas statsCanvas;
    private JsonConverter<QuestionCollection> _converter;
    private QuestionCollection questionsCollection;

    private int rightAnswersCounter = 0,
                currentQuestionId = 0;
    
    private void Awake() 
    {
        if(JsonConverter<QuestionCollection>.TryRead(Application.streamingAssetsPath + "/" + sourceFileName))
            Application.Quit();

        _converter = new JsonConverter<QuestionCollection>("questions.json");
        questionsCollection = _converter.Convert();
        questionText.text = questionsCollection.questions[currentQuestionId].question;
        
    }
    void Start()
    {
        falseButton.onClick.AddListener(() => 
            { 
                ButtonClicked(false);            
            }       
        );
        trueButton.onClick.AddListener(() => 
            { 
                ButtonClicked(true);            
            }       
        );
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void ButtonClicked(bool choice)
    {
        bool rightAnswer = questionsCollection.questions[currentQuestionId].answer;

        if(rightAnswer == choice)
            rightAnswersCounter++;

        UpdateAnswer();
    }
    
    private void UpdateAnswer()
    {
        currentQuestionId++;

        if(currentQuestionId >= questionsCollection.questions.Count){
            ShowStats();
            return;
        }          
        
        questionText.text = questionsCollection.questions[currentQuestionId].question;
    }
    private void ShowStats()
    {
        var script = statsCanvas.gameObject.GetComponent<StatsController>();
        script.Show(rightAnswersCounter);

         this.gameObject.SetActive(false);
         this.enabled = false;
    }
}
