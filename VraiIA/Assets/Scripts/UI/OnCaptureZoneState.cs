using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCaptureZoneState : BaseZoneState
{
    #region fileds

    #endregion

    #region Properties

    #endregion

    #region Methods   
    public override void StartState()
    {
      
    }

    public override void UpdateState()
    {
        if (_machine.RedCap == true & _machine.BlueCap == true)
        {
            _machine.changeState(EzoneState.ONCONFLICT);
        }
    }

    public override void FixedUpdateState()
    {
        _machine._scoreZone +=  Time.fixedDeltaTime;
        Debug.Log(_machine._scoreZone);
        if(_machine._scoreZone >=15)
        {
            _machine.changeState(EzoneState.CAPTURED);
        }
        if (_machine.BlueCap == false & _machine.RedCap == false)
        {
            _machine.changeState(EzoneState.DECREASING);
        }
    }

    public override void LeaveState()
    {
        _machine.LastZoneState = EzoneState.ONCAPTURE;
    }

    #endregion
}
