// using UnityEngine;
// using System.Collections;
// using UnityEditor;
//
//
// #if UNITY_EDITOR
// [CustomEditor (typeof (FieldOfView))]
// public class FieldOfViewEditor : Editor {
//
//
// 	void OnSceneGUI() {
// 		FieldOfView fow = (FieldOfView)target;
// 		Handles.color = Color.white;
// 		// Handles.DrawWireArc (fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
// 		Vector3 viewAngleA = fow.DirFromAngle (fow.viewAngle - fow.viewPos, false);
// 		Vector3 viewAngleB = fow.DirFromAngle (fow.viewAngle + fow.viewPos, false);
//
// 		Handles.DrawLine (fow.transform.position, (fow.transform.position + viewAngleA * fow.viewRadius));
// 		Handles.DrawLine (fow.transform.position, (fow.transform.position + viewAngleB * fow.viewRadius));
//
// 		Handles.color = Color.blue;
// 		viewAngleA = fow.DirFromAngle (90, false);
// 		viewAngleB = fow.DirFromAngle (90, false);
// 		Handles.DrawLine (fow.transform.position, (fow.transform.position + viewAngleA * fow.viewRadius));
// 		Handles.DrawLine (fow.transform.position, (fow.transform.position + viewAngleB * fow.viewRadius));
//
// 		Handles.color = Color.red;
// 		foreach (Transform visibleTarget in fow.visibleTargets) {
// 			Handles.DrawLine (fow.transform.position, visibleTarget.position);
// 		}
// 	}
//
// }
// #endif
