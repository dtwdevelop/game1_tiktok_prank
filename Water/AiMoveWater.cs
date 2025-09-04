using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.HighDefinition; // Assuming you are still using HDRP for WaterSurface

public class AiMoveWater : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform patrolRouteParent; // Родительский объект для точек патрулирования
    public List<Transform> patrolPoints; // Список самих точек патрулирования
    private int currentPatrolIndex = 0; // Текущий индекс точки патрулирования

    [Header("NavMesh Agent Settings")]
    private NavMeshAgent agent;
    public float agentSpeed = 10f;
    public float agentAcceleration = 50f;
    public float agentAngularSpeed = 3f;
    public float agentBaseOffset = 0.5f; // Смещение агента относительно NavMesh
    public float agentStoppingDistance = 0.5f; // Расстояние до точки, когда агент считается прибывшим

    [Header("Buoyancy Settings")]
    public Rigidbody rb;
    public float buoyancyStrength = 5f;
    public WaterSurface water; // Ссылка на компонент WaterSurface (HDRP)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Получаем компоненты
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        // Инициализируем точки патрулирования
        InitializePatrolPoints();

    // Настраиваем NavMesh Agent
        agent.updatePosition = false; // Tell NavMeshAgent NOT to move the transform directly
        agent.updateRotation = false;
        agent.updateUpAxis = false; // Сохранять Y-ось объекта относительно самого себя (для лодки)
        agent.autoBraking = false; // Отключить автоторможение для непрерывного патрулирования
        agent.acceleration = agentAcceleration;
        agent.speed = agentSpeed;
        agent.angularSpeed = agentAngularSpeed;
        agent.baseOffset = agentBaseOffset;
        agent.stoppingDistance = agentStoppingDistance; // Устанавливаем дистанцию остановки

        // Устанавливаем первую цель для начала патрулирования
        SetNextDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // Выводим отладочную информацию в консоль
        // Debug.Log($"Path Status: {agent.pathStatus}");
        // Debug.Log($"Agent Velocity: {agent.velocity}");
        // // Debug.Log($"Agent Remaining Distance: {agent.remainingDistance}");
        // Debug.Log($"Agent is Stopped: {agent.isStopped}");
        // Debug.Log($"Agent Speed: {agent.speed}");
        // Debug.Log($"Current Patrol Index: {currentPatrolIndex}");


        // Проверяем, находится ли агент на NavMesh
        if (!agent.isOnNavMesh)
        {
            Debug.LogError("Agent is not on the NavMesh! Ensure your NavMesh is baked correctly for the water area.");
        }

        // Проверяем, достиг ли агент текущей цели
        // agent.hasPath гарантирует, что путь был найден и агент его преследует
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.1f) // Добавляем небольшой запас к stoppingDistance
        {
            // Debug.Log("Destination reached or path pending, setting next destination.");
            SetNextDestination(); // Переходим к следующей точке и устанавливаем ее как цель
        }
    }

  // FixedUpdate is called once per fixed framerate frame
  void FixedUpdate()
  {
    ApplyBuoyancy();
    if (agent.enabled && !agent.isStopped)
    {
      // Calculate desired velocity (horizontal movement)
      Vector3 desiredVelocity = agent.desiredVelocity;
      desiredVelocity.y = 0; // Ensure horizontal movement only from agent

      // --- Добавьте эту проверку ---
      if (desiredVelocity.sqrMagnitude > 0.01f) // Проверяем, что скорость не нулевая (или очень маленькая)
      {
        // Calculate desired rotation
        Quaternion desiredRotation = Quaternion.LookRotation(desiredVelocity, Vector3.up);

        // Smoothly move and rotate the Rigidbody
        Vector3 targetPosition = rb.position + desiredVelocity * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, desiredRotation, agent.angularSpeed * Time.fixedDeltaTime / 100f));
      }
      else
      {
        // Если desiredVelocity нулевой, возможно, лодка уже на месте или застряла.
        // Можно добавить логику для остановки движения или анимации здесь.
        // Debug.Log("Agent desiredVelocity is zero, no horizontal movement applied.");
      }
    }
    //agent.Move(transform.forward * agent.speed * Time.deltaTime);

  }

    // Метод для инициализации точек патрулирования из дочерних объектов
    void InitializePatrolPoints()
    {
        if (patrolRouteParent == null)
        {
            Debug.LogError("Patrol Route Parent Transform is not assigned! Please assign a parent GameObject containing your patrol points.");
            enabled = false; // Отключаем скрипт, если родительский объект не назначен
            return;
        }

        // Очищаем список на случай повторной инициализации или изменений в редакторе
        patrolPoints.Clear();

        // Добавляем дочерние объекты родительского объекта в список
        foreach (Transform child in patrolRouteParent)
        {
            if (child != null)
            {
                patrolPoints.Add(child);
            }
        }

        if (patrolPoints.Count < 2) // Для патрулирования между 2 точками нужно минимум 2 точки
        {
            // Debug.LogWarning("Less than two patrol points found under the Patrol Route Parent. Please add at least two empty GameObjects as children to your PatrolRouteParent object.");
            enabled = false; // Отключаем скрипт, если точек недостаточно
        }
    }

    // Метод для установки следующей точки патрулирования
    void SetNextDestination()
    {
        if (patrolPoints.Count == 0)
        {
            Debug.LogWarning("No patrol points available to set a destination.");
            return;
        }

        // Увеличиваем индекс текущей точки, используя оператор по модулю для зацикливания
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;

        NavMeshHit hit;
        // Увеличиваем maxSampleDistance, чтобы гарантировать нахождение точки на NavMesh рядом с целью
        float maxSampleDistance = 50.0f; // Учитывает предыдущие обсуждения

        if (patrolPoints[currentPatrolIndex] == null)
        {
            // Debug.LogError($"Patrol point at index {currentPatrolIndex} is null. Check your patrolRouteParent children.");
            return;
        }

        // Используем NavMesh.SamplePosition для нахождения ближайшей валидной точки на NavMesh
        if (NavMesh.SamplePosition(patrolPoints[currentPatrolIndex].position, out hit, maxSampleDistance, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
            // Debug.Log($"Set destination to: {hit.position} (Patrol Point: {patrolPoints[currentPatrolIndex].name})");
        }
        else
        {
            Debug.LogError($"Failed to find a valid NavMesh position for destination: {patrolPoints[currentPatrolIndex].position} within {maxSampleDistance} units. Make sure the NavMesh is baked correctly and covers your patrol points.");
            // Если не удалось найти путь, агент останется на месте или будет продолжать предыдущий путь.
            // Возможно, стоит добавить логику для обработки таких случаев (например, попробовать следующую точку).
        }
    }

    // Метод для применения силы плавучести
    void ApplyBuoyancy()
    {
        if (!water)
        {
            // Debug.LogWarning("WaterSurface component not assigned to AiMoveWater script.");
            return; // Выход, если WaterSurface не назначен
        }

        WaterSearchParameters searchParams = new WaterSearchParameters { startPositionWS = transform.position };
        WaterSearchResult searchResult;

        // Попытка получить высоту водной поверхности в позиции лодки
        if (water.ProjectPointOnWaterSurface(searchParams, out searchResult))
        {
            float displacement = searchResult.projectedPositionWS.y - transform.position.y;
            if (displacement > 0) // Применять силу вверх только если погружено
            {
                // Сила должна быть пропорциональна объему погружения
                rb.AddForce(Vector3.up * displacement * buoyancyStrength, ForceMode.Acceleration);
            }
        }
        else
        {
             // Debug.LogWarning("Could not project boat's position onto water surface. Is the boat outside the water or is the water surface not active?");
        }
    }

    // OnDrawGizmos для визуальной отладки в редакторе Unity
    void OnDrawGizmos()
    {
        // Рисуем точки патрулирования синим
        if (patrolRouteParent != null)
        {
            Gizmos.color = Color.blue;
            foreach (Transform child in patrolRouteParent)
            {
                if (child != null)
                {
                    Gizmos.DrawSphere(child.position, 0.75f);
                }
            }
        }

        // Рисуем текущий путь агента зеленым
        if (agent != null && agent.hasPath)
        {
            Gizmos.color = Color.green;
            Vector3 lastCorner = transform.position;
            foreach (Vector3 corner in agent.path.corners)
            {
                Gizmos.DrawLine(lastCorner, corner);
                Gizmos.DrawSphere(corner, 0.2f); // Рисуем маленькую сферу в каждом углу пути
                lastCorner = corner;
            }
        }

        // Рисуем текущую цель красным
        if (patrolPoints != null && patrolPoints.Count > 0 && currentPatrolIndex < patrolPoints.Count && patrolPoints[currentPatrolIndex] != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(patrolPoints[currentPatrolIndex].position, 1.5f);
            if (agent != null && agent.hasPath)
            {
                // Рисуем линию от лодки к текущей цели
                Gizmos.DrawLine(transform.position, patrolPoints[currentPatrolIndex].position);
            }
        }
    }
}