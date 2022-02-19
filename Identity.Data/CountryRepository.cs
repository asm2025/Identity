using essentialMix.Core.Data.Entity.Patterns.Repository;
using Identity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Identity.Data;

public class CountryRepository<TContext> : Repository<TContext, Country, string>
	where TContext : DbContext
{
	/// <inheritdoc />
	public CountryRepository(TContext context, IConfiguration configuration)
		: this(context, configuration, null, false)
	{
	}

	/// <inheritdoc />
	public CountryRepository(TContext context, IConfiguration configuration, ILogger logger)
		: this(context, configuration, logger, false)
	{
	}

	/// <inheritdoc />
	public CountryRepository(TContext context, IConfiguration configuration, ILogger logger, bool ownsContext)
		: base(context, configuration, logger, ownsContext)
	{
	}
}