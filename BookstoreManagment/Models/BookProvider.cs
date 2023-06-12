using BookstoreManagment.Contracts;
using BookstoreManagment.DTOs;
using Newtonsoft.Json;

namespace BookstoreManagment.Models
{
    public class BookProvider : IBookProvider
    {
        private IConfig _config;

        public BookProvider(IConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Gets the books collection from a json file
        /// </summary>
        /// <returns>The books collection or an empty list of books if something went wrong</returns>
        public List<Book> GetBooks()
        {
            try
            {
                string path = _config.GetJsonPath();
                string json = File.ReadAllText(path);
                JsonDTO jsonObject = JsonConvert.DeserializeObject<JsonDTO>(json);

                 return jsonObject.Books.ToList();
            }
            catch (Exception)
            {
                return new List<Book>();
            }
        }
    }
}
