using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonMapper
{
    public static TournamentsData GetTournaments(string data)
    {
        TournamentsData tournaments = JsonUtility.FromJson<TournamentsData>(data);

        return tournaments;
    }
}
