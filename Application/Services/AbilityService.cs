using Domain.Interfaces;
using Domain.Enums;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Dtos.Ability;

namespace Application.Services
{
    public class AbilityService
    {
        private readonly IUnitOfWork _uowApplication;
        private readonly IRepository<Ability> _abilityRepo;
        public AbilityService(IUnitOfWorkFactory factory)
        {
            _uowApplication = factory.CreateUnitOfWork(UnitOfWorkType.DbPrimary);
            _abilityRepo = _uowApplication.Repository<Ability>();
        }

        public async Task<List<AbilityDto>> GetAllAbilities()
        {
            return await _abilityRepo.AsQueryable()
                .AsNoTracking()
                .Select(s => new AbilityDto(s.Id, s.Description))
                .ToListAsync();

        }

        public async Task<AbilityDto> CreateAbility(CreateAbilityRequest request)
        {
            Ability ability = new Ability()
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
            };

            Ability abilityAdded = await _abilityRepo.AddAsync(ability);
            await _uowApplication.SaveAsync();
            return new AbilityDto(abilityAdded.Id, abilityAdded.Description);
        }

        public async Task<AbilityDto> UpdateAbility(AbilityDto request)
        {
            Ability? ability = await _abilityRepo.AsQueryable()
                .FirstOrDefaultAsync(f => f.Id == request.Id);

            if (ability is null)
            {
                throw new ArgumentNullException(nameof(ability));
            }
            ability.Description = request.Description;
            await _uowApplication.SaveAsync();
            return new AbilityDto(ability.Id, ability.Description);
        }

        public async Task<Guid> DeleteAbility(Guid id)
        {
            await _abilityRepo.Delete(id);
            await _uowApplication.SaveAsync();
            return id;
        }
    }
}
