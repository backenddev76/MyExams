using TechExam1.Interface;

namespace TechExam1.Services
{
    public class StringOrganizerService : IStringOrganizerService
    {
        public async Task<int> GetNumberOfUniqueCharacterFromString(string input)
        {
            return input.ToCharArray().Count(x => input.ToCharArray().Count(y => y == x) == 1);//simplified one liner
        }
    }
}
