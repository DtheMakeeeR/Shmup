namespace Shmup
{
    public class Enemy : Plane
    {
        protected override void Die()
        {
            GameManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
