namespace FreeflyAcademy.Services.Contracts.Technical
{
    public interface IHashService
    {
        string CalculateMD5Hash(string input);

        bool IsMatching(string input, string hash);
    }
}
