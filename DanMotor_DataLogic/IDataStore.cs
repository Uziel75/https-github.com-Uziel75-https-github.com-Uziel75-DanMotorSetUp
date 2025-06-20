namespace DanMotor.Common
{
    public interface IDataStore
    {
        List<string> GetBrands();
        List<string> GetModels(string brand);
        List<string> GetConcepts(string brand, string model);
        List<string> GetParts(string brand, string model, string concept);
        bool AddPart(string brand, string model, string concept, string part);
        bool EditPart(string brand, string model, string concept, string oldPart, string newPart);
        bool DeletePart(string brand, string model, string concept, string part);
        List<string> SearchParts(string brand, string model, string concept, string keyword);
    }
}