using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin;
	public float xMax;

	public float zMin;
	public float zMax;


	public float ClampX(float x) {
		return Mathf.Clamp (x, this.xMin, this.xMax);
	}

	public float ClampZ(float z) {
		return Mathf.Clamp (z, this.zMin, this.zMax);
	}

	public Vector3 Constrain(Vector3 pos) {
		return new Vector3 (
			this.ClampX(pos.x),
			pos.y,
			this.ClampZ(pos.z)
		);
	}
}
