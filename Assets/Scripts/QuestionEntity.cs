using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionEntity
{
    public int id;
    public string question;
    public bool answer;
}
[System.Serializable]
public class QuestionCollection
{
    public List<QuestionWithOptions> questions;
}
[System.Serializable]
public class QuestionWithOptions
{
	public int id;
    public string question_ru;
    public string question_kz;
    public string question_en;
	public List<Option> options;
}
[System.Serializable]
public class Option
{
    public int id;
	public bool isTrue;
	public string text_ru;
	public string text_kz;
	public string text_en;	
}
