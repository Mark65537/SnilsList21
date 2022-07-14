using SnilsList21.Data;

namespace ToDoList21.Data.Repository
{
    public class SnilsRepository
    {
        private readonly AppDBContext _appDBContext;

        public SnilsRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
    }
}
