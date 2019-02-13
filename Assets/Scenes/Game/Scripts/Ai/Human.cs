using UnityEngine;

public abstract class Human : MonoBehaviour 
{
    private string hName;
    private uint weight;
    private uint health;
    private uint armor;
    private bool isAlive;
    [Range(-1, 1)]
    private int skinColor;
    private int authority;
    private float hunger;
    private float sleep;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="health"></param>
    /// <param name="armor"></param>
    public Human(uint weight, uint health, uint armor){

    }

    #region GETANDSET

    /// <summary>
    /// Get the health of the human.
    /// </summary>
    /// <returns>The humans health</returns>
    public uint GetHealth()
    {
        return health;
    }

    /// <summary>
    /// Set the health of the human.
    /// </summary>
    /// <param name="amount"></param>
    public void SetHealth(uint health){
        this.health = health;
    }

    /// <summary>
    /// Get the weight of the human.
    /// </summary>
    /// <returns>The humans weight</returns>
    public uint GetWeight()
    {
        return weight;
    }

    /// <summary>
    /// Set the weight of the human.
    /// </summary>
    /// <param name="weight"></param>
    public void SetWeight(uint weight)
    {
        this.weight = weight;
    }

    /// <summary>
    /// Get the armor of the human.
    /// </summary>
    /// <returns>The amount of armor</returns>
    public uint GetArmor()
    {
        return armor;
    }

    /// <summary>
    /// Set the armor of the human.
    /// </summary>
    /// <param name="armor"></param>
    public void SetArmor(uint armor)
    {
        this.armor = armor;
    }


    /// <summary>
    /// Check if the player is alive.
    /// </summary>
    /// <returns>The alive state</returns>
    public bool IsAlive()
    {
        return isAlive;
    }

    /// <summary>
    /// Sets the alive state of the human.
    /// </summary>
    /// <param name="alive"></param>
    public void SetAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

    /// <summary>
    /// Get the authority of the human.
    /// </summary>
    /// <returns>The authority of the human</returns>
    public int GetAuthority()
    {
        return authority;
    }

    /// <summary>
    /// Sets the authority of the human.
    /// </summary>
    /// <param name="authority"></param>
    public void SetAuthority(int authority)
    {
        this.authority = authority;
    }

    /// <summary>
    /// Get the hunger of the player;
    /// </summary>
    /// <returns>The hunger of the player</returns>
    public float GetHunger()
    {
        return hunger;
    }

    /// <summary>
    /// Set the hunger of the player;
    /// </summary>
    /// <param name="hunger"></param>
    public void SetHunger(float hunger)
    {
        this.hunger = hunger;
    }

    /// <summary>
    /// Get the sleep of the human.
    /// </summary>
    /// <returns>The sleep of the human</returns>
    public float GetSleep()
    {
        return sleep;
    }

    /// <summary>
    /// Set the sleep of the human.
    /// </summary>
    /// <param name="sleep"></param>
    public void SetSleep(float sleep)
    {
        this.sleep = sleep;
    }

    #endregion

    #region Methods

    private void SetSkinColor(int skinColor)
    {
        if (skinColor < 0)
        {

        }
    }

    #endregion
}
