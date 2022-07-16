using UnityEngine;

public class RangedBehaviour : MonoBehaviour
{
    private enum State
    {
        Chasing,
        Firing
    }

    public float speed = 4f;
    public float minShootRange = 6f;
    public float firingRange = 2f;
    public Shooting shooting;

    public Transform target;
    [SerializeField] private State currentState = State.Chasing;

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        switch (currentState)
        {
            case State.Chasing:
                ChasingBehaviour();
                break;
            case State.Firing:
                shooting.RotateWeaponToTarget(target.position);
                FiringBehaviour();
                break;
        }

    }

    private void ChasingBehaviour()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        if (distanceToTarget <= minShootRange)
        {
            currentState = State.Firing;
        }
    }

    private void FiringBehaviour()
    {
        shooting.Shoot();

        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        if (distanceToTarget >= minShootRange + firingRange)
        {
            currentState = State.Chasing;
        }
    }
}
