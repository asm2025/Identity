using essentialMix.Core.Data.Entity.Patterns.Repository;
using essentialMix.Data.Model;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Identity.Data;

public class UserUnit<TContext, TUserManager, TRoleManager, TUser, TRole, TKey> : UnitOfWork<TContext>
	where TContext : DbContext
	where TUserManager : UserManager<TUser>
	where TRoleManager : RoleManager<TRole>
	where TUser : IdentityUser<TKey>, IEntity<TKey>
	where TRole : IdentityRole<TKey>, IEntity<TKey>
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
	/// <inheritdoc />
	public UserUnit([NotNull] TContext context, [NotNull] TUserManager userManager, [NotNull] TRoleManager roleManager, [NotNull] IConfiguration configuration)
		: this(context, userManager, roleManager, configuration, null, false)
	{
	}

	/// <inheritdoc />
	public UserUnit([NotNull] TContext context, [NotNull] TUserManager userManager, [NotNull] TRoleManager roleManager, [NotNull] IConfiguration configuration, ILogger logger)
		: this(context, userManager, roleManager, configuration, logger, false)
	{
	}

	/// <inheritdoc />
	public UserUnit([NotNull] TContext context, [NotNull] TUserManager userManager, [NotNull] TRoleManager roleManager, [NotNull] IConfiguration configuration, ILogger logger, bool ownsContext)
		: base(context, configuration, logger, ownsContext)
	{
		UserManager = userManager;
		RoleManager = roleManager;
	}

	[NotNull]
	public TUserManager UserManager { get; }

	[NotNull]
	public TRoleManager RoleManager { get; }
}