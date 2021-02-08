using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMover
{
    void StartMoving();

    void Move();

    void Jump();

    bool IsMoving();
}
