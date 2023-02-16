using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerAnimation : XRSimpleInteractable
{

    public string openAnimation;
    public string closingAnimation;
    private Animator _animator;
    private bool _enable = false;
    
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        _enable = !_enable;

        if (_enable)
        {
            _animator.Play(openAnimation);
        }
        else
        {
            _animator.Play(closingAnimation);
        }
    }
}
