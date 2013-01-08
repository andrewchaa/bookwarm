using Bookwarm.Models;

namespace Bookwarm.Services
{
    public interface IReadingRepository
    {
        void Save(Reading readingToSave);
    }
}