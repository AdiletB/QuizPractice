using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonScript : MonoBehaviour
{
	[SerializeField]
	private Text label;
	
	[SerializeField]
	private Button button;
	
	public Action<bool, int> onClick;
	
	public bool isTrue;
	public int id;
	
	public void Init(bool isTrue, int id, string text){
		this.isTrue = isTrue;
		this.id = id;
		label.text = text;
	}
	private void ButtonClicked(){
		onClick(isTrue, id);
	}
	private void OnDestroy(){
		 button.onClick.RemoveAllListeners();
	}
    void Start()
    {
        button.onClick.AddListener(ButtonClicked);
    }
}
