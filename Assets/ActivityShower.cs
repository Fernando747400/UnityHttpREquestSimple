using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using TMPro;
using UnityEngine.UI;

public class ActivityShower : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Gradient _gradient;
    [SerializeField] private TextMeshProUGUI _activity;
    [SerializeField] private TextMeshProUGUI _type;
    [SerializeField] private TextMeshProUGUI _participants;
    [Header("Price Slider")]
    [SerializeField] private Slider _sliderPrice;
    [SerializeField] private Image _sliderPriceImage;
    [SerializeField] private TextMeshProUGUI _sliderPriceText;
    [Header("Link")]
    [SerializeField] private TextMeshProUGUI _Link;
    [Header("Accessibility Slider")]
    [SerializeField] private Slider _sliderAccess;
    [SerializeField] private Image _sliderAccessImage;
    [SerializeField] private TextMeshProUGUI _sliderAccessText;
    [Header("Doggo Image")]
    [SerializeField] private RawImage _doggoImage;

    public void DisplayActivity(JSONNode root)
    {
        foreach (var key in root.Keys)
        {
            Debug.Log(key);
            Debug.Log(root[key]);
            SortData(key, root[key]);
        }
    }

    public void DisplayImage(Texture doggoImage)
    {
        _doggoImage.texture = doggoImage;
    }

    private void SortData(string key, string value)
    {
        value.Replace('"',' ');
        switch (key)
        {
            case "activity":
                _activity.text = value;
                break;

            case "type":
                _type.text = value;
                break;

            case "participants":
                _participants.text = value;
                break;

            case "price":
                HandleSlider(float.Parse(value),_sliderPrice, _sliderPriceImage, _sliderPriceText);             
                break;

            case "link":
                _Link.text = value;
                break;

            case "accessibility":
                if (float.Parse(value) == 0)
                {
                    _sliderAccessText.text = "Very Accessible";
                    _sliderAccess.value = 1f;
                    _sliderAccessImage.color = _gradient.Evaluate(0f);
                }
                else
                {
                    _sliderAccess.value = Mathf.Abs(float.Parse(value) -1f);
                    _sliderAccessImage.color = _gradient.Evaluate(float.Parse(value));
                    _sliderAccessText.text = "";
                } 
                break;

            case "message":
                break;
        }
    }

    private void HandleSlider(float value, Slider slider, Image image, TextMeshProUGUI textMP)
    {
        if (value == 0)
        {
            slider.value = 1f;
            image.color = new Color(1,0,1,1);
            if (textMP != null) textMP.text = "FREE";
        } else
        {
            slider.value = value;
            image.color = _gradient.Evaluate(slider.normalizedValue);
            if (textMP != null) textMP.text = MultiplyFloat(value);
        }
    }

    private string MultiplyFloat(float value)
    {
        string tempString = "";
        int temp = Mathf.RoundToInt(value * 10f);
        for (int i = 0; i <= temp; i++)
        {
            tempString = tempString + "$";
        }
        return tempString;
    }

    public void OpenLink()
    {
        if (_Link.text.ToString() != "")
        {
            Application.OpenURL(_Link.text.ToString());
        } else
        {
            Debug.Log("Can't open external link");
        }
    }
}
