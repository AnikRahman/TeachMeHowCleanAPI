using Mapster;
using TeachMeHow.Application.Dtos;
using TeachMeHow.Application.Persistence;
using TeachMeHow.Application.Persistence.Repository;
using TeachMeHow.Domain;

namespace TeachMeHow.Persistence.Services
{
    public class DummyService
    {
        private readonly IWriteRepository<Dummy> _dummyWriteRepository;
        private readonly IReadRepository<Dummy> _dummyReadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DummyService(IWriteRepository<Dummy> dummyWriteRepository, IReadRepository<Dummy> dummyReadRepository, IUnitOfWork unitOfWork)
        {
            _dummyWriteRepository = dummyWriteRepository;
            _dummyReadRepository = dummyReadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DummyDto>> GetAllDummiesAsync()
        {
            var dummies = await _dummyReadRepository.GetAllAsync();
            return dummies.Adapt<List<DummyDto>>();
        }

        public async Task<DummyDto> GetDummyByIdAsync(int id)
        {
            var dummy = await _dummyReadRepository.GetByIdAsync(id);
            return dummy.Adapt<DummyDto>();
        }

        public async Task CreateDummyAsync(DummyDto dummyDto)
        {
            var dummy = dummyDto.Adapt<Dummy>();
            await _dummyWriteRepository.AddAsync(dummy);
            await _unitOfWork.SaveAndCommitAsync();
        }

        public async Task UpdateDummyAsync(DummyDto dummyDto)
        {
            var dummy = dummyDto.Adapt<Dummy>();
            await _dummyWriteRepository.UpdateAsync(dummy);
            await _unitOfWork.SaveAndCommitAsync();
        }

        public async Task DeleteDummyAsync(int id)
        {
            var dummy = await _dummyWriteRepository.GetByIdAsync(id);
            if (dummy != null)
            {
                await _dummyWriteRepository.DeleteAsync(dummy);
                await _unitOfWork.SaveAndCommitAsync();
            }
        }
    }
}
