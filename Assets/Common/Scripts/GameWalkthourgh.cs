using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWalkthourgh : MonoBehaviour
{
    public GameObject walkthroughCanvas;
    public Animator firstTaskAnimator;
    public Animator secondTaskAnimator;
    public Animator thirdTaskAnimator;
    public Animator forthTaskAnimator;
    
    private int lastCompletedTaskNumber = 0;
    
    void Start()
    {
        if (Application.isEditor)
        {
            print("We are running this from inside of the editor!");
            walkthroughCanvas.SetActive(true);
        }
        else
        {
            walkthroughCanvas.SetActive(false);
        }
        
        // stop all animations
        firstTaskAnimator.StopPlayback();
        secondTaskAnimator.StopPlayback();
        thirdTaskAnimator.StopPlayback();
        forthTaskAnimator.StopPlayback();

    }

    private void StartTaskAnimation()
    {
        walkthroughCanvas.SetActive(false);
        switch (lastCompletedTaskNumber)
        {
            case 0:
                firstTaskAnimator.StartPlayback();
                // disable first button
                break;
            case 2: 
                secondTaskAnimator.StartPlayback();
                // disable second button
                break;
            case 3: 
                thirdTaskAnimator.StartPlayback();
                // disable third button
                break;
            case 4: 
                forthTaskAnimator.StartPlayback();
                // disable forth button
                break;
        }
        
    }
}
