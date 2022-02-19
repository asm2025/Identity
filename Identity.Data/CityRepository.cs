using essentialMix.Core.Data.Entity.Patterns.Repository;
using essentialMix.Extensions;
using essentialMix.Patterns.Pagination;
using Identity.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Identity.Data;

public class CityRepository<TContext> : Repository<TContext, City, int>
	where TContext : DbContext
{
	/// <inheritdoc />
	public CityRepository(TContext context, IConfiguration configuration)
		: this(context, configuration, null, false)
	{
	}

	/// <inheritdoc />
	public CityRepository(TContext context, IConfiguration configuration, ILogger logger)
		: this(context, configuration, logger, false)
	{
	}

	/// <inheritdoc />
	public CityRepository(TContext context, IConfiguration configuration, ILogger logger, bool ownsContext)
		: base(context, configuration, logger, ownsContext)
	{
	}

	public IQueryable<City> List([NotNull] string countryId, IPagination settings = null)
	{
		ThrowIfDisposed();
		if (string.IsNullOrEmpty(countryId)) throw new ArgumentNullException(nameof(countryId));
		return PrepareListQuery(DbSet.Where(e => e.CountryId == countryId), settings);
	}

	public ValueTask<IList<City>> ListAsync([NotNull] string countryId, IPagination settings = null, CancellationToken token = default(CancellationToken))
	{
		ThrowIfDisposed();
		token.ThrowIfCancellationRequested();
		if (string.IsNullOrEmpty(countryId)) throw new ArgumentNullException(nameof(countryId));
		settings ??= new Pagination();
		return new ValueTask<IList<City>>(PrepareListQuery(DbSet.Where(e => e.CountryId == countryId), settings)
										.Paginate(settings)
										.ToListAsync(token)
										.As<List<City>, IList<City>>(token));
	}
}