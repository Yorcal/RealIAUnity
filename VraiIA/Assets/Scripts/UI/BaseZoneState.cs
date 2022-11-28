using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseZoneState
{
    #region Fields
    protected EzoneState _state = EzoneState.FREE;
    protected ZoneStateMachine _machine = null;
    #endregion

    #region Properties
    public EzoneState State => _state;
    #endregion

    #region Methods
    public void Init(ZoneStateMachine machine, EzoneState state)
    {
        _machine = machine;
        _state = state;
    }

    public abstract void StartState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void LeaveState();
    #endregion
}
