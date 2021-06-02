using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using System;


public static class APIGetHandler
{ 
    private static readonly HttpClient client = new HttpClient();

    public static event Action OnLoadStarted;
    public static event Action<String> OnLoadFinished;
    public static event Action<String> OnError;

    public static void Init()
    {
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiIzMTFmZjExMC1hNWQ5LTAxMzktZjliYS01OWM3OGRmYmQ2ZTciLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjIyNjQyNTkyLCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InBlcnNvbmFsY2hhbGxlIn0.J7MvBCssSeWq_v3t8EugAAeVj3zDdvnIwU_3rkRRVE4");

        client.DefaultRequestHeaders.Add("Accept", "application/vnd.api+json");
    }

    public static void LoadData()
    {
        LoadJson();
    }

    private static async void LoadJson()
    {
        try
        {
            OnLoadStarted?.Invoke();
            
            string responseTournament = await client.GetStringAsync("https://api.pubg.com/tournaments");

            OnLoadFinished?.Invoke(responseTournament);
        }
        catch (HttpRequestException e )
        { 
            OnError?.Invoke(e.Message);
        }


    }
}
