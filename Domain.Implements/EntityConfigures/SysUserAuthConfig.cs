using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Implements.EntityConfigures
{
	public class SysUserAuthConfig : IEntityTypeConfiguration<SysUserAuthEntity>
	{
	public void Configure(EntityTypeBuilder<SysUserAuthEntity> builder)
		{
			builder.ToTable("SysUserAuth");
			builder.HasKey(p => p.Id);
		}
	}
}