using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    [SerializeField]
    private Text rightAnswers;

    [SerializeField]
    private Button closeButton;

    public void Show(int count, int countOfQuestions){
        rightAnswers.text = GetResultInPercents(countOfQuestions, count).ToString() + "%";
        gameObject.SetActive(true);
    }
	private double GetResultInPercents(int count, int value){
		return (value % count) * 100;
	}
    void Start()
    {
        closeButton.onClick.AddListener(()=> { Application.Quit(); });
    }
	
    void OnDestroy(){
        closeButton.onClick.RemoveAllListeners();
    }
}
