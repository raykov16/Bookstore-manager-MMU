using BookstoreManagment.Contracts;

namespace BookstoreManagment.Models
{
    public class Config : IConfig
    {
        /// <summary>
        /// Gets the path to the json file that holds the data
        /// </summary>
        /// <returns>The path to the json file that holds the data</returns>
        public string GetJsonPath()
        {
            return jsonPaths.jsonFilePath;
        }
    }
}
