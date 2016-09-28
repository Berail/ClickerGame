using UnityEngine;
using System.Collections;

public class MenuLogicParent : MonoBehaviour {
    public void Activate()
    {
        foreach(Transform child in transform.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(true);
        }
    }
    public void Deactivate()
    {
        foreach (Transform child in transform.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
    }
}
