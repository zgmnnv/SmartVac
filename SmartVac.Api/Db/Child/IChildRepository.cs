using SmartVac.Api.Dto;
using SmartVac.Api.Dto.Child;

namespace SmartVac.Api.Db.Child;

public interface IChildRepository
{
    Task<long> CreateChildAsync(Child child);
    Task<Child> GetChildAsync(long id);

    Task<List<Child>> GetChildListByParentIdAsync(long userId);

    Task<Child> UpdateChildAsync(Child child);

    Task DeleteChildAsync(long id);

}