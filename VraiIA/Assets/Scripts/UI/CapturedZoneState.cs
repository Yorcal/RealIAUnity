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
      
    }

    public override void UpdateState()
    {
        
    }

    public override void FixedUpdateState()
    {
        if (_machine._scoreZone >= 5)
        {
            if(_machine.blueCol && _machine._scoreZone >= 5)
            {
                Debug.Log("Blue Capturing .....");
                _machine._scoreBlue += Time.fixedDeltaTime;
                if ( _machine._scoreBlue > 5)
                {
                    _machine.changeState(EzoneState.GAMEEND);
                }
            if(_machine._scoreRed && _machine._scoreRed >= 5)
                Debug.Log("Red Capturing .....");
                _machine._scoreRed += Time.fixedDeltaTime;
                if (_machine._scoreRed > 5)
                {
                    _machine.changeState(EzoneState.GAMEEND);
                }
            }
            
            
        }
    }

    public override void LeaveState()
    {
        _machine.LastZoneState = EzoneState.CAPTURED;
    }

    #endregion
}
