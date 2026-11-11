using UnityEngine;
using UnityEngine.EventSystems;

public class LightTrigger : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected SpriteRenderer spriteRenderer;

    public void OnPointerClick(PointerEventData eventData)
    {
        TriggerLight();
    }

    public void TriggerLight()
    {
        //Demo
        spriteRenderer.color = (spriteRenderer.color == Color.white) ? Color.black : Color.white;
        Debug.Log("Light click!");
    }
}
