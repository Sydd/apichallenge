using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class APIManager : MonoBehaviour
{
    [SerializeField] private Button buttonLoad;
    [SerializeField] private Transform grid;

    private GridManager gridManager;
    private Text buttonText;
    void Start()
    {
        APIGetHandler.Init();
        APIGetHandler.OnLoadFinished    += LoadFinished;
        APIGetHandler.OnLoadStarted     += LoadStarted;
        APIGetHandler.OnError           += LoadError;

        gridManager = new GridManager(grid);

        buttonText = buttonLoad.GetComponentInChildren<Text>();
    }


    //This is called from the UI button.
    public void LoadData()
    {
        buttonLoad.interactable = false;

        ResetGrid();

        APIGetHandler.LoadData();
    }

    private void ResetGrid()
    {
        List<Transform> textList = new List<Transform>();
        
        for (int i = 2; i < grid.childCount; i++)
        {
            textList.Add(grid.GetChild(i));
        }

        if (textList.Count > 0) TextPool.ReturnToPool(textList);
    }

    private void LoadFinished(string data)
    {
        buttonLoad.interactable = true;

        buttonText.text = "Reload Tournaments";

        //We send the data mapped to C# objects.
        gridManager.PopulateGrid(JsonMapper.GetTournaments(data));
    }

    private void LoadStarted()
    {
        buttonText.text = "Loading..";
    }

    private void LoadError(string E)
    {
        Debug.Log(E);

        buttonLoad.interactable = true;

        buttonText.text = "Error in downloading! Try again!";
    }
}
