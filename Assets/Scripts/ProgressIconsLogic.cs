using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressIconsLogic : MonoBehaviour {

    GameObject PrevIcon;
    GameObject CurrentIcon;
    GameObject NextIcon;
	// Use this for initialization
	void Awake () {
        Statistics.UpdateLvlIconsEvent += this.OnLvlChange;
        PrevIcon = transform.GetChild(0).gameObject;
        CurrentIcon = transform.GetChild(1).gameObject;
        NextIcon = transform.GetChild(2).gameObject;
    }

    public void OnLvlChange(double lvl)
    {
        if(lvl.Equals(1))
        {
            PrevIcon.SetActive(false);
            CurrentIcon.transform.GetComponentInChildren<Text>().text = lvl.ToString().Split('.')[0];
            NextIcon.transform.GetComponentInChildren<Text>().text = (lvl + 1).ToString().Split('.')[0];
        }
        else
        {
            PrevIcon.SetActive(true);
            PrevIcon.transform.GetComponentInChildren<Text>().text = (lvl - 1).ToString().Split('.')[0];
            CurrentIcon.transform.GetComponentInChildren<Text>().text = lvl.ToString().Split('.')[0];
            NextIcon.transform.GetComponentInChildren<Text>().text = (lvl + 1).ToString().Split('.')[0];
        }
       
    }
}
