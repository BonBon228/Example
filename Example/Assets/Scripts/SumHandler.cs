using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SumHandler : MonoBehaviour
{
    [SerializeField]
    private int _sum;
    [Header("Sum Display")]
    [SerializeField]
    private TMP_Text _sumText;
    [SerializeField]
    private TMP_Text _newSumText;

    private void OnEnable()
    {
        FindObjectOfType<BetSetter>().SumBetChanged += OnSumBetChanged; 
        FindObjectOfType<ResultsHandler>().SumResultsChanged += OnSumResultsChanged;
    }

    private void OnDisable()
    {
        if(FindObjectOfType<BetSetter>() != null)
        {
            FindObjectOfType<BetSetter>().SumBetChanged -= OnSumBetChanged; 
            FindObjectOfType<ResultsHandler>().SumResultsChanged -= OnSumResultsChanged;
        }
    }
    
    private void Start()
    {
        SetSumText();
    }

    private void OnSumBetChanged(int _bet)
    {
        if(_sum >= _bet)
        {
            _sum -= _bet;
            SaveSum();
            SetSumText();
        }
    }

    private void OnSumResultsChanged()
    {
        if(ResultsHandler.isTeam1 == true)
        {
            _sum += (int)ResultsHandler.betTeam1;
        }
        else
        {
            _sum += (int)ResultsHandler.betTeam2;
        }
        SaveSum();
        SetSumText();
    }

    private void SetSumText()
    {
        _sum = PlayerPrefs.GetInt("Sum");
        
        _sumText.SetText("Your balance: " + _sum.ToString());
        _newSumText.SetText("Your balance: " + _sum.ToString());
    }

    private void SaveSum()
    {
        PlayerPrefs.SetInt("Sum", _sum);
    }
}
