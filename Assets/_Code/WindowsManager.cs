using TMPro;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private MyAPIRequest _myAPIRequest;
    [SerializeField] private RequestController _requestController;
    [SerializeField] private TMP_Dropdown _dropDownBox;
    [SerializeField] private GameObject _getCanvas;
    [SerializeField] private GameObject _manageCanvas;
    [SerializeField] private TextMeshProUGUI _statusMessage;

    private void Start()
    {
        _getCanvas.SetActive(true);
        _manageCanvas.SetActive(false);

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
                    _requestController.RefreshView();
                    _manageCanvas.SetActive(false);

                    break;
                case 1: //Upload
                    _getCanvas.SetActive(false);
                    _manageCanvas.SetActive(true);
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
