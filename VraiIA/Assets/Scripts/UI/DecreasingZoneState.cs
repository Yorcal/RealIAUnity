using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasingZoneState : BaseZoneState
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

    }

    public override void FixedUpdateState()
    {
        if(_machine._scoreZoneBlue > 0)
        {
            _machine._scoreZoneBlue -=  Time.fixedDeltaTime;
            Debug.Log(Mathf.FloorToInt(_machine._scoreZoneBlue));
        }
        if(_machine._scoreZoneRed > 0)
        {
            _machine._scoreZoneRed -= Time.fixedDeltaTime;
            Debug.Log(Mathf.FloorToInt(_machine._scoreZoneRed));
        }
        if(_machine._scoreZoneBlue <= 0 & _machine._scoreZoneRed <= 0)
        {
            _machine.changeState(EzoneState.FREE);
        }
        else if(_machine._scoreZoneRed <= 0 & _machine._scoreZoneBlue <= 0)
        {
            _machine.changeState(EzoneState.FREE);
        }
        else if(_machine.BlueCap == true || _machine.RedCap == true)
        {
            _machine.changeState(EzoneState.ONCAPTURE);
        }
    }

    public override void LeaveState()
    {
        _machine.LastZoneState = EzoneState.DECREASING;
    }

    #endregion
}
