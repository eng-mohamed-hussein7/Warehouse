using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Repositories.DismissalNoticeRepositories;

namespace BusinessLogicLayer.Services.DismissalNoticeServices
{
    public class DismissalNoticeService : IDismissalNoticeService
    {
        private readonly IDismissalNoticeRepository _repository;
        private readonly IMapper _mapper;

        public DismissalNoticeService(IDismissalNoticeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task AddAsync(DismissalNoticeDTO invoiceDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DismissalNoticeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DismissalNoticeDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DismissalNoticeDTO invoiceDto)
        {
            throw new NotImplementedException();
        }
    }
}
