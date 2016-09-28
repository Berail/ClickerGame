﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatisticsDisplay : MonoBehaviour
{

    GameObject statistic;
    public GameObject tapCountTextObject;
    Text tapCountTextObjectText;
    public GameObject currencyTextObject;
    Text currencyTextObjectText;
    public GameObject currentLvlTextObject;
    Text currentLvlTextObjectText;
    public GameObject encounterSliderObject;
    // Use this for initialization
    void Start()
    {

        statistic = GameObject.Find("StatisticObject");

        tapCountTextObjectText = tapCountTextObject.GetComponent<Text>();
        currencyTextObjectText = currencyTextObject.GetComponent<Text>();
        currentLvlTextObjectText = currentLvlTextObject.GetComponent<Text>();

        tapCountTextObjectText.text = statistic.GetComponent<Statistics>().tapCount.ToString();
        currencyTextObjectText.text = statistic.GetComponent<Statistics>().currency.ToString();
        currentLvlTextObjectText.text = statistic.GetComponent<Statistics>().currentLvlDificult.ToString().Split('.')[0];
        encounterSliderObject.GetComponent<Slider>().maxValue = (float)statistic.GetComponent<Statistics>().currentLvlDificult;

        Statistics.UpdateCurrencyEvent += this.OnUpdateCurrency;
        Statistics.UpdateTapCountEvent += this.OnUpdateTapCount;
        Statistics.UpdateLvlDifficultEvent += this.OnUpdateLvlDifficult;
        TapAreaBehaviour.UpdateTapCountEvent += this.OnUpdateTapCount;

    }

    // Update is called once per frame
    //10K is fitting in space of text so only 5 digits (4 digits and sufix ?)

    public void OnUpdateTapCount()
    {
        encounterSliderObject.GetComponent<Slider>().value = (float)statistic.GetComponent<Statistics>().tapCount;
        tapCountTextObjectText.text = statistic.GetComponent<Statistics>().tapCount.ToString();
    }

    public void OnUpdateCurrency()
    {
        currencyTextObjectText.text = statistic.GetComponent<Statistics>().currency.ToString();
    }
    public void OnUpdateLvlDifficult()
    {
        encounterSliderObject.GetComponent<Slider>().maxValue = (float)statistic.GetComponent<Statistics>().currentLvlDificult;
        currentLvlTextObjectText.text = statistic.GetComponent<Statistics>().currentLvlDificult.ToString().Split('.')[0];
    }

    void OnApplicationQuit()
    {
        Statistics.UpdateTapCountEvent -= this.OnUpdateTapCount;
        TapAreaBehaviour.UpdateTapCountEvent -= this.OnUpdateTapCount;
    }


    //string FormatOfTapCount(int tapCount)
    //{

    //}
}
