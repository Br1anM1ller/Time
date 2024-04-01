using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptsGame : MonoBehaviour
{
    public float timeStart = 60;
    public Text timerText;
    [SerializeField] private Text pinText1;
    [SerializeField] private Text pinText2;
    [SerializeField] private Text pinText3;
    public GameObject youLosePanel;
    public GameObject youWinPanel;

    private bool _isGameStarted;

    private int a;
    private int b;
    private int c;

    private void Start()
    {
        timerText.text = timeStart.ToString();
        pinText1.text = "0";
        pinText2.text = "0";
        pinText3.text = "0";
        youLosePanel.SetActive(false);
        youWinPanel.SetActive(false);
    }

    void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();
        if (timeStart <= 0)
        {
            TimeIsUp();
        }
        if (pinText1.text == "5" && pinText2.text == "5" && pinText3.text == "5")
        {
            YouWin();
        }
    }

    public void Tools(int indexTools)
    {
        switch (indexTools)
        {
            case 0:
                Drel();
                break;

            case 1:
                Molot();
                break;

            case 2:
                Otmichka();
                break;

            default:
                break;
        }
    }


    public void Execute(int a, int b, int c)
    {
        pinText1.text = a.ToString();
        pinText2.text = b.ToString();
        pinText3.text = c.ToString();
    }

    public void Drel()
    {
        a = a + 1;
        b = b - 1;
        c = 0;
        Execute(a, b, c);
    }

    public void Molot()
    {
        a = a - 1;
        b = 2;
        c = c - 1;
        Execute(a, b, c);
    }

    public void Otmichka()
    {
        a = a - 1;
        b = b + 1;
        c = c + 1;
        Execute(a, b, c);
    }

    public void TimeIsUp()
    {
        if (timeStart <= 0)
        {
            youLosePanel.SetActive(true);
        }
    }

    public void YouWin()
    {
        youWinPanel.SetActive(true);
    }

    public void Restart()
    {
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
