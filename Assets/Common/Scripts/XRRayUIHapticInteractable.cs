using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;

[System.Serializable]
public class Haptic
{
    [Range(0, 1)] public float intensity;
    public float duration;
    
    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0)
            controller.SendHapticImpulse(intensity, duration);
    }
}

public class XRRayUIHapticInteractable : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{

    public Haptic hapticOnEnter;
    public Haptic hapticOnClicked;
    
    private XRUIInputModule InputModule => EventSystem.current.currentInputModule as XRUIInputModule;
 
    public void OnPointerEnter(PointerEventData eventData)
    {
        XRRayInteractor interactor = getRayInteractor(eventData);
        hapticOnEnter.TriggerHaptic(interactor.xrController);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        XRRayInteractor interactor = getRayInteractor(eventData);
        hapticOnClicked.TriggerHaptic(interactor.xrController);
    }

    private XRRayInteractor getRayInteractor(PointerEventData eventData)
    {
        return InputModule.GetInteractor(eventData.pointerId) as XRRayInteractor;
    }

    
}
