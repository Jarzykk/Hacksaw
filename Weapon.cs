public class Weapon
{
    private readonly int _damage;
    private int _bullets;

    public Weapon(int damage, int bulletsAmount)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException();

        if (bulletsAmount <= 0)
            throw new ArgumentOutOfRangeException();

        _damage = damage;
        _bullets = bulletsAmount;
    }

    public void Fire(Player player)
    {
        if(player == null)
            throw new ArgumentNullException();

        if (_bullets <= 0)
            throw new ArgumentOutOfRangeException();

        _bullets--;
        player.TakeDamage(_damage);
    }
}

public class Player
{
    public int Health { get; private set; }
    private bool _isDead => Health <= 0;

    public Player(int health)
    {
        if (health <= 0)
            throw new ArgumentOutOfRangeException();

        Health = health;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead)
            throw new InvalidOperationException();

        if (damage < 0)
            throw new ArgumentOutOfRangeException();

        Health -= damage;
    }
}

public class Bot
{
    private Weapon _weapon;

    public Bot(Weapon weapon)
    {
        if (weapon == null)
            throw new ArgumentNullException();

        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        _weapon.Fire(player);
    }
}