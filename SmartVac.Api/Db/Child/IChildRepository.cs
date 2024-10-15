using SmartVac.Api.Dto;
using SmartVac.Api.Dto.Child;

namespace SmartVac.Api.Db.Child;

public interface IChildRepository
{
    public Task<long> CreateChildAsync();

    public Task<Child> GetChildAsync(long id);

    public Task<List<Child>> GetChildrenByUserIdAsync(long userId);

    public Task<Child> UpdateChildAsync(Child child);

    public Task DeleteChildAsync(long id);

}