using UnityEngine;
using UnityEngine.EventSystems;

public class LightTrigger : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    public int rowIndex;
    public int columnIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        GridGenerator.Instance.Press(rowIndex, columnIndex);
    }

    public void TriggerLight()
    {
        //Demo
        spriteRenderer.color = (spriteRenderer.color == Color.white) ? Color.black : Color.white;
    }
}
