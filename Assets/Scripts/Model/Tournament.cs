using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tournament
{
    public string type;

    public string id;

    public TournamentAttributes attributes;
}

[System.Serializable]
public class TournamentAttributes
{
    public string createdAt;
}
