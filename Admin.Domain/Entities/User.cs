namespace Admin.Domain.Entities;

public class User
{
    public int Id { get; init; }

    public Guid UniqueId { get; init; } = Guid.NewGuid();

    public string Name { get; private set; } = string.Empty;
    public byte[] PasswordHash { get; private set; } = Array.Empty<byte>();

    public byte[] PasswordSalt { get; private set; } = Array.Empty<byte>();
    public int Iterations { get; private set; } 


    public void ChangePassword(byte[] passwordHash, byte[] passwordSalt, int iterations = 210_000)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Iterations = iterations;
    }
}
