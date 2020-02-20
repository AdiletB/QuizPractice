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
    public List<QuestionEntity> questions;
}
