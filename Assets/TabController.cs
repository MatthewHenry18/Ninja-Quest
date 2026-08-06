using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    //for highlighting and greyed out images 
    public Image[] tabImages;
    public GameObject[] pages;


    // Start is called before the first frame update
    void Start()
    {
        //Sets starting tab 
        ActivateTab(0);
    }

    public void ActivateTab(int tabNum)
    {
        //First deactivate all tabs and grey images 
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }
        //Set active tab based on tab number selected
        pages[tabNum].SetActive(true);
        tabImages[tabNum].color = Color.white;
    }
}
