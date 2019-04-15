using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using System;
using System.IO;

public class EventManager : MonoBehaviour
{
    public delegate void PrisonStateChanged(PrisonState state);
    public static event PrisonStateChanged OnPrisonStateChanged;

    public EventData eventData;
    public TMP_Text eventText;

    private void Start()
    {
        string jsonPath = Application.streamingAssetsPath + "/PrisonEventScheme.json";
        string jsondata = File.ReadAllText(jsonPath);
        eventData = JsonConvert.DeserializeObject<EventData>(jsondata);
    }

    public void NextHour(int hour, WeekDay day)
    {
        string HourString = string.Format("{0:00}:00", hour);
        string EventText = eventData.Days[(int)day][HourString];

        eventText.text = EventText;
        PrisonState curState = (PrisonState)Enum.Parse(typeof(PrisonState), EventText, true);
        OnPrisonStateChanged?.Invoke(curState);
    }
}

public enum PrisonState
{
    FreeTime,
    LockUp,
    Shower,
    Eating,
    Sleep,
    Work
}

[System.Serializable]
public class EventData
{
    public Dictionary<string, string>[] Days = new Dictionary<string, string>[7];
}