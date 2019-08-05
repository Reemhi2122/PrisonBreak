using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{

    public delegate void TimeFastForward(bool Enabled);
    public static event TimeFastForward OnFastForward;

    public static Clock instance;

    public TMP_Text ClockText;
    public TMP_Text DayText;
    public TMP_Text WeekDayText;

    [SerializeField]
    private Button SelectedButton;
    [SerializeField]
    private Button PauseButton;
    [SerializeField]
    private Button PlayButton;
    [SerializeField]
    private Button FastForwardButton;

    [SerializeField]
    private EventManager eventManager;

    private float startTime;
    private bool fastForwardEnabled;
    private bool gamePaused;

    [SerializeField]
    private float multiplier;
    private float originalSpeed;
    private float fastforwardSpeed;
    private float pauseSpeed;

    private float seconds;
    private float minutes;
    private float hours;
    private float days;

    private int lastHour;

    private WeekDay curDay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        startTime = 43200;
        fastForwardEnabled = false;
        multiplier = 60;
        originalSpeed = 60;
        fastforwardSpeed = 1.5f;
        pauseSpeed = 0;
        seconds = startTime;
    }

    private void Update()
    {
        seconds += (Time.deltaTime * multiplier);

        minutes = ((seconds / 60) % 60);
        hours = ((seconds / 3600) % 24);
        days = ((seconds / 86400) + 1);
        curDay = (WeekDay)((seconds / 86400) % 7);

        if (lastHour != (int)hours)
        {
            eventManager.NextHour((int)hours, curDay);
            lastHour = (int)hours;
        }

        ClockText.text = string.Format("{0:00}:{1:00}", (int)hours, (int)minutes);
        DayText.text = string.Format("DAY {0}", (int)days);
        WeekDayText.text = curDay.ToString();

        if (Input.GetKeyDown(KeyCode.Space)){
            if (!gamePaused) ClockPause(PauseButton);
            else PlaySpeed(PlayButton);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!fastForwardEnabled) FastForward(FastForwardButton);
            else PlaySpeed(PlayButton);
        }
    }

    public void FastForward(Button button)
    {
        multiplier = originalSpeed * fastforwardSpeed;
        ChangeButton(button);
        if (GameManager.instance.GetGameState() != GameState.Play) GameManager.instance.SetGameState(GameState.Play);
        if (!fastForwardEnabled && OnFastForward != null) OnFastForward(true);
        fastForwardEnabled = true;
        gamePaused = false;
    }

    public void PlaySpeed(Button button)
    {
        multiplier = originalSpeed;
        ChangeButton(button);
        if (GameManager.instance.GetGameState() != GameState.Play) GameManager.instance.SetGameState(GameState.Play);
        if (fastForwardEnabled && OnFastForward != null) OnFastForward(false);
        fastForwardEnabled = false;
        gamePaused = false;
    }

    public void ClockPause(Button button)
    {
        multiplier = pauseSpeed;
        ChangeButton(button);
        if (GameManager.instance.GetGameState() != GameState.Pause) GameManager.instance.SetGameState(GameState.Pause);
        if (fastForwardEnabled && OnFastForward != null) OnFastForward(false);
        fastForwardEnabled = false;
        gamePaused = true;
    }

    private void ChangeButton(Button button)
    {
        if (SelectedButton != null) SelectedButton.image.color = Color.white;
        SelectedButton = button;
        button.image.color = Color.black;
    }

    public TimeDisplay GetTime()
    {
        TimeDisplay curTimeDisplay;
        curTimeDisplay.TimeStamp = string.Format("{0:00}:00", hours);
        curTimeDisplay.Day = curDay;
        return curTimeDisplay;
    }
}

public struct TimeDisplay
{
    public string TimeStamp;
    public WeekDay Day;
}

public enum WeekDay
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}