public abstract class Spell : IMagic
{
    protected int n_mana;
    public int NMana
    { get { return n_mana; } }

    protected bool n_speak;
    public bool NSpeak
    { get { return n_speak; } }

    protected bool n_move;
    public bool NMove
    { get { return n_move; } }

    public abstract void MakeMagic(object player, int strength);

}
