using TestBL;

namespace MVVM_WPF
{
    internal class Repository
    {
        private Repository<Report> repository;

        public Repository()
        {
        }

        public Repository(Repository<Report> repository)
        {
            this.repository = repository;
        }
    }
}