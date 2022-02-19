using essentialMix.Core.Data.Entity.Patterns.Repository;
using essentialMix.Data.Model;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Identity.Data;

public class UserUnit<TContext, TUser, TRole, TKey> : UnitOfWork<TContext>
	where TContext : DbContext
	where TUser : IdentityUser<TKey>, IEntity<TKey>
	where TRole : IdentityRole<TKey>, IEntity<TKey>
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
	/// <inheritdoc />
	public UserUnit([NotNull] TContext context, [NotNull] UserManager<TUser> userManager, [NotNull] RoleManager<TRole> roleManager, [NotNull] IConfiguration configuration)
		: this(context, userManager, roleManager, configuration, null, false)
	{
	}

	/// <inheritdoc />
	public UserUnit([NotNull] TContext context, [NotNull] UserManager<TUser> userManager, [NotNull] RoleManager<TRole> roleManager, [NotNull] IConfiguration configuration, ILogger logger)
		: this(context, userManager, roleManager, configuration, logger, false)
	{
	}

	/// <inheritdoc />
	public UserUnit([NotNull] TContext context, [NotNull] UserManager<TUser> userManager, [NotNull] RoleManager<TRole> roleManager, [NotNull] IConfiguration configuration, ILogger logger, bool ownsContext)
		: base(context, configuration, logger, ownsContext)
	{
		UserManager = userManager;
		RoleManager = roleManager;
	}

	[NotNull]
	public UserManager<TUser> UserManager { get; }

	[NotNull]
	public RoleManager<TRole> RoleManager { get; }
}