using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnConflictZoneState : BaseZoneState
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
        if(_machine.RedCap == true & _machine.BlueCap == false)
      {
        _machine.changeState(EzoneState.ONCAPTURE);
      }
      else if(_machine.RedCap == false & _machine.BlueCap == true)
      {
        _machine.changeState(EzoneState.ONCAPTURE);
      }
    }

    public override void FixedUpdateState()
    {

    }

    public override void LeaveState()
    {
        _machine.LastZoneState = EzoneState.ONCONFLICT;
    }

    #endregion
}
