using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using SimpleJSON;
using TMPro;
using System;

public class MyAPIRequest : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI _OutputText;
    [SerializeField] private string _URLToRequest;
    
    [HideInInspector] public RequestType RequestTypeOf;

    public enum RequestType
    {
        GET,
        POST,
        PUT,
        DELETE,
    }

    public void NewRequest()
    {
        StartCoroutine(GetRequest(_URLToRequest));
    }

    public void SendRequest(System.Object requestData, int id = 0 )
    {
        switch (RequestTypeOf)
        {
            case RequestType.GET:
                StartCoroutine(GetRequest(_URLToRequest));
                break;
            case RequestType.POST:
                StartCoroutine(PostRequest(_URLToRequest, requestData));
                break;
            case RequestType.PUT:
                StartCoroutine(PutRequest(_URLToRequest,requestData, id));
                break;
            case RequestType.DELETE:
                StartCoroutine(DeleteRequest(_URLToRequest, id));
                break;
        }
    }

    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest getRequest = UnityWebRequest.Get(uri);
        yield return getRequest.SendWebRequest();
        JSONNode root = HandleResult(getRequest);
        getRequest.Dispose();
    }

    IEnumerator PostRequest(string uri, System.Object Data)
    {
        string json = JsonUtility.ToJson(Data);
        UnityWebRequest postRequest = UnityWebRequest.Put(uri, json);
        postRequest.method = "POST";
        postRequest.SetRequestHeader("Content-Type", "application/json");
        yield return postRequest.SendWebRequest();
        HandleResult(postRequest);
        postRequest.Dispose();
    }

    IEnumerator PutRequest(string uri, System.Object Data, int id)
    {
        Debug.Log("The id is " + id);
        if (id <= 0) throw new ArgumentOutOfRangeException("id"); 
        string json = JsonUtility.ToJson(Data);
        UnityWebRequest putRequest = UnityWebRequest.Put(uri +"/"+ id, json);
        putRequest.SetRequestHeader("Content-Type", "application/json");
        yield return putRequest.SendWebRequest();
        HandleResult(putRequest);
        putRequest.Dispose();
    }

    IEnumerator DeleteRequest(string uri, int id)
    {
        Debug.Log("The id is " + id);
        if (id <= 0) throw new ArgumentOutOfRangeException("id");
        UnityWebRequest deleteRequest = UnityWebRequest.Delete(uri + "/" + id);
        deleteRequest.SetRequestHeader("Content-Type", "application/json");
        yield return deleteRequest.SendWebRequest();
        HandleResult(deleteRequest);
        deleteRequest.Dispose();
    }

    private JSONNode HandleResult(UnityWebRequest webRequest)
    {
        JSONNode root = null;
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(": Error: " + webRequest.error);
                break;

            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(": HTTP Error: " + webRequest.error);
                break;

            case UnityWebRequest.Result.Success:
                if (webRequest.downloadHandler != null)
                {
                    _OutputText.text = webRequest.downloadHandler.text;
                    Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                    root = JSONNode.Parse(webRequest.downloadHandler.text);

                    Debug.Log("EL root es el siguiente " + root);

                    foreach (var key in root.Keys)
                    {
                        Debug.Log(key);
                        Debug.Log(root[key]);
                    }
                }
                break;
               
        }
        return root;
    }

}
