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

    }

    public override void FixedUpdateState()
    {
        _machine._scoreZone +=  Time.fixedDeltaTime;
        Debug.Log(_machine._scoreZone);
        if(_machine._scoreZone >=5)
        {
            _machine.changeState(EzoneState.CAPTURED);
        }
    }

    public override void LeaveState()
    {
        _machine.LastZoneState = EzoneState.ONCAPTURE;
    }

    #endregion
}
