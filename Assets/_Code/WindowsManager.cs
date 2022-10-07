using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WindowsManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private MyAPIRequest _myAPIRequest;
    [SerializeField] private TMP_Dropdown _dropDownBox;
    [SerializeField] private GameObject _getCanvas;
    [SerializeField] private GameObject _postCanvas;
    [SerializeField] private GameObject _putCanvas;
    [SerializeField] private GameObject _deleteCanvas;
    [SerializeField] private TextMeshProUGUI _statusMessage;

    private void Start()
    {
        _getCanvas.SetActive(true);
        _postCanvas.SetActive(false);
        _putCanvas.SetActive(false);
        _deleteCanvas.SetActive(false);

        _myAPIRequest.SuccesResponseEvent += ShowSuccess;
        _myAPIRequest.FailedResponseEvent += ShowFailed;
    }

    public void OnValueChanged()
    {
        {
            switch (_dropDownBox.value)
            {
                case 0: //Browse
                    _getCanvas.SetActive(true);
                    _postCanvas.SetActive(false);
                    _putCanvas.SetActive(false);
                    _deleteCanvas.SetActive(false);
                    break;
                case 1: //Upload
                    _getCanvas.SetActive(false);
                    _postCanvas.SetActive(true);
                    _putCanvas.SetActive(false);
                    _deleteCanvas.SetActive(false);
                    break;
                case 2://Update
                    _getCanvas.SetActive(false);
                    _postCanvas.SetActive(false);
                    _putCanvas.SetActive(true);
                    _deleteCanvas.SetActive(false);
                    break;
                case 3://Delete
                    _getCanvas.SetActive(false);
                    _postCanvas.SetActive(false);
                    _putCanvas.SetActive(false);
                    _deleteCanvas.SetActive(true);
                    break;
            }
        }
    }

    private void ShowSuccess()
    {
        _statusMessage.text = "Success";
    }

    private void ShowFailed(string message)
    {
        _statusMessage.text = message;
    }
}
