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
      _bd = GameObject.FindWithTag("player2").GetComponent<getBehaviourTreeAllParameters>();
    }

    public override void UpdateState()
    {
      if(_machine.RedCap == true & _machine.BlueCap == false)
      {
        _bd.setCaptureStateRed(true);
        _bd.setCaptureStateBlue(false);
        _bd.setConflictState(false);
        _machine.changeState(EzoneState.ONCAPTURE);
      }
      else if(_machine.RedCap == false & _machine.BlueCap == true)
      {
        _bd.setCaptureStateBlue(true);
        _bd.setCaptureStateRed(false);
        _bd.setConflictState(false);
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
