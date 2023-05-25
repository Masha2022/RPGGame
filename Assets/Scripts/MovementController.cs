using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Перемещаем персонажа в направлении _destination.
        _navMeshAgent.SetDestination(_destination);

        // TODO: Получите точку, по которой кликнули мышью и задайте ее вектор в поле _destination.
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем координаты точки клика на экране.
            Vector3 clickPosition = Input.mousePosition;

            // Выпускаем луч из точки клика мыши.
            Ray ray = Camera.main.ScreenPointToRay(clickPosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Если луч пересек какой-то объект, получаем его координаты.
                Vector3 worldPosition = hit.point;

                // Вычисляем вектор направления от текущей позиции игрока до точки клика.
                Vector3 direction = worldPosition - transform.position;
                direction.y = 0f; // Убираем компоненту по оси Y.

                // Задаем полученный вектор направления в поле _destination.
                _destination = transform.position + direction;
            }
        }
    }
}