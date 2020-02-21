using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class QuizController : MonoBehaviour
{
    [SerializeField]
    private string sourceFileName;
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Canvas statsCanvas;
	[SerializeField]
	private GameObject buttonPrefab;
	[SerializeField]
	private Transform buttonContainer;
	
	private string langMode;
	
    private JsonConverter<QuestionCollection> _converter;
    private QuestionCollection questionsCollection;
	
    private int rightAnswersCounter = 0,
                currentQuestionId = 0;
    
    private void Awake() 
    {
        langMode = "ru";

        if(JsonConverter<QuestionCollection>.TryRead(Application.streamingAssetsPath + "/" + sourceFileName))
            Application.Quit();

        _converter = new JsonConverter<QuestionCollection>("questions.json");
        questionsCollection = _converter.Convert();
        questionText.text = LocalizeQuestion();
        Debug.Log("Count"+questionsCollection.questions[currentQuestionId].options.Count);
        GenerateButtons(questionsCollection.questions[currentQuestionId].options.Count);
        
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void ButtonClicked(bool choice, int id)
    {
        bool rightAnswer = questionsCollection.questions[currentQuestionId]
											  .options[id]
											  .isTrue;

        if(rightAnswer == choice)
            rightAnswersCounter++;

        UpdateAnswer();
    }
    
    private void UpdateAnswer()
    {
	    ClearPanel();
		
        currentQuestionId++;

        if(currentQuestionId >= questionsCollection.questions.Count){
            ShowStats();
            return;
        }          
        
        questionText.text = LocalizeQuestion();
		GenerateButtons(questionsCollection.questions[currentQuestionId].options.Count);
    }
    private void ShowStats()
    {
        var script = statsCanvas.gameObject.GetComponent<StatsController>();
        script.Show(rightAnswersCounter, questionsCollection.questions.Count);

        this.gameObject.SetActive(false);
        this.enabled = false;
    }
	private void GenerateButtons(int quantity){
		for(int i=0; i < quantity; i++)
		{
			var button = Instantiate(buttonPrefab, buttonContainer);
            Debug.Log("button"+button);
			bool flag = questionsCollection.questions[currentQuestionId].options[i].isTrue;
			string localizedText = LocalizeOption(i);
			
            var buttonScript = button.GetComponent<ButtonScript>();
			buttonScript.Init(flag,i,localizedText);
			buttonScript.onClick += ButtonClicked;
		}
	}
	private string LocalizeOption(int i)
	{
		switch(langMode){
				
				case "ru": return questionsCollection.questions[currentQuestionId].options[i].text_ru;
				case "en": return questionsCollection.questions[currentQuestionId].options[i].text_en;
				case "kz": return questionsCollection.questions[currentQuestionId].options[i].text_kz;

                default: return questionsCollection.questions[currentQuestionId].options[i].text_en;
		}
	}
	private string LocalizeQuestion()
	{
		switch(langMode){
				
				case "ru": return questionsCollection.questions[currentQuestionId].question_ru;
				case "en": return questionsCollection.questions[currentQuestionId].question_en;
				case "kz": return questionsCollection.questions[currentQuestionId].question_kz;

                default: return questionsCollection.questions[currentQuestionId].question_en;
		}
	}
	private void ClearPanel()
    {
		foreach(Transform button in buttonContainer){
			GameObject.Destroy(button.gameObject);
		}
	}
}
