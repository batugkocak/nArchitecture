using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules : BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<bool> BrandNameDuplicatedWhenInserted(string name)
    {
        Brand? result = await _brandRepository.GetAsync(b => b.Name.ToLower() == name.ToLower());
        if (result != null)
        {
            throw new BusinessException(BrandMessages.BrandNameExists);
        }
        return true;
    }
}
