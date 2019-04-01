using UnityEngine;

public abstract class Human
{
    public string hName;
    protected uint weight;
    protected uint health;
    protected uint armor;
    protected bool isAlive;
    [Range(-1, 1)]
    protected float skinColor;
    protected int authority;

    /// <summary>
    ///     Create a human.
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="health"></param>
    /// <param name="armor"></param>
    public Human(string hName, uint weight, uint health, uint armor, float skinColor, int authority)
    {
        this.hName = hName;
        this.weight = weight;
        this.health = health;
        this.armor = armor;
        this.skinColor = skinColor;
        this.authority = authority;
    }

    public Human()  {
        
    }

    #region GETANDSET

    public string GetName(){
        return hName;
    }

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
    /// Returns skincolor.
    /// </summary>
    /// <returns>the skin color</returns>
    public float GetSkinColor()
    {
        return this.skinColor;
    }

    #endregion
}
