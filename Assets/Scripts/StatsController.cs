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

    public void Show(int count){
        rightAnswers.text = count.ToString();
        gameObject.SetActive(true);
    }
    void Start()
    {
        closeButton.onClick.AddListener(()=> { Application.Quit(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
