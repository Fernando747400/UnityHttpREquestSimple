using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using TMPro;

public class MyAPIRequest : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI _OutputText;
    [SerializeField] private string _URLToRequest;

    public void Start()
    {
        StartCoroutine(GetRequest(_URLToRequest));
    }

    public void NewRequest()
    {
        StartCoroutine(GetRequest(_URLToRequest));
    }


    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;

                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;

                case UnityWebRequest.Result.Success:
                    _OutputText.text = webRequest.downloadHandler.text;
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    JSONNode root = JSONNode.Parse(webRequest.downloadHandler.text);
                    Debug.Log("EL root es el siguiente");
                    Debug.Log(root);

                    foreach (var key in root.Keys)
                    {
                        Debug.Log(key);
                        Debug.Log(root[key]);
                    }
                    
                    yield return root;
                    break;
            }
        }
    }
}
