using Data.Models;
using Domain.Implements.Infrastructure;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;namespace Domain.Implements.Repository
{
	public class SysUserAuthRepository : BaseRepository<SysUserAuthEntity>, ISysUserAuthModifyRepository,ISysUserAuthSearchRepository 
	{
	public SysUserAuthRepository(DbContext context) : base(context)
		{
		}
	}
}