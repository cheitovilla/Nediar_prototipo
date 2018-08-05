using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour 
{

	public NavMeshAgent navMesh;
	public Transform target;


	public void InstancaiNav()
	{
		navMesh = GetComponent<NavMeshAgent>();
	}

	public void Moviendo()
	{
		navMesh.SetDestination(target.position);
	}
}
