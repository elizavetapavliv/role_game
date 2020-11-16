using System;

public enum States { normal, weak, ill, poisoned, paralyzed, dead }
public enum Genders { male, female }
public class Character : IComparable
{
    #region
    private static int next_id = 0;
    private int id;
    private string player_name;
    private States state;
    private bool able_to_talk;
    private bool able_to_move;
    private string race;
    private Genders gender;
    private int age;
    private int health;
    private int max_health = 100;
    private int experience;
    #endregion
    public static int Next_ID
    {
        get { return next_id; }
        set { next_id = value; }
    }
    public int ID
    {
        get { return id; }
    }
    public string Name
    {
        get { return player_name; }
    }
    public States State
    {
        get { return state; }
        set { state = value; }
    }
    public bool Able_to_talk
    {
        get { return able_to_talk; }
        set { able_to_talk = value; }
    }
    public bool Able_to_move
    {
        get { return able_to_move; }
        set { able_to_move = value; }
    }
    public string Player_Race
    {
        get { return race; }
    }
    public Genders Gender
    {
        get { return gender; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public int Health
    {
        get { return health; }
        set
        {
            if (value < 10 && State == States.normal)
            {
                state = States.weak;
            }
            if (value >= 10 && State == States.weak)
            {
                State = States.normal;
            }
            if (value == 0)
            {
                State = States.dead;
            }
            if (value > Max_health)
            {
                health = Max_health;
            }
            health = value;
        }
    }
    public int Max_health
    {
        get { return max_health; }
    }
    public int Experience
    {
        get { return experience; }
        set { experience = value; }
    }
	public Character()
    {
        this.id = ++next_id;
        State = States.normal;
        Able_to_talk = true;
        Able_to_move = true;
        Health = Max_health;
        Experience = 0;
    }
    public Character(string name, string race, Genders gender, int age):this()
    {
        player_name = name;
        this.race = race;
        this.gender = gender;
        Age = age;
    }
    public int CompareTo(object obj)
    {
        if (!(obj is PlayerScript))
        {
            throw new ArgumentException("object is not a Player");
        }
        Character other_player = (Character)obj;
        if (this.experience < other_player.Experience)
        {
            return -1;
        }
        if (this.experience > other_player.Experience)
        {
            return 1;
        }
        return 0;
    }
    public override string ToString()
    {
        string info = "ID:" + ID + "," + Environment.NewLine + "name:" + Name +
            "," +Environment.NewLine +"race:" + Player_Race
            + "," + Environment.NewLine +
            "age:" + Age + "," + Environment.NewLine +
            "gender:" + Gender + "," + Environment.NewLine +
            "health:" + Health + "," + Environment.NewLine +
            "experience:" + Experience + "," + Environment.NewLine +
        "able to move:" + Able_to_move + "," + Environment.NewLine +
         "able to talk:" + Able_to_talk + "," + Environment.NewLine +
         "state:" + State;
        return info;
    }

	protected bool isprotected;
	public bool IsProtected {
		get { return isprotected; }
		set { isprotected = value; }
	}
}
public class MagicCharacter : Character
{
    private int max_mana = 100;
    private int mana;
    public MagicCharacter() : base()
    {
        Mana = Max_mana;
    }
    public MagicCharacter(string name, string race, Genders gender, int age) :base(name,race,gender,age)
    {
        Mana = Max_mana;
    }
    public int Max_mana
    {
        get { return max_mana; }
    }
    public int Mana
    {
        get { return mana; }
        set
        {
            if (value <= 0)
            {
                mana = 0;
            }
            else if (value > Max_mana)
            {
                mana = Max_mana;
            }
            else
            {
                mana = value;
            }
        }
    }
    public override string ToString()
    {
        string info=base.ToString() + ", mana:" + Mana;
        return info;
    }
}