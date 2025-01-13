namespace Core.Interfaces
{
    public interface IAlphabetService
    {
        /// <summary>
        /// Contract to check if a string has all a-z Character
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool CheckAlphabet(string input);
    }
}
