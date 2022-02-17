using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{

	public float positionSmoothTime = 1f;       // a public variable to adjust smoothing of camera motion
	public float rotationSmoothTime = 1f;
	public float positionMaxSpeed = 50f;        //max speed camera can move
	public float rotationMaxSpeed = 50f;
	public Transform desiredPose;           // the desired pose for the camera, specified by a transform in the game
	public Transform target;

	protected Vector3 currentPositionCorrectionVelocity;
	//protected Vector3 currentFacingCorrectionVelocity;
	//protected float currentFacingAngleCorrVel;
	protected Quaternion quaternionDeriv;

	protected float angle;

	void LateUpdate()
	{
		desiredPose = this.transform;
		//if (desiredPose != null)
		//{
			//transform.position = Vector3.SmoothDamp(transform.position, desiredPose.position, ref currentPositionCorrectionVelocity, positionSmoothTime, positionMaxSpeed, Time.deltaTime);
			//var targForward = desiredPose.position.forwar;
			//transform.rotation = SmoothDamp(transform.rotation,Quaternion.LookRotation(targForward, Vector3.up), ref quaternionDeriv, rotationSmoothTime);
		//}
	}


	/*
	Originally from: https://gist.github.com/maxattack/4c7b4de00f5c1b95a33b  
 
	Copyright 2016 Max Kaufmann (max.kaufmann@gmail.com)
	Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
	The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
	*/
	public static Quaternion SmoothDamp(Quaternion rot, Quaternion target, ref Quaternion deriv, float time)
	{
		if (Time.deltaTime < Mathf.Epsilon) return rot;
		// account for double-cover
		var Dot = Quaternion.Dot(rot, target);
		var Multi = Dot > 0f ? 1f : -1f;
		target.x *= Multi;
		target.y *= Multi;
		target.z *= Multi;
		target.w *= Multi;
		// smooth damp (nlerp approx)
		var Result = new Vector4(
			Mathf.SmoothDamp(rot.x, target.x, ref deriv.x, time),
			Mathf.SmoothDamp(rot.y, target.y, ref deriv.y, time),
			Mathf.SmoothDamp(rot.z, target.z, ref deriv.z, time),
			Mathf.SmoothDamp(rot.w, target.w, ref deriv.w, time)
		).normalized;

		// ensure deriv is tangent
		var derivError = Vector4.Project(new Vector4(deriv.x, deriv.y, deriv.z, deriv.w), Result);
		deriv.x -= derivError.x;
		deriv.y -= derivError.y;
		deriv.z -= derivError.z;
		deriv.w -= derivError.w;

		return new Quaternion(Result.x, Result.y, Result.z, Result.w);
	}

}
