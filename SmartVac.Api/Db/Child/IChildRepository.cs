using SmartVac.Api.Dto;
using SmartVac.Api.Dto.Child;

namespace SmartVac.Api.Db.Child;

public interface IChildRepository
{
    Task<long> CreateChildAsync(ChildDbModel childDbModel);
    Task<ChildDbModel> GetChildAsync(long id);

    Task<List<ChildDbModel>> GetChildListByParentIdAsync(long userId);

    Task<ChildDbModel> UpdateChildAsync(ChildDbModel childDbModel);

    Task DeleteChildAsync(long id);

}