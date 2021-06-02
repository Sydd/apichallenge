using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TournamentsData
{
    public List<Tournament> data;

    public TournamentLinks links;

    public string meta;
}

[System.Serializable]
public class TournamentLinks
{
    public string self;
}