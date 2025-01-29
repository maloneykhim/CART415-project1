using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Canvas canvas;
    public bool instructions = false;

    public GameObject[] pages; // Array to hold your pages (Page1, Page2, etc.)
    private int currentPageIndex =0; // Tracks the current page index
    [SerializeField] int maxPage;



    // start the game
    public void StartGame()
    {
        SceneManager.LoadScene("Level0");
    }

    // quit the game
    public void QuitGame()
    {
        Application.Quit();
    }


    // open and close instruction
    public void HowToPlayGame()
    {
        if (instructions == false)
        {
            instructions = true;
            canvas.enabled = true;
            ShowPage(0);
           

        } else if (instructions == true) 
        {
            instructions = false;
            canvas.enabled = false;
            ShowPage(-1);
        }
    }

    // navigate the instructions
    public void NextPage()
    {
        if(currentPageIndex < maxPage-1)
        {
           currentPageIndex++;
            ShowPage(currentPageIndex);
          
        }

    }

    public void PreviousPage()
    {

        if (currentPageIndex > 0)
        {
           currentPageIndex--;
            ShowPage(currentPageIndex);
        }
    }



    private void ShowPage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex); // Activate only the current page
        }
    }
}
