using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextPool : MonoBehaviour
{
    public GameObject textPrefab;

    static TextPool Instance;

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);         
        }
    }

    public static Text GetOneText()
    {
        if (Instance.transform.childCount > 0)
        {
            Instance.transform.GetChild(0).gameObject.SetActive(true);

            return Instance.transform.GetChild(0).GetComponent<Text>();
        }

        return Instantiate(Instance.textPrefab, Instance.transform).GetComponent<Text>();
    }

    public static void ReturnToPool(List<Transform> texts)
    {

        texts.ForEach(text => 
        { 
            text.SetParent(Instance.transform);

            text.gameObject.SetActive(false);
        });
    }
}