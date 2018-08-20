using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAngelBSM : StateMachineBehaviour
{
    public GameObject npc;
    public GameObject enemy;
    public float speed = 5f;
    public float rotation = 5f;
    public float accuracy = .5f;

    private void Awake()
    {

    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.gameObject;
        enemy = SAngelOAI.obj;
    }
}
