using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetSetter : MonoBehaviour
{
    public static int bet1 = 0;
    public static int bet2 = 0;
    [Header ("Input Bet Area")]
    [SerializeField]
    private TMP_InputField _inputBet1;
    [SerializeField]
    private TMP_InputField _inputBet2;
    [Header ("Set Bet Button")]
    [SerializeField]
    private Button _setBetTeam1;
    [SerializeField]
    private Button _setBetTeam2;
    public event Action<int> SumBetChanged = default;

    public void OnSetBetTeam1ButtonClick()
    {
        bet1 = int.Parse(_inputBet1.text);
        _setBetTeam1.GetComponent<Button>().interactable = false;
        if(SumBetChanged != null)
        {
            SumBetChanged(bet1);
        }
    }

    public void OnSetBetTeam2ButtonClick()
    {
        bet2 = int.Parse(_inputBet2.text);
        _setBetTeam2.GetComponent<Button>().interactable = false;
        if(SumBetChanged != null)
        {
            SumBetChanged(bet2);
        }
    }
}