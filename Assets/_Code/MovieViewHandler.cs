using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class MovieViewHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _yearText;
    [SerializeField] private TextMeshProUGUI _directorText;
    [SerializeField] private TextMeshProUGUI _leadActorText;
    [SerializeField] private TextMeshProUGUI _supportActorText;
    [SerializeField] private Image _criticScoreImage;
    [SerializeField] private Image _audienceScoreImage;
    [SerializeField] private TextMeshProUGUI _synopsisText;
    [SerializeField] private TextMeshProUGUI _budgetText;
    [SerializeField] private TextMeshProUGUI _revenueText;

    [HideInInspector] public MoviesItemModel _myModel;

    public void UpdateView(MoviesItemModel model)
    {
        _nameText.text = model.Name;
        _yearText.text = model.Year.ToString();
        _directorText.text = model.Director;
        _leadActorText.text = model.LeadActor;
        _supportActorText.text = model.SupportActor;
        _criticScoreImage.fillAmount = Mathf.InverseLerp(0, 100, model.CriticScore); 
        _audienceScoreImage.fillAmount = Mathf.InverseLerp(0, 100, model.AudienceScore);
        _synopsisText.text = model.Synopsis;
        _budgetText.text = model.Budget.ToString();
        _revenueText.text = model.Revenue.ToString();
    }
}
