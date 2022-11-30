using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FreeZoneState : BaseZoneState
{
    #region fileds

    #endregion

    #region Properties
    #endregion

    #region Methods   
    public override void StartState()
    {
       if (_machine._scoreZone <= 0)
       {
            _machine._scoreZone = 0;
       }
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {
        if (_machine.RedCap == true & _machine.BlueCap == true)
        {
            _machine.changeState(EzoneState.ONCONFLICT);
        }
        else if(_machine.BlueCap == true)
        {
            _machine.changeState(EzoneState.ONCAPTURE);
        }
        else if(_machine.RedCap == true)
        {
            _machine.changeState(EzoneState.ONCAPTURE);
        }
    }

    
    public override void LeaveState()
    {
        _machine.LastZoneState = EzoneState.FREE;
    }

    #endregion
}
