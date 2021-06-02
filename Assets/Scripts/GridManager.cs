using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager
{
    private Transform gridLayout;
    public GridManager(Transform grid)
    {
        gridLayout = grid;
    }

    //We populate the grid with text from a pool.
    public void PopulateGrid(TournamentsData tournamentsData)
    {
        tournamentsData.data.ForEach(tournament =>
        {
            Text textID = TextPool.GetOneText();

            textID.transform.SetParent( gridLayout);

            Text textCreatedAt = TextPool.GetOneText();

            textCreatedAt.transform.SetParent(gridLayout);

            textID.text = tournament.id;

            textCreatedAt.text = tournament.attributes.createdAt;
        });
    }
}
