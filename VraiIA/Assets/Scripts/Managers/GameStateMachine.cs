using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    #region fields
    private Dictionary<EgameState, BaseGameState> _statesGDict = new Dictionary<EgameState, BaseGameState>();
    private EgameState _curentGState;
    #endregion

    #region Properties
    public BaseGameState CurrentGState => _statesGDict[_curentGState];
    public EgameState CurrentStateType => _curentGState;
    public EgameState LastGState;
    #endregion

    #region Methods

    #region Start And Init
    private void Start()
    {
        _statesGDict = new Dictionary<EgameState, BaseGameState>();
        SubGStateInit();
        CurrentGState.UpdateState();
        Debug.Log(_curentGState);
    }

    private void SubGStateInit()
    {
        StartGameState startState = new StartGameState();
        startState.Init(this, EgameState.START);
        _statesGDict.Add(EgameState.START, startState);

        MenuGameState menuState = new MenuGameState();
        menuState.Init(this, EgameState.MENU);
        _statesGDict.Add(EgameState.MENU, menuState);

    }
    #endregion

    #region RunTime
    private void Update()
    {
        CurrentGState.UpdateState();
    }

    private void FixedUpdate()
    {
        CurrentGState.FixedUpdateState();
    }

    public void changeState(EgameState nextState)
    {
        CurrentGState.LeaveState();
        _curentGState = nextState;
        CurrentGState.StartState();
    }

    public void OnClickStart()
    {
        changeState(EgameState.START);
    }

    public void OnClickMenu()
    {
        changeState(EgameState.MENU);
    }
    #endregion

    #endregion
}

public enum EgameState
{
    START,
    MENU,
    NONE
}