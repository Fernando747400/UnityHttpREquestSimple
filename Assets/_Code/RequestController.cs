using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private MyAPIRequest _APIRequester;
    [SerializeField] private MyAPIRequest.RequestType _RequestType;

    [Header("Settings")]
    [SerializeField] private int _modelID;
    [SerializeField] private string _modelName;
    [SerializeField] private bool _modelIsComplete;

    private TodoItemModel _myModel;

    private void Start()
    {
        Prepare();
    }

    public void SendRequest()
    {
        BuildModel();
        _APIRequester.RequestTypeOf = _RequestType;
        _APIRequester.SendRequest(_myModel, _myModel.TodoItemId);
    }

    private void BuildModel()
    {
        if (_modelID > 0) _myModel = new TodoItemModel(_modelID, _modelName, _modelIsComplete);
        else _myModel = new TodoItemModel(_modelName, _modelIsComplete);
    }

    private void Prepare()
    {
        BuildModel();
    }
}
