using Data.Models;
using Domain.Infrastructure;
namespace Domain.Repository
{
	public interface ISysUserAuthModifyRepository : IModifyRepository<SysUserAuthEntity>
	{
	}
	public interface ISysUserAuthSearchRepository : ISearchRepository<SysUserAuthEntity>
	{
	}
}