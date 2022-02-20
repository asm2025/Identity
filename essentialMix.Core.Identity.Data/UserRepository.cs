using essentialMix.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Identity.Data;

public class UserRepository<TContext, TUser, TKey> : essentialMix.Core.Data.Entity.Patterns.Repository.Repository<TContext, TUser, TKey>
	where TContext : DbContext
	where TUser : IdentityUser<TKey>, IEntity<TKey>
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
	/// <inheritdoc />
	public UserRepository(TContext context, IConfiguration configuration)
		: this(context, configuration, null, false)
	{
	}

	/// <inheritdoc />
	public UserRepository(TContext context, IConfiguration configuration, ILogger logger)
		: this(context, configuration, logger, false)
	{
	}

	/// <inheritdoc />
	public UserRepository(TContext context, IConfiguration configuration, ILogger logger, bool ownsContext)
		: base(context, configuration, logger, ownsContext)
	{
	}
}