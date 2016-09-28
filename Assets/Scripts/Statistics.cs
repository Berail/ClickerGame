using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public class Statistics : MonoBehaviour
{

    [HideInInspector]
    public double tapCount;
    [HideInInspector]
    public double tapModificator;
    [HideInInspector]
    public double tapPerSecond;
    [HideInInspector]
    public double currency;
    [HideInInspector]
    public double currentLvl;
    [HideInInspector]
    public double currentLvlDificult;
    private float baseDificulty;
    private float encounterModifier;
    [HideInInspector]
    public double income;

    public static event DelegateClass.UpdateTapCountFieldHandler UpdateTapCountEvent;
    public static event DelegateClass.UpdateCurrencyFieldHandler UpdateCurrencyEvent;
    public static event DelegateClass.UpdateLvlDiffcultFieldHandler UpdateLvlDifficultEvent;
    public static event DelegateClass.UpdateLvlIconsHandler UpdateLvlIconsEvent;

    void Awake()
    {

        if (!PlayerPrefs.HasKey("Currency"))
        {
            PlayerPrefs.SetString("Currency", "0");
        }
        if (!PlayerPrefs.HasKey("Income"))
        {
            PlayerPrefs.SetString("Income", "0");
        }
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetString("CurrentLevel", "1");
        }
        if (!PlayerPrefs.HasKey("TapModificator"))
        {
            PlayerPrefs.SetString("TapModificator", "1");
        }
        if (!PlayerPrefs.HasKey("TapPerSecond"))
        {
            PlayerPrefs.SetString("TapPerSecond", "0");
        }
        if (PlayerPrefs.HasKey("TimeExit"))
        {
            DateTime myDate = DateTime.Parse(PlayerPrefs.GetString("TimeExit"));

            Debug.Log(CountHowManySecondsPass(myDate));
        }

        currency = Double.Parse(PlayerPrefs.GetString("Currency"));
        tapModificator = Double.Parse(PlayerPrefs.GetString("TapModificator"));
        tapPerSecond = Double.Parse(PlayerPrefs.GetString("TapPerSecond"));
        currentLvl = Double.Parse(PlayerPrefs.GetString("CurrentLevel"));
        income = Double.Parse(PlayerPrefs.GetString("Income"));
        baseDificulty = 100;
        income = CalculateIncome();
        if (currentLvl % 10 == 0)
        {
            encounterModifier = 2.0f;
        }
        else
        {
            encounterModifier = 1.2f;
        }
        currentLvlDificult = CountCurrentLvlDificult();
        OnUpdateLvlIcons(currentLvl);
        OnUpdateLvlDifficult();
    }

    private double CalculateIncome()
    {
        return (currentLvl % 10 != 0) ? (currentLvl * 10) : (currentLvl * 100);
    }

    public double CountCurrentLvlDificult()
    {
        return (baseDificulty * currentLvl) * encounterModifier;
    }

    void Start()
    {
        InvokeRepeating("TapPerSecondLogic", 0, 1);
    }

    void Update()
    {
        if (tapCount >= currentLvlDificult)
        {
            AddCurrency(2);
            GoToNextEncounter();
            OnUpdateCurrency();
            OnUpdateTapCount();
        }

    }

    public int CountHowManySecondsPass(DateTime date)
    {
        return DateTime.Now.Subtract(date).Seconds;
    }

    public void IncreaseTapCount()
    {
        tapCount += tapModificator;
    }

    //Tmp Modificator Increase
    public void IncreaseTapModificator()
    {
        tapModificator++;
    }

    //Tmp Per Sec Increase
    public void IncreaseTapPerSecond()
    {
        tapPerSecond++;
    }

    public void TapPerSecondLogic()
    {
        if (tapPerSecond > 0)
        {
            tapCount += tapPerSecond;
            OnUpdateTapCount();
        }
    }

    public void GoToNextEncounter()
    {
        currentLvl++;
        currentLvlDificult = CountCurrentLvlDificult();
        tapCount = 0;
        encounterModifier += 0.01f;
        AddCurrency(income);
        income = CalculateIncome();
        encounterModifier = (currentLvl % 10 == 0) ? 2.0f : 1.2f;
        OnUpdateLvlIcons(currentLvl);
        OnUpdateLvlDifficult();
    }

    public void AddCurrency(double currency)
    {
        this.currency += currency;
        OnUpdateCurrency();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Currency", currency.ToString());
        PlayerPrefs.SetString("TapModificator", tapModificator.ToString());
        PlayerPrefs.SetString("TapPerSecond", tapPerSecond.ToString());
        PlayerPrefs.SetString("CurrentLevel", currentLvl.ToString());
        if (!PlayerPrefs.HasKey("TimeExit"))
        {
            PlayerPrefs.SetString("TimeExit", "");
        }
        PlayerPrefs.SetString("TimeExit", DateTime.Now.ToString());
    }

    public void RemovePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }


    public static void OnUpdateTapCount()
    {
        if (UpdateTapCountEvent != null)
            UpdateTapCountEvent();

    }

    public static void OnUpdateCurrency()
    {
        if (UpdateCurrencyEvent != null)
            UpdateCurrencyEvent();

    }

    public void OnUpdateLvlDifficult()
    {
        if (UpdateLvlDifficultEvent != null)
            UpdateLvlDifficultEvent();
    }

    public void OnUpdateLvlIcons(double lvl)
    {
        if (UpdateLvlIconsEvent != null)
            UpdateLvlIconsEvent(lvl);
    }
}
