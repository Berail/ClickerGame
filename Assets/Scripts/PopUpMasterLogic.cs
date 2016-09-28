using UnityEngine;
using System.Collections;

public class PopUpMasterLogic : MonoBehaviour {

    GameObject upgradeClickMenu;
    GameObject upgradeTimedMenu;
    GameObject legacyMenu;
    GameObject settings;

    // Use this for initialization
    void Awake () {
        upgradeClickMenu = GameObject.Find("UpgradeClickMenu");
        upgradeTimedMenu = GameObject.Find("UpgradeTimedMenu");
        legacyMenu = GameObject.Find("LegacyMenu");
        settings = GameObject.Find("Settings");
    }

    public void HideAll()
    {
        if(upgradeClickMenu.GetComponent<Animator>().GetBool("Show"))
            upgradeClickMenu.GetComponent<Animator>().SetBool("Show", false);
        if (upgradeTimedMenu.GetComponent<Animator>().GetBool("Show"))
            upgradeTimedMenu.GetComponent<Animator>().SetBool("Show", false);
        if (legacyMenu.GetComponent<Animator>().GetBool("Show"))
            legacyMenu.GetComponent<Animator>().SetBool("Show", false);
        if (settings.GetComponent<Animator>().GetBool("Show"))
            settings.GetComponent<Animator>().SetBool("Show", false);
    }

    public void ShowMenu(int menu)
    {
        switch(menu)
        {
            case 1:
                if(upgradeTimedMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    upgradeTimedMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                if(legacyMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    legacyMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                if(settings.GetComponent<Animator>().GetBool("Show"))
                {
                    settings.GetComponent<Animator>().SetBool("Show", false);
                }
                if(upgradeClickMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    upgradeClickMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                else
                {
                    upgradeClickMenu.transform.SetAsFirstSibling();
                    upgradeClickMenu.GetComponent<Animator>().SetBool("Show", true);
                }
                break;
            case 2:
                if (upgradeClickMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    upgradeClickMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                if (legacyMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    legacyMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                if (settings.GetComponent<Animator>().GetBool("Show"))
                {
                    settings.GetComponent<Animator>().SetBool("Show", false);
                }
                if (upgradeTimedMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    upgradeTimedMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                else
                {
                    upgradeTimedMenu.transform.SetAsFirstSibling();
                    upgradeTimedMenu.GetComponent<Animator>().SetBool("Show", true);
                }
                break;
            case 3:
                if (upgradeClickMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    upgradeClickMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                if (upgradeTimedMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    upgradeTimedMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                if (settings.GetComponent<Animator>().GetBool("Show"))
                {
                    settings.GetComponent<Animator>().SetBool("Show", false);
                }
                if (legacyMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    legacyMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                else
                {
                    legacyMenu.transform.SetAsFirstSibling();
                    legacyMenu.GetComponent<Animator>().SetBool("Show", true);
                }
                break;
            case 4:
                if (upgradeClickMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    upgradeClickMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                if (upgradeTimedMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    upgradeTimedMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                if (legacyMenu.GetComponent<Animator>().GetBool("Show"))
                {
                    legacyMenu.GetComponent<Animator>().SetBool("Show", false);
                }
                if (settings.GetComponent<Animator>().GetBool("Show"))
                {
                    settings.GetComponent<Animator>().SetBool("Show", false);
                }
                else
                {
                    settings.transform.SetAsFirstSibling();
                    settings.GetComponent<Animator>().SetBool("Show", true);
                }
                break;
        }
    }
}
