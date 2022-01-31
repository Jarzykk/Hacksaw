public class Weapon
{
    private int _damage;
    private int _bullets;

    public Weapon(int damage, int bulletsAmount)
    {
        if (damage <= 0 || bulletsAmount <= 0)
            throw new ArgumentOutOfRangeException();

        _damage = damage;
        _bullets = bulletsAmount;
    }

    public void Fire(Player player)
    {
        if (_bullets > 0)
        {
            _bullets--;
            player.TakeDamage(_damage);
        }
    }
}

public class Player
{
    public int Health { get; private set; }
    private bool _isDead = false;

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

        if (Health <= 0)
            Die();
    }

    private void Die()
    {
        _isDead = true;
    }
}

public class Bot
{
    private Weapon _weapon;

    public Bot(Weapon weapon)
    {
        if (weapon == null)
            throw new NullReferenceException();

        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        _weapon.Fire(player);
    }