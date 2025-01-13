using Core.Interfaces;

namespace Core.Services
{
    public class AlphabetService : IAlphabetService
    {
        //Usually Used to Inject Repository
        public AlphabetService() { }
        /// <summary>
        /// Implementation to Check if a string has all a-z Character
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool CheckAlphabet(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            var alphabets = new HashSet<char>("abcdefghijklmnopqrstuvwxyz");
            foreach (var ch in input.ToLower())
            {
                alphabets.Remove(ch);
                if (alphabets.Count == 0)
                {
                    return true; 
                }
            }
            return false;
        }
    }
}
