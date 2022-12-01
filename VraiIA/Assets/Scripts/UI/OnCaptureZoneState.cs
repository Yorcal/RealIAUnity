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
        
        _bd = GameObject.FindWithTag("player2").GetComponent<getBehaviourTreeAllParameters>();
    }

    public override void UpdateState()
    {
        if (_machine.RedCap == true & _machine.BlueCap == true)
        {
            _bd.setConflictState(true);
            _bd.setCaptureStateBlue(false);
            _bd.setCaptureStateRed(false);
            _machine.changeState(EzoneState.ONCONFLICT);
        }
    }

    public override void FixedUpdateState()
    {
        if (_machine.BlueCap == false & _machine.RedCap == false)
        {
            _bd.setCaptureStateBlue(false);
            _bd.setCaptureStateRed(false);
            _machine.changeState(EzoneState.DECREASING);
        }
        if (_machine.BlueCap == true)
        {
            _bd.setCaptureStateBlue(true);
            _bd.setCaptureStateRed(false);
            if (_machine._scoreZoneRed <= 0)
            {
                _machine._scoreZoneBlue += Time.fixedDeltaTime;
            }
            else
            {
                _machine._scoreZoneRed -= Time.fixedDeltaTime;
            }
        }
        if (_machine.RedCap == true)
        {
            _bd.setCaptureStateRed(true);
            _bd.setCaptureStateBlue(false);
            if (_machine._scoreZoneBlue <= 0)
            {
                _machine._scoreZoneRed += Time.fixedDeltaTime;
            }
            else
            {
                _machine._scoreZoneBlue -= Time.fixedDeltaTime;
            }
        }
        if(_machine._scoreZoneBlue >=5)
        {
            _bd.setCapturedStateBlue(true);
            _bd.setCapturedStateRed(false);
            _machine._blueCaptured = true;
            _machine.changeState(EzoneState.CAPTURED);
        }
        if(_machine._scoreZoneRed >= 5)
        {
            _bd.setCapturedStateRed(true);
            _bd.setCapturedStateBlue(false);
            _machine._redCaptured = true;
            _machine.changeState(EzoneState.CAPTURED);
        }
    }

    public override void LeaveState()
    {
        _machine.LastZoneState = EzoneState.ONCAPTURE;
    }

    #endregion
}
