using BookstoreManagment.Contracts;

namespace BookstoreManagment.Models
{
    public class Config : IConfig
    {
        public string GetJsonPath()
        {
            return jsonPaths.jsonFilePath;
        }
    }
}
