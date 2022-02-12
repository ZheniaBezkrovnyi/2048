using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONLanguag : ScoreAndCanvas
{
    [System.Serializable]
    public class CurrentLanguages
    {
        public string play;
    }
    [System.Serializable]
    public class Languages
    {
        public CurrentLanguages[] languages;
    }


    [SerializeField] private Languages languages = new Languages();
    [SerializeField] private TextAsset file;

    public void ChangeLang()
    {
        languages = JsonUtility.FromJson<Languages>(JsonUtility.ToJson(file.text));
    }
}