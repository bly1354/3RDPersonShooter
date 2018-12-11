using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour {
    public enum State { state1, state2, state3 }

    public State correctState = State.state1;
    public State[] states = new State[] { State.state1, State.state2, State.state3 };
    public List<GameObject> stateObjects = new List<GameObject>();

    public Animator anim;
    public string boolName;

    public int index = 0;

    private State currentState = State.state1;

    private void Start()
    {
        currentState = states[index];
        anim.SetBool(boolName, currentState == correctState);
    }

    public void Damage(Vector3 damage)
    {
        stateObjects[index].SetActive(false);
        index = (index + 1) % states.Length;
        currentState = states[index];
        stateObjects[index].SetActive(true);
        anim.SetBool(boolName, currentState == correctState);
    }
}
