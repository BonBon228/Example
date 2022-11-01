using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsHandler : MonoBehaviour
{
    public static bool isTeam1;
    [SerializeField]
    private Image _GerbWinTeam;
    [SerializeField]
    private GameObject _resultsPanel;
    [Header ("Image Of Teams")]
    [SerializeField]
    private Image _GerbTeam1;
    [SerializeField]
    private Image _GerbTeam2;
    public static float betTeam1;
    public static float betTeam2;
    public event System.Action SumResultsChanged = default;

    public void OnShowResultsButtonClick()
    {
        ResultsCalculation();
    }

    private void ShowResults()
    {
        _resultsPanel.SetActive(true);
        if(isTeam1 == true)
        {
            _GerbWinTeam.sprite = _GerbTeam1.sprite;
            betTeam1 = BetSetter.bet1 * TeamsGenerator.coefVal1;
            betTeam2 = 0;
            if(SumResultsChanged != null)
            {
                SumResultsChanged();
            }
        }
        else if(isTeam1 == false)
        {
            _GerbWinTeam.sprite = _GerbTeam2.sprite;
            betTeam2 = BetSetter.bet2 * TeamsGenerator.coefVal2;
            betTeam1 = 0;
            if(SumResultsChanged != null)
            {
                SumResultsChanged();
            }
        }
    }

    private void ResultsCalculation()
    {
        float val1 = TeamsGenerator.coefVal1;
        float val2 = TeamsGenerator.coefVal2;
        float chance = Random.Range(1f, 3f);
        if(val1 < val2)
        {
            if(val1 <= chance)
            {
                isTeam1 = true;
            }  
            else if(val1 >= chance)
            {
                isTeam1 = false;
            }  
        }
        else if(val1 > val2)
        {
            if(val1 >= chance)
            {
                isTeam1 = true;
            }  
            else if(val1 <= chance)
            {
                isTeam1 = false;
            } 
        }
        ShowResults();
    }
}