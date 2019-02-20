using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerNPC : MonoBehaviour
{
    Prisoner prisoner;

    private void Start() {
        GameObject gameObject;
        gameObject.AddComponent<MeshFilter>().mesh = new Mesh(Cubemap);
        prisoner = new Prisoner(NameGenerator.GetName(), (uint)Random.Range(50, 200), 100, 100, 1, 1);

    }
}
