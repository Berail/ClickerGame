using UnityEngine;
using System.Collections;

public class ButtonsMenuBehaviour : MonoBehaviour
{

    GameObject ButtonsCollection;
    GameObject ImageCollection;
    bool shown = true;



    // Use this for initialization
    void Awake()
    {
        ButtonsCollection = transform.GetChild(1).gameObject;
        ImageCollection = transform.GetChild(0).gameObject;
    }

    public void HideMenu()
    {
        if (shown)
        {
            GetComponent<Animator>().SetBool("MoveDown", true);
            GetComponent<Animator>().SetBool("MoveUp", false);
        }
        else
        {

            GetComponent<Animator>().SetBool("MoveDown", false);
            GetComponent<Animator>().SetBool("MoveUp", true);
        }
    }

    public void SwitchShown()
    {
        shown = !shown;
    }

    public void SwitchActive()
    {
        if (shown)
        {
            ButtonsCollection.SetActive(true);
            ImageCollection.SetActive(true);
        }
        else
        {
            ButtonsCollection.SetActive(false);
            ImageCollection.SetActive(false);
        }
    }

}
