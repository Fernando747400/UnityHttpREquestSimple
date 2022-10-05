using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private MyAPIRequest _APIRequester;
    [SerializeField] private MyAPIRequest.RequestType _RequestType;

    [Header("Settings")]
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private int _year;
    [SerializeField] private string _director;
    [SerializeField] private string _leadActor;
    [SerializeField] private string _supportActor;
    [SerializeField] private float _criticScore;
    [SerializeField] private float _audienceScore;
    [TextArea(5,15)]
    [SerializeField] private string _synopsis;
    [SerializeField] private double _budget;
    [SerializeField] private double _revenue;

    private MoviesItemModel _myModel;

    private void Start()
    {
        Prepare();
    }

    public void SendRequest()
    {
        BuildModel();
        _APIRequester.RequestTypeOf = _RequestType;
        _APIRequester.SendRequest(_myModel, _myModel.Id);
    }

    private void BuildModel()
    {
        if (_id > 0) _myModel = new MoviesItemModel(_id, _name, _year, _director, _leadActor, _supportActor, _criticScore, _audienceScore, _synopsis, _budget, _revenue);
        else _myModel = new MoviesItemModel(_name, _year, _director, _leadActor, _supportActor, _criticScore, _audienceScore, _synopsis, _budget, _revenue);
    }

    private void Prepare()
    {
        BuildModel();
    }
}
