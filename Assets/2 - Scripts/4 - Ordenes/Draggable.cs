using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Transform parentAfterDrag;
    private Vector3 startPosition;
    
    private Transform positionOrder;
    
    private Transform targetPosition;
    private GameObject targetPositionGO;
    
    private Vector3 scale;
    
    private float snapDistance = 100f;
    
    private GameObject gameManagerGO;
    private GameManager gameManager;
    
    private bool isClipped;
    private void Start()
    {
        targetPositionGO = GameObject.Find("TargetPositionScaleOrder");
        targetPosition = targetPositionGO.transform;
        
        gameManagerGO = GameObject.Find("GameManager");
        gameManager = gameManagerGO.GetComponent<GameManager>();
        
        parentAfterDrag = transform.parent;
        

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            gameManager.canDrag = !gameManager.canDrag;
            transform.SetParent(parentAfterDrag);
            isClipped = false;

        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gameManager.canDrag)
        {
            Debug.Log("BeginDrag");
            startPosition = transform.position; // Guardar la posición inicial
            transform.SetParent(transform.root); // Mover al nivel raíz para evitar restricciones
            transform.SetAsLastSibling();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gameManager.canDrag)
        {
            Debug.Log("Dragging");
            transform.position = Input.mousePosition;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameManager.canDrag)
        {
            Debug.Log("End Drag");

            // Verificar la distancia al objetivo
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition.position);

            if (distanceToTarget <= snapDistance)
            {
                if (targetPosition.childCount > 0)
                {
                    
                    Transform existingChild = targetPosition.GetChild(0);
                    existingChild.SetParent(parentAfterDrag);
                    existingChild.transform.localScale = Vector3.one; // Mantén la escala original
                    existingChild.transform.localPosition = Vector3.zero; // Opcional: centra al hijo en el padre
                    existingChild.transform.localRotation = Quaternion.identity; // Opcional: reinicia rotación
                    
                }
                // Colocamos el objeto en la posición objetivo y lo fijamos ahí
                transform.SetParent(targetPosition);// Cambiar el padre al targetPosition
                transform.localScale = new Vector3(0.3366396f, 0.2502762f, 2);
                
                isClipped = true; // Marcar como clippeado
            }
            else
            {
                transform.SetParent(parentAfterDrag); // Regresa al inventario

                transform.localScale = Vector3.one; // Mantén la escala original
                transform.localPosition = Vector3.zero; // Opcional: centra al hijo en el padre
                transform.localRotation = Quaternion.identity; // Opcional: reinicia rotación
                transform.position = startPosition; // Restauramos la posición original
                // Si no está cerca del objetivo, restauramos el padre original

                
                isClipped = false; // Aseguramos que no está clippeado
                Debug.Log("Returned to original parent");
            }
        }
    }


}