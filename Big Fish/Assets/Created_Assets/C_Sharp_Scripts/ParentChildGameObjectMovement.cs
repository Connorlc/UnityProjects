// THIS SCRIPT HAS NOT BEEN TESTED!

using UnityEngine;
using System.Collections;


// NOTE:	This script should be attached as a component to the parent object. It keeps a parent and child object's transforms in sync
[ExecuteInEditMode]
public class ParentChildGameObjectMovement : MonoBehaviour
{
	private Transform parentTrans;
	private Transform childTrans;



	private void Awake ()
	{
		parentTrans = GetComponent<Transform>();
		childTrans = parentTrans.GetChild(2).transform;
  } // Start()
	


	private void Update ()
	{
		parentTrans.position = new Vector2(childTrans.position.x, childTrans.position.y);
	} // Update()
} // class ParentChildGameObjectMovement
