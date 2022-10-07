using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovieSenderHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject _IDText;
    [SerializeField] private GameObject _nameText;
    [SerializeField] private GameObject _yearText;
    [SerializeField] private GameObject _directorText;
    [SerializeField] private GameObject _leadActorText;
    [SerializeField] private GameObject _supportActorText;
    [SerializeField] private GameObject _criticScoreText;
    [SerializeField] private GameObject _audienceScoreText;
    [SerializeField] private GameObject _synopsisText;
    [SerializeField] private GameObject _budgetText;
    [SerializeField] private GameObject _revenueText;

    public MoviesItemModel MyModel;

    public void BuildModelFromInput()
    {
        if (_IDText.GetComponent<TMP_InputField>().text != "")
        {
            MyModel.Id = int.Parse(_IDText.GetComponent<TMP_InputField>().text);
        }
        else
        {
            MyModel.Id = 0;
        }
        MyModel.Name = _nameText.GetComponent<TMP_InputField>().text;
        MyModel.Year = int.Parse(_yearText.GetComponent<TMP_InputField>().text);
        MyModel.Director = _directorText.GetComponent<TMP_InputField>().text;
        MyModel.LeadActor = _leadActorText.GetComponent<TMP_InputField>().text;
        MyModel.SupportActor = _supportActorText.GetComponent<TMP_InputField>().text;
        MyModel.CriticScore = int.Parse(_criticScoreText.GetComponent<TMP_InputField>().text);
        MyModel.AudienceScore = int.Parse(_audienceScoreText.GetComponent<TMP_InputField>().text);
        MyModel.Synopsis = _synopsisText.GetComponent<TMP_InputField>().text;
        MyModel.Budget = int.Parse(_budgetText.GetComponent<TMP_InputField>().text);
        MyModel.Revenue = int.Parse(_revenueText.GetComponent<TMP_InputField>().text);
    }
}
