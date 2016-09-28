using UnityEngine;
using System.Collections;

public class DelegateClass
{

    public delegate void UpdateTapCountFieldHandler();
    public delegate void UpdateLvlDiffcultFieldHandler();
    public delegate void UpdateCurrencyFieldHandler();
    public delegate void UpdateLvlIconsHandler(double lvl);

}
