using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RequestController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private MovieViewHandler _movieViewHandler;
    [SerializeField] private MovieSenderHandler _movieSenderHandler;
    [SerializeField] private MyAPIRequest _APIRequester;
    [SerializeField] private MyAPIRequest.RequestType _RequestType;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _previousButton;
    [SerializeField] private TMP_Dropdown  _dropDownBox;

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
    private int _index;

    private void Start()
    {
        Prepare();
        GetRequest();
        _APIRequester.GotResponseEvent += BuildModelFromJson;
        _APIRequester.GotResponseEvent += PoblateDropDown;
        _APIRequester.GotResponseEvent += HasNext;
        _APIRequester.GotResponseEvent += HasPrevious;
    }

    public void RefreshView()
    {
        Prepare();
        GetRequest();
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
        _index = 0;
        _responseModel = _APIRequester.ResponseData[_index];
        SendToView();
    }
    
    public void GetRequest()
    {
        _APIRequester.RequestTypeOf = MyAPIRequest.RequestType.GET;
        _APIRequester.SendRequest(new MoviesItemModel(), 0);
    }
    
    public void PostRequest()
    {
        _movieSenderHandler.BuildModelFromInput();
        _APIRequester.RequestTypeOf = MyAPIRequest.RequestType.POST;
        _APIRequester.SendRequest(_movieSenderHandler.MyModel, _movieSenderHandler.MyModel.Id);
    }

    public void PutRequest()
    {
        _movieSenderHandler.BuildModelFromInput();
        _APIRequester.RequestTypeOf = MyAPIRequest.RequestType.PUT;
        _APIRequester.SendRequest(_movieSenderHandler.MyModel, _movieSenderHandler.MyModel.Id);
    }
    
    public void DeleteRequest()
    {
        _APIRequester.RequestTypeOf = MyAPIRequest.RequestType.DELETE;
        _APIRequester.SendRequest(new MoviesItemModel(), _movieSenderHandler.GetID());     
    }

    #region UI Methods

    private void PoblateDropDown()
    {
        _dropDownBox.options.Clear();
        foreach (var item in _APIRequester.ResponseData)
        {
            _dropDownBox.options.Add(new TMP_Dropdown.OptionData() { text = item.Name });
        }
        _dropDownBox.RefreshShownValue();
    }

    public void DropDownValueChanged(int value)
    {
        _index = value;
        _responseModel = _APIRequester.ResponseData[_index];
        SendToView();
        HasNext();
        HasPrevious();
    }

    private void SendToView()
    {
        _movieViewHandler.UpdateView(_responseModel);
    }

    public void NextButtonClick()
    {
        _index++;
        if (_index < _APIRequester.ResponseData.Count)
        {
            _responseModel = _APIRequester.ResponseData[_index];
            SendToView();
            HasNext();
            HasPrevious();
            _dropDownBox.value = _index;
        }
        else
        {
            _index = _APIRequester.ResponseData.Count - 1;
        }
    }

    public void PreviousButtonClick()
    {
        _index--;
        if (_index >= 0)
        {
            _responseModel = _APIRequester.ResponseData[_index];
            SendToView();
            HasNext();
            HasPrevious();
            _dropDownBox.value = _index;
        }
        else
        {
            _index = 0;
        }
    }
    
    private void HasNext()
    {
        if (_index < _APIRequester.ResponseData.Count - 1)
        {
            _nextButton.SetActive(true);
        }
        else
        {
            _nextButton.SetActive(false);
        }
    }

    private void HasPrevious()
    {
        if (_index > 0)
        {
            _previousButton.SetActive(true);
        }
        else
        {
            _previousButton.SetActive(false);
        }
    }
    #endregion
}
