using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndZoneState : BaseZoneState
{
    #region fileds

    #endregion

    #region Properties

    #endregion

    #region Methods   
    public override void StartState()
    {
      if(_machine._scoreRed > _machine._scoreBlue)
        {
          _machine.GameTerminadoRed = true;
          _machine.EndMenuRed.SetActive(true);
        }
        else
        {
          _machine.GameTerminadoBlue = true;
          _machine.EndMenuBlue.SetActive(true);
        }
      _machine.isPaused = true;
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }

    public override void LeaveState()
    {
        _machine.LastZoneState = EzoneState.GAMEEND;
    }

    #endregion
}
