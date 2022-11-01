using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TeamsGenerator : MonoBehaviour
{
    private string[] _footballTeams = {"Barcelona", "Real Madrid", "Milan", "Arcenal"};
    [SerializeField]
    private Sprite[] _footballGerbs;
    [Header("Team Coefficient Display")]
    [SerializeField]
    private TMP_Text _coefText1;
    [SerializeField]
    private TMP_Text _coefText2;
    [Header("Team Name Display")]
    [SerializeField]
    private TMP_Text _teamText1;
    [SerializeField]
    private TMP_Text _teamText2;
    [Header("Team Gerb Display")]
    [SerializeField]
    private Image _footballGerb1;
    [SerializeField]
    private Image _footballGerb2;
    public static float coefVal1;
    public static float coefVal2;

    void Start()
    {
        SetCoefficient();
        SetTeam();
    }

    private void SetCoefficient()
    {
        coefVal1 = Random.Range(1f, 3f);
        coefVal2 = 1;

        coefVal2 += 2/coefVal1;

        _coefText1.SetText(System.Math.Round(coefVal1, 2).ToString());
        _coefText2.SetText(System.Math.Round(coefVal2, 2).ToString());
    }

    private void SetTeam()
    {
        int val1 = Random.Range(0, _footballTeams.Length);
        int val2 = Random.Range(0, _footballTeams.Length);

        while(val2 == val1)
        {
            val2 = Random.Range(0, _footballTeams.Length);
        }
        
        string team1 = _footballTeams[val1];
        string team2 = _footballTeams[val2];
        _teamText1.SetText(team1);
        _teamText2.SetText(team2);
        _footballGerb1.sprite = _footballGerbs[val1];
        _footballGerb2.sprite = _footballGerbs[val2];
    }
}