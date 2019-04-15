using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PrisonerNPC : MonoBehaviour
{
    private Prisoner prisoner;
    private PrisonState prisonState;
    private NavMeshAgent agent;

    private readonly float PrisonerSpeed = 3.5f;

    private void OnEnable() {
        GameManager.OnGameStateChanged += GameState;
        EventManager.OnPrisonStateChanged += OnPrisonStateChange;
        Clock.OnFastForward += IsFastForward;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= GameState;
        EventManager.OnPrisonStateChanged -= OnPrisonStateChange;
        Clock.OnFastForward -= IsFastForward;
    }

    public void SetupAi()
    {
        prisoner = new Prisoner(NameGenerator.GetName(), (uint)Random.Range(200, 50), 100, 100, Random.Range(0f, 4f), 0);
        this.transform.position = prisoner.GetPrison().transform.position;
        this.GetComponent<Renderer>().material.color = SkinColor.instance.GetSkinColor(prisoner.GetSkinColor());
        agent = this.gameObject.AddComponent<NavMeshAgent>();
    }

    private void GameState(GameState state)
    {
        switch (state)
        {
            case global::GameState.Pause:
                agent.speed = 0;
                break;
            case global::GameState.Play:
                agent.speed = PrisonerSpeed;
                break;
        }
    }

    private void OnPrisonStateChange(PrisonState state)
    {
        if (state == prisonState) return;
        prisonState = state;
        switch (state)
        {
            case PrisonState.LockUp:
                agent.SetDestination(prisoner.GetPrison().transform.position);
                break;
            case PrisonState.Sleep:
                agent.SetDestination(prisoner.GetPrison().bed.transform.position);
                break;
            case PrisonState.FreeTime:
                break;
            case PrisonState.Shower:
                ShowerTime();
                break;
            case PrisonState.Eating:
                EatingTime();
                break;
            case PrisonState.Work:
                break;
        }
    }

    private void ShowerTime()
    {
        Shower curShower = RoomManager.instance.GetClosestShower(this.gameObject);
        ShowerHead showerHead = curShower.GetShower();
        agent.SetDestination(showerHead.transform.position);
    }

    private void EatingTime()
    {
        Canteen curCanteen = RoomManager.instance.GetClosestCanteen(this.gameObject);
        CanteenChair curChair = curCanteen.GetChair();
        agent.SetDestination(curChair.gameObject.transform.position);
    }

    private void IsFastForward(bool enabled)
    {
        if (enabled) agent.speed = PrisonerSpeed * 10;
        else agent.speed = PrisonerSpeed;
    }

    public Prisoner GetPrisonerClass()
    {
        return prisoner;
    }
}