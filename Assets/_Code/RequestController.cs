using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private MovieViewHandler _movieViewHandler;
    [SerializeField] private MovieSenderHandler _movieSenderHandler;
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
    private MoviesItemModel _responseModel;

    private void Start()
    {
        Prepare();
        _APIRequester.GotResponseEvent += BuildModelFromJson;
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

    private void BuildModelFromJson()
    {
        _responseModel = JsonUtility.FromJson<MoviesItemModel>(_APIRequester.ResponseData[0]);
        SendToView();
    }

    private void SendToView()
    {
        _movieViewHandler.UpdateView(_responseModel);
    }

    private void GetFirstObjectFromJason()
    {
        
    }

    private void SendPost()
    {
        _movieSenderHandler.BuildModelFromInput();
        _APIRequester.RequestTypeOf = MyAPIRequest.RequestType.POST;
        _APIRequester.SendRequest(_movieSenderHandler.MyModel, _movieSenderHandler.MyModel.Id);
    }
}
