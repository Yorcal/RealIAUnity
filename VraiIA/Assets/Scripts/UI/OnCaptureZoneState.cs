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
        if (_machine.BlueCap == false & _machine.RedCap == false)
        {
            _machine.changeState(EzoneState.DECREASING);
        }
        if (_machine.BlueCap == true)
        {
            if (_machine._scoreZoneRed <= 0)
            {
                _machine._scoreZoneBlue += Time.fixedDeltaTime;
                Debug.Log(_machine._scoreZoneBlue);   
            }
            else
            {
                _machine._scoreZoneRed -= Time.fixedDeltaTime;
                Debug.Log(_machine._scoreZoneRed);
            }
        }
        if (_machine.RedCap == true)
        {
            if (_machine._scoreZoneBlue <= 0)
            {
                _machine._scoreZoneRed += Time.fixedDeltaTime;
                Debug.Log(_machine._scoreZoneRed);
            }
            else
            {
                _machine._scoreZoneBlue -= Time.fixedDeltaTime;
                Debug.Log(_machine._scoreZoneBlue);
            }
        }
        if(_machine._scoreZoneBlue >=15)
        {
            _machine._blueCaptured = true;
            Debug.Log(_machine._blueCaptured);
            _machine.changeState(EzoneState.CAPTURED);
        }
        if(_machine._scoreZoneRed >= 15)
        {
            _machine._redCaptured = true;
            Debug.Log(_machine._redCaptured);
            _machine.changeState(EzoneState.CAPTURED);
        }
    }

    public override void LeaveState()
    {
        _machine.LastZoneState = EzoneState.ONCAPTURE;
    }

    #endregion
}
