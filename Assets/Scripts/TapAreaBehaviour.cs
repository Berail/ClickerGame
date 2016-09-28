using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class TapAreaBehaviour : MonoBehaviour, IPointerDownHandler
{

    GameObject statistics;
    PopUpMasterLogic popUpMasterLogicScript;

    public static event DelegateClass.UpdateTapCountFieldHandler UpdateTapCountEvent;

    // Use this for initialization
    void Awake()
    {
        statistics = GameObject.Find("StatisticObject");
        popUpMasterLogicScript = GameObject.Find("PopUpMenuMaster").GetComponent<PopUpMasterLogic>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.eligibleForClick)
        {
            popUpMasterLogicScript.HideAll();
            statistics.GetComponent<Statistics>().IncreaseTapCount();
            OnUpdateText();
        }
    }

    public static void OnUpdateText()
    {
        if (UpdateTapCountEvent != null)
            UpdateTapCountEvent();
    }

}
