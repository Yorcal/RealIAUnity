using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturedZoneState : BaseZoneState
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

    }

    public override void FixedUpdateState()
    {
        if ((_machine._redCaptured == true ) & (_machine.BlueCap == false))
        {
            _bd.setCapturedStateRed(true);
            _bd.setCapturedStateBlue(false);
            _machine._scoreRed += Time.fixedDeltaTime;
            Debug.Log(Mathf.FloorToInt(_machine._scoreRed));
        }
        else if ((_machine._blueCaptured == true ) & (_machine.RedCap == false))
        {
            _bd.setCapturedStateBlue(true);
            _bd.setCapturedStateRed(false);
            _machine._scoreBlue += Time.fixedDeltaTime;
            Debug.Log(Mathf.FloorToInt(_machine._scoreBlue));
        }
        else if((_machine._redCaptured == true) & (_machine.BlueCap == true))
        {
            _bd.setCapturedStateBlue(false);
            _bd.setCapturedStateRed(true);
            _bd.setCaptureStateBlue(true);
            _bd.setCaptureStateRed(false);
            _machine._redCaptured = false;
            _machine.changeState(EzoneState.ONCAPTURE);
        }
        else if((_machine._blueCaptured == true) & (_machine.RedCap == true))
        {
            _bd.setCapturedStateBlue(true);
            _bd.setCapturedStateRed(false);
            _bd.setCaptureStateBlue(false);
            _bd.setCaptureStateRed(true);
            _machine._blueCaptured = false;
            _machine.changeState(EzoneState.ONCAPTURE);
        }
        if((_machine._scoreZoneRed >= 5) & (_machine._scoreRed >= 5))
        {
            _machine.changeState(EzoneState.GAMEEND);
        }
        if((_machine._scoreZoneBlue >= 5) & (_machine._scoreBlue >= 5))
        {
            _machine.changeState(EzoneState.GAMEEND);
        }
    }

    public override void LeaveState()
    {
        _bd.setCapturedStateBlue(false);
        _bd.setCapturedStateRed(false);
        _machine.LastZoneState = EzoneState.CAPTURED;
    }

    #endregion
}