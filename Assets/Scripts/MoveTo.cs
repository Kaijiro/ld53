using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MoveTo : MonoBehaviour
{

    public Transform[] plan;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool arrived = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (plan.Length == 0 )
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = plan[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % plan.Length;
        if (destPoint == 0)
        {
            agent.autoBraking = true;
            arrived = true;
        }

        Debug.Log(plan.Length + " <> " + destPoint);
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f && !arrived)
            GotoNextPoint();

        if (arrived && agent.remainingDistance <= 0)
        {
            SceneManager.LoadScene(2);
        }

    }
}
