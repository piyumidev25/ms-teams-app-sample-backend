using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace Libraries.DBClient
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IAADUserRepository _aadUserRepository;
        public IAADUserRepository AADUserRepository {
            get
            {
                if (_aadUserRepository == null)
                {
                    _aadUserRepository = new AADUserRepository(_repoContext);
                }
                return _aadUserRepository;
            }
        }
        public async Task SaveAsync()
        {
            try
            {
                await _repoContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

    }
}
