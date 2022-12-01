using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ZoneStateMachine : MonoBehaviour
{
    #region fields
    private Dictionary<EzoneState, BaseZoneState> _statesZoneDict = new Dictionary<EzoneState, BaseZoneState>();
    private EzoneState _curentZoneState;
    #endregion

    #region Properties
    public BaseZoneState CurrentZoneState => _statesZoneDict[_curentZoneState];
    public EzoneState CurrentStateType => _curentZoneState;
    public EzoneState LastZoneState;
    public float _scoreZoneBlue = 0;
    public float _scoreZoneRed = 0;
    public float _scoreRed = 0;
    public float _scoreBlue = 0;
    public bool redCol = false;
    public bool blueCol = false;
    public bool RedCap = false;
    public bool BlueCap = false;
    public bool _redCaptured = false;
    public bool _blueCaptured = false;
    public Slider score;
    public Slider scoreBlueSlider;
    public Slider scoreRedSlider;
    public Image fillscore;
    public TextMeshProUGUI text;
    public TextMeshProUGUI scoreRed;
    public TextMeshProUGUI scoreBlue;
    public bool isPaused;
    public GameObject EndMenu;
    public bool GameTerminado = false;
    public getBehaviourTreeAllParameters _bd;


    
    
    #endregion

    #region Methods

    #region Start And Init
    private void Start()
    {
        _statesZoneDict = new Dictionary<EzoneState, BaseZoneState>();
        SubZoneStateInit();
        CurrentZoneState.UpdateState();
        EndMenu.SetActive(false);
        Debug.Log(_curentZoneState);
    }

    private void SubZoneStateInit()
    {
        FreeZoneState freeState = new FreeZoneState();
        freeState.Init(this, EzoneState.FREE);
        _statesZoneDict.Add(EzoneState.FREE, freeState);

        OnCaptureZoneState onCaptureState = new OnCaptureZoneState();
        onCaptureState.Init(this, EzoneState.ONCAPTURE);
        _statesZoneDict.Add(EzoneState.ONCAPTURE, onCaptureState);

        OnConflictZoneState onConflictState = new OnConflictZoneState();
        onConflictState.Init(this, EzoneState.ONCONFLICT);
        _statesZoneDict.Add(EzoneState.ONCONFLICT, onConflictState);

        DecreasingZoneState decreasingState = new DecreasingZoneState();
        decreasingState.Init(this, EzoneState.DECREASING);
        _statesZoneDict.Add(EzoneState.DECREASING, decreasingState);

        CapturedZoneState capturedState = new CapturedZoneState();
        capturedState.Init(this, EzoneState.CAPTURED);
        _statesZoneDict.Add(EzoneState.CAPTURED, capturedState);

        GameEndZoneState gameEndState = new GameEndZoneState();
        gameEndState.Init(this, EzoneState.GAMEEND);
        _statesZoneDict.Add(EzoneState.GAMEEND, gameEndState);

    }
    #endregion

    #region RunTime
    private void Update()
    {
        CurrentZoneState.UpdateState();
        if(_scoreZoneBlue > _scoreZoneRed)
        {
            int percent = (int)((_scoreZoneBlue / 15) * 100);
            int scb = (int)(_scoreBlue);
            fillscore.color = Color.blue;
            score.value = _scoreZoneBlue;
            scoreBlueSlider.value = _scoreBlue;
            text.text = percent.ToString();
            scoreBlue.text = scb.ToString();
        }
        else
        {
            int percent = (int)((_scoreZoneRed / 15) * 100);
            int scr = (int)(_scoreRed);
            fillscore.color = Color.red;
            score.value = _scoreZoneRed;
            scoreRedSlider.value = _scoreRed;
            text.text = percent.ToString();
            scoreRed.text = scr.ToString();
        }
    }

    private void FixedUpdate()
    {
        CurrentZoneState.FixedUpdateState();
    }

    public void changeState(EzoneState nextState)
    {
        CurrentZoneState.LeaveState();
        _curentZoneState = nextState;
        CurrentZoneState.StartState();
    }
    
    public void OnClicks()
    {
        changeState(EzoneState.FREE);
        Debug.Log(_curentZoneState);
    }
    public void OnCLickF()
    {
        changeState(EzoneState.ONCAPTURE);
        Debug.Log(_curentZoneState);
    }
    public void Reload()
    {
        changeState(EzoneState.DECREASING);
    }
    public void RedCollision()
    {
        redCol = !redCol;
        Debug.Log(redCol);
    }
    public void BlueCollision()
    {
        blueCol = !blueCol;
        Debug.Log(blueCol);
    }
    #endregion

    #endregion
}

public enum EzoneState
{
    FREE,
    ONCONFLICT,
    ONCAPTURE,
    DECREASING,
    CAPTURED,
    GAMEEND
}

