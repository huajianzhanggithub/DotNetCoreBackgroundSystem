using Data.Models;
using Domain.Implements.Infrastructure;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;namespace Domain.Implements.Repository
{
	public class SysUserInfoRepository : BaseRepository<SysUserInfoEntity>, ISysUserInfoModifyRepository,ISysUserInfoSearchRepository 
	{
	public SysUserInfoRepository(DbContext context) : base(context)
		{
		}
	}
}