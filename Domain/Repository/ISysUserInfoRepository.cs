using Data.Models;
using Domain.Infrastructure;
namespace Domain.Repository
{
	public interface ISysUserInfoModifyRepository : IModifyRepository<SysUserInfoEntity>
	{
	}
	public interface ISysUserInfoSearchRepository : ISearchRepository<SysUserInfoEntity>
	{
	}
}