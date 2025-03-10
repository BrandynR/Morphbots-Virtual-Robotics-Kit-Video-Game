﻿using UnityEngine;
using System.Collections;

///<summary> Shape handles moving/rotating the shapes in the game,
/// as well as particle Fx on the blocks
///</summary>
public class Shape : MonoBehaviour {

	// turn this property off if you don't want the shape to rotate (Shape O)
	public bool m_canRotate = true;
	public Vector3 m_queueOffset;

	GameObject[] m_glowSquareFx;
	public string glowSquareTag = "LandShapeFx";

	void Start()
	{
		if (glowSquareTag != "")
		{
			m_glowSquareFx = GameObject.FindGameObjectsWithTag(glowSquareTag);
		}
	}

	// general move method
	void Move(Vector3 moveDirection)
	{
		transform.position += moveDirection;
	}

	// adds glow effect to squares
	public void LandShapeFX()
    {
        int i = 0;

        foreach (Transform child in gameObject.transform)
        {
            if (m_glowSquareFx[i])
            {
                m_glowSquareFx[i].transform.position = new Vector3(child.position.x, child.position.y,-2f);
                ParticlePlayer particlePlayer = m_glowSquareFx[i].GetComponent<ParticlePlayer>();

                if (particlePlayer)
                {
                    particlePlayer.Play();
                }
            }

            i++;
        }

    }


	//public methods for moving left, right, up and down, respectively
	public void MoveLeft()
	{
		Move(new Vector3(-1, 0, 0));
	}

	public void MoveRight()
	{
		Move(new Vector3(1, 0, 0));
	}

	public void MoveUp()
	{
		Move(new Vector3(0, 1, 0));
	}

	public void MoveDown()
	{
		Move(new Vector3(0, -1, 0));
	}


	//public methods for rotating right and left
	public void RotateRight()
	{
		if (m_canRotate)
			transform.Rotate(0, 0, -90);
	}
	public void RotateLeft()
	{
		if (m_canRotate)
			transform.Rotate(0, 0, 90);
	}
	public void RotateClockwise(bool clockwise)
	{
		if (clockwise)
		{
			RotateRight();
		}
		else
		{
			RotateLeft();
		}
	}
		
}
