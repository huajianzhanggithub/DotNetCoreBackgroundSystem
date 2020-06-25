using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Implements.EntityConfigures
{
	public class SysUserInfoConfig : IEntityTypeConfiguration<SysUserInfoEntity>
	{
	public void Configure(EntityTypeBuilder<SysUserInfoEntity> builder)
		{
			builder.ToTable("SysUserInfo");
			builder.HasKey(p => p.Id);
		}
	}
}