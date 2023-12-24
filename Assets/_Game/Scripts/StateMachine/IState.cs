using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{
    void OnEnter(Enemy enemy); //bdau vao state
    void OnExecute(Enemy enemy); //update state
    void OnExit(Enemy enemy); //exit state
}
